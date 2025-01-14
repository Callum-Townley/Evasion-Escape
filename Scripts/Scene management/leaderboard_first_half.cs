using Godot;
using System;
using Godot.Collections;
using System.Threading;

public partial class leaderboard_first_half : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//sorts the accounts array from highest VP to lowest VP
		Data.Sort();
		int count = 1;
		//loops through each account in the accounts array, and displays its place in the leaderboard
		//(count), the username and the account's VP.
		foreach (Dictionary i in Globe.Accounts)
		{
			string text = count + ". " + (string)i["Username"] + ": " + (string)i["VP"] + "\n";
			//gives first,second and third place different colours
			if (count == 1)
			{
				Text = "[color=gold]" + text + "[/color]";
			}
			else if (count == 2)
			{
				Text += "[color=gray]" + text + "[/color]";

			}
			else if (count == 3)
			{
				Text += "[color=saddle_brown]" + text + "[/color]";

			}
			else
			{
				Text += text;
			}

			count += 1;



		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
