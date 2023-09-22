using Godot;

public partial class Mob : RigidBody2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		string[] mobTypes = animSprite.SpriteFrames.GetAnimationNames();
		var mobType = GD.RandRange(0, mobTypes.Length - 1);

		GD.Print(mobType);

		animSprite.Play(mobTypes[mobType]);
	}

	public void OnScreenExit()
    {
        QueueFree();
    }
}
