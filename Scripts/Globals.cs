using Godot;
using System;
using Godot.Collections;
using System.Collections.Generic;
// this entire class is just used to hold "global" variables (you cant have true global variables in C#)
// so i use a static class to replicate it as a static class can only hold attributes and cannot instantiate objects

//Also, i am aware global variables are incredibly inefficient however past me wasnt the smartest,
//and by the time i realised the glaring issues in maintaining a game with global variables, it was too late.
public static class Globe
{
	public static string picked_character;
	public static int Level = 70;
	public static int True_Level = 1;

	public static float enemy_speed = 3;

	public static string[] world_Name_list = { "Simple Slopes", "Volcanic Valley", "Midnight Massacre", "Derelict Desert", "Hypnotic Hills" };
	public static string current_world_name = "Simple Slopes";
	public static bool ispaused;
	public static string movement = "WASD";
	public static bool Mouse_move = false;
	public static int SizeSelect = 0;

	public static int VP = 0;

	public static float time;

	public static FileAccess save_game;

	public static Dictionary data;
	public static string Username;
	public static string Password;
	public static List<Dictionary> Accounts;

	public static double energy = 100;

	public static bool ability1active = false;

	public static bool ability2active = false;

	public static int energy_rate = 1;
}



