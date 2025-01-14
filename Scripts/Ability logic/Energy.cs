using Godot;
using System;

public partial class Energy : RichTextLabel
{
	int count = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//displays the energy percentage text within the label
		Text = Convert.ToString(Math.Round(Globe.energy) + " %");
		//this section causes the player's energy to regenerate over time, aslong as they
		//are not using an ability
		if (Globe.energy < 100 && Globe.ability1active == false && Globe.ability2active == false)
		{
			Globe.energy = Globe.energy + 0.5;
		}
		//if an ability is active, the energy is decreased by 0.5 multiplied by the
		//abilities energy drain rate
		else if (Globe.energy > 0 && Globe.ability1active == true || Globe.energy > 0 && Globe.ability2active == true)
		{
			Globe.energy = Globe.energy - 0.5 * Globe.energy_rate;
		}
		//this ensures that energy does not go negative
		else if (Globe.energy < 0)
		{
			Globe.energy = 0;
		}

	}
}
