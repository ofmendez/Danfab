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
: 'imprima' expression 
;



arraysize
: 'tamaño' 'de'  ID 
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
: print  			                    #bodyPrint
| function_call                         #bodyFunctionCall
| ID ':' expression                     #bodyAssignVariable
| ID 'en' expression ':'  expression    #bodyArrayPosition
| 'lista' ID 'de' expression            #bodyArrayDeclaration
;


body_regular
: body 		        body_regular 	#body_regularBody
| if_regular 		body_regular 	#body_regularIfRegular
| switch_regular 	body_regular 	#body_regularSwRegular
| while_regular 	body_regular 	#body_regularWhileRegular
|									#body_regularEpsilon
;

body_return
: body 			 		body_return		#body_returnBody
| if_return	  	 		body_return		#body_returnIfReturn
| switch_return	 		body_return		#body_returnSwitchReturn
| while_return	 		body_return		#body_returWhileReturn
| return_regular    	body_return		#body_returnReturnregular
|										#body_returnEpsilon
;


return_regular
: 'responde' 	('nada')?				
| 'responde' expression						
;


body_break_continue
: body 					         	  body_break_continue	#body_BC_Body
| if_break_continue	  	         	  body_break_continue	#body_BC_IfBC
| switch_break_continue	         	  body_break_continue	#body_BC_SwitchBC
| while_regular	 		         	  body_break_continue	#body_BC_WhileRegular
| bc=('interrumpir'|'continuar')      body_break_continue	#body_BC_BC
|															#body_BC_Epsilon
;


body_return_break_continue
: body 					 		body_return_break_continue 	#body_RBC_Body
| if_return_break_continue	  	body_return_break_continue 	#body_RBC_IfRBC
| switch_return_break_continue	body_return_break_continue 	#body_RBC_SwitchRBC
| while_return	 				body_return_break_continue 	#body_RBC_WhileReturn
| bc=('interrumpir'|'continuar') 	    body_return_break_continue 	#body_RBC_BC
| return_regular 		 		body_return_break_continue 	#body_RBC_Return
|															#body_RBC_Epsilon
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
|  arraysize 												#expressionContentArraySize
//|  input                                                    #expressionContentInput
;


dataType
: INTEGER
| DOUBLE
| STRING
| TRUE
| FALSE
;

//input
//: 'entrada'  
//;


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


