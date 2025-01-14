using Godot;
using System;

public partial class Game_Over : Node2D
{
	// Called when the node enters the scene tree for the first time.

	Godot.RichTextLabel Minutes;

	Godot.RichTextLabel Seconds;

	Godot.RichTextLabel Miliseconds;
	public override void _Ready()
	{
		//If the game does not have the reference to the timer labels, it will fetch them
		if (Minutes == null)
		{
			Minutes = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/GridContainer/Minutes");
			Seconds = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/GridContainer/Seconds");
			Miliseconds = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/GridContainer/Miliseconds");
		}
		//calculates each part of the timer using the global time.
		float miliseconds = (Globe.time % 1) * 1000;
		float seconds = Globe.time % 60;
		float minutes = (Globe.time % 3600) / 60;
		//displays the time on each timer label
		Minutes.Text = "." + Convert.ToString(minutes);
		Seconds.Text = "." + Convert.ToString(Convert.ToInt32(seconds));
		Miliseconds.Text = Convert.ToString(Convert.ToInt32(miliseconds));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//this function is for the back button- all globals are reset to default
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
