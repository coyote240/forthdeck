\ Functions for managing GPIO pins

\ User bank IO registers
$40014000 constant IO_BANK0_BASE

: pins ( -- )
  $30 $00 DO I u. 4 +LOOP ;

: pin-status ( -- )
  cr
  30 0 DO
    I u.
    I 8 * IO_BANK0_BASE + @ hex. cr LOOP ;
