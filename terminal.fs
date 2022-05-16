\ Emit escape codes
: ESC[ ( -- ) 27 emit 91 emit ;

\ Movement
: [home] ( -- ) ESC[ ." H" ;
: at-xy ( column row -- ) 1+ swap 1+ swap ESC[ u. ." ;" u. ." H" ;

\ Foreground colors
: [color] ( n -- ) ESC[ u. ." m" ;
: [black]   ( -- ) 30 [color] ;
: [red]     ( -- ) 31 [color] ;
: [green]   ( -- ) 32 [color] ;
: [yellow]  ( -- ) 33 [color] ;
: [blue]    ( -- ) 34 [color] ;
: [magenta] ( -- ) 35 [color] ;
: [cyan]    ( -- ) 36 [color] ;

\ Background colors
: [black/bg]    ( -- ) ESC[ ." 40m" ;
: [red/bg]      ( -- ) ESC[ ." 41m" ;
: [green/bg]    ( -- ) ESC[ ." 42m" ;
: [yellow/bg]   ( -- ) ESC[ ." 43m" ;
: [blue/bg]     ( -- ) ESC[ ." 44m" ;
: [magenta/bg]  ( -- ) ESC[ ." 45m" ;
: [cyan/bg]     ( -- ) ESC[ ." 46m" ;

\ Attributes
: [bold]      ( -- ) ESC[ ." 1m" ;
: [dim]       ( -- ) ESC[ ." 2m" ;
: [smso]      ( -- ) ESC[ ." 3m" ;
: [underline] ( -- ) ESC[ ." 4m" ;
: [blink]     ( -- ) ESC[ ." 5m" ;
: [reverse]   ( -- ) ESC[ ." 7m" ;

\ Reset to default colors
: [reset]   ( -- ) ESC[ ." 0m" ;

: rainbow ( -- )
  [red] ." r"
  [yellow] ." a"
  [green] ." i"
  [blue] ." n"
  [cyan] ." b"
  [magenta] ." o"
  [red] ." w"
  [reset] ;

