extends Node2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var score1 = 0
var score2 = 0

	
func _ready():	
	pass

func Start():
	$Ball.position = $Position2D.position;
	pass

func _process(delta):
	#$Raqueta1.velY = 
	var velY1 = 0;
	var velY2 = 0;
	if Input.is_action_pressed("W"):
		velY1 -= 1;
	if Input.is_action_pressed("S"):
		velY1 += 1;
	if Input.is_action_pressed("ui_up"):
		velY2 -= 1;
	if Input.is_action_pressed("ui_down"):
		velY2 += 1;	
	
	$Raqueta1.velY = velY1;
	$Raqueta2.velY = velY2;


func _on_Ball_score1():
	score1 += 1 ;
	$CanvasLayer.ChangeText(score1, score2);
	pass # replace with function body


func _on_Ball_score2():
	score2 += 1;
	$CanvasLayer.ChangeText(score1, score2);
	pass # replace with function body
