using Godot;
using System;

public partial class ParallaxBackground : Godot.ParallaxBackground
{
	[Export]
	private float _parallaxScale = -1000f;

	public override void _Process(double delta)
	{
		var offset = new Vector2(
			ScrollOffset.X + _parallaxScale * (float)delta,
			0
		);
		ScrollOffset = offset;
	}
}
