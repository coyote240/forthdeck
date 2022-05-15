: ESC[ ( -- ) 27 emit 91 emit ;

: erase ( n -- )
  0 ?DO $08 emit LOOP ;

: countdown ( n -- )
  cr ." Counting... "
  0 ?DO I . 2 ERASE LOOP ;

\ Foreground colors
: [black]   ( -- ) ESC[ ." 30m " ;
: [red]     ( -- ) ESC[ ." 31m " ;
: [green]   ( -- ) ESC[ ." 32m " ;
: [yellow]  ( -- ) ESC[ ." 33m " ;
: [blue]    ( -- ) ESC[ ." 34m " ;
: [magenta] ( -- ) ESC[ ." 35m " ;
: [cyan]    ( -- ) ESC[ ." 36m " ;

\ Background colors
: [black/bg]    ( -- ) ESC[ ." 40m " ;
: [red/bg]      ( -- ) ESC[ ." 41m " ;
: [green/bg]    ( -- ) ESC[ ." 42m " ;
: [yellow/bg]   ( -- ) ESC[ ." 43m " ;
: [blue/bg]     ( -- ) ESC[ ." 44m " ;
: [magenta/bg]  ( -- ) ESC[ ." 45m " ;
: [cyan/bg]     ( -- ) ESC[ ." 46m " ;

\ Attributes
: [bold]      ( -- ) ESC[ ." 1m " ;
: [dim]       ( -- ) ESC[ ." 2m " ;
: [smso]      ( -- ) ESC[ ." 3m " ;
: [underline] ( -- ) ESC[ ." 4m " ;
: [blink]     ( -- ) ESC[ ." 5m " ;
: [reverse]   ( -- ) ESC[ ." 7m " ;

\ Reset to default colors
: [reset]   ( -- ) ESC[ ." 0m " ;
