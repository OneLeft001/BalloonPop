using Godot;
using System;

public partial class Wind : Area2D
{
	
	// positive X is right
	// negative X is left
	
	private float _speed;
	
	public bool Direction {get; set;}
	
	
	public override void _Ready()
	{

		

	}

	
	public override void _Process(double delta)
	{
		
		if (Direction )
		{
			_speed = 100;
		}
		else if (Direction == false)
		{

			_speed = -100;

		}
		
	}


	public float GetSpeed()
	{
		
		return _speed;
		
	}
	
}
