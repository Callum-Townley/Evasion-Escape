using Godot;
using System;

public partial class Ruin2_Projectile : CharacterBody2D
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
		direction = direction.Normalized();
	}

	public override void _Process(double delta)
	{
		//despawns the projectile after 2 seconds
		time += delta;
		if (time > 2)
		{
			QueueFree();
		}
	}


	public override void _PhysicsProcess(double delta)
	{
		//slows the speed of the projectile until it comes to a standstill
		direction = direction - ((float)0.05 * direction);
		Godot.Vector2 velocity = (direction * speed) / 4;
		var collision = MoveAndCollide(velocity);
		//destroys the projectile if it hits a wall
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
