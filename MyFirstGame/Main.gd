extends Node2D
export (PackedScene) var Mob;
var score = 0;

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

func _ready():
	randomize()
	# Called every time the node is added to the scene.
	# Initialization here
	pass

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass

func GameOver():
	$HUD.ShowGameOver()
	$MobTimer.stop()
	$ScoreTimer.stop()
	pass
func new_Game():
	$HUD.ShowMessage("Get Ready")

	score = 0;
	$Player.start($StartPosition.position)
	$StartTimer.start()
	pass


func _on_Player_hit():
	GameOver()
	pass # replace with function body


func _on_MobTimer_timeout():
	 # choose a random location on the Path2D
	$MobPath/MobspawnLocation.set_offset(randi())
    # create a Mob instance and add it to the scene
	var mob = Mob.instance()
	add_child(mob)
    # set the mob's direction perpendicular to the path direction
	var direction = $MobPath/MobspawnLocation.rotation + PI/2
    # set the mob's position to the random location
	mob.position = $MobPath/MobspawnLocation.position
    # add some randomness to the direction
	direction += rand_range(-PI/4, PI/4)
	mob.rotation = direction
    # choose the velocity
	mob.set_linear_velocity(Vector2(rand_range(mob.MIN_SPEED, mob.MAX_SPEED), 0).rotated(direction))
	
	pass # replace with function body


func _on_ScoreTimer_timeout():
	score += 1;
	$HUD.UpdateScore(score)
	pass # replace with function body


func _on_StartTimer_timeout():
	$MobTimer.start()
	pass # replace with function body


func _on_HUD_StartGame():
	new_Game()
	pass # replace with function body
