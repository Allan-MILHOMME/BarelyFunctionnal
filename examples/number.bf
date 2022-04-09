[zero, inc, dec] {
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
}