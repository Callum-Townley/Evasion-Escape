using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public partial class Normal_Enemy : CharacterBody2D
{
	//private List<int> enemysize = new List<int>{1,2,3};

	private int i = 1;

	public Vector2 velocity = Vector2.Zero;

	private int speed = 5;

	float randomspeed;
	float scale1;
	float scale2;

	double deathtimer = 0;

	double time;

	bool isdead = false;

	KinematicCollision2D collision;



	double[,] stats = GameMaster.StatDictionary[(eSceneNames)Globe.Level];


	RandomNumberGenerator rng = new RandomNumberGenerator();
	public override void _Ready()
	{

		Velocity = new Vector2(1, 1);
		//makes the enemy spawn with velocity of magnitude 1 in a random direction
		velocity.X = rng.RandfRange((float)-10.0, (float)10.0);
		velocity.Y = rng.RandfRange((float)-10.0, (float)10.0);
		//multiplies the velocity(1) by the enemy's respective speed in the game master script
		velocity = velocity.Normalized() * (float)stats[1, Globe.SizeSelect];
		//sets the scale of the enemy to be the enemy's respective scale in the game master script
		this.Scale = new Vector2((float)stats[0, Globe.SizeSelect], (float)stats[0, Globe.SizeSelect]);
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
		collision = MoveAndCollide(velocity * Globe.enemy_speed * Velocity);
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
		//checks if the enemy is dead
		dead(collision);
	}

	public void dead(KinematicCollision2D collision)
	{
		//if the projectile that hits the enemy is supposed to kill an enemy, the enemy will die
		if (collision != null)
		{
			var collidename = (string)((Node)collision.GetCollider()).Name;
			GD.Print(collidename);

			if (collidename.Contains("kill"))
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
			this.SetCollisionMaskValue(7, true);
			this.SetCollisionLayerValue(3, true);



		}








	}



}

