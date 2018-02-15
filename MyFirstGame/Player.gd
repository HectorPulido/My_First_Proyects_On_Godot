extends Area2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

export (int) var speed;
signal hit
var velocity = Vector2();
var screensize;

func _ready():
	screensize = get_viewport_rect().size
	hide()
	# start(Vector2(screensize.x / 2, screensize.y/2));
	# Called every time the node is added to the scene.
	# Initialization here
	pass

func _process(delta):
	velocity = Vector2();
	
	if Input.is_action_pressed("ui_right"):
		velocity.x += 1;
	if Input.is_action_pressed("ui_left"):
		velocity.x -= 1;
	if Input.is_action_pressed("ui_up"):
		velocity.y -= 1;
	if Input.is_action_pressed("ui_down"):
		velocity.y += 1;
	if velocity.length() > 0:
		velocity = velocity.normalized() * speed;
		$AnimatedSprite.play();
	else:
		$AnimatedSprite.stop();
		
	position += velocity * delta
	position.x = clamp(position.x, 0, screensize.x)
	position.y = clamp(position.y, 0, screensize.y)
	
	if velocity.x != 0:
	    $AnimatedSprite.animation = "Right"
	    $AnimatedSprite.flip_v = false
	    $AnimatedSprite.flip_h = velocity.x < 0
	elif velocity.y != 0:
	    $AnimatedSprite.animation = "Up"
	    $AnimatedSprite.flip_v = velocity.y > 0
	
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
	pass
	
func start(pos):
	position = pos
	show()
	$CollisionShape2D.disabled = false

func _on_Player_body_entered( body ):
	hide();
	emit_signal("hit");
	$CollisionShape2D.disabled = true;
	pass # replace with function body
