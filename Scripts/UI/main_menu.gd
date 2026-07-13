extends Control


func _on_start_pressed() -> void:
	get_tree().change_scene_to_file("res://Scenes/Levels/MainLevel.tscn")


func _on_settings_pressed() -> void:
	$Main.hide()
	$Options.show()


func _on_quit_pressed() -> void:
	get_tree().quit()


func _on_back_pressed() -> void:
	$Options.hide()
	$Main.show()
