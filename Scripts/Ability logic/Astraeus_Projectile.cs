using Godot;
using System;
using System.Data;
using System.Numerics;

public partial class Astraeus_Projectile : CharacterBody2D
{

	[Export] int speed = 75;
	public float dir;
	public Godot.Vector2 spawnpos;

	public float spawnrot;
	public Godot.Vector2 direction;

	public double time;

	public KinematicCollision2D collision;

	String thing;

	bool hit = false;

	public override void _Ready()
	{
		//ensures the rotation and position is the same as the character's
		GlobalPosition = spawnpos;
		GlobalRotation = spawnrot;
		//sets this projectile above all other layers
		ZIndex = 10;
	}

	public override void _Process(double delta)
	{
		time += delta;
		//sets the max scale for the projectile
		Godot.Vector2 maxScale = new Godot.Vector2((float)6, (float)6);
		//sets the projectiles velocity to 0
		Godot.Vector2 velocity = Godot.Vector2.Zero;
		// will grow the projectile until it hits max size, then it will be destroyed
		if (Scale <= maxScale)
		{
			velocity = Godot.Vector2.Zero;
			Scale = Scale * new Godot.Vector2((float)1.05, (float)1.05);
		}
		else
		{
			QueueFree();
		}
	}


	//ensures the projectile does not move and will collide with enemies
	public override void _PhysicsProcess(double delta)
	{

		var velocity = Godot.Vector2.Zero;

		var collision = MoveAndCollide(velocity);

	}
}





