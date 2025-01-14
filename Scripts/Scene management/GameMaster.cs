using Godot;
using System;
using System.Collections.Generic;

public partial class GameMaster : Node
{
	//holds stats for each label, first array is for size, second array is for speed
	public static double[,] Stats_1_1 = { { 1, 1, 1 }, { 1, 1, 1 } };
	public static double[,] Stats_1_2 = { { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
	public static double[,] Stats_1_3 = { { 1.5, 1, 1.5, 1.5, 1 }, { 1, 1.5, 1, 1, 1.5 } };
	public static double[,] Stats_1_4 = { { 1, 1.25, 1, 1, 1.25 }, { 1.75, 1.25, 1, 1.75, 1.25 } };
	public static double[,] Stats_1_5 = { { 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2, 2 } };
	public static double[,] Stats_1_6 = { { 1, 1, 1, 1 }, { 4, 4, 4, 0.5 } };
	public static double[,] Stats_1_7 = { { 2, 2, 2 }, { 2, 2, 2 } };
	public static double[,] Stats_1_8 = { { 2.5, 2.5, 1, 1, 1, 1, 1 }, { 3, 3, 2, 2, 2, 2, 2 } };
	public static double[,] Stats_1_9 = { { 2.5, 2.5, 2.5, 2.5, 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 1, 1, 1, 1, 1, 1 } };
	public static double[,] Stats_1_10 = { { 3.5, 3.5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5 } };

	public static Dictionary<eSceneNames, double[,]> StatDictionary = new Dictionary<eSceneNames, double[,]>()
	{
		//assigns each 2D array to each world enum for easy referencing
		{eSceneNames.First_world_1,Stats_1_1},
		{eSceneNames.First_world_2,Stats_1_2},
		{eSceneNames.First_world_3,Stats_1_3},
		{eSceneNames.First_world_4,Stats_1_4},
		{eSceneNames.First_world_5,Stats_1_5},
		{eSceneNames.First_world_6,Stats_1_6},
		{eSceneNames.First_world_7,Stats_1_7},
		{eSceneNames.First_world_8,Stats_1_8},
		{eSceneNames.First_world_9,Stats_1_9},
		{eSceneNames.First_world_10,Stats_1_10},
		{eSceneNames.Second_world_1,Stats_1_1},
		{eSceneNames.Second_world_2,Stats_1_2},
		{eSceneNames.Second_world_3,Stats_1_3},
		{eSceneNames.Second_world_4,Stats_1_4},
		{eSceneNames.Second_world_5,Stats_1_5},
		{eSceneNames.Second_world_6,Stats_1_6},
		{eSceneNames.Second_world_7,Stats_1_7},
		{eSceneNames.Second_world_8,Stats_1_8},
		{eSceneNames.Second_world_9,Stats_1_9},
		{eSceneNames.Second_world_10,Stats_1_10},
		{eSceneNames.Third_world_1,Stats_1_1},
		{eSceneNames.Third_world_2,Stats_1_2},
		{eSceneNames.Third_world_3,Stats_1_3},
		{eSceneNames.Third_world_4,Stats_1_4},
		{eSceneNames.Third_world_5,Stats_1_5},
		{eSceneNames.Third_world_6,Stats_1_6},
		{eSceneNames.Third_world_7,Stats_1_7},
		{eSceneNames.Third_world_8,Stats_1_8},
		{eSceneNames.Third_world_9,Stats_1_9},
		{eSceneNames.Third_world_10,Stats_1_10},
		{eSceneNames.Fourth_world_1,Stats_1_1},
		{eSceneNames.Fourth_world_2,Stats_1_2},
		{eSceneNames.Fourth_world_3,Stats_1_3},
		{eSceneNames.Fourth_world_4,Stats_1_4},
		{eSceneNames.Fourth_world_5,Stats_1_5},
		{eSceneNames.Fourth_world_6,Stats_1_6},
		{eSceneNames.Fourth_world_7,Stats_1_7},
		{eSceneNames.Fourth_world_8,Stats_1_8},
		{eSceneNames.Fourth_world_9,Stats_1_9},
		{eSceneNames.Fourth_world_10,Stats_1_10},
		{eSceneNames.Fifth_world_1,Stats_1_1},
		{eSceneNames.Fifth_world_2,Stats_1_2},
		{eSceneNames.Fifth_world_3,Stats_1_3},
		{eSceneNames.Fifth_world_4,Stats_1_4},
		{eSceneNames.Fifth_world_5,Stats_1_5},
		{eSceneNames.Fifth_world_6,Stats_1_6},
		{eSceneNames.Fifth_world_7,Stats_1_7},
		{eSceneNames.Fifth_world_8,Stats_1_8},
		{eSceneNames.Fifth_world_9,Stats_1_9},
		{eSceneNames.Fifth_world_10,Stats_1_10}





	};
	public override void _Ready()
	{
	}


	public override void _Process(double delta)
	{
	}
}
