using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;


public partial class PlayerData : Control
{
	public static FileAccess save_game;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


}

public static class Data
{
	//this function creates a new account using the inputted username and passwords
	public static Dictionary Save(string Username, string Password)
	{
		Dictionary save_dict = new Dictionary(){
		{"Username",Username},
		{"Password",Password},
		{"VP",Globe.VP},
		{"Radion",false},
		{"Mantle",false},
		{"Vanta",false},
		{"Ruin",false},
		{"Hypno",false}




	};
		return save_dict;
	}


	public static dynamic Save_game(string Username, string Password)
	{
		//attempts to open the file in readWrite mode(does nothing if the file doesnt exist)
		Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.ReadWrite);
		//if the file is not opened, it means it doesnt exist to begin with, so it is opened in write
		//mode, which creates the file
		if (Globe.save_game == null)
		{
			Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.Write);
			//the file is then closed
			Globe.save_game.Close();
		}
		//the file is opened again in readwrite mode
		Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.ReadWrite);

		//checks if the accounts list has been loaded
		if (Globe.Accounts != null)
		{
			//iterates through each account within the accounts list
			foreach (Dictionary i in Globe.Accounts)
			{
				//reads each line within the JSON file(which just reads each account)
				var line = Globe.save_game.GetLine();
				//if the line isnt empty, the line is parsed into a C# object from a JSON string
				if (line != "" && line != null)
				{
					var JSON = new Json();
					var parse_result = JSON.Parse(line);
					//returns the parsed data into a dictionary data (data now holds the account)
					Dictionary data = (Dictionary)JSON.Data;
					//if the username the user wants to use to make their account is the same
					//as an account that already exists, it will return a warning and not make 
					//an account
					if (Convert.ToString(data["Username"]) == Username)
					{
						return "Account username same as another";

					}

					else
					{
						continue;
					}
				}
			}
			//ensures the Username and Password lengths of the account is a valid length
			if (Username.Length < 5 || Username.Length > 20)
			{
				return "Username length must be between 4-20 characters";
			}
			else if (Password.Length < 5 || Password.Length > 20)
			{
				return "Password length must be between 4-20 characters";
			}
			//if all the checks are passed, the new account is added to the accounts list
			Globe.Accounts.Add(Save(Username, Password));
			//the account is turned into a json string which is stored in the JSON file
			var Json_string = Json.Stringify(Save(Username, Password));
			Globe.save_game.StoreLine(Json_string);
			//the file is closed
			Globe.save_game.Close();
			return "Account created!";

		}


		return "";




	}

	public static void Save_Victory(string Character, string Username, string Password)
	{
		//opens the file in readwrite mode
		Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.ReadWrite);
		//iterates through each account in the accounts list
		foreach (Dictionary i in Globe.Accounts)
		{
			//checks if the account stored in the list is the same as the one that is currently
			//being used
			if (Convert.ToString(i["Username"]) == Convert.ToString(Globe.data["Username"]) && Convert.ToString(i["Password"]) == Convert.ToString(Globe.data["Password"]))
			{
				//removes the respective character that the user is to unlock
				i.Remove(Character);
				//adds the character back, but the value is changed to true,unlocking the character.
				i.Add(Character, true);
				//increases the VP of the account by the point 
				int num = (int)i["VP"];
				num += Globe.VP;
				i.Remove("VP");
				i.Add("VP", num);
				//updates the stored account in the system to show the changes to the user.
				Globe.data = i;
			}
			//opens the save file in read/write mode if it isnt already
			Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.ReadWrite);
			//loops through each account in the accounts array
			foreach (Dictionary j in Globe.Accounts)
			{
				//converts each account into a JSON string and stores it in the save file,
				//this overwrites the contents of the save file, storing the updated accounts
				var Json_string = Json.Stringify(j);
				Globe.save_game.StoreLine(Json_string);


			}
			Globe.save_game.Close();






		}
	}


	public static dynamic Load_game(string Username, string Password)
	{


		//opens the JSON file in read mode
		Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.Read);
		//loops through the entire save file one line at a time
		while (Globe.save_game.GetPosition() < Globe.save_game.GetLength())
		{
			var line = Globe.save_game.GetLine();
			if (line != "" && line != null)
			{
				//aquires the account(data) from the current line of the save file
				var JSON = new Json();
				var parse_result = JSON.Parse(line);
				Dictionary data = (Dictionary)JSON.Data;
				//if the username and password of the account match the ones that the user inputed
				//the account will be returned
				if (Convert.ToString(data["Username"]) == Username && Convert.ToString(data["Password"]) == Password)
				{
					return data;
				}
				else
				{
					continue;
				}
			}
			else
			{
				continue;
			}




		}
		Globe.save_game.Close();
		return null;




	}

	public static dynamic Json_list()
	{
		//creates the accounts list
		List<Dictionary> Accounts = new List<Dictionary>();
		//opens the save file in readwrite mode
		Globe.save_game = Godot.FileAccess.Open("user://savegame.json", Godot.FileAccess.ModeFlags.ReadWrite);


		//iterates through the entire save file, one line at a time
		while (Globe.save_game.GetPosition() < Globe.save_game.GetLength())
		{
			var line = Globe.save_game.GetLine();
			if (line != "" && line != null)
			{
				//aquires the account and ensures it is a C# object
				var JSON = new Json();
				var parse_result = JSON.Parse(line);
				Dictionary data = (Dictionary)JSON.Data;
				//adds the account to the accounts list
				Accounts.Add(data);
			}
			else
			{
				//closes the save file and returns the accounts list
				Globe.save_game.Close();
				return Accounts;
			}




		}
		Globe.save_game.Close();
		return Accounts;


	}
	//this entire function bubble sorts the list of accounts into order, from highest to
	//lowest VP
	public static void Sort()
	{

		for (int j = 0; j < Globe.Accounts.Count; j += 1)
		{
			int i = 0;
			while (i < Globe.Accounts.Count - 2)
			{

				if ((int)Globe.Accounts[i]["VP"] < (int)Globe.Accounts[i + 1]["VP"])
				{
					Dictionary temp = Globe.Accounts[i];
					Globe.Accounts[i] = Globe.Accounts[i + 1];
					Globe.Accounts[i + 1] = temp;

				}
				i += 1;


			}






		}


	}

}

