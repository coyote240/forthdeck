\ Words for managing GPIO pins

\ User bank IO registers
$40014000       constant IO_BANK0_BASE
$00000004       constant GPIO_CTRL
$d0000000       constant SIO_BASE
SIO_BASE $020 + constant GPIO_OE
SIO_BASE $024 + constant GPIO_OE_SET
SIO_BASE $028 + constant GPIO_OE_CLR
SIO_BASE $02c + constant GPIO_OE_XOR

\ GPIO pin functions
1 constant SPI0
2 constant UART
3 constant I2C
4 constant PWM
5 constant SIO
6 constant PIO0
7 constant PIO1
9 constant USB
31 constant NULL

\ Given a pin #, leave its address on the stack
: pin ( n -- addr ) 8 * IO_BANK0_BASE + ;

\ Given a pin address, leave its selected function value on the stack
\ example: 13 pin funcsel
: funcsel@ ( addr -- n ) GPIO_CTRL + @ ;

\ Given a pin address, set its function
\ example: 13 pin SIO funcset
: funcsel! ( addr n -- ) swap GPIO_CTRL + ! ;

\ Display a list of all gpio pins and their current function
: pins ( -- ) cr 30 0 DO I dup u. pin funcsel u. cr LOOP ;

\ Enable/disable pin for GPIO output
\ example: 13 output-enable
\ example: 13 output-disable
: output-enable ( n -- ) 1 swap lshift GPIO_OE_SET ! ;
: output-disable ( n -- ) 1 swap lshift GPIO_OE_CLR ! ;

\ Check if pin has GPIO output enabled
: output-enabled? ( n -- flag ) 1 swap lshift GPIO_OE @ and 0 > ;
