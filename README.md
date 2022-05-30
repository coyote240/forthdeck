---
title: ForthDeck
keywords:
- projects
- forth
- hardware
- microcontrollers
- rp2040
---
# ForthDeck

The purpose of this project is to build a general purpose, interactive computer
out of an rp2040, while learning practical programming using the Forth language.

## GPIO

*file: gpio.fs*

### pin ( n -- addr )

Given a pin number, return the pin's address on the IO bank.

```forth
13 pin
```

### funcsel@ ( addr -- n ) *funcsel fetch*

Given a pin address, leave the number of the currently selected pin function on
the stack.

```forth
13 pin funcsel@
```

### funcsel! ( addr n -- ) *funcsel set*

Given a pin address and a function number (see GPIO pin constants), set the
selected pin's function.

```forth
13 pin SIO funcsel!
```

### pins ( -- )

Display a list of all GPIO pins and their currently selected function.

```forth
pins
```

### output-enable ( n -- ), output-disable ( n -- )

Given a pin number, enable or disable that pin for output.

```forth
13 output-enable
13 output-disable
```

### output-enabled? ( n -- flag )

Given a pin number, leave a flag on the stack indicating whether or not output
is enabled.

```forth
13 output-enabled?
```

### output-enabled. ( -- )

Display a table of pins and their output status.

```forth
output-enabled.
```

## Terminal

*file: terminal.fs*

## TODO

* Timers
* Blocks
* SPI
* U2F image
