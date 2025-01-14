using Godot;
using System;

public partial class Radiation : Area2D
{

	int count = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_body_entered(CharacterBody2D body)
	{
		//halfs the speed of the enemy that enters the aura
		string name = body.Name;
		if (name.Contains("enemy"))
		{
			body.Velocity /= 2;




		}


	}

	public void _on_body_exited(CharacterBody2D body)
	{
		//doubles the speed of the enemy that exits the aura-returning it to normal
		string name = body.Name;
		if (name.Contains("enemy"))
		{
			body.Velocity *= 2;




		}


	}
}
