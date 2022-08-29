# BarelyFunctionnal

A minimal programming language which is basically lambda calculus + closure.
Created to be used for termination analysis.

## Syntax and behaviour

### Creating a function

```
  [x, y] {}
  {}
```

A function is composed of a list of parameters and a list of instructions.
Parameters are specified between square brackets, separated by commas and are optionnal if there are none.

### Assigning a value

```
  x = {}
  x = y
```

### Executing a value

```
  x(y, z)
  {}(x)
```

If the executed value expects less arguments that what is given, arguments on the right are removed.
If it expects more arguments that what is given, the remaining arguments are set to the empty function {}

### Unknown

```
  x = ?
  ?(x, y)
```

Unknown is a special value whose behaviour is unknown. It can only execute its first parameter zero or once, with no arguments. 
It is used for any native function, such as user input, reading files or creating random numbers.
Since it only gives a boolean of information, it must be executed multiple times to read numbers or more complex results.

### Closures

A closure is the tuple of a function and its environment.

```
  [x, y] {
    y = {
      x = y
    }
  }

```

In this example, the y function does not define a parameter x ; instead it uses the one defined in its parent function.
This is used to store information, and create non-pure functions, as well as recursions.

## Examples

### Natural

Provides utilitary functions for manipulating natural numbers, such as addition, subtraction and multiplication.

## Native

Provides utilitary functions to read and write numbers, as well as a boolean random.

## Main

Asks the user to enter 2 numbers and print out their sum, difference and product.
