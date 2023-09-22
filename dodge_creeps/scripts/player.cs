using Godot;
using System;

public partial class player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

	public Vector2 ScreenSize; // Size of the game window.

	[Signal]
	public delegate void HitEventHandler();

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Hide();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	public override void _Process(double delta)
	{
		var velocity = new Vector2(); // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}
		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}
		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.X != 0) {
			animatedSprite.Animation = "walk";
			animatedSprite.FlipV = false;

			animatedSprite.FlipH = velocity.X < 0;
		}
		if (velocity.Y != 0) {
			animatedSprite.Animation = "up";
			animatedSprite.FlipV = velocity.Y > 0;
		}


		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite.Play();
		}
		else
		{
			animatedSprite.Stop();
		}

		Position += velocity * (float)delta;
		// No euclidean space, if the player goes off-screen, wrap around to the other side.
		Position = new Vector2(
			x: Mathf.Wrap(Position.X, 0, ScreenSize.X),
			y: Mathf.Wrap(Position.Y, 0, ScreenSize.Y)
		);
	}

	public void OnBodyEntered(PhysicsBody2D body)
	{
		Hide(); // Player disappears after being hit.
		EmitSignal(SignalName.Hit);
		// Must be deferred as we can't change physics properties on a physics callback.
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}

	public void Start(Vector2 pos)
	{
		Position = pos;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
