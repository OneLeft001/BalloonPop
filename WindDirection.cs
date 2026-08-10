using Godot;
using System;

public partial class WindDirection : RigidBody2D
{

	[Export] public bool Direction;
	
	private Area2D area2D;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		area2D = GetNode<Area2D>("Area2D");
		
		GD.Print(area2D);
		
		Wind wind = area2D as Wind;
		
		GD.Print(wind);
		
		GD.Print(wind.GetSpeed());
		wind.Direction = this.Direction;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
