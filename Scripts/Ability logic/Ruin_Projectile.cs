using Godot;
using System;
using System.Numerics;

public partial class Ruin_Projectile : CharacterBody2D
{

	[Export] int speed = 75;
	public float dir;
	public Godot.Vector2 spawnpos;

	public float spawnrot;
	public Godot.Vector2 direction;

	public override void _Ready()
	{
		//ensures the rotation and position is the same as the character's
		GlobalPosition = spawnpos;
		GlobalRotation = spawnrot;
		//ensures the projectile will layer ontop of all other entities
		ZIndex = 10;
	}

	public override void _Process(double delta)
	{
		//sets the max scale of the projectile
		Godot.Vector2 maxScale = new Godot.Vector2((float)2.5, (float)2.5);

		Godot.Vector2 velocity = Godot.Vector2.Zero;
		//the projectile will grow until it hits max size, and then stay at that size.
		if (Scale <= maxScale)
		{
			velocity = Godot.Vector2.Zero;
			Scale = Scale * new Godot.Vector2((float)1.025, (float)1.025);
		}
		else
		{
		}


	}



	public override void _PhysicsProcess(double delta)
	{
		//sets the velocity, it is divided by 4 to slow it down.
		Godot.Vector2 velocity = direction * speed;
		velocity /= 4;
		var collision = MoveAndCollide(velocity);
		//deletes the projectile after it collides with a wall
		if (collision != null)
		{
			var thing = ((Node)collision.GetCollider()).Name;
			if (thing == "Top wall" || thing == "Bottom wall" || thing == "Left wall" || thing == "Right wall")
			{
				QueueFree();


			}
		}
	}





}
