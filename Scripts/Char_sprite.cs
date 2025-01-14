using Godot;
using System;

public partial class Char_sprite : Sprite2D
{

	public override void _Ready()
	{
		//loads the player object
		var Player = character.Character_load(Globe.picked_character);
		//ensures the player object exists (probably unnecessary)
		if (Player != null)
		{
			// assigns the player object a texture depending on character type, so the texture can be referenced throughout the game
			Player.texture = (Texture2D)GD.Load($"res://Sprites/Character sprites/{Player.character_type}.png");
			//assigns the texture to the sprite node, so it shows up ingame
			this.Texture = Player.texture;
		}


	}


	public override void _Process(double delta)
	{
	}
}
