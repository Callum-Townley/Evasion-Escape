using Godot;
using System;


public partial class Options : Control
{

	Control options;
	TextureButton Mouse;
	TextureButton WASD;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//gets the references for the options menu, the mouse button and the WASD button
		options = this;
		Mouse = GetNode<TextureButton>("MarginContainer/GridContainer/Mouse button");
		WASD = GetNode<TextureButton>("MarginContainer/GridContainer/WASD");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_resume_button_pressed()
	{
		// when the resume button is pressed, the options menu is hidden and the game is unpaused.
		Hide();
		GetTree().Paused = false;
		Globe.ispaused = !Globe.ispaused;



	}
	private void _on_quit_to_menu_button_pressed()
	{
		//unpauses the game, resets all game data, and changes the scene back to the main menu
		GetTree().Paused = false;
		Globe.Level = 70;
		Globe.True_Level = 1;
		Globe.enemy_speed = 3;
		Globe.SizeSelect = 0;
		Globe.time = 0;
		SceneManager.instance.ChangeScene(eSceneNames.MainMenu);
	}

	public void _on_options_button_pressed()
	{
		//toggles the options menu on and off
		Globe.ispaused = !Globe.ispaused;

		if (Globe.ispaused)
		{
			Show();
			GetTree().Paused = true;
		}
		else
		{
			Hide();
			GetTree().Paused = false;
		}




	}
	public void _on_mouse_button_pressed()
	{
		//changes movement mode to mouse
		Globe.movement = "Mouse";
		//changes the mouse button green and the WASD button grey
		Mouse.TextureNormal = (Texture2D)GD.Load($"res://Sprites/Button Sprites/Mouse (selected) button (options).png");
		WASD.TextureNormal = (Texture2D)GD.Load($"res://Sprites/Button Sprites/WASD (unselected) button (options).png");



	}

	public void _on_wasd_pressed()
	{
		//changes movement mode to WASD
		Globe.movement = "WASD";
		//changes the WASD button green and the mouse button grey
		WASD.TextureNormal = (Texture2D)GD.Load($"res://Sprites/Button Sprites/WASD (selected) button (options).png");
		Mouse.TextureNormal = (Texture2D)GD.Load($"res://Sprites/Button Sprites/Mouse (unselected) button (options).png");
	}


}
