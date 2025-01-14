using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

// instantiates the character class
public class character
{

	//allows the character to be alive/dead , which is useful for the game over screen
	public bool isAlive = true;
	//stores the character type
	public string character_type = "";
	//sets the base speed of the character
	public int speed = 1600;

	public int VX;
	public int VY;

	public Texture2D texture;

	public Godot.Vector2 Bullet_direction;

	public Godot.Vector2 GlobalPosition;

	public void set_character_type(string Chara)
	{
		character_type = Chara;
	}
	// character_load will load the player (derived from the character class) into the scene, so its attributes can be accessed
	public static dynamic Character_load(string picked_character)
	{
		// these else if statements ensure the correct character type is loaded in
		if (picked_character == "Spore")
		{
			Spore Player = Spore.Instance();
			return Spore.Instance();


		}
		else if (picked_character == "Ignis")
		{
			Ignis Player = Ignis.Instance();
			return Ignis.Instance();



		}
		else if (picked_character == "Atlantia")
		{
			Atlantia Player = Atlantia.Instance();
			return Atlantia.Instance();



		}
		else if (picked_character == "Astraeus")
		{
			Astraeus Player = Astraeus.Instance();
			return Astraeus.Instance();



		}
		else if (picked_character == "Radion")
		{
			Radion Player = Radion.Instance();
			return Radion.Instance();



		}
		else if (picked_character == "Mantle")
		{
			Mantle Player = Mantle.Instance();
			return Mantle.Instance();



		}
		else if (picked_character == "Vanta")
		{
			Vanta Player = Vanta.Instance();
			return Vanta.Instance();



		}
		else if (picked_character == "Ruin")
		{
			Ruin Player = Ruin.Instance();
			return Ruin.Instance();



		}
		else if (picked_character == "Hypno")
		{
			Hypno Player = Hypno.Instance();
			return Hypno.Instance();



		}
		return null;


	}

}
// makes the spore class (a character type) inherit from the character class to carry over some attributes
public class Spore : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		//only triggers at 30% energy
		if (Globe.energy > 30)
		{
			//creates an instance of the projectile
			var instance = projectile.Instantiate<Spore_Projectile>();
			//assigns the scale, direction and spawn position of the projectile
			instance.Scale = instance.Scale / 2;
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			//adds the projectile as a child of the main node, so it can hit enemies
			main.AddChild(instance);
			//ensures the projectile will kill enemies
			instance.Name = "kill";
			//decrements the energy by the energy cost
			Globe.energy -= 30;
		}
	}




	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		//de-activates the ability
		if (abilityenable == false)
		{
			Globe.ability2active = false;

		}
		else
		{
			//activates the ability and sets the energy rate to 1, so that the character's energy
			//decreases over time
			Globe.ability2active = true;
			Globe.energy_rate = 1;
			//instantiates the projectile
			var instance = projectile.Instantiate<Spore2_Projectile>();
			//SetDefferred() makes an area2D active, so that it reacts to entered objects
			//in this case, it will slow down any enemies that enter the area
			instance.SetDeferred("disabled", false);
			//sets the colour to green (based on RGB) and slightly transparent
			instance.Modulate = new Color(0, (float)1, (float)0, (float)0.5);
			//sets the attributes of the projectile
			instance.Scale = instance.Scale * (float)1.25;
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			//adds the projectile as a child to the main scene
			main.AddChild(instance);
			instance.Name = "slow";
		}
	}

	//uses the singleton pattern- this way only one instance can be created, otherwise the constructor just returns the existing instance
	private Spore() { }

	private static Spore Player;

	public static Spore Instance()
	{
		//checks if the player object exists, if not,creates one
		if (Player == null)
		{

			Player = new Spore();

		}
		return Player;
	}






}

