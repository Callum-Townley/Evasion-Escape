using Godot;
using System;
// instantiates the path to a scene as an object to make it accessible
public class SceneData
{
	public SceneData(string path)
	{
		this.path = path;
	}
	public string path;
}