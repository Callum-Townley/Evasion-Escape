using Godot;
using System;

public partial class Username_label : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//lets me use BBcode formatting, which is a way to create styled text in godot
		this.BbcodeEnabled = true;
		string text = $"[center] {Globe.Username} [/center]";
		//centers the players username within the text label
		//checks if the accounts list contains enough accounts to have a first,second or third place account
		if (Globe.Accounts.Count >= 1)
		{
			//if the user's account is first on the leaderboard, their username is gold
			if (Globe.Username == (string)Globe.Accounts[0]["Username"])
			{
				text = "[center][color=gold]" + text + "[/color][/center]";
			}
		}
		if (Globe.Accounts.Count >= 2)
		{
			//if the user's account is second on the leaderboard, their username is silver
			if (Globe.Username == (string)Globe.Accounts[1]["Username"])
			{
				text = "[center][color=gray]" + text + "[/color][/center]";

			}
		}
		if (Globe.Accounts.Count >= 3)
		{
			//if the user's account is third on the leaderboard, their username is bronze
			if (Globe.Username == (string)Globe.Accounts[2]["Username"])
			{
				text = "[center][color=saddle_brown]" + text + "[/color][/center]";

			}
		}
		//sets the text attribute of the label to the text that has been created
		Text = text;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
