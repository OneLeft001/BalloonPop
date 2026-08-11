using Godot;
using System;
using System.Collections.Generic;

public partial class WindDirection : RigidBody2D
{

	[Export] public bool Direction;
	
	private Area2D _area2D;
	private List<Sprite2D> _wind;
	private bool _checkWind = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		_wind = new List<Sprite2D>();
		PopulateWindSpriteList();
		ChangeWindSpriteDirection();

		
		
		
		_area2D = GetNode<Area2D>("Area2D");
		
		GD.Print(_area2D);
		
		Wind wind = _area2D as Wind;
		
		GD.Print(wind);
		
		GD.Print(wind.GetSpeed());
		wind.Direction = this.Direction;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}



	private void PopulateWindSpriteList()
	{
		
		var children = GetChildren();

		for (int i = 0; i < children.Count; i++)
		{

			if (children[i] is Sprite2D)
			{
					
				_wind.Add((Sprite2D)children[i]);
					
			}
				
		}
		
	}

	private void ChangeWindSpriteDirection()
	{
		
		if (Direction)
		{

			foreach (Sprite2D sprite in _wind)
			{
				
				sprite.FlipH = true;
				
			}
			
		}
		
	}
	
	
}
