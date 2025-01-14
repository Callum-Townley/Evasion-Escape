using Godot;
using System;
using System.Collections.Generic;

// creates a list of enums to hold my different scenes and i space them by 10 (incase i decide to add inbetween scenes)
//I try to keep simple numbering conventions to make each scene easily accessible
public enum eSceneNames : uint
{
	GameOver = 0,
	victory = 1,
	MainMenu = 10,
	CharacterSelect = 20,
	HowToPlay = 30,
	leaderboards = 40,
	Profile = 50,
	Login_SignUp = 60,
	First_world_1 = 70,

	First_world_2 = 80,
	First_world_3 = 90,
	First_world_4 = 100,
	First_world_5 = 110,
	First_world_6 = 120,

	First_world_7 = 130,

	First_world_8 = 140,

	First_world_9 = 150,

	First_world_10 = 160,

	Second_world_1 = 71,

	Second_world_2 = 81,

	Second_world_3 = 91,
	Second_world_4 = 101,

	Second_world_5 = 111,

	Second_world_6 = 121,
	Second_world_7 = 131,

	Second_world_8 = 141,
	Second_world_9 = 151,

	Second_world_10 = 161,
	Third_world_1 = 72,

	Third_world_2 = 82,

	Third_world_3 = 92,

	Third_world_4 = 102,

	Third_world_5 = 112,

	Third_world_6 = 122,

	Third_world_7 = 132,

	Third_world_8 = 142,

	Third_world_9 = 152,

	Third_world_10 = 162,
	Fourth_world_1 = 73,

	Fourth_world_2 = 83,

	Fourth_world_3 = 93,

	Fourth_world_4 = 103,

	Fourth_world_5 = 113,

	Fourth_world_6 = 123,

	Fourth_world_7 = 133,

	Fourth_world_8 = 143,

	Fourth_world_9 = 153,

	Fourth_world_10 = 163,
	Fifth_world_1 = 74,

	Fifth_world_2 = 84,

	Fifth_world_3 = 94,

	Fifth_world_4 = 104,

	Fifth_world_5 = 114,

	Fifth_world_6 = 124,

	Fifth_world_7 = 134,

	Fifth_world_8 = 144,

	Fifth_world_9 = 154,

	Fifth_world_10 = 164



}

public partial class SceneManager : Node
{

