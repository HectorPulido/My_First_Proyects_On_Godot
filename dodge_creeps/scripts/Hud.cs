using Godot;
using System;

public partial class Hud : CanvasLayer
{
	// Don't forget to rebuild the project so the editor knows about the new signal.

	[Signal]
	public delegate void StartGameEventHandler();

	public void ShowMessage(string message)
	{
		var messageLabel = GetNode<Label>("Message");
		messageLabel.Text = message;
		messageLabel.Show();

		GetNode<Timer>("MessageTimer").Start();
	}

	public void OnStartButtonPressed()
	{
		GetNode<Button>("StartButton").Hide();
		GetNode<Label>("Message").Hide();
		
		EmitSignal(SignalName.StartGame);
	}

	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = score.ToString();
	}

	async public void ShowGameOver()
	{
		ShowMessage("Game Over");

		var messageTimer = GetNode<Timer>("MessageTimer");
		await ToSignal(messageTimer, Timer.SignalName.Timeout);

		var message = GetNode<Label>("Message");
		message.Text = "Dodge the\nCreeps!";
		message.Show();

		await ToSignal(GetTree().CreateTimer(1.0), SceneTreeTimer.SignalName.Timeout);
		GetNode<Button>("StartButton").Show();
	}
}
