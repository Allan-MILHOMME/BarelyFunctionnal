[readNumber, writeNumber, random] {
	readNumber = [number] { ?({}, number) }
	writeNumber = [result] { ?([x]{x()}, result) }
	random = [result] { ?([x]{x()x()}, result) }
}