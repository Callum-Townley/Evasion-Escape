using Godot;
using System;
using System.Data;
using System.Numerics;

public partial class Spore_Projectile : CharacterBody2D
{
	int speed = 75;
	public float dir;
	public Godot.Vector2 spawnpos;

	public float spawnrot;

	public double time;
	public Godot.Vector2 direction;

	public override void _Ready()
	{
		this.Modulate = new Color(0, 1, 0, (float)1);
		//ensures the rotation and position is the same as the character's
		GlobalPosition = spawnpos;
		GlobalRotation = spawnrot;
		//ensures the projectile will layer ontop of all other entities
		ZIndex = 10;
	}

	public override void _Process(double delta)
	{
		time += delta;
		//sets the max scale of the projectile
		Godot.Vector2 maxScale = new Godot.Vector2((float)2.5, (float)2.5);

		Godot.Vector2 velocity = Godot.Vector2.Zero;
		//after 1.5 seconds, the projectile will grow until max size, then it will despawn
		if (time > 1.5)
		{
			if (Scale <= maxScale)
			{
				Scale = Scale * new Godot.Vector2((float)1.030, (float)1.030);
			}
			else
			{
				QueueFree();
			}


		}
	}


	public override void _PhysicsProcess(double delta)
	{
	}





}
