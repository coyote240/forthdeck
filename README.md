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

### funcsel@ ( addr -- n )

Given a pin address, leave the number of the currently selected pin function on
the stack.

```forth
13 pin funcsel@
```

### funcsel! ( addr n -- )

Given a pin address and a function number (see GPIO pin constants), set the
selected pin's function.

```forth
13 pin SIO funcsel!
```

## Terminal

*file: terminal.fs*

## TODO

* Timers
* Blocks
* SPI
* U2F image
