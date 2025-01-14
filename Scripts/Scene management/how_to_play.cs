using Godot;
using System;

public partial class how_to_play : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//function for the back button to take the user back to the main menu
	public void _on_texture_button_pressed()
	{
		SceneManager.instance.ChangeScene(eSceneNames.MainMenu);

	}
}
