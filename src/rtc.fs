\ Words for interacting with RTC peripheral

$4005c000       constant RTC_BASE
RTC_BASE $00 +  constant RTC_CLKDIV_M1
RTC_BASE $04 +  constant RTC_SETUP_0
RTC_BASE $08 +  constant RTC_SETUP_1
RTC_BASE $0c +  constant RTC_CTRL
RTC_BASE $10 +  constant RTC_IRC_SETUP_0
RTC_BASE $14 +  constant RTC_IRC_SETUP_1
RTC_BASE $18 +  constant RTC_1
RTC_BASE $1c +  constant RTC_0
RTC_BASE $20 +  constant RTC_INTR
RTC_BASE $24 +  constant RTC_INTE
RTC_BASE $28 +  constant RTC_INTF
RTC_BASE $2c +  constant RTC_INTS

( Working with the onboard RTC
  It would appear the the rpiPico does have an onboard RTC.)

: rtc-active? ( -- flag ) RTC_CTRL %10 and ;
: rtc-enable ( -- ) RTC_CTRL %1 or ;
