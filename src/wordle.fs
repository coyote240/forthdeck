\ The hit game, Wordle

\ QOL words
: ? @ . ;
: R? R@ . ;

\ Random number generator
\ relies on the rp2040 Ring Oscillator
$40060000       constant ROSC_BASE
ROSC_BASE $1c + constant RANDOMBIT

\ Given a size in bits, return a random number
: random ( bits -- n )
  0 SWAP 0 DO
    RANDOMBIT @ I lshift OR
  LOOP ;

\ Lexicon
5 constant WORDSIZE
20 WORDSIZE * constant SIZE
CREATE lexicon SIZE ALLOT
lexicon VARIABLE lex-ptr

\ Given an address for storage, read and store
\ a string to memory.
: load-lexicon ( addr -- )
  BEGIN
    lex-ptr @ WORDSIZE ACCEPT
    WORDSIZE =
  WHILE
    WORDSIZE lex-ptr +!
  REPEAT ;

: advance ( -- ) WORDSIZE lex-ptr +! ;

: store ( size addr -- ) lex-ptr @ SWAP MOVE advance ;

: fake-lexicon ( addr -- )
  s" women" store
  s" nikau" store
  s" swack" store
  s" feens" store ;

: word. ( index -- ) WORDSIZE * lexicon + WORDSIZE TYPE ;
: word@ ( index -- addr ) WORDSIZE * lexicon + ;
: randword. ( -- addr ) 2 random word. ;
: randword@ ( -- addr ) 2 random word@ ;

: check-word ( input target -- )
  WORDSIZE 0 DO
    I + C@ <# # #> type
  LOOP ;

0 VARIABLE target

: wordle ( -- )
  randword@ target !  \ Get random word
  6 0 DO
    \ Accept user input
    \ Show matching letters
  LOOP
  ;
