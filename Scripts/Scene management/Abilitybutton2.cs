using Godot;
using System;

public partial class Abilitybutton2 : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//loads the second ability button of the respective character
		if (Globe.picked_character == "Spore")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Spore Spore trail.png");

		}
		if (Globe.picked_character == "Ignis")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Ignis flamethrower.png");

		}
		if (Globe.picked_character == "Atlantia")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Atlantia Tsunami.png");

		}
		if (Globe.picked_character == "Astraeus")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Astaeus gamma ray.png");

		}
		if (Globe.picked_character == "Vanta")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Vanta void.png");

		}
		if (Globe.picked_character == "Ruin")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Ruin stomp.png");

		}
		if (Globe.picked_character == "Mantle")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Mantle Lava trail.png");

		}
		if (Globe.picked_character == "Hypno")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Hypno Control.png");

		}
		if (Globe.picked_character == "Radion")
		{
			this.TextureNormal = (Texture2D)GD.Load("res://Sprites/Button Sprites/Exported ability buttons/Radion Nuke.png");

		}

	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
