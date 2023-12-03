\ it is case insensitive 
0 Value fd-in
0 Value fd-out

\ read write function definitions
: open-input ( addr u -- )  r/o open-file throw to fd-in ;
: open-output ( addr u -- )  w/o create-file throw to fd-out ;

\ n -- n   type fed to the funciton and second it type returned

\ read the file in
s" day01test" open-input \ filename function defined earlier

\ vaiable 
variable lsd \ creates a variable named testing nothing on the stack
lsd \ instantiate the variable adds memory address to the stack
12 lsd ! \ adds value "12" and then memory address to the stack "!" once this happens it is in memory stack not needed
lsd ? \ pulls the value and prints it
lsd @ \ puts the value on the stack

\ contants are only on the stack

\ arrays
variable my_array   \ creates the variable
my_array 5 cells allot \ creates array of 5 cells = block of memory  "allot" reserves memory for it

my_array 5 cells dump \ this dumps the memory 

create newarray 10 cells allot
newarray 4 , 3 , 4 ,
     

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

