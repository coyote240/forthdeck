\ format codes
0 constant PLAIN
1 constant BRIGHT
2 constant DIM
3 constant ITALIC
4 constant UNDERLINE
5 constant BLINK
7 constant REVERSE

\ color codes
0 constant BLACK
1 constant RED
2 constant GREEN
3 constant YELLOW
4 constant BLUE
5 constant MAGENTA
6 constant CYAN
7 constant WHITE
30 constant FG
40 constant BG

: WITH ( -- ) 59 emit ;

\ Emit escape codes
: ESC[ ( -- ) 27 emit 91 emit ;

\ TUI mode, these need better names
: TI ( -- ) ESC[ ." ?1047h" ; \ enter TUI mode
: TE ( -- ) ESC[ ." ?1049l" ; \ exit TUI mode

: at-xy ( column row -- ) 1+ swap 1+ swap ESC[ u. ." ;" u. ." H" ;
: page ( -- ) ESC[ ." 2J" 0 0 at-xy ;

: hide-cursor ( -- ) ESC[ ." ?25l" ;
: show-cursor ( -- ) ESC[ ." ?25h" ;

: cleanup ( -- ) page TE show-cursor ;

\ Movement
: [home] ( -- ) ESC[ ." H" ;

\ Foreground colors
: [format]  ( n -- ) ESC[ u. ." m" ;
: [black]   ( -- ) FG BLACK   + [format] ;
: [red]     ( -- ) FG RED     + [format] ;
: [green]   ( -- ) FG GREEN   + [format] ;
: [yellow]  ( -- ) FG YELLOW  + [format] ;
: [blue]    ( -- ) FG BLUE    + [format] ;
: [magenta] ( -- ) FG MAGENTA + [format] ;
: [cyan]    ( -- ) FG CYAN    + [format] ;

\ Background colors
: [black/bg]    ( -- ) BG BLACK   + [format] ;
: [red/bg]      ( -- ) BG RED     + [format] ;
: [green/bg]    ( -- ) BG GREEN   + [format] ;
: [yellow/bg]   ( -- ) BG YELLOW  + [format] ;
: [blue/bg]     ( -- ) BG BLUE    + [format] ;
: [magenta/bg]  ( -- ) BG MAGENTA + [format] ;
: [cyan/bg]     ( -- ) BG CYAN    + [format] ;

\ Attributes
: [bold]      ( -- ) BOLD       [format] ;
: [dim]       ( -- ) DIM        [format] ;
: [italic]    ( -- ) ITALIC     [format] ;
: [underline] ( -- ) UNDERLINE  [format] ;
: [blink]     ( -- ) BLINK      [format] ;
: [reverse]   ( -- ) REVERSE    [format] ;

\ Reset to default colors
: [reset]   ( -- ) ESC[ ." 0m" ;

: rainbow ( -- ) 
  [red] ." r" [yellow] ." a" [green] ." i" [blue] ." n"
  [cyan] ." b" [magenta] ." o" [red] ." w" [reset] ;