public class Ignis : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		//the ability is only used if energy is above 70%
		if (Globe.energy > 70)
		{
			//creates an instance of the projectile
			var instance = projectile.Instantiate<Ignis_Projectile>();
			//makes the projectile red
			instance.Modulate = new Color(1, 0, 0, 1);
			//assigns attributes to the projectile
			instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			//adds the projectile as a child to the main scene
			main.AddChild(instance);
			//ensures the projectile will kill enemies
			instance.Name = "kill";
			//the energy is decremented by the energy cost
			Globe.energy -= 70;
		}

	}

	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		var rng = new RandomNumberGenerator();
		float angle = (float)1.2;
		//if the ability needs to be de-activated, it is de-activated
		if (abilityenable == false)
		{
			Globe.ability2active = false;

		}
		else
		{
			//activates the ability and makes energy drain over time
			Globe.ability2active = true;
			Globe.energy_rate = 5;
			//instantiates a projectile object
			var instance = projectile.Instantiate<Ignis2_Projectile>();
			//sets the projectiles attributes
			instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
			instance.Modulate = new Color((float)1, 0, 0, 1);
			instance.direction = Player.Bullet_direction / angle;
			//here, the direction is being changed by a random amount, so the projectiles have
			//random spread
			instance.direction.X = instance.direction.X + rng.RandfRange((float)-0.5, (float)0.5);
			instance.direction.Y = instance.direction.Y + rng.RandfRange((float)-0.5, (float)0.5);
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			angle = angle - (float)0.1;
			//ensures the projectile will kill enemies
			instance.Name = "kill";
		}









	}


	private Ignis() { }

	private static Ignis Player;

	public static Ignis Instance()
	{
		if (Player == null)
		{

			Player = new Ignis();

		}
		return Player;
	}






}

public class Atlantia : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		float angle = (float)1.2;
		if (Globe.energy > 30)
		{
			//fires 3 projectiles in a row
			for (int i = 0; i <= 2; i++)
			{
				//instantiates a projectile and sets its attributes
				var instance = projectile.Instantiate<Atlantia_Projectile>();
				instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
				//divides the direction vector by the angle, making the projectiles get progressively faster
				//after each is fired
				instance.direction = Player.Bullet_direction / angle;
				instance.spawnpos = Player.GlobalPosition;
				main.AddChild(instance);
				angle = angle - (float)0.1;
				instance.Name = "kill";



			}
			Globe.energy -= 30;
		}




	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		if (Globe.energy > 70)
		{
			//instantiates a projectile and sets its attributes
			var instance = projectile.Instantiate<Atlantia_Projectile>();
			instance.Scale = new Godot.Vector2((float)1.5, (float)1.5);
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			instance.Name = "live";
			Globe.energy -= 70;


		}

	}
	private Atlantia() { }

	private static Atlantia Player;

	public static Atlantia Instance()
	{
		if (Player == null)
		{

			Player = new Atlantia();

		}
		return Player;
	}






}

public class Astraeus : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		if (Globe.energy >= 100)
		{
			//instantiates a projectile, makes it purple and sets its attributes
			var instance = projectile.Instantiate<Astraeus_Projectile>();
			instance.Modulate = new Color(1, 0, 1, 1);
			instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			//ensures the projectile kills enemies
			instance.Name = "kill";
			Globe.energy -= 100;
		}

	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		var rng = new RandomNumberGenerator();
		float angle = (float)1.2;
		if (Globe.energy >= 100)
		{
			//causes 11 projectiles to be fired in a burst
			for (int i = 0; i <= 10; i++)
			{
				//instantiates a projectile and assigns its attributes
				var instance = projectile.Instantiate<Astraeus2_Projectile>();
				instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
				//makes the projectile purple
				instance.Modulate = new Color((float)1, 0, 1, 1);
				instance.direction = Player.Bullet_direction / angle;
				//gives the projectiles a random spread
				instance.direction.X = instance.direction.X + rng.RandfRange((float)-0.5, (float)0.5);
				instance.direction.Y = instance.direction.Y + rng.RandfRange((float)-0.5, (float)0.5);

				instance.spawnpos = Player.GlobalPosition;
				main.AddChild(instance);
				angle = angle - (float)0.1;
				//makes the projectiles kill enemies
				instance.Name = "kill";



			}
			Globe.energy -= 100;
		}




	}
	private Astraeus() { }

	private static Astraeus Player;

	public static Astraeus Instance()
	{
		if (Player == null)
		{

			Player = new Astraeus();

		}
		return Player;
	}






}

public class Radion : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Variant main, Variant projectile)
	{
		//gets a reference to the radiation aura and its collision body
		Area2D aura = Playerbody.GetNode<Area2D>("Radiation");
		Godot.CollisionShape2D shape = Playerbody.GetNode<Godot.CollisionShape2D>("Radiation/CollisionShape2D");
		//if the ability is disabled, the aura becomes invisible, its aura effect is disabled and the ability is made inactive
		if (abilityenable == false)
		{
			aura.Visible = false;
			shape.SetDeferred("disabled", true);
			Globe.ability1active = false;

		}
		//if the ability is enabled, the aura becomes visible and its aura effect is enabled, and the ability is set to active
		else
		{
			Globe.ability1active = true;
			aura.Visible = true;
			shape.SetDeferred("disabled", false);
		}

	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		if (Globe.energy >= 100)
		{
			//instantiates an instance of the projectile and alters its attributes
			var instance = projectile.Instantiate<Radion2_Projectile>();
			//the colour is set to green
			instance.Modulate = new Color(0, 1, 0, 1);
			instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			//ensures the projectile kills
			instance.Name = "kill";
			Globe.energy -= 100;
		}

	}
	private Radion() { }

	private static Radion Player;

	public static Radion Instance()
	{
		if (Player == null)
		{

			Player = new Radion();

		}
		return Player;
	}






}
public class Mantle : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		RandomNumberGenerator rng = new RandomNumberGenerator();

		if (Globe.energy > 30)
		{
			//makes sure 11 projectiles are fired
			for (int i = 0; i <= 10; i++)
			{
				//creates random float values for the x and y indexes
				float xindex = rng.RandfRange((float)-10.0, (float)10.0);
				float yindex = rng.RandfRange((float)-10.0, (float)10.0);
				//instantiates the projectile and sets its attributes
				var instance = projectile.Instantiate<Mantle_Projectile>();
				//the projectile is made red
				instance.Modulate = new Color(1, 0, 0, 1);
				instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
				//the firing direction is completely randomised
				instance.direction = new Vector2(xindex, yindex);
				instance.spawnpos = Player.GlobalPosition;
				main.AddChild(instance);
				//the projectiles are made to kill enemies
				instance.Name = "kill";



			}
			Globe.energy -= 30;
		}




	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		//if the ability is to be disabled, it is set to inactive
		if (abilityenable == false)
		{
			Globe.ability2active = false;

		}
		else
		{
			//the ability is set to active and its energy rate is set to 1 so that energy is drained
			//over time
			Globe.ability2active = true;
			Globe.energy_rate = 1;
			//instantiates a projectile and sets its attributes
			var instance = projectile.Instantiate<Mantle2_Projectile>();
			//activates the projectiles aura effect
			instance.SetDeferred("disabled", false);
			//sets the projectile to red and transparent
			instance.Modulate = new Color(1, (float)0, (float)0, (float)0.5);
			instance.Scale = instance.Scale * (float)1.25;
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			//ensures the projectile/aura can kill enemies
			instance.Name = "kill";
		}
	}
	private Mantle() { }

	private static Mantle Player;

	public static Mantle Instance()
	{
		if (Player == null)
		{

			Player = new Mantle();

		}
		return Player;
	}






}

public class Vanta : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Variant main, Variant projectile)
	{
		//makes the ability drain energy over time
		Globe.energy_rate = 5;
		//if the ability is disabled, the players colour becomes opaque, and the player can
		//collide with enemies again
		if (abilityenable == false)
		{
			Playersprite.Modulate = new Color(1, 1, 1, (float)1);
			Playerbody.SetCollisionMaskValue(3, true);
			Globe.ability1active = false;
		}
		//if the ability is enabled, the player becomes translucent and its collision layer is
		//changed, so it cannot get hit by enemies
		else
		{
			Globe.ability1active = true;
			Playersprite.Modulate = new Color(1, 1, 1, (float)0.5);
			Playerbody.SetCollisionMaskValue(3, false);
		}
	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Variant main, Variant projectile)
	{
		//gets references to the blackhole aura and collision body
		StaticBody2D aura = Playerbody.GetNode<StaticBody2D>("Blackhole_kill");
		Godot.CollisionShape2D shape = Playerbody.GetNode<Godot.CollisionShape2D>("Blackhole_kill/CollisionShape2D");
		//ensures the ability uses energy over time
		Globe.energy_rate = 5;
		//if the ability is disabled, the aura becomes invisible and cannot effect enemies
		if (abilityenable == false)
		{
			aura.Visible = false;
			shape.SetDeferred("disabled", true);
			Globe.ability2active = false;

		}
		//if the ability is enabled, the aura becomes visible and can effect enemies
		else
		{
			Globe.ability2active = true;
			aura.Visible = true;
			shape.SetDeferred("disabled", false);
		}



	}
	private Vanta() { }

	private static Vanta Player;

	public static Vanta Instance()
	{
		if (Player == null)
		{

			Player = new Vanta();

		}
		return Player;
	}






}

