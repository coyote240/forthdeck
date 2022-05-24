\ Words for managing GPIO pins

\ User bank IO registers
$40014000 constant IO_BANK0_BASE
$00000004 constant GPIO_CTRL

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
: funcsel ( addr -- n ) GPIO_CTRL + @ ;

\ Given a pin address, set its function
\ example: 13 pin SIO funcset
: funcset ( addr n -- ) swap GPIO_CTRL + ! ;

\ Display a list of all gpio pins and their current function
: pins ( -- ) cr 30 0 DO I dup u. pin funcsel u. cr LOOP ;
