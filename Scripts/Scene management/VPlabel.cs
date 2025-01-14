using Godot;
using System;

public partial class VPlabel : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//displays the VP earned for completing a world in the victory screen.
		//this value for VP is also utilised in VP calculations when adding it to an account
		if (Globe.current_world_name == "Simple Slopes")
		{
			Globe.VP = 1;
		}
		else if (Globe.current_world_name == "Volcanic Valley")
		{
			Globe.VP = 2;
		}
		else if (Globe.current_world_name == "Midnight Massacre")
		{
			Globe.VP = 5;
		}
		else if (Globe.current_world_name == "Derelict Desert")
		{
			Globe.VP = 3;
		}
		else if (Globe.current_world_name == "Hypnotic Hills")
		{
			Globe.VP = 4;
		}
		Text = $"{Globe.VP}";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
