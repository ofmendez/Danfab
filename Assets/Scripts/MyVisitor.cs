using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.InteropServices;
using Antlr4.Runtime.Tree;
using UnityEngine;

using Utils;

public class MyVisitor : FaBaseVisitor<System.Object>{

	Dictionary<string, Instance> memory = new Dictionary<string, Instance>();
	LinkedList<Dictionary<string, Instance>> queue = new LinkedList<Dictionary<string, Instance>>();

	public int getType(object value){
		int result =  -1 ;
		if (value is bool)
			result = 0;
		if(value is int)
			result = 1;
		if(value is double || value is float)
			result = 2;
		if(value is string)
			result = 3;
		return result;
	}


	object Exist (string id){
		foreach(Dictionary<string, Instance> d in queue.Reverse()){
			if( d.ContainsKey(id) )
				return   d[id];
		}
		Debug.LogError("Variable "+id+" no existe en ningún contexto.");
		// Console.WriteLine("Variable "+id+" no existe en ningún contexto.");
		MyConsole.main.AppendText("Variable "+id+" no existe en ningún contexto.");
		return null;
	}

	object ExistInLast (string id){

		if( queue.Last().ContainsKey(id) )
			return   queue.Last()[id];

		return null;
	}

	string PrintQueue(LinkedList<Dictionary<string, Instance>> Q){
		string result = "";
		foreach (Dictionary<string, Instance> D in Q) {
			foreach(KeyValuePair<string, Instance> entry in D) {
			   	result += (" ["+entry.Key+" , "+entry.Value+"] ");
			   	 // do something with entry.Value or entry.Key
			}
		   	result += (" ## ");
		}
		return result;
	}

	public override object VisitPrint(FaParser.PrintContext context){

		object toPrint = Visit(context.expression());
		if(toPrint is bool){
			// Console.WriteLine((bool)toPrint?"verdadero":"falso");
			Debug.Log( ((bool)toPrint)?"verdadero":"falso");
			MyConsole.main.AppendText(""+  ( ((bool)toPrint)?"verdadero":"falso") ); 
		}else{
			// Console.WriteLine(toPrint);
 			Debug.Log( toPrint);
			MyConsole.main.AppendText(""+toPrint); 
		}
		return null;
	}



	public override object VisitPrincipal(FaParser.PrincipalContext context){
		queue.AddLast(memory);
		return VisitChildren(context);
	}

	public override object VisitDataType(FaParser.DataTypeContext context){
		object result = null;
		if(context.DOUBLE() != null){
			result = double.Parse(context.DOUBLE().GetText());
		}
		if(context.INTEGER() != null){
			result = int.Parse(context.INTEGER().GetText());
		}
		if (context.STRING() != null){
			result = context.STRING().GetText().Trim('"');
		}
		if (context.TRUE() != null){
			result = true;
		}
		if (context.FALSE() != null){
			result = false;
		}
		return result;
	}
	
	//######################
	// ARRAYS
	//######################

	public override object VisitArrayPosition(FaParser.ArrayPositionContext context){
		object result = null;
		string id = context.ID().GetText();
		object position = VisitExpression(context.expression());
		object arr = ExistInLast(id);
		if (arr is MyArray) {

			if (position is int) {
				result = ((MyArray) arr).getValue((int)position);
			}
			else {
				//			Debug.LogError("Debe consultarse con un tipo de dato entero");
				Console.WriteLine("Debe consultarse con un tipo de dato entero");
				//			MyConsole.main("Debe consultarse con un tipo de dato entero");
			}
		}
		else {
			//			Debug.LogError("Este identificador no es de un Array o no está declarado");
			Console.WriteLine("Este identificador no es de un Array o no está declarado");
			//			MyConsole.main("Este identificador no es de un Array o no está declarado");
		}
		return result;
	}

	public override object VisitArraysize(FaParser.ArraysizeContext context){
		object result = null;
		string id = context.ID().GetText();
		object arr = ExistInLast(id);
		if (arr is MyArray){
			result = ((MyArray) arr).getSize();
		}
		//			Debug.LogError(id+" no ha sidop declarado");
		Console.WriteLine(id+" no ha sidop declarado");
		//			MyConsole.main(id+" no ha sidop declarado");
		
		return result;

	}


	//######################
	// EXPRESSIONS
	//######################
	
