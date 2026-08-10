using Godot;
using System;

public partial class Wind : Area2D
{
	
	// positive X is right
	// negative X is left
	
	private float _speed;
	
	
	public override void _Ready()
	{
		

		switch (GD.RandRange(0, 1))
		{
			
			case 0:
				_speed = 100;
				break;
			case 1:
				_speed = -100;
				break;
			default:
				_speed = 0;
				break;
			
		}

	}

	
	public override void _Process(double delta)
	{
	}


	public float GetSpeed()
	{
		
		return _speed;
		
	}
	
}
