using Godot;
using System;

public partial class top_world_teleporter : Area2D
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
		//loads the character object so its attributes can be accessed
		var Player = character.Character_load(Globe.picked_character);
		//if the character collides with the top world teleporter, the level is increased by 1,
		//which changes the world
		if (body.GetClass() == "CharacterBody2D")
		{
			Globe.Level += 1;
			//if the Level hits 75(last world), it loops back around to 70(the first world)
			if (Globe.Level == 75)
			{
				Globe.Level = 70;
			}
			//stores the current world name for the program to use in labels
			Globe.current_world_name = Globe.world_Name_list[Globe.Level - 70];
			//abilities are de-activated
			Globe.ability1active = false;
			Globe.ability2active = false;
			//the scene is changed to the next level
			SceneManager.instance.ChangeScene((eSceneNames)Globe.Level);
		}


	}
}
