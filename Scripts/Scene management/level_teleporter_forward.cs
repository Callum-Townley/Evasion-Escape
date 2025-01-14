using Godot;
using System;


public partial class level_teleporter_forward : Area2D
{


	public void _on_body_entered(Node2D body)
	{
		//loads the character object so its attributes can be accessed
		var Player = character.Character_load(Globe.picked_character);
		if (body.GetClass() == "CharacterBody2D" && Player.VX > 0)
		{
			//if the character collides with the last level teleporter(when True_level is 10)
			//the victory scene is displayed
			if (Globe.True_Level == 10)
			{
				SceneManager.instance.ChangeScene(eSceneNames.victory);
			}
			//otherwise , the character will be moved to the next level(which in the enum is 10 above)
			//True_level is incremented to handle the victory screen beig displayed
			else
			{
				Globe.Level += 10;
				Globe.True_Level += 1;
				//abilities are de-activated
				Globe.ability1active = false;
				Globe.ability2active = false;
				SceneManager.instance.ChangeScene((eSceneNames)Globe.Level);
			}
		}
		//if the player hits the teleporter with negative X velocity (going backwards)
		//they will be teleported to the level before
		else if (Player.VX < 0 && body.GetClass() == "CharacterBody2D")
		{
			Globe.Level -= 10;
			Globe.True_Level -= 1;
			Globe.ability1active = false;
			Globe.ability2active = false;
			SceneManager.instance.ChangeScene((eSceneNames)Globe.Level);
		}


	}

}
