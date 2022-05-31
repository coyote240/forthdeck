\ Words for dealing with the system timer peripheral

$e0000000 constant PPB_BASE
PPB_BASE $e100 + constant NVIC_ISER \ Interrupt set-enable register
PPB_BASE $e180 + constant NVIC_ICER \ Interrupt clear-enable register

: interrupt-enable ( n -- ) 1 swap lshift NVIC_ISER @ or NVIC_ISER ! ;
: interrupt-disable ( n -- ) 1 swap lshift NVIC_ICER @ and NVIC_ICER ! ;

\ Check if an interrupt is enabled.
\ example: 12 interrupt-enabled?
: interrupt-enabled? ( n -- flag ) 1 swap lshift NVIC_ISER @ and 0 > ;

\ Display a list of interrupts and their enabled status.
: interrupts-enabled. ( -- )
  cr 32 0 DO I dup ." IRQ-" u.
    interrupt-enabled? IF ." 1" ELSE ." 0" THEN
  cr LOOP ;

$40054000 constant TIMER_BASE
TIMER_BASE $00 + constant TIMEHW \ High/Low Write
TIMER_BASE $04 + constant TIMELW
TIMER_BASE $08 + constant TIMEHR \ High/Low Read
TIMER_BASE $0c + constant TIMELR
TIMER_BASE $10 + constant ALARM0
TIMER_BASE $14 + constant ALARM1
TIMER_BASE $18 + constant ALARM2
TIMER_BASE $1c + constant ALARM3
TIMER_BASE $24 + constant TIMERAWH \ Timer, raw read, no side effects (latch)
TIMER_BASE $28 + constant TIMERAWL

TIMER_BASE $38 + constant TIMER_INTE \ Interrupt enable


\ Display the current system timer. "counter print"
: counter. ( -- ) TIMELR @ TIMEHR @ swap UD. ; 

\ Enable or disable a specific alarm.
\ example: 2 alarm-enable
: alarm-enable ( n -- ) 1 swap lshift TIMER_INTE @ or TIMER_INTE ! ;
: alarm-disable ( n -- ) 1 swap lshift TIMER_INTE @ and TIMER_INTE ! ;

\ Check if an alarm is enabled.
\ example: 2 alarm-enabled?
: alarm-enabled? ( n -- flag ) 1 swap lshift TIMER_INTE @ and 0 > ;

: ms ( n -- )
  0 dup alarm-enable interrupt-enable
  1000 *      \ convert milliseconds to microseconds
  TIMERAWL +  \ add raw time, lower 32 bits
  ALARM0 !    \ write time to ALARM0
