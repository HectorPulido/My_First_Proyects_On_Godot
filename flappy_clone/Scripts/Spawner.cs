using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export]
	public float initialSpawn = 100f;

	[Export]
	public float spawnSeparation = 200f;

	[Export]
	public int spawnCount = 5;

	[Export]
    public PackedScene Pipes { get; set; }

	public override void _Ready()
	{
		for (int i = 0; i < spawnCount; i++)
		{
			var pipe = Pipes.Instantiate<Pipes>();
			pipe.Position = new Vector2(initialSpawn + (i * spawnSeparation), 0);
			AddChild(pipe);
		}

	}
}
