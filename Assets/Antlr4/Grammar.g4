grammar Grammar;		

principal : block ;

block
: body 				block					
| function 			block				
| if_regular 		block 		
| switch_regular 	block 		
| while_regular 	block		
| 								
;


function_call
: 'usa' ID 'nada'
| 'usa' ID expression (',' expression)*
;

arrayPosition
: ID 'en' expression
;


print 
: '_print' expression 
;


arraysize
: '_sizeof' ID 
;




if_regular
: 'si' expression 'entonces' body_regular ( 'o_si' expression 'entonces' body_regular  )*  ('sino' body_regular )? 'fin'
;


if_return
: 'si' expression 'entonces' body_return ( 'o_si' expression 'entonces' body_return  )*  ('sino' body_return )? 'fin'
;

if_break_continue
: 'si' expression 'entonces' body_break_continue ( 'o_si' expression 'entonces' body_break_continue  )*  ('sino' body_break_continue )? 'fin'
;

if_return_break_continue
: 'si' expression 'entonces' body_return_break_continue ( 'o_si' expression 'entonces' body_return_break_continue  )*  ('sino' body_return_break_continue )? 'fin'
;



switch_regular
: 'cuando'  ID  'escoge' ('case' dataType 'entonce' body_regular )+ ('sino'  body_regular )? 'fin'
;


switch_return
: 'cuando'  ID  'escoge' ('case' dataType 'entonce' body_return )+ ('sino'  body_return )? 'fin'
;


switch_break_continue
: 'cuando'  ID  'escoge' ('case' dataType 'entonce' body_break_continue )+ ('sino'  body_break_continue )? 'fin'
;


switch_return_break_continue
: 'cuando'  ID  'escoge' ('case' dataType 'entonce' body_return_break_continue )+ ('sino'  body_return_break_continue )? 'fin'
;


while_regular
: 'mientras'  expression   'entonces' body_break_continue 'fin'
;

while_return
: 'mientras'  expression   'entonces' body_return_break_continue 'fin'
;



function
:  ID 'usa' 'nada'  'como'  body_return 'fin'
|  ID 'usa' ID ( ',' ID  )*  'como'  body_return 'fin'
;


body
: print  			
| function_call 
| ID ':' expression
;


body_regular
: body 		        body_regular 	#body_regularBody
| if_regular 		body_regular 	#body_regularIfRegular
| switch_regular 	body_regular 	#body_regularSwRegular
| while_regular 	body_regular 	#body_regularWhileRegular
|									#body_regularEpsilon
;

body_return
: body 			 		body_return
| if_return	  	 		body_return
| switch_return	 		body_return
| while_return	 		body_return
| return_regular ';'	body_return
|
;


return_regular
: 'responde' 	('nada')?				
| 'responde' expression						
;


body_break_continue
: body 					         	  body_break_continue
| if_break_continue	  	         	  body_break_continue
| switch_break_continue	         	  body_break_continue
| while_regular	 		         	  body_break_continue
| bc=('interrumpir'|'continuar') ';'  body_break_continue
|
;


body_return_break_continue
: body 					 		body_return_break_continue
| if_return_break_continue	  	body_return_break_continue
| switch_return_break_continue	body_return_break_continue
| while_return	 				body_return_break_continue
| bc=('break'|'continue') ';'	body_return_break_continue
| return_regular 	';'	 		body_return_break_continue
|
;

expression :   expressionContent   ;

expressionContent
:  '(' expressionContent ')'								#expressionContentParenthesis
|  NOT expressionContent 								    #expressionContentNot
|  NEGATIVE expressionContent 								#expressionContentNegative
|  expressionContent MUL  	 			expressionContent 	#expressionContentMul
|  expressionContent (SUM |NEGATIVE)	expressionContent 	#expressionContentSumOrNeg
|  expressionContent RELATIONAL  		expressionContent 	#expressionContentRelational
|  expressionContent EQUALITY_NUMERIC   expressionContent 	#expressionContentequality
|  expressionContent AND 				expressionContent 	#expressionContentAnd
|  expressionContent OR  				expressionContent 	#expressionContentContentOr

|  dataType													#expressionContentdataType
|  ID 														#expressionContentID
|  arrayPosition 											#expressionContentArrayPosition
|  function_call 											#expressionContentFunctionCall
|  input                                                    #expressionContentInput
;


dataType
: INTEGER
| DOUBLE
| STRING
| TRUE
| FALSE
;

input
: 'entrada'  
;


TRUE 
: 'verdadero' ; 
FALSE 
: 'falso' ;
NOT 
: 'negar' ;
RELATIONAL
: 'menorque' | 'menorigual' | 'mayorque' | 'mayorigual' ;
EQUALITY_NUMERIC
: 'igual' | 'diferente' ;
AND	  
: 'y_logico' ;
OR	  
: 'o_logico' ;


ID : [a-zA-Z][a-zA-Z0-9_]* ;
COMMENT : '#' ~[\r\n]* -> skip ;


DOUBLE : [0-9]+[.][0-9]+ ;
INTEGER : [0-9]+ ;
STRING : '"' .*? '"' ;

MUL   : '*' | '/' | '%'	;
SUM   : '+' ;
NEGATIVE :  '-'	 ;

WS		: [ \t\r\n]+ -> skip ;
ErrorChar : . ;