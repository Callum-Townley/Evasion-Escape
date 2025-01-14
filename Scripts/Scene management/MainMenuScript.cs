using Godot;
using Godot.Collections;
using System;
using System.IO;

public partial class MainMenuScript : Node2D
{
	[Export] public eSceneNames mySceneName;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	////Each of these functions are called whenever their respective buttons are pressed
	private void _on_play_button_pressed(){
		SceneManager.instance.ChangeScene(eSceneNames.CharacterSelect);
	
	}
	private void _on_leaderboards_button_pressed(){
		SceneManager.instance.ChangeScene(eSceneNames.leaderboards);
	}
	private void _on_profile_button_pressed(){
		SceneManager.instance.ChangeScene(eSceneNames.Profile);
	}
	private void _on_logout_button_pressed(){
		SceneManager.instance.ChangeScene(eSceneNames.Login_SignUp);
	}
	private void _on_how_to_play_button_pressed(){
		SceneManager.instance.ChangeScene(eSceneNames.HowToPlay);
	}

	private void _on_texture_button_pressed(){
		GetTree().Quit();
	}

	
}
