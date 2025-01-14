using Godot;
using Godot.Collections;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

public partial class Login_SignUp : Node2D
{

	public Godot.LineEdit Username;

	public Godot.LineEdit Password;

	public Godot.RichTextLabel Warning;

	public Godot.FileAccess data;

	public Godot.Control Datacontrol;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	//this function is mapped to the login button
	public void _on_texture_button_pressed()
	{
		//aquires references to the Username and password input boxes, and the warning text label.
		Username = GetNode<Godot.LineEdit>("CanvasLayer/Control/Username_text");
		Password = GetNode<Godot.LineEdit>("CanvasLayer/Control/Password_text");
		Warning = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/RichTextLabel3");
		//this sets the default warning text, which is displayed if the user does not log in
		Warning.Text = "You've failed to log in";
		//attempts to load the requested data from an account in the JSON file using
		//the username and password inputted into the text boxes
		Globe.data = Data.Load_game(Username.Text, Password.Text);
		//checks if the aquired account has a username and password equal to what was inputted
		//into the text boxes
		if (Convert.ToString(Globe.data["Username"]) == Username.Text && Convert.ToString(Globe.data["Password"]) == Password.Text)
		{
			//if this check is passed, we aquire all accounts in the JSON file as a list
			Globe.Accounts = Data.Json_list();
			//saves Username and Password into variables for later use in the program
			Globe.Username = Username.Text;
			Globe.Password = Password.Text;
			//sorts the Accounts list in order of VP-highest to lowest
			Data.Sort();
			//changes the scene to the main menu
			SceneManager.instance.ChangeScene(eSceneNames.MainMenu);
		}
		else
		{
			// will display a warning if you failed to log in
			Warning.Text = "You've failed";
		}

	}
	//this function is mapped to the sign up button
	public void _on_texture_button_2_pressed()
	{
		//gets references for the username and password text boxes, and the warning label.
		Username = GetNode<Godot.LineEdit>("CanvasLayer/Control/Username_text");
		Password = GetNode<Godot.LineEdit>("CanvasLayer/Control/Password_text");
		Warning = GetNode<Godot.RichTextLabel>("CanvasLayer/Control/RichTextLabel3");
		//gets the username and password entered from the text boxes.
		string Ustring = Username.Text;
		string Pstring = Password.Text;
		//attempts to create a new account with the inputed username and password
		//success stores the warning that is returned, letting the user know what the outcome is
		string success = Data.Save_game(Ustring, Pstring);
		//fetches the accounts from the JSON file and puts them into a list "Accounts"
		Globe.Accounts = Data.Json_list();
		//displays the warning text
		Warning.Text = success;





	}
}
