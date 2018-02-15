extends RigidBody2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

export (int) var maxSpeed;
var velY = 0;
var screensize;

func _ready():
	velY = 0;
	screensize = get_viewport_rect().size
	pass



func _process(delta):	
	position += Vector2(0, velY *  delta * maxSpeed);
	position.y = clamp(position.y, 0 , screensize.y);
	pass
