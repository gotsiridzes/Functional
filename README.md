# Functional
First steps into functional C#

## Discriminated Unions
### Constraining a set of types
Function defined on all of them
Completness verified by compiler

### Interface inheritance in C#
Still no discriminated unions in C#

## Higher-order functions
A function receives a delegate
Delegate can gave dependencies
  types
  other functions
 Dependencies not visible to the consumer
 
### Higher-order template functions
Receive a delegate to fill the blanks
Template function <b>knows</b> when to call the delegate

## Function composition
Supported by functional languages
Chained calls in object-oriented code
Use extension methods that are chainable

### Partial function application
Fix values of one or more arguments
Results in a new function
Expect the remaining (not fixed) arguments

### No native support in c#
Construct a func delegate
Overload a function
  Receive shorter argument list
  Internally call the larger function