	public override object VisitExpression(FaParser.ExpressionContext context){
		return Visit(context.expressionContent());

	}

	public override object VisitExpressionContentSumOrNeg(FaParser.ExpressionContentSumOrNegContext context){
		// Tebug.Log("v Suma Resta");
        object left = Visit(context.expressionContent(0));
        object right = Visit(context.expressionContent(1));
        bool isSum =  context.SUM() != null  ;

		object result = null;
		if (left is bool   || right is bool){
			Debug.LogError("No es posible aplicar el símbolo"+(isSum? "+":"-")+"a un booleano");
			// Console.WriteLine("No es posible aplicar el símbolo"+(isSum? "+":"-")+"a un booleano");
			MyConsole.main.AppendText("No es posible aplicar el símbolo"+(isSum? "+":"-")+"a un booleano");
			return null;
		}
		if (left is string || right is string){
			if (!isSum){
				Debug.LogError("No es posible aplicar el operador - a strings");
				// Console.WriteLine("No es posible aplicar el operador - a strings");
				MyConsole.main.AppendText("No es posible aplicar el operador - a strings");
			}else
				result = left.ToString() + right.ToString();
		}else{
			if (left is double || right is double)
				result = isSum? Convert.ToDouble(left) + Convert.ToDouble(right) : Convert.ToDouble(left) - Convert.ToDouble(right);
			else if (left is int || right is int)
				result = isSum? (int) left + (int) right :(int) left - (int) right;
			else{
				Debug.LogError("Llegaron valores de tipo desconocido");
				// Console.WriteLine("Llegaron valores de tipo desconocido");
				MyConsole.main.AppendText("Llegaron valores de tipo desconocido");
			}
		}

		return result;
	}

	public override object VisitExpressionContentNot(FaParser.ExpressionContentNotContext context){
        object value = Visit(context.expressionContent());
		if ( value is bool)
			return  ! (bool) value ;

		Debug.LogError("Operador ! sólo es aplicable a booleano");
		// Console.WriteLine("Operador ! sólo es aplicable a booleano");
		MyConsole.main.AppendText("Operador ! sólo es aplicable a booleano");
		return null;
	}

	public override object VisitExpressionContentID(FaParser.ExpressionContentIDContext context){
		string id = context.ID().GetText();
		object var = ExistInLast(id);
		if (var is MyVariable){
			return ((MyVariable) var).value;
		}
		if (var is MyArray){
			return ((MyArray) var).ToString();
		}
		Debug.LogError("No se ha declarado esta variable o arreglo(id)");
		// Console.WriteLine("No se ha declarado esta variable o arreglo(id)");
		MyConsole.main.AppendText("No se ha declarado esta variable o arreglo(id)");
		return null;
	}

	public override object VisitExpressionContentParenthesis(FaParser.ExpressionContentParenthesisContext context){
		return Visit(context.expressionContent());
	}

	public override object VisitExpressionContentNegative(FaParser.ExpressionContentNegativeContext context){
		object expToNegate = Visit(context.expressionContent());
		object result = null;
		if (expToNegate is double)
			result = - Convert.ToDouble(expToNegate);
		if (expToNegate is int)
			result = - (int)expToNegate;
		if (expToNegate is string || expToNegate is bool){
			Debug.LogError("No es posible aplicar el operador - a string o bool");
			// Console.WriteLine("No es posible aplicar el operador - a string o bool");
			MyConsole.main.AppendText("No es posible aplicar el operador - a string o bool");
		}

		return result;
	}

	public override object VisitExpressionContentRelational(FaParser.ExpressionContentRelationalContext context){

		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		bool leftIsNum  = left   is int || left  is double;
		bool rigthIsNum =  right is int || right is double;
		bool areNums = leftIsNum &&  rigthIsNum;
		bool areStrgs = left is string &&  right is string;

		object result  =  false;

		switch (context.RELATIONAL().GetText() ) {
		    case "menorque":
		    	if(areNums){
		    		result = Convert.ToDouble(left) < Convert.ToDouble(right);
		    	}
		    	else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) < 0;
	    		else {
	    			Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de datos: "+getType(left)+" contra "+getType(right));
	    			// Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de datos: "+getType(left)+" contra "+getType(right));
	    			MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de datos: "+getType(left)+" contra "+getType(right));
	    		}
		      	break;
		    case "menorigual":
		    	if(areNums)
		    		result = Convert.ToDouble(left) <= Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) <= 0;
	    		else {
	    			Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "mayorque":
		    	if(areNums){
		    		result =  (bool)(Convert.ToDouble(left) > Convert.ToDouble(right) );
		    	}
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) > 0;
	    		else {
	    			Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "mayorigual":
		    	if(areNums)
		    		result =Convert.ToDouble(left) >= Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) >= 0;
	    		else {
	    			Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		     	break;
		}

