[writeNatural, readBoolean, random, readNatural] {
	writeNatural = [number] { ?({}, zero, number) }
	readBoolean = [result] { ?(result, one) }
	random = [result] { ?(result, two) }
	
	readNatural = [result, loop, inter] {
		inter = zero
		loop = {
			readBoolean({inc(inter, [x]{inter = x loop()})})
		}
		loop()
		result(inter)
	}
}