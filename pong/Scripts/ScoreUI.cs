using Godot;
using System;

public partial class ScoreUI : CanvasLayer
{
	private int leftScore;
	private int rightScore;

	private Label scoreLabel;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("Label");
	}

	public void OnScore(bool leftSide)
	{
		GD.Print("Score! ", leftSide);
		GD.Print(leftScore, " - ", rightScore);
		if (leftSide)
		{
			leftScore++;
		}
		else
		{
			rightScore++;
		}
		scoreLabel.Text = $"{leftScore} - {rightScore}";
	}
}
