extends RigidBody2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

export (int) var MIN_SPEED
export (int) var MAX_SPEED
var mob_types = ["Walk", "Swim", "Fly"]


func _ready():
	$AnimatedSprite.animation = mob_types[randi() % mob_types.size()]
	
	# Called every time the node is added to the scene.
	# Initialization here
	pass

func _on_VisibilityNotifier2D_screen_exited():
	queue_free()
	pass