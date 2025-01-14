using Godot;
using System;
using System.Data;
using System.Numerics;

public partial class Ignis_Projectile : CharacterBody2D
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
		//ensures the projectile will layer ontop of all other entities
		ZIndex = 10;
	}

	public override void _Process(double delta)
	{
		time += delta;
		//sets the maximum scale of the projectile
		Godot.Vector2 maxScale = new Godot.Vector2((float)2.5, (float)2.5);
		//ensures the velocity is 0
		Godot.Vector2 velocity = Godot.Vector2.Zero;
		//if the projectile has been out long enough, or has hit an enemy, it will expand until
		//max scale, then it will disappear
		if (time > 1.5 || hit == true)
		{
			if (Scale <= maxScale)
			{
				velocity = Godot.Vector2.Zero;
				Scale = Scale * new Godot.Vector2((float)1.1, (float)1.1);
			}
			else
			{
				QueueFree();
			}


		}
	}


	public override void _PhysicsProcess(double delta)
	{
		//sets the velocity of the projectile
		Godot.Vector2 velocity = direction * speed;
		//stops the projectile after it hits an enemy
		if (hit == true)
		{
			velocity = Godot.Vector2.Zero;
		}
		var collision = MoveAndCollide(velocity);
		if (collision != null)
		{
			thing = ((Node)collision.GetCollider()).Name;
			//turns hit to true if the projectile hits an enemy
			if (thing.Contains("enemy"))
			{
				hit = true;
			}
		}
	}





}
