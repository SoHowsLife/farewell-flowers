extends HSlider

@export_enum("Music", "Sounds") var audio_bus = "Sounds"
var bus_index : int

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	connect("value_changed", _on_value_changed)
	AudioServer.get_bus_index(audio_bus)
	if bus_index == -1:
		print_debug("MISSING AUDIO BUS")

func _on_value_changed(value: float) -> void:
	var db = linear_to_db(value)
	#print(db)
	if bus_index != -1:
		AudioServer.set_bus_volume_db(bus_index, db)
