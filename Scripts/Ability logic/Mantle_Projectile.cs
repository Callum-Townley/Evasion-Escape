using Godot;
using System;

public partial class Mantle_Projectile : CharacterBody2D
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
		//sets the magnitude of the direction vector to 1
		direction = direction.Normalized();
	}


	public override void _PhysicsProcess(double delta)
	{
		//sets the velocity of the projectile
		Godot.Vector2 velocity = direction * speed;
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
