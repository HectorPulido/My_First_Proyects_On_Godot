using Godot;

public partial class Raqueta : CharacterBody2D
{
	[Export]
	private float Speed { get; set; } = 400;
	[Export]
	private bool IsAI { get; set; } = false;

	public float velocityY = 0;
	private Vector2 screenSize = new();
	private Ball ball;

	public override void _Ready()
	{
		velocityY = 0;
		screenSize = GetViewportRect().Size;

        float initialPositionX;
        if (IsAI)
		{
			ball = GetNode<Ball>("../Ball");
			initialPositionX = 0.9f;
		}
		else
		{
			initialPositionX = 0.1f;
		}
		Position = new Vector2(screenSize.X * initialPositionX, screenSize.Y / 2);
	}

	private void HandleAI()
	{
		var direction = ball.Position.Y - Position.Y;
		direction = Mathf.Clamp(direction, -1, 1);
		velocityY = direction * Speed;
	}

	private void HandlePlayer()
	{
		velocityY = 0;
		if (Input.IsActionPressed("ui_up"))
		{
			velocityY = -Speed;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			velocityY = Speed;
		}
	}

	public override void _Process(double delta)
	{
		if (IsAI)
		{
			HandleAI();
		}
		else
		{
			HandlePlayer();
		}

		var tempPosition = velocityY * (float)delta + Position.Y;
		tempPosition = Mathf.Clamp(tempPosition, 0, screenSize.Y);
		Position = new Vector2(Position.X, tempPosition);
	}
}
