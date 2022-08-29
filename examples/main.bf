[true, a, b, c, d, e, turn] {
	true = [x] { x() }
	a = true
	b = true
	c = true
	d = {}

	turn = {
		a = b
		b = c
		c = d
		a(turn)
	}

	turn()
}