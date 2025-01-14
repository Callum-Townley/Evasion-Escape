using Godot;
using System;

public partial class RichTextLabel : Godot.RichTextLabel
{
	string worldnum;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// creates the colours that i will use for the text of each world
		Color FirstFontColour = new Color(Colors.PaleGreen);
		Color SecondFontColour = new Color(Colors.Firebrick);
		Color ThirdFontColour = new Color(Colors.DarkMagenta);
		Color FourthFontColour = new Color(Colors.Gold);
		Color FifthFontColour = new Color(Colors.Violet);
		//gets the number of the world the user is on
		worldnum = Convert.ToString(Globe.Level);
		//checks the last digit of the Level number (used in the Escenenames enum in scenemanager.cs)
		//to find the world the user is in
		//it then displays the world name and level for the respective world,in the world's colour
		if (worldnum[worldnum.Length - 1] == '0')
		{
			Text = Convert.ToString(Globe.world_Name_list[0] + $" {Globe.True_Level}");
			Modulate = FirstFontColour;
		}
		else if (worldnum[worldnum.Length - 1] == '1')
		{
			Text = Convert.ToString(Globe.world_Name_list[1] + $" {Globe.True_Level}");
			Modulate = SecondFontColour;
		}
		else if (worldnum[worldnum.Length - 1] == '2')
		{
			Text = Convert.ToString(Globe.world_Name_list[2] + $" {Globe.True_Level}");
			Modulate = ThirdFontColour;
		}
		else if (worldnum[worldnum.Length - 1] == '3')
		{
			Text = Convert.ToString(Globe.world_Name_list[3] + $" {Globe.True_Level}");
			Modulate = FourthFontColour;
		}
		else if (worldnum[worldnum.Length - 1] == '4')
		{
			Text = Convert.ToString(Globe.world_Name_list[4] + $" {Globe.True_Level}");
			Modulate = FifthFontColour;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
