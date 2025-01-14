using Godot;
using System;
using System.Numerics;

public partial class Ignis2_Projectile : CharacterBody2D
{

	[Export] int speed = 75;
	public float dir;
	public Godot.Vector2 spawnpos;

	public float spawnrot;
	public Godot.Vector2 direction;

	double time;

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
		//destroys the projectile after 3 seconds
		time += delta;
		if (time > 0.3)
		{
			QueueFree();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		//makes the magnitude of the direction vector equal 1
		direction = direction.Normalized();
		//sets the velocity of the projectile
		Godot.Vector2 velocity = direction * speed;
		velocity /= (float)1.5;
		var collision = MoveAndCollide(velocity);
		//destroys the projectile if it hits the wall
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
