[zero, one, two, three, four, five, inc, dec, add, sub, mul] {
	zero = {}
	
	inc = [number, result] {
		result([function]{
			function()
			number(function)
		})
	}
	
	dec = [number, result, current, previous, method] {
		current = {}
		previous = {}
		method = {
			previous = current
			inc(current , [x] { current = x } )
		}
		number(method)
		result(previous)
	}
	
	add = [op1, op2, result] {
		op2({inc(op1, [x]{op1 = x})})
		result(op1)
	}
	
	sub = [op1, op2, result] {
		op2({dec(op1, [x]{op1 = x})})
		result(op1)
	}
	
	mul = [op1, op2, result, inter] {
		inter = zero
		op2({add(op1, inter, [x]{inter = x})})
		result(inter)
	}
	
	inc(zero, [x]{one = x})
	inc(one, [x]{two = x})
	inc(two, [x]{three = x})
	inc(three, [x]{four = x})
	inc(four, [x]{five = x})
}