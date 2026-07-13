extends AudioStreamPlayer


func change_music(newMusic : AudioStream):
	self.stop()
	self.stream = newMusic
	self.play()
