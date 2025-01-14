using Godot;
using System;

public partial class Character_unlocks : GridContainer
{

	Godot.TextureButton radion;
	Godot.TextureButton mantle;
	Godot.TextureButton vanta;
	Godot.TextureButton ruin;
	Godot.TextureButton hypno;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//gets the references to the texture buttons for the unlockable characters
		radion = GetNode<Godot.TextureButton>("Char_button5");
		mantle = GetNode<Godot.TextureButton>("Char_button6");
		vanta = GetNode<Godot.TextureButton>("Char_button7");
		ruin = GetNode<Godot.TextureButton>("Char_button8");
		hypno = GetNode<Godot.TextureButton>("Char_button9");
		//loads the data of the current account from the JSON file
		Globe.data = Data.Load_game(Globe.Username, Globe.Password);
		//checks if each character is unlocked (true) in the account dictionary
		//if it is, the button is activated, allowing the player to use the character
		if ((bool)Globe.data["Radion"] == true)
		{
			radion.Disabled = false;
		}
		if ((bool)Globe.data["Mantle"] == true)
		{
			mantle.Disabled = false;



		}
		if ((bool)Globe.data["Vanta"] == true)
		{
			vanta.Disabled = false;



		}
		if ((bool)Globe.data["Ruin"] == true)
		{
			ruin.Disabled = false;



		}
		if ((bool)Globe.data["Hypno"] == true)
		{
			hypno.Disabled = false;



		}


	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}