using Godot;
using System;
using System.Numerics;

public partial class Atlantia_Projectile : CharacterBody2D
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


	public override void _PhysicsProcess(double delta)
	{
		//moves the projectile in the calculated direction with its speed
		Godot.Vector2 velocity = direction * speed;
		var collision = MoveAndCollide(velocity);
		if (collision != null)
		{
			var thing = ((Node)collision.GetCollider()).Name;
			//makes the projectile disappear if it hits a wall
			if (thing == "Top wall" || thing == "Bottom wall" || thing == "Left wall" || thing == "Right wall")
			{
				QueueFree();


			}
		}
	}





}
