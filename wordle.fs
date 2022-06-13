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

: wordle ( -- ) ;
