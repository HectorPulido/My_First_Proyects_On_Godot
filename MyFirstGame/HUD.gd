extends CanvasLayer

signal StartGame
# class member variables go here, for example:
# var a = 2
# var b = "textvar"

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	pass

func ShowMessage(text):
	$MessageLabel.text = text;
	$MessageLabel.show()
	$MessageTimer.start() 

func ShowGameOver():
	ShowMessage("Game over");
	yield($MessageTimer, "timeout");
	$StartButton.show();
	$MessageLabel.text = "DODGE THE CREEPS!";
	$MessageLabel.show();


func UpdateScore(score):
	$ScoreLabel.text = str(score);

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass


func _on_StartButton_pressed():
	$StartButton.hide()
	emit_signal("StartGame");
	pass # replace with function body


func _on_MessageTimer_timeout():
	$MessageLabel.hide();
	pass # replace with function body
