using Godot;
using System;

public partial class Spore2_Projectile : Area2D
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
		//after 2 seconds, the projectile will despawn
		time += delta;
		if (time > 2)
		{
			QueueFree();
		}
	}
	public void _on_body_entered(CharacterBody2D body)
	{

		string name = body.Name;
		//if an enemy enters the area of the projectile, its speed will be halved
		if (name.Contains("enemy"))
		{
			body.Velocity /= 2;




		}


	}

	public void _on_body_exited(CharacterBody2D body)
	{
		string name = body.Name;
		//if an enemy exits the area of the projectile, its speed will be doubed,back to its original
		if (name.Contains("enemy"))
		{
			body.Velocity *= 2;




		}


	}
}
