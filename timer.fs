\ Words for dealing with the system timer peripheral

$40054000 constant TIMER_BASE
TIMER_BASE $00 + constant TIMEHW
TIMER_BASE $04 + constant TIMELW
TIMER_BASE $08 + constant TIMEHR
TIMER_BASE $0c + constant TIMELR

TIMER_BASE $38 + constant TIMER_INTE


\ Display the current system timer. "counter print"
: counter. ( -- ) TIMELR @ TIMEHR @ swap D. ; 

\ Enable or disable a specific alarm.
\ example: 2 alarm-enable
: alarm-enable ( n -- ) 1 swap lshift TIMER_INTE @ or TIMER_INTE ! ;
: alarm-disable ( n -- ) 1 swap lshift TIMER_INTE @ and TIMER_INTE ! ;

\ Check if an alarm is enabled.
\ example: 2 alarm-enabled?
: alarm-enabled? ( n -- flag ) 1 swap lshift TIMER_INTE @ and 0 > ;
