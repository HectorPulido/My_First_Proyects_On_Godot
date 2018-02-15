extends Area2D

signal score1
signal score2

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

export (int) var speed 
var Vel = Vector2()
var screensize;

func _ready():
	screensize = get_viewport_rect().size
	Start();
	# Called every time the node is added to the scene.
	# Initialization here
	pass


func Start():
	position = screensize / 2;
	
	randomize();
	var x = randi() % 2 - 1;
	if x == 0:
		x = 1
	Vel = Vector2(x, randi() % 2 - 1)

func ChangeSpeed(speed):
	Vel.x *= -1;
	Vel.y = speed;

func _process(delta):
	position += Vel.normalized() * speed * delta;	
	
	if position.x > screensize.x:
		Start();
		emit_signal("score1")
	if position.x < 0:
		Start();
		emit_signal("score2")		
	if position.y > screensize.y:
		Vel.y *= -1;
	if position.y < 0:
		Vel.y *= -1;
		
	# Called every frame. Delta is time since last frame.
	# Update game logic here.
	pass


func _on_Ball_body_entered( body ):
	print(body.name);
	ChangeSpeed(body.velY);
	pass # replace with function body
