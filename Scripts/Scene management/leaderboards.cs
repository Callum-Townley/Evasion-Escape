using Godot;
using System;
using Godot.Collections;

public partial class leaderboards : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//function takes you back to the main menu
	public void _on_texture_button_pressed()
	{
		SceneManager.instance.ChangeScene(eSceneNames.MainMenu);
	}
}
