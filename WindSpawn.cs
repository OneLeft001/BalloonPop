using Godot;
using System;
using System.Collections.Generic;


public partial class WindSpawn : Node2D
{

	private PackedScene _windBody;
	private List<RigidBody2D> _windList;
	private int _initialWindCount = 6;
	private bool _initialWind = false;
	private bool _setWindDirection = false;
	
	public override void _Ready()
	{
		
		//this.Position = new Vector2(0, 0);
		//this.GlobalPosition = new Vector2(0, 0);
		
		InitialSpawn();
		_initialWind = true;
		

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}



	private void InitialSpawn()
	{

		_windBody = GD.Load<PackedScene>("res://Scenes//wind.tscn");
		_windList = new List<RigidBody2D>();

		for (int i = 0; i < _initialWindCount; i++)
		{
			
			InstantiateWind();
			
		}


		RigidBody2D lastWind = null;

		var windArea = _windList[0].FindChild("Area2D");
		var windCollisionShape2D = windArea.FindChild("CollisionShape2D") as CollisionShape2D;
		int gap = (int)windCollisionShape2D.Shape.GetRect().Size.Y;
		
		int lastY = 0;
		for (int i = 0; i < _windList.Count; i++)
		{

			if (i != 0)
			{

				RigidBody2D wind = _windList[i];

				wind.GlobalPosition = new Vector2(0, gap + lastY);
				lastY = (int)wind.GlobalPosition.Y;
			}
			else
			{
				
				lastY = (int)_windList[0].GlobalPosition.Y;
				
			}
			
		}

		
		
	}

	private void InstantiateWind()
	{
		
		var wind = _windBody.Instantiate() as RigidBody2D;
		var windScript = wind as WindDirection;
		windScript.Direction = _setWindDirection;
		_windList.Add(wind);
		AddChild(wind);

		if (_setWindDirection)
		{
			_setWindDirection = false;
		}
		else
		{
			_setWindDirection = true;
		}
		
	}

	public void OnArea2DAreaExited(Area2D area)
	{

		if (_initialWind)
		{

			GD.Print(area);
			InstantiateWind();

		}

	}
	
	
}
