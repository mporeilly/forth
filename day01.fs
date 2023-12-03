\ it is case insensitive 
0 Value fd-in
0 Value fd-out

\ read write function definitions
: open-input ( addr u -- )  r/o open-file throw to fd-in ;
: open-output ( addr u -- )  w/o create-file throw to fd-out ;

: close-input ( -- )  fd-in close-file throw ;
: close-output ( -- )  fd-out close-file throw ;
\ read the file in
s" day01test" open-input \ filename function defined earlier

\ constant definitions
256 Constant max-line   
Create line-buffer  max-line 2 + allot
     
: scan-file ( addr u -- )
    begin
       line-buffer max-line fd-in read-line throw
   while
            >r 2dup line-buffer r> compare 0=
        until
    else
        drop
    then
        2drop ;
s" pqr3stu8vwx" scan-file

     : copy-file ( -- )
       begin
           line-buffer max-line fd-in read-line throw
       while
           line-buffer swap fd-out write-line throw
       repeat ;