public class Ruin : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		if (Globe.energy > 70)
		{
			//instantiates a projectile object and sets its attributes
			var instance = projectile.Instantiate<Ruin_Projectile>();
			//changes the colour of the projectile to red
			instance.Modulate = new Color(1, 0, 0, 1);
			instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			instance.Name = "kill";
			Globe.energy -= 70;
		}

	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{
		RandomNumberGenerator rng = new RandomNumberGenerator();

		if (Globe.energy > 30)
		{
			//ensures projectiles are shot in bursts of 11
			for (int i = 0; i <= 10; i++)
			{
				//creates random x and y indexes
				float xindex = rng.RandfRange((float)-1.0, (float)1.0);
				float yindex = rng.RandfRange((float)-1.0, (float)1.0);
				//instantiates a projectile and sets its attributes
				var instance = projectile.Instantiate<Ruin2_Projectile>();
				instance.Modulate = new Color((float)1, (float)0, 0, 1);
				instance.Scale = new Godot.Vector2((float)0.5, (float)0.5);
				//the x and y indexes are random, so the projectile is fired in a random direction
				instance.direction = new Vector2(xindex, yindex);
				instance.spawnpos = Player.GlobalPosition;
				main.AddChild(instance);
				//ensures the projectile kills
				instance.Name = "kill";



			}
			Globe.energy -= 30;
		}




	}
	private Ruin() { }

	private static Ruin Player;

	public static Ruin Instance()
	{
		if (Player == null)
		{

			Player = new Ruin();

		}
		return Player;
	}






}

public class Hypno : character
{


	public void ability1(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Variant main, Variant projectile)
	{
		//gets references to the hypnosis aura and its collision body
		Area2D aura = Playerbody.GetNode<Area2D>("Hypnosis");
		Godot.CollisionShape2D shape = Playerbody.GetNode<Godot.CollisionShape2D>("Hypnosis/CollisionShape2D");
		//If the ability is to be disabled, the aura is made invisible and its collision box is disabled
		if (abilityenable == false)
		{
			aura.Visible = false;
			shape.SetDeferred("disabled", true);
			Globe.ability1active = false;

		}
		//if the ability is to be enabled, it is made visible, its hitbox becomes active, and it is made green
		else
		{
			Globe.ability1active = true;
			aura.Visible = true;
			shape.SetDeferred("disabled", false);
			aura.Modulate = new Color(1, (float)0, (float)0, 1);
		}

	}
	public void ability2(Sprite2D Playersprite, CharacterBody2D Playerbody, bool abilityenable, Node2D main, PackedScene projectile)
	{

		if (Globe.energy > 30)
		{
			//instantiates the projectile and assigns its attributes
			var instance = projectile.Instantiate<Hypno2_Projectile>();
			//the projectile is made red
			instance.Modulate = new Color((float)1, (float)0, (float)1);
			instance.Scale = new Godot.Vector2((float)1, (float)1);
			instance.direction = Player.Bullet_direction;
			instance.spawnpos = Player.GlobalPosition;
			main.AddChild(instance);
			//ensures the projectile will kill enemies
			instance.Name = "kill";



			Globe.energy -= 30;
		}




	}
	private Hypno() { }

	private static Hypno Player;

	public static Hypno Instance()
	{
		if (Player == null)
		{

			Player = new Hypno();

		}
		return Player;
	}






}
public partial class characters : Node
{

	public override void _Ready()
	{

	}


	public override void _Process(double delta)
	{
	}
}
