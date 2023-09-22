using Godot;

public partial class Pipes : StaticBody2D
{
	[Export]
	private float speed = 100;
	[Export]
	private float maxPosition = -10;
	[Export]
	private float jumpPosition = 450;

	[Export]
	private Vector2 randomYRange = new(0, 100);

	private float initialX = 0;
	private RandomNumberGenerator random;

	public override void _Ready()
	{
		initialX = Position.X;
		random = new RandomNumberGenerator();
		Reset();
	}

	public void Reset()
	{
		Position = new Vector2(initialX, RandomY());
	}

	private float RandomY()
	{
		return random.RandfRange(randomYRange.X, randomYRange.Y);
	}

	public override void _Process(double delta)
	{
		Position += new Vector2(-speed * (float)delta, 0);

		if (Position.X < maxPosition)
		{
			Reset();
		}
	}
}
