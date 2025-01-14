using Godot;
using System;

public partial class bottom_world_teleporter : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void _on_body_entered(Node2D body)
	{
		//loads the character object to access its attributes
		var Player = character.Character_load(Globe.picked_character);
		//if the player collides with the bottom world teleporter, the level decreases by 1
		//Because the worlds are 1 appart from eachother (see the scene manager EsceneNames enum)
		//this decreases the world
		if (body.GetClass() == "CharacterBody2D")
		{
			Globe.Level -= 1;
			//here i am looping the worlds back around, so if you get to the last one,
			//it loops back to the first
			if (Globe.Level == 69)
			{
				Globe.Level = 74;
			}
			//fetches the world name from the world name list
			Globe.current_world_name = Globe.world_Name_list[Globe.Level - 70];
			//deactivates any active abilities
			Globe.ability1active = false;
			Globe.ability2active = false;
			//changes the scene to the new world
			SceneManager.instance.ChangeScene((eSceneNames)Globe.Level);
		}


	}
}
