using Godot;
using System;
using System.Collections.Generic;


public partial class WindSpawn : Node2D
{

	//[Export] public RigidBody2D WindBody;
	
	private PackedScene _windBody;
	private List<Node> _windList;
	private int _initialWindCount = 6;
	
	public override void _Ready()
	{
		
		InitialSpawn();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		InitialSpawn();
	}




	private void InitialSpawn()
	{

		_windBody = GD.Load<PackedScene>("res://Scenes/wind.tscn");
		_windList = new List<Node>();

		for (int i = 0; i < _initialWindCount; i++)
		{

			var wind = _windBody.Instantiate();
			_windList.Add(wind);
			
		}
		
		
	}
	
}
