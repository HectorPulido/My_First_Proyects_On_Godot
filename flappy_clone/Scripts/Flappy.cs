using Godot;
using System;

public partial class Flappy : CharacterBody2D
{
	[Export]
	private float jumpVelocity = 5;

	[Export]
	private float gravity = 10;

	[Export]
	private float floorY = 413;

	private bool jumping = false;
	private float velocityY = 0;


	public override void _Ready()
	{
		StartGame();
	}

	private void StartGame()
	{
		velocityY = 0;
		var targetPosition = GetNode<Marker2D>("./StartingPoint").Position;
		Position = targetPosition;
		gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");
	}

	private void HandleRotation()
	{
		var speed = Velocity.Y;
		if (speed > 0)
			Rotation = 45;
		else if (speed < 0)
			Rotation = -45;
		else
			Rotation = 0;
	}

	private float HandleGravity(float delta)
	{
		velocityY += gravity * delta;

		if (jumping)
		{
			jumping = false;
			velocityY = -jumpVelocity;
		}

		return velocityY;
	}

	public override void _Process(double delta)
	{
		HandleRotation();

		if (Position.Y > floorY)
		{
			HandleGameOver();
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton && @event.IsPressed())
		{
			jumping = true;
		}
	}

	private void HandleGameOver()
	{
		StartGame();
		GetTree().CallGroup("Pipes", Pipes.MethodName.Reset);
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocityY = HandleGravity((float)delta);
		Velocity = new Vector2(0, velocityY);
		var collision = MoveAndCollide(Velocity);

		if (collision != null)
		{
			HandleGameOver();
		}
	}

}