	// creates an instance of the SceneManager so its functions 
	//can be accessed in the other scripts
	public static SceneManager instance;
	// creates a dictionary that holds both the enums of each scene as a key, and their 
	//corresponding paths so they can be accessed
	//I probably should have used a loop to assign the keys and values to the dictionary...
	public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>(){
		{eSceneNames.GameOver, new SceneData("res://Scenes/Game_Over.tscn") },
		{eSceneNames.MainMenu, new SceneData("res://Scenes/MainMenu.tscn") },
		{eSceneNames.CharacterSelect, new SceneData("res://Scenes/CharacterSelect.tscn") },
		{eSceneNames.HowToPlay, new SceneData("res://Scenes/how_to_play.tscn")},
		{eSceneNames.leaderboards, new SceneData("res://Scenes/leaderboards.tscn") },
		{eSceneNames.Profile, new SceneData("res://Scenes/Profile.tscn") },
		{eSceneNames.Login_SignUp, new SceneData("res://Scenes/Login_SignUp.tscn") },
		{eSceneNames.victory, new SceneData("res://Scenes/victory.tscn") },
		{eSceneNames.First_world_1, new SceneData("res://Scenes/Levels/First_world_1.tscn") },
		{eSceneNames.First_world_2, new SceneData("res://Scenes/Levels/First_world_2.tscn") },
		{eSceneNames.First_world_3, new SceneData("res://Scenes/Levels/First_world_3.tscn") },
		{eSceneNames.First_world_4, new SceneData("res://Scenes/Levels/First_world_4.tscn") },
		{eSceneNames.First_world_5, new SceneData("res://Scenes/Levels/First_world_5.tscn") },
		{eSceneNames.First_world_6, new SceneData("res://Scenes/Levels/First_world_6.tscn") },
		{eSceneNames.First_world_7, new SceneData("res://Scenes/Levels/First_world_7.tscn") },
		{eSceneNames.First_world_8, new SceneData("res://Scenes/Levels/First_world_8.tscn") },
		{eSceneNames.First_world_9, new SceneData("res://Scenes/Levels/First_world_9.tscn") },
		{eSceneNames.First_world_10, new SceneData("res://Scenes/Levels/First_world_10.tscn") },
		{eSceneNames.Second_world_1, new SceneData("res://Scenes/Levels/Second_world_1.tscn") },
		{eSceneNames.Second_world_2, new SceneData("res://Scenes/Levels/Second_world_2.tscn") },
		{eSceneNames.Second_world_3, new SceneData("res://Scenes/Levels/Second_world_3.tscn") },
		{eSceneNames.Second_world_4, new SceneData("res://Scenes/Levels/Second_world_4.tscn") },
		{eSceneNames.Second_world_5, new SceneData("res://Scenes/Levels/Second_world_5.tscn") },
		{eSceneNames.Second_world_6, new SceneData("res://Scenes/Levels/Second_world_6.tscn") },
		{eSceneNames.Second_world_7, new SceneData("res://Scenes/Levels/Second_world_7.tscn") },
		{eSceneNames.Second_world_8, new SceneData("res://Scenes/Levels/Second_world_8.tscn") },
		{eSceneNames.Second_world_9, new SceneData("res://Scenes/Levels/Second_world_9.tscn") },
		{eSceneNames.Second_world_10, new SceneData("res://Scenes/Levels/Second_world_10.tscn") },
		{eSceneNames.Third_world_1, new SceneData("res://Scenes/Levels/Third_world_1.tscn") },
		{eSceneNames.Third_world_2, new SceneData("res://Scenes/Levels/Third_world_2.tscn") },
		{eSceneNames.Third_world_3, new SceneData("res://Scenes/Levels/Third_world_3.tscn") },
		{eSceneNames.Third_world_4, new SceneData("res://Scenes/Levels/Third_world_4.tscn") },
		{eSceneNames.Third_world_5, new SceneData("res://Scenes/Levels/Third_world_5.tscn") },
		{eSceneNames.Third_world_6, new SceneData("res://Scenes/Levels/Third_world_6.tscn") },
		{eSceneNames.Third_world_7, new SceneData("res://Scenes/Levels/Third_world_7.tscn") },
		{eSceneNames.Third_world_8, new SceneData("res://Scenes/Levels/Third_world_8.tscn") },
		{eSceneNames.Third_world_9, new SceneData("res://Scenes/Levels/Third_world_9.tscn") },
		{eSceneNames.Third_world_10, new SceneData("res://Scenes/Levels/Third_world_10.tscn") },
		{eSceneNames.Fourth_world_1, new SceneData("res://Scenes/Levels/Fourth_world_1.tscn") },
		{eSceneNames.Fourth_world_2, new SceneData("res://Scenes/Levels/Fourth_world_2.tscn") },
		{eSceneNames.Fourth_world_3, new SceneData("res://Scenes/Levels/Fourth_world_3.tscn") },
		{eSceneNames.Fourth_world_4, new SceneData("res://Scenes/Levels/Fourth_world_4.tscn") },
		{eSceneNames.Fourth_world_5, new SceneData("res://Scenes/Levels/Fourth_world_5.tscn") },
		{eSceneNames.Fourth_world_6, new SceneData("res://Scenes/Levels/Fourth_world_6.tscn") },
		{eSceneNames.Fourth_world_7, new SceneData("res://Scenes/Levels/Fourth_world_7.tscn") },
		{eSceneNames.Fourth_world_8, new SceneData("res://Scenes/Levels/Fourth_world_8.tscn") },
		{eSceneNames.Fourth_world_9, new SceneData("res://Scenes/Levels/Fourth_world_9.tscn") },
		{eSceneNames.Fourth_world_10, new SceneData("res://Scenes/Levels/Fourth_world_10.tscn") },
		{eSceneNames.Fifth_world_1, new SceneData("res://Scenes/Levels/Fifth_world_1.tscn") },
		{eSceneNames.Fifth_world_2, new SceneData("res://Scenes/Levels/Fifth_world_2.tscn") },
		{eSceneNames.Fifth_world_3, new SceneData("res://Scenes/Levels/Fifth_world_3.tscn") },
		{eSceneNames.Fifth_world_4, new SceneData("res://Scenes/Levels/Fifth_world_4.tscn") },
		{eSceneNames.Fifth_world_5, new SceneData("res://Scenes/Levels/Fifth_world_5.tscn") },
		{eSceneNames.Fifth_world_6, new SceneData("res://Scenes/Levels/Fifth_world_6.tscn") },
		{eSceneNames.Fifth_world_7, new SceneData("res://Scenes/Levels/Fifth_world_7.tscn") },
		{eSceneNames.Fifth_world_8, new SceneData("res://Scenes/Levels/Fifth_world_8.tscn") },
		{eSceneNames.Fifth_world_9, new SceneData("res://Scenes/Levels/Fifth_world_9.tscn") },
		{eSceneNames.Fifth_world_10, new SceneData("res://Scenes/Levels/Fifth_world_10.tscn") },
	};

	public override void _Ready()
	{
		instance = this;
	}
	// function to actually change the scene
	public void ChangeScene(eSceneNames mySceneName)
	{
		//selects the path which correlates with the requested scene- which is the key in the dictionary
		string myPath = sceneDictionary[mySceneName].path;
		//changes the scene to the scene specified by the path
		GetTree().ChangeSceneToFile(myPath);
	}




}
