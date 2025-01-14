using Godot;
using System;

public partial class Expanding_enemy : CharacterBody2D
{
	private int i = 1;

	public Vector2 velocity = Vector2.Zero;
	private int speed = 5;

	float randomspeed;
	float scale1;
	float scale2;

	int count = 0;

	bool isdead = false;

	int time;

	Sprite2D sprite;

	CollisionShape2D shape;

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
		sprite = GetNode<Sprite2D>("Sprite2D");
		shape = GetNode<CollisionShape2D>("CollisionShape2D");
		Velocity = new Vector2(1, 1);
		//makes the enemy spawn with velocity of magnitude 1 in a random direction
		velocity.X = rng.RandfRange((float)-10.0, (float)10.0);
		velocity.Y = rng.RandfRange((float)-10.0, (float)10.0);
		scale1 = (float)stats[0, Globe.SizeSelect] / (float)1.5;
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

	//this function handles the actual movement
	public override void _PhysicsProcess(double delta)
	{
		//moves the enemy based on its velocity values and the global enemy speed stat
		var collision = MoveAndCollide(velocity * Globe.enemy_speed * Velocity);
		//checks if the enemy is dead
		dead(collision);
		collisioncheck(collision);
		//this if statement causes the enemy to expand until it reaches a max size
		if (count == 0 && sprite.Scale.X < (float)stats[0, Globe.SizeSelect] * 1.5)
		{
			scale1 = scale1 * (float)1.003;
			sprite.Scale = sprite.Scale * new Vector2((float)1.004, (float)1.004);
			shape.Scale = sprite.Scale * new Vector2((float)1.004, (float)1.004);
			collisioncheck(collision);
		}
		else
		{
			count = 1;
		}
		//this if statement causes the enemy to shrink until it reaches a minimum size
		if (count == 1 && sprite.Scale.X > (float)stats[0, Globe.SizeSelect] * 0.60)
		{
			scale1 = scale1 / (float)1.003;
			sprite.Scale = sprite.Scale / new Vector2((float)1.004, (float)1.004);
			shape.Scale = sprite.Scale / new Vector2((float)1.004, (float)1.004);
			collisioncheck(collision);
		}
		else
		{
			count = 0;
		}
		collisioncheck(collision);




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
