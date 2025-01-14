using Godot;
using System;

public partial class CharacterSelect : Node2D
{
	Godot.RichTextLabel ability_description;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//gets a reference to the label in which ability descriptions are to be displayed
		ability_description = GetNode<Godot.RichTextLabel>("CanvasLayer/PanelContainer2/Ability Description");



	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	//each of these button press functions map to each character button
	//here i instantiate an instance of the character's object, ensure that the game
	//knows that the respective character has been picked (using globals and attributes) 
	//and i change the scene to the first level
	public void _on_char_button_1_pressed()
	{
		Spore Player = Spore.Instance();
		Player.set_character_type("Spore");
		Globe.picked_character = "Spore";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	//the mouse entered functoions display the ability descriptions depending which button the mouse
	//is hovering over
	public void _on_char_button_1_mouse_entered()
	{
		ability_description.Text = ("Ability1- Spore Bomb: drops a bomb that explodes after 1.5 seconds,killing enemies. Costs 30 energy\n\n\nAbility2- Spore trail:Leaves a trail that slows enemies by 50%. stacks on itself. costs 5 energy per second used");


	}


	public void _on_char_button_2_pressed()
	{
		Ignis Player = Ignis.Instance();
		Player.set_character_type("Ignis");
		Globe.picked_character = "Ignis";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_2_mouse_entered()
	{
		ability_description.Text = ("Ability1- Fire Ball: Fires projectile that explodes after 1.5 seconds or on a collision with an enemy/wall. Costs 70 energy\n\n\nAbility2- flamethrower: Spews short ranges flames that kill enemies in front. Costs 5 energy per second used");


	}


	public void _on_char_button_3_pressed()
	{
		Atlantia Player = Atlantia.Instance();
		Player.set_character_type("Atlantia");
		Globe.picked_character = "Atlantia";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_3_mouse_entered()
	{
		ability_description.Text = ("Ability1- Water Bolt: Fires a chain of 3 projectiles that kill enemies. Costs 30 energy\n\n\nAbility2- Tsunami: Fires a large projectile that pushes back enemies. Costs 70 energy");


	}

	public void _on_char_button_4_pressed()
	{
		Astraeus Player = Astraeus.Instance();
		Player.set_character_type("Astraeus");
		Globe.picked_character = "Astraeus";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_4_mouse_entered()
	{
		ability_description.Text = ("Ability1- Supernova: Causes the player to violently explode, killing all enemies around them. Costs 100 energy\n\n\nAbility2- Gamma Ray: Fires a random burst of 10 ultra-fast projectiles, killing enemies. Costs 100 energy");


	}
	public void _on_char_button_5_pressed()
	{
		Radion Player = Radion.Instance();
		Player.set_character_type("Radion");
		Globe.picked_character = "Radion";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_5_mouse_entered()
	{
		ability_description.Text = ("Ability1- Radiation: creates an aura around the player which slows enemies by 50%. Costs 5 energy per second used \n\n\nAbility2- Nuke: fires a projectile that leaves a massive explosion on collision. Costs 100 energy");


	}
	public void _on_char_button_6_pressed()
	{
		Mantle Player = Mantle.Instance();
		Player.set_character_type("Mantle");
		Globe.picked_character = "Mantle";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_6_mouse_entered()
	{
		ability_description.Text = ("Ability1- Eruption: Randomly fires 10 projectiles in all directions around the player. Costs 30 energy\n\n\nAbility2- Lava trail: Leaves a trail that kills enemies. Costs 5 energy per second used");


	}
	public void _on_char_button_7_pressed()
	{
		Vanta Player = Vanta.Instance();
		Player.set_character_type("Vanta");
		Globe.picked_character = "Vanta";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_7_mouse_entered()
	{
		ability_description.Text = ("Ability1- Spirit: makes the player completely immune to enemies. Costs 5 energy per second used\n\n\nAbility2- Void: Creates a small aura around the player which kills enemies. Costs 5 energy per second used");


	}
	public void _on_char_button_8_pressed()
	{
		Ruin Player = Ruin.Instance();
		Player.set_character_type("Ruin");
		Globe.picked_character = "Ruin";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_8_mouse_entered()
	{
		ability_description.Text = ("Ability1- Boulder: Fires a projectile that slowly grows until reaching max size, kills enemies hit. Costs 70 energy\n\n\nAbility2- Stomp: Randomly fires 10 projectiles around the user that linger for 2 seconds.kills enemies. Costs 30 energy per second used");


	}
	public void _on_char_button_9_pressed()
	{
		Hypno Player = Hypno.Instance();
		Player.set_character_type("Hypno");
		Globe.picked_character = "Hypno";
		SceneManager.instance.ChangeScene(eSceneNames.First_world_1);
	}
	public void _on_char_button_9_mouse_entered()
	{
		ability_description.Text = ("Ability1- Hypnotized: Creates an aura around the player that makes enemies go in the opposite direction they were traveling in. Makes homing enemies run from the player. Costs 5 energy per second used \n\n\nAbility2- Control: Fires a projectile which continues to slow down,and then go back towards the player. Costs 30 energy");


	}
	public void _on_texture_button_pressed()
	{
		SceneManager.instance.ChangeScene(eSceneNames.MainMenu);


	}



}
