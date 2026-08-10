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
}
