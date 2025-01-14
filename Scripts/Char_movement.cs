using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Char_movement : CharacterBody2D
{
	public Control Options;
	Vector2 mouse_position;
	double time = 0.0;
	Godot.CollisionShape2D shape;

	Godot.Sprite2D playersprite;

	Godot.CharacterBody2D playerbody;

	public Godot.RichTextLabel Minutes;
	public Godot.RichTextLabel Seconds;

	public Godot.RichTextLabel Miliseconds;

	int ability_time = 0;



	Node2D main;
	PackedScene projectile;
	//this function checks if the character has colided with an enemy, if so, the game changes
	//to the game over scene

	//handles the timer
	public void timer(double delta)
	{
		//gets the references to the timer labels
		if (Minutes == null)
		{
			Minutes = GetNode<Godot.RichTextLabel>("GridContainer/Minutes");
			Seconds = GetNode<Godot.RichTextLabel>("GridContainer/Seconds");
			Miliseconds = GetNode<Godot.RichTextLabel>("GridContainer/Miliseconds");
		}
		//increments time by the time elapsed between each frame
		Globe.time += (float)delta;
		//calculates the times for each label of the timer
		float miliseconds = (Globe.time % 1) * 1000;
		float seconds = Globe.time % 60;
		float minutes = (Globe.time % 3600) / 60;
		//assigns the times to the labels within the timer
		Minutes.Text = "." + Convert.ToString(minutes);
		Seconds.Text = "." + Convert.ToString(Convert.ToInt32(seconds));
		Miliseconds.Text = Convert.ToString(Convert.ToInt32(miliseconds));
	}
	//acts as a way for me to stop the timer e.g. if the game pauses
	public void stoptimer()
	{
		SetProcess(false);
	}
	public void deathcheck()
	{

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			string obname = ((Node)collision.GetCollider()).Name;


			if (obname.Contains("enemy"))
			{
				SceneManager.instance.ChangeScene(eSceneNames.GameOver);

			}

		}

	}





	//here im just creating a reference to the options menu and ensuring that when the game starts
	//the game is not paused and the options is hidden.
	public override void _Ready()
	{
		Globe.ispaused = false;
		Options = GetNode<Control>("Options");
		Options.Hide();
		main = (Node2D)GetParent();


	}


	public override void _Process(double delta)
	{
		//adds the time between each frame to time variable
		time += delta;
		//gets references to the player
		playersprite = GetNode<Godot.Sprite2D>("Char_sprite");
		playerbody = GetNode<Godot.CharacterBody2D>(".");
		//loads the player
		var Player = character.Character_load(Globe.picked_character);
		//cancels any active ability 1's if the players energy is 0
		if (Globe.energy == 0)
		{
			Player.ability1(playersprite, playerbody, false, main, projectile);
			Player.ability2(playersprite, playerbody, false, main, projectile);
		}
		//checks if J has been pressed(for the first ability) and that ability 2 is not active
		if (Input.IsActionJustPressed("Ability1") && Globe.ability2active == false)
		{
			//loads the scene for the character's projectile so it can be fired
			projectile = GD.Load<PackedScene>($"res://Scenes/Entities/{Globe.picked_character} Projectile.tscn");
			//toggles the first ability on and off (this only matters if it lasts until toggled off again)
			if (Globe.ability1active == true)
			{
				Player.ability1(playersprite, playerbody, false, main, projectile);
			}
			else
			{
				Player.ability1(playersprite, playerbody, true, main, projectile);
			}
		}
		//checks if K has been pressed(for the second ability) and that ability 1 is not active
		if (Input.IsActionJustPressed("Ability2") && Globe.ability1active == false)
		{
			//loads the scene for the character's second projectile so it can be fired
			projectile = GD.Load<PackedScene>($"res://Scenes/Entities/{Globe.picked_character}2 Projectile.tscn");
			//toggles the second ability on and off (this only matters if it lasts until toggled off again)
			if (Globe.ability2active == true)
			{
				Player.ability2(playersprite, playerbody, false, main, projectile);
			}
			else
			{
				Player.ability2(playersprite, playerbody, true, main, projectile);

			}
		}
		//these specific characters have trail abilities, which i do not want to be called every frame
		//so i used a time variable, so the ability can only be used every 0.05 seconds
		if (Globe.ability2active == true && (Globe.picked_character == "Spore" || Globe.picked_character == "Mantle" || Globe.picked_character == "Ignis"))
		{

			if (time > 0.05)
			{
				Player.ability2(playersprite, playerbody, true, main, projectile);
				time = 0;
			}
		}

		timer(delta);


	}

	//This section handles WASD movement
	public override void _PhysicsProcess(double delta)
	{
		MotionMode = MotionModeEnum.Floating;
		var velocity = Velocity;


		//this line ensures the player object is loaded in so its attributes (in this case speed) can be accessed
		var Player = character.Character_load(Globe.picked_character);
		if (Globe.movement == "WASD")
		{
			//the line below creates a vector object and uses a function which takes inputs from the user
			//and converts that input into a vector
			Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();
			//sets the direction in which projectiles are fired to the players direction
			if (direction != Vector2.Zero)
			{
				Player.Bullet_direction = direction;
			}
			//checks if the vector has a length
			//ensures the velocity is proportional to the players speed.
			velocity = direction * Player.speed;
			//sets the characters Velocity attribute to the calculated velocity
			Velocity = velocity;
			Player.VX = Convert.ToInt32(Velocity.X);
			Player.VY = Convert.ToInt32(Velocity.Y);
			//translates the player in the direction of the vector, with its speed based on the player attribute.Also handles collision.
			MoveAndSlide();
			//checks if the player has hit an enemy, and handles possible death.
			deathcheck();
		}
		else
		{
			//gets the mouse position on the screen
			mouse_position = GetGlobalMousePosition();
			//toggles the mouse movement on mouse click
			if (Input.IsActionJustPressed("Mouse_move_toggle"))
			{
				Globe.Mouse_move = !Globe.Mouse_move;
				Velocity = Vector2.Zero;

			}

			if (Globe.Mouse_move)
			{
				//gets the vector between the mouse and the charcter and multiplies its magnitude by 3
				var direction = (mouse_position - Position) * 3;
				//sets the Velocity attribute and velocity variable to equal the direction vector
				velocity = direction;
				Velocity = velocity;
				//uses pythagoras to calculate the magnitude of the Velocity
				var trueV = Math.Sqrt((Velocity.X * Velocity.X) + (Velocity.Y * Velocity.Y));
				//finds the characters X and Y velocities and assigns them to the player's attributes
				//to be used for teleporter logic
				Player.VX = Convert.ToInt32(Velocity.X);
				Player.VY = Convert.ToInt32(Velocity.Y);
				//if the absolute value of trueV is larger than the players max speed, it will be
				//normalised and multiplied by the players speed, effectively capping the max speed
				//while making the character move slower if the mouse is closer
				if (Math.Abs(trueV) >= Player.speed)
				{
					Velocity = direction.Normalized() * Player.speed;
				}
				//makes it easier to stay completely still when the mouse is ontop of the player
				else if (Math.Abs(trueV) < 50)
				{
					Velocity = Vector2.Zero;
				}
				//makes the bullet direction equal to the normalised Velocity of the player
				Player.Bullet_direction = Velocity.Normalized();
				//moves the character using their Velocity attribute
				MoveAndSlide();
				//checks if the user has collided with an enemy and handles character death
				deathcheck();





			}
			else
			{
				//these must be ran even if the player does not move, so they can still die from enemies
				MoveAndSlide();
				deathcheck();
			}



		}



		//ensures the ability projectiles spawn at the character's position
		Player.GlobalPosition = GlobalPosition;
	}


}






