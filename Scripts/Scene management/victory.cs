using Godot;
using System;

public partial class victory : Node2D
{
	// Called when the node enters the scene tree for the first time.

	Godot.RichTextLabel Minutes;

	Godot.RichTextLabel Seconds;

	Godot.RichTextLabel Miliseconds;

	public override void _Ready()
	{
		//ensures the _Ready() function is called whenever the victory screen opens
		this.RequestReady();
		//fetches the references to the timer labels if they dont exist (minutes,seconds,miliseconds)
		if (Minutes == null)
		{
			Minutes = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/GridContainer/Minutes");
			Seconds = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/GridContainer/Seconds");
			Miliseconds = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/GridContainer/Miliseconds");
		}
		//calculates the times for each section of the timer
		float miliseconds = (Globe.time % 1) * 1000;
		float seconds = Globe.time % 60;
		float minutes = (Globe.time % 3600) / 60;
		//assigns the calculated times their respective timer label
		Minutes.Text = "." + Convert.ToString(minutes);
		Seconds.Text = "." + Convert.ToString(Convert.ToInt32(seconds));
		Miliseconds.Text = Convert.ToString(Convert.ToInt32(miliseconds));
		//unlocks a character depending on which world has been completed
		if (Globe.current_world_name == "Simple Slopes")
		{
			Data.Save_Victory("Radion", Globe.Username, Globe.Password);



		}
		if (Globe.current_world_name == "Volcanic Valley")
		{
			Data.Save_Victory("Mantle", Globe.Username, Globe.Password);



		}
		if (Globe.current_world_name == "Midnight Massacre")
		{
			Data.Save_Victory("Vanta", Globe.Username, Globe.Password);



		}
		if (Globe.current_world_name == "Derelict Desert")
		{
			Data.Save_Victory("Ruin", Globe.Username, Globe.Password);



		}
		if (Globe.current_world_name == "Hypnotic Hills")
		{
			Data.Save_Victory("Hypno", Globe.Username, Globe.Password);



		}
		//loads the updated account
		Globe.data = Data.Load_game(Globe.Username, Globe.Password);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//this function is responsible for the back button, which resets all game data and takes
	//the user back to the menu
	public void _on_texture_button_pressed()
	{
		Globe.Level = 70;
		Globe.True_Level = 1;
		Globe.enemy_speed = 3;
		Globe.time = 0;
		Globe.SizeSelect = 0;
		SceneManager.instance.ChangeScene(eSceneNames.MainMenu);

	}
}