		return result;
	}

	public override object VisitExpressionContentequality(FaParser.ExpressionContentequalityContext context){

		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		bool leftIsNum  = left   is int || left  is double;
		bool rigthIsNum =  right is int || right is double;
		bool areNums = leftIsNum &&  rigthIsNum;
		bool areStrgs = left is string &&  right is string;

		object result  =  null;

		switch (context.EQUALITY_NUMERIC().GetText() ) {
		    case "igual":
		    	if(areNums)
		    		result = Convert.ToDouble(left) == Convert.ToDouble(right);
		    	else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) < 0;
	    		else {
	    			Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "diferente":
		    	if(areNums)
		    		result = Convert.ToDouble(left) != Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) <= 0;
	    		else {
	    			Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		}

		return result;
	}

	public override object VisitExpressionContentAnd(FaParser.ExpressionContentAndContext context){
		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		object result = null;

		if (left is bool && right is bool)
			result = (bool) left && (bool) right;
		else{
			Debug.LogError("No se puede aplicar && a tipos no booleanos");
			// Console.WriteLine("No se puede aplicar && a tipos no booleanos");
			MyConsole.main.AppendText("No se puede aplicar && a tipos no booleanos");
		}

		return result;
	}

	public override object VisitExpressionContentContentOr(FaParser.ExpressionContentContentOrContext context){

		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		object result = null;

		if (left is bool && right is bool)
			result = (bool) left || (bool) right;
		else{
			Debug.LogError("No se puede aplicar && a tipos no booleanos");
			// Console.WriteLine("No se puede aplicar && a tipos no booleanos");
			MyConsole.main.AppendText("No se puede aplicar && a tipos no booleanos");
		}

		return result;

	}

	public override object VisitExpressionContentMul(FaParser.ExpressionContentMulContext context){
		object result = null;

		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		bool isMod =  context.MUL().GetText().Equals("%");
		bool isMul =  context.MUL().GetText().Equals("*");
		bool isDiv =  context.MUL().GetText().Equals("/");
		bool leftIsNum  = left   is int || left  is double;
		bool rigthIsNum =  right is int || right is double;
		bool areNums = leftIsNum &&  rigthIsNum;
		bool areStringMul = (left is int && right is string) || (left is string && right  is int) ;

		if (isDiv && rigthIsNum && Convert.ToDouble(right) == 0 ){
			Debug.LogError("Error en división por cero");
			// Console.WriteLine("Error en división por cero");
			MyConsole.main.AppendText("Error en división por cero");
			return null;
		}

		if (areNums){
			result = isMul ? Convert.ToDouble(left) * Convert.ToDouble(right) : result;
			result = isDiv ? Convert.ToDouble(left) / Convert.ToDouble(right) : result;
			result = isMod ? Convert.ToDouble(left) % Convert.ToDouble(right) : result;
		}
		if (areStringMul){
			result = "";
			for(int i=0; i< (     left is int ? (int) left :(int) right     ) ; i++){
				result += (left is int ? (string) right : (string) left);
			}
		}
		return result;
	}


	public override object VisitExpressionContentFunctionCall(FaParser.ExpressionContentFunctionCallContext context){
		return VisitFunction_call(context.function_call());
	}

	
	//TODO : expresionContentArrayPosition
	
	//######################
	// FUNCTIONS
	//######################
	public override object VisitFunction(FaParser.FunctionContext context){

		string id = context.ID(0).GetText();

		int nArgs = context.ID().Length -1;
		LinkedList<string> namesParams = new LinkedList<string>();

		for(int i = 1; i <= nArgs; i++){
			namesParams.AddLast(context.ID(i).GetText());
		}

		MyFunction var = new MyFunction(id, nArgs, namesParams, context.body_return() );
		queue.Last().Add(id,var);

		return null;
	}


	public override object VisitFunction_call(FaParser.Function_callContext context){
		String id = context.ID().GetText();
		object instance = Exist (id);

		if (context.expression() != null){
			int nparams = context.expression().Length;

			if (instance is MyFunction){
				MyFunction func = (MyFunction) instance;

				if (nparams == func.nparams){
					Dictionary<string, Instance> memAmbit = new Dictionary<string, Instance>();
					for (int i = 0; i < nparams; i++){
						object value = Visit(context.expression(i));
						MyVariable xvar = new MyVariable(func.namesParams.ElementAt(i), getType(value), value);
						memAmbit.Add(func.namesParams.ElementAt(i), xvar);
					}
					queue.AddLast(memAmbit);
					// Tebug.Log("queue: "+ PrintQueue(queue)) ;
					object res = Visit((IParseTree) func.instructions);
					// Tebug.Log(" EVALUADO 3 : " + (string)res);
					queue.RemoveLast();
					return res == null ? (object) "nada" : res;
				}else{
					Debug.LogError("Esta funcion recibe un número diferente de parametros");
					// Console.WriteLine("Esta funcion recibe un número diferente de parametros");
					MyConsole.main.AppendText("Esta funcion recibe un número diferente de parametros");
				}
			} else{
				Debug.LogError("Este ID no pertenece a una funcion");
				// Console.WriteLine("Este ID no pertenece a una funcion");
				MyConsole.main.AppendText("Este ID no pertenece a una funcion");
			}
		} else{
			if (instance is MyFunction){
				MyFunction func = (MyFunction) instance;
				if (func.nparams == 0){
					Dictionary<string, Instance> memAmbit = new Dictionary<string, Instance>();
					queue.AddLast(memAmbit);
					object res = Visit((IParseTree) func.instructions);
					// Tebug.Log(" EVALUADO 4	 : " + res);
					queue.RemoveLast();
					return res == null ? (object) "nada" : res;
				}
				else{
					Debug.LogError("Se esperaban cero parametros para esta func.");
					// Console.WriteLine("Se esperaban cero parametros para esta func.");
					MyConsole.main.AppendText("Se esperaban cero parametros para esta func.");
				}
			}
			else{
				Debug.LogError("No ha sido declarada una funcion con este nombre");
				// Console.WriteLine("No ha sido declarada una funcion con este nombre");
				MyConsole.main.AppendText("No ha sido declarada una funcion con este nombre");
			}
		}

		return null;
	}

	public override object VisitReturn_regular(FaParser.Return_regularContext context){
		if (context.expression() == null)
			return null; //TODO : solucionar responde "nada"
		// string result = (string) Visit(context.expression());
		// Tebug.Log(" EVALUADO: " + result);
		// return result;
		return Visit(context.expression());
	}

	//######################
	// IF's
	//######################
	public override object VisitIf_regular(FaParser.If_regularContext context){
		int nExpressions = context.expression().Length;
		bool thrown = false;
		for (int i = 0; i < nExpressions; i++){
			object valueExp = VisitExpression( context.expression(i) );
			if (getType(valueExp) == 0){
				if ((bool) valueExp){
					Visit(context.body_regular(i));
					thrown = true;
					break;
				}
			}else{
				Debug.LogError("La expresión a evaluar debe ser booleana");
				// Console.WriteLine("La expresión a evaluar debe ser booleana");
				MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_regular().Length > nExpressions && !thrown){
			Visit(context.body_regular(context.body_regular().Length - 1));
		}
		return null;
	}
	
	public override object VisitIf_return(FaParser.If_returnContext context){
		int nExpressions = context.expression().Length;
		object result = null;
		bool thrown = false;
		for (int i = 0; i < nExpressions; i++){
			object valueExp = VisitExpression( context.expression(i) );
			if (getType(valueExp) == 0){
				if ((bool) valueExp){
					result = Visit(context.body_return(i));
					thrown = true;
					break;
				}

			}else{
				Debug.LogError("La expresión a evaluar debe ser booleana");
				// Console.WriteLine("La expresión a evaluar debe ser booleana");
				MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_return().Length > nExpressions && !thrown){
			result = Visit(context.body_return(context.body_return().Length - 1));
		}
		return result;
	}


	public override object VisitIf_break_continue(FaParser.If_break_continueContext context)
	{
		int nExpressions = context.expression().Length;
		object result = null;
		bool thrown = false;
		for (int i = 0; i < nExpressions; i++){
			object valueExp = VisitExpression( context.expression(i) );
			if (getType(valueExp) == 0){
				if ((bool) valueExp){
					result = Visit(context.body_break_continue(i));
					thrown = true;
					break;
				}

			}else{
				Debug.LogError("La expresión a evaluar debe ser booleana");
				// Console.WriteLine("La expresión a evaluar debe ser booleana");
				MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_break_continue().Length > nExpressions && !thrown){
			result = Visit(context.body_break_continue(context.body_break_continue().Length - 1));
		}
		return result;
	}


	public override object VisitIf_return_break_continue(FaParser.If_return_break_continueContext context)
	{
		int nExpressions = context.expression().Length;
		object result = null;
		bool thrown = false;
		for (int i = 0; i < nExpressions; i++){
			object valueExp = VisitExpression( context.expression(i) );
			if (getType(valueExp) == 0){
				if ((bool) valueExp){
					result = Visit(context.body_return_break_continue(i));
					thrown = true;
					break;
				}

			}else{
				Debug.LogError("La expresión a evaluar debe ser booleana");
				// Console.WriteLine("La expresión a evaluar debe ser booleana");
				MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_return_break_continue().Length > nExpressions && !thrown){
			result = Visit(context.body_return_break_continue(context.body_return_break_continue().Length - 1));
		}
//		Console.WriteLine("SE OBTIENE PARA ifbrc directo: "+result);
		return result;
	}
	
	
	
	//######################
	// SWITCH's
	//######################

	 public override object VisitSwitch_regular(FaParser.Switch_regularContext context)
	 {
		 int nCases = context.dataType().Length;
		 string id = context.ID().GetText();
		 bool thrown = false;
		 if (Exist(id) is MyVariable)  //TODO : agregar array
		 {
			 object value = ((MyVariable) Exist(id)).value;
			 for (int i = 0; i < nCases; i++){
				 object caseValue = VisitDataType( context.dataType(i) );
				 if (caseValue.GetType() == value.GetType() && caseValue == value)
				 {
					 Visit(context.body_regular(i));
					 thrown = true;
					 break;
				 }

			 }
			 if (context.body_regular().Length > nCases && !thrown){
				 Visit(context.body_regular(context.body_regular().Length - 1));
			 }
		 }
		 return null;
	 }



	public override object VisitSwitch_return(FaParser.Switch_returnContext context)
	{
		int nCases = context.dataType().Length;
		string id = context.ID().GetText();
		bool thrown = false;
		object result = null;
		if (Exist(id) is MyVariable)  //TODO : agregar array
		{
			object value = ((MyVariable) Exist(id)).value;
			for (int i = 0; i < nCases; i++){
				object caseValue = VisitDataType( context.dataType(i) );
				if ( caseValue.GetType() == value.GetType() && caseValue == value  ){
					result = Visit(context.body_return(i));
					thrown = true;
					break;
				}
//				else{
//					Debug.LogError("La expresión a evaluar debe ser booleana");
//					// Console.WriteLine("La expresión a evaluar debe ser booleana");
//					MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
//					break;
//				}
			}
			if (context.body_return().Length > nCases && !thrown){
				result = Visit(context.body_return(context.body_return().Length - 1));
			}
		}
		return result;
	}
	

	public override object VisitSwitch_break_continue(FaParser.Switch_break_continueContext context)
	{
		int nCases = context.dataType().Length;
		string id = context.ID().GetText();
		bool thrown = false;
		object result = null;
		if (Exist(id) is MyVariable)  //TODO : agregar array
		{
			object value = ((MyVariable) Exist(id)).value;
			for (int i = 0; i < nCases; i++){
				object caseValue = VisitDataType( context.dataType(i) );
				if ( caseValue.GetType() == value.GetType() && caseValue == value  ){
					result = Visit(context.body_break_continue(i));
					thrown = true;
					break;
				}
//				else{
//					Debug.LogError("La expresión a evaluar debe ser booleana");
//					// Console.WriteLine("La expresión a evaluar debe ser booleana");
//					MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
//					break;
//				}
			}
			if (context.body_break_continue().Length > nCases && !thrown){
				result = Visit(context.body_break_continue(context.body_break_continue().Length - 1));
			}
		}
		return result;
	}

	public override object VisitSwitch_return_break_continue(FaParser.Switch_return_break_continueContext context)
	{
		int nCases = context.dataType().Length;
		string id = context.ID().GetText();
		bool thrown = false;
		object result = null;
		if (Exist(id) is MyVariable)  //TODO : agregar array
		{
			object value = ((MyVariable) Exist(id)).value;
			for (int i = 0; i < nCases; i++){
				object caseValue = VisitDataType( context.dataType(i) );
				if ( caseValue.GetType() == value.GetType() && caseValue == value  ){
					result = Visit(context.body_return_break_continue(i));
					thrown = true;
					break;
				}
//				else{
//					Debug.LogError("La expresión a evaluar debe ser booleana");
//					// Console.WriteLine("La expresión a evaluar debe ser booleana");
//					MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
//					break;
//				}
			}
			if (context.body_return_break_continue().Length > nCases && !thrown){
				result = Visit(context.body_return_break_continue(context.body_return_break_continue().Length - 1));
			}
		}
		return result;
	}

	//######################
	// CICLES
	//######################
	public override object VisitWhile_regular(FaParser.While_regularContext context)
	{
		object valueExp = VisitExpression( context.expression() );
		int limit = 500;
		int cicles = 0;
		if (valueExp is bool)
		{

			while((bool)valueExp)
			{
				object resp = Visit(context.body_break_continue());
				if (resp is float)
				{
					if ((float) resp == (float)1.1)
					{
						break;
					}
					else
					{
						// Debug.Log("PINCHE MIERDAAAAAAAAAAAAAA!");
						//Console.WriteLine("PINCHE MIERDAAAAAAAAAAAAAA!");
					}
				}
				valueExp = VisitExpression( context.expression() );
				cicles++;
				if(cicles > limit){
					break;
				}
			}

		}
		else
		{
			Debug.LogError("No es una expresion booleana para while");
			// Console.WriteLine("No es una expresion booleana para while");
			MyConsole.main.AppendText("No es una expresion booleana para while");
		}
		return null;
	}

	public override object VisitWhile_return(FaParser.While_returnContext context)
	{
		object valueExp = VisitExpression( context.expression() );

		if (valueExp is bool)
		{

			while((bool)valueExp)
			{
				object resp = Visit(context.body_return_break_continue());
				if (resp is float)
				{
					if ((float) resp == (float)1.1)
					{	
						break;
					}

				}else if (resp != null)
				{
					return resp;
				}
				valueExp = VisitExpression( context.expression() );
			}

		}
		else
		{
			Debug.LogError("No es una expresion booleana para while.(r)");
			// Console.WriteLine("No es una expresion booleana para while.(r)");
			MyConsole.main.AppendText("No es una expresion booleana para while.(r)");
		}
		return null;
	}

	//######################
	// BODIES
	//######################


	public override object VisitBodyPrint(FaParser.BodyPrintContext context){
		VisitPrint(context.print());
		return null;
	}

	public override object VisitBodyFunctionCall(FaParser.BodyFunctionCallContext context){
		VisitFunction_call(context.function_call());
		return null;
	}

	public override object VisitBodyAssignVariable(FaParser.BodyAssignVariableContext context){
		string id = context.ID().GetText();
		object value = VisitExpression(context.expression());
		MyVariable var = new MyVariable(id, getType(value),value);
		object varExist = ExistInLast(id);
		if (varExist != null){
			if (!(varExist is MyFunction)){
				queue.Last()[id] = var;
			}
			else{
				Debug.LogError("Este identificador ya ha sido asignado a una funcion");
				// Console.WriteLine("Este identificador ya ha sido asignado a una funcion");
				MyConsole.main.AppendText("Este identificador ya ha sido asignado a una funcion");
			}
		}
		else{
			queue.Last().Add(id,var);
		}
		return null;
	}

	public override object VisitBodyArrayPosition(FaParser.BodyArrayPositionContext context){
		//Assign position of array
		string id = context.ID().GetText();
		object position = VisitExpression(context.expression(0));

		if (!(position is int)){
			position = 0;
			Debug.LogError("La posición debe ser de tipo entero");
			// Console.WriteLine("La posición debe ser de tipo entero");
			MyConsole.main.AppendText("La posición debe ser de tipo entero");
		}
		else{
			object value = VisitExpression(context.expression(1));
			object arrExist = ExistInLast(id);
			if (arrExist is MyArray){
				((MyArray) arrExist).setValue((int)position, value);
			}else{
				Debug.LogError("Array con este identificador no ha sido declarado");
				// Console.WriteLine("Array con este identificador no ha sido declarado");
				MyConsole.main.AppendText("Array con este identificador no ha sido declarado");
			}
		}
		return null;
	}
	

	public override object VisitBodyArrayDeclaration(FaParser.BodyArrayDeclarationContext context){
		string id = context.ID().GetText();
		
//		int position = Convert.ToInt32( context.INTEGER().GetText() );
		object size = VisitExpression(context.expression());
		
		if (size is int){
			MyArray var = new MyArray(id, (int) size);
			object varExist = ExistInLast(id);
			if (varExist != null){
				if (!(varExist is MyFunction)){
					queue.Last()[id] = var;
				}
				else{
					Debug.LogError("Este identificador ya ha sido asignado a una funcion");
					// Console.WriteLine("Este identificador ya ha sido asignado a una funcion");
					MyConsole.main.AppendText("Este identificador ya ha sido asignado a una funcion");
				}
			}
			else{
				queue.Last().Add(id, var);
			}
		}
		else{			
			Debug.LogError("El tamaño de la lista de be ser un entero");
			// Console.WriteLine("El tamaño de la lista de be ser un entero");
			MyConsole.main.AppendText("El tamaño de la lista de be ser un entero");
		}		
		return null;
	}


	public override object VisitBody_returnBody(FaParser.Body_returnBodyContext context){
		Visit(context.body());
		return Visit(context.body_return());
	}
	
	
	public override object VisitBody_returnReturnregular(FaParser.Body_returnReturnregularContext context){
		return VisitReturn_regular(context.return_regular());
	}

	public override object VisitBody_RBC_Return(FaParser.Body_RBC_ReturnContext context) {
		return VisitReturn_regular(context.return_regular());
	}

	public override object VisitBody_returnIfReturn(FaParser.Body_returnIfReturnContext context){
		object result = VisitIf_return(context.if_return());
		if ( result == null){
			result = Visit(context.body_return());
		}
		return result;
	}

	public override object VisitBody_BC_IfBC(FaParser.Body_BC_IfBCContext context)
	{
		object result = VisitIf_break_continue(context.if_break_continue());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_RBC_IfRBC(FaParser.Body_RBC_IfRBCContext context)
	{
		object result = VisitIf_return_break_continue(context.if_return_break_continue());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}

	public override object VisitBody_BC_Body(FaParser.Body_BC_BodyContext context)
	{	
		object result = Visit(context.body());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_BC_BC(FaParser.Body_BC_BCContext context)
	{
		if (context.bc.Text == "interrumpir")
		{
			return (float)1.1;
		}
		if (context.bc.Text == "saltar")
		{
			return (float)1.0;
		}

		return Visit(context.body_break_continue());
	}


	public override object VisitBody_RBC_BC(FaParser.Body_RBC_BCContext context)
	{
		if (context.bc.Text == "interrumpir")
		{
			return (float)1.1;
		}
		if (context.bc.Text == "saltar")
		{
			return (float)1.0;
		}

		return Visit(context.body_return_break_continue());
	}

	public override object VisitBody_RBC_Body(FaParser.Body_RBC_BodyContext context)
	{
		object result = Visit(context.body());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}

	public override object VisitBody_returWhileReturn(FaParser.Body_returWhileReturnContext context)
	{
		object result = VisitWhile_return(context.while_return());
		if ( result == null){
			result = Visit(context.body_return());
		}
		return result;
	}

	public override object VisitBody_returnSwitchReturn(FaParser.Body_returnSwitchReturnContext context)
	{
		object result = VisitSwitch_return(context.switch_return());
		if ( result == null){
			result = Visit(context.body_return());
		}
		return result;
	}

	public override object VisitBody_BC_WhileRegular(FaParser.Body_BC_WhileRegularContext context)
	{
		object result = VisitWhile_regular(context.while_regular());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_BC_SwitchBC(FaParser.Body_BC_SwitchBCContext context)
	{
		object result = VisitSwitch_break_continue(context.switch_break_continue());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_RBC_WhileReturn(FaParser.Body_RBC_WhileReturnContext context)
	{
		object result = VisitWhile_return(context.while_return());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}

	public override object VisitBody_RBC_SwitchRBC(FaParser.Body_RBC_SwitchRBCContext context)
	{
		object result = VisitSwitch_return_break_continue(context.switch_return_break_continue());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}
	
	
}

