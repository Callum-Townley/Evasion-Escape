using Godot;
using System;
using System.Numerics;

public partial class Hypno2_Projectile : CharacterBody2D
{

	[Export] int speed = 75;
	public float dir;
	public Godot.Vector2 spawnpos;

	public float spawnrot;
	public Godot.Vector2 direction;
	public Godot.Vector2 slow;

	public override void _Ready()
	{
		slow = direction;
		//ensures the rotation and position is the same as the character's
		GlobalPosition = spawnpos;
		GlobalRotation = spawnrot;
		//ensures the projectile will layer ontop of all other entities
		ZIndex = 10;
	}


	public override void _PhysicsProcess(double delta)
	{
		//slows the projectile over time,by decreasing its velocity in the X axis 
		direction.X = direction.X - ((float)0.02 * slow.X);
		//moves the projectile in the calculated direction with its speed
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
