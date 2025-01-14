using Godot;
using System;

public partial class Homing_enemy : CharacterBody2D
{
	private int i = 1;

	private Vector2 velocity = Vector2.Zero;
	private int speed = 5;

	float randomspeed;
	float scale1;
	float scale2;

	int count = 0;

	Sprite2D sprite;

	CollisionShape2D shape;

	Godot.CharacterBody2D player;

	bool isdead = false;

	int time;

	double deathtimer = 0;


	double[,] stats = GameMaster.StatDictionary[(eSceneNames)Globe.Level];

	public void collisioncheck(KinematicCollision2D collision)
	{
		//this if statement handles the enemies bouncing off of walls
		if (collision != null)
		{
			var thing = ((Node)collision.GetCollider()).Name;
			if (thing == "Top wall" || thing == "Bottom wall")
			{
				velocity.Y *= -1;


			}
			else if (thing == "First safe zone" || thing == "Second safe zone")
			{
				velocity.X *= -1;
			}
		}

	}

	RandomNumberGenerator rng = new RandomNumberGenerator();
	public override void _Ready()
	{
		this.RequestReady();
		GD.Print(Globe.SizeSelect);
		player = GetParent().GetNode<Godot.CharacterBody2D>("Player");
		Velocity = new Vector2(1, 1);
		//makes the enemy spawn with velocity of magnitude 1 in a random direction
		velocity.X = rng.RandfRange((float)-10.0, (float)10.0);
		velocity.Y = rng.RandfRange((float)-10.0, (float)10.0);
		scale1 = (float)stats[0, Globe.SizeSelect];
		//multiplies the velocity(1) by the enemy's respective speed in the game master script
		velocity = velocity.Normalized() * (float)stats[1, Globe.SizeSelect];
		//sets the scale of the enemy to be the enemy's respective scale in the game master script
		this.Scale = new Vector2(scale1, scale1);
		//increments the pointer which is going through the game master stat dictionary by 1
		Globe.SizeSelect += 1;
		//if the pointer reaches the end of the list, it resets back to 0 for when the next batch
		//of enemies are loaded in
		if (Globe.SizeSelect == stats.GetLength(1))
		{
			Globe.SizeSelect = 0;

		}



	}

	//this function handles the actual movement
	public override void _PhysicsProcess(double delta)
	{
		//calculates the direction vector between the enemy and the player
		var direction = (player.Position - Position) - new Vector2(275, 450);
		//uses pythagoras to calculate the magnitude of the direction vector
		var trueD = Math.Sqrt((direction.X * direction.X) + (direction.Y * direction.Y));
		//only utilises the calculated direction when the enemy is under 1000 pixels from 
		//the player
		if (trueD < 1000)
		{
			velocity = (new Vector2(1, 1) * direction.Normalized() * 3);
			//moves the enemy based on its velocity values and the global enemy speed stat
			var collision = MoveAndCollide(velocity * Globe.enemy_speed * Velocity);
			//checks if the enemy is dead
			dead(collision);
			collisioncheck(collision);
		}
		else
		{
			//moves the enemy based on its velocity values and the global enemy speed stat
			var collision = MoveAndCollide(velocity * Globe.enemy_speed * Velocity);
			dead(collision);
			collisioncheck(collision);
		}





	}
	//handles the enemies death, if it is dead and it has been dead for longer than the allotted
	//time, it will come back to life
	public override void _Process(double delta)
	{
		if (isdead == true)
		{
			deathtimer += delta;
			if (deathtimer > time)
			{
				isdead = false;
				deathtimer = 0;
			}


		}
	}

	public void dead(KinematicCollision2D collision)
	{
		//if the projectile that hits the enemy is supposed to kill an enemy, the enemy will die
		if (collision != null)
		{
			var thing = (string)((Node)collision.GetCollider()).Name;
			GD.Print(thing);

			if (thing.Contains("kill"))
			{
				isdead = true;


			}
		}
		if (isdead == true)
		{
			//changes the opacity of the enemy to make it transparent
			this.Modulate = new Color(1, 1, 1, (float)0.5);
			//changes collision layer and mask values, setting them to false so that 
			//the enemy cannot collide with the player
			this.SetCollisionLayerValue(3, false);
			this.SetCollisionMaskValue(7, false);
			//sets the time to 3, so the enemy will be dead for 3 seconds
			time = 3;


		}
		//if the enemy is alive, it will become fully opaque and collide with the player again
		else
		{
			this.Modulate = new Color(1, 1, 1, (float)1);
			this.SetCollisionLayerValue(3, true);
			this.SetCollisionMaskValue(7, true);


		}








	}
}
