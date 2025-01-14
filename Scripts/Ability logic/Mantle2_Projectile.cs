using Godot;
using System;

public partial class Mantle2_Projectile : StaticBody2D
{
	double time;


	public Godot.Vector2 spawnpos;

	public float spawnrot;
	public Godot.Vector2 direction;

	public override void _Ready()
	{
		//ensures the rotation and position is the same as the character's
		GlobalPosition = spawnpos;
		GlobalRotation = spawnrot;
	}
	public override void _Process(double delta)
	{
		//destroys the projectile after 2 seconds
		time += delta;
		if (time > 2)
		{
			QueueFree();
		}
	}

}
