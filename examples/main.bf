{
	readNatural([x] {
		readNatural([y] {
			add(x, y, [z] {
				writeNatural(z)
			})
			sub(x, y, [z] {
				writeNatural(z)
			})
			mul(x, y, [z] {
				writeNatural(z)
			})
		})
	})
}