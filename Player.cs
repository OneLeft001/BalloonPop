using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float _speed = 200.0f;
	private const float _acceleration = 20.5f;

	public override void _PhysicsProcess(double delta)
	{
		
		
		Vector2 velocity = Velocity;
		
		float yInput = Input.GetActionStrength("Down") - Input.GetActionStrength("Up");
		
		float velocityWeight = (float)delta * _acceleration;
		
		velocity.Y = float.Lerp(velocity.Y, yInput * _speed, velocityWeight);
		
		velocity += GetGravity() * (float)delta;
		
		Velocity = velocity;
		MoveAndSlide();
		
		
	}


	public void OnArea2dAreaEntered(Area2D area)
	{


		if (area.IsInGroup("Wind"))
		{

			var wind = area as Wind;
			GD.Print("Wind floating balloon!!");
			
			// Float balloon left or right depending on wind direction.
			
			Vector2 velocity = Velocity;
			
			velocity.X = wind.GetSpeed();
			Velocity = velocity;
			
			
		}
		
		//GD.Print("OnArea2dAreaEntered");
		
	}
	
}
