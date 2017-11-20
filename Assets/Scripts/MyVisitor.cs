using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Antlr4.Runtime.Tree;

using Utils;

public class MyVisitor : GrammarBaseVisitor<System.Object>{

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
		// Debug.LogError("Variable "+id+" no existe en ningún contexto.");
		Console.WriteLine("Variable "+id+" no existe en ningún contexto.");
		// MyConsole.main.AppendText("Variable "+id+" no existe en ningún contexto.");
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

	public override object VisitPrint(GrammarParser.PrintContext context){
		// Debug.Log(Visit(context.expression()));
		Console.WriteLine(Visit(context.expression()));
		// MyConsole.main.AppendText(""+Visit(context.expression())); 
		return null;
	}



	public override object VisitPrincipal(GrammarParser.PrincipalContext context){
		queue.AddLast(memory);
		return VisitChildren(context);
	}

	public override object VisitDataType(GrammarParser.DataTypeContext context){
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

	public override object VisitArrayPosition(GrammarParser.ArrayPositionContext context)
	{
		object result = null;
		string id = context.ID().GetText();
		object position = VisitExpression(context.expression());
		if (position is int)
		{
			//TODO: obtener la posicion del array
		}
		else
		{
//			Debug.LogError("Debe consultarse con un tipo de dato entero");
			Console.WriteLine("Debe consultarse con un tipo de dato entero");
//			MyConsole.main("Debe consultarse con un tipo de dato entero");
		}
		return result;
	}

	public override object VisitArraysize(GrammarParser.ArraysizeContext context)
	{
		object result = null;

		return result;

	}


	//######################
	// EXPRESSIONS
	//######################
	
	public override object VisitExpression(GrammarParser.ExpressionContext context){
		return Visit(context.expressionContent());

	}

	public override object VisitExpressionContentSumOrNeg(GrammarParser.ExpressionContentSumOrNegContext context){
		// Tebug.Log("v Suma Resta");
        object left = Visit(context.expressionContent(0));
        object right = Visit(context.expressionContent(1));
        bool isSum =  context.SUM() != null  ;

		object result = null;
		if (left is bool   || right is bool){
			// Debug.LogError("No es posible aplicar el símbolo"+(isSum? "+":"-")+"a un booleano");
			Console.WriteLine("No es posible aplicar el símbolo"+(isSum? "+":"-")+"a un booleano");
			// MyConsole.main.AppendText("No es posible aplicar el símbolo"+(isSum? "+":"-")+"a un booleano");
			return null;
		}
		if (left is string || right is string){
			if (!isSum){
				// Debug.LogError("No es posible aplicar el operador - a strings");
				Console.WriteLine("No es posible aplicar el operador - a strings");
				// MyConsole.main.AppendText("No es posible aplicar el operador - a strings");
			}else
				result = left.ToString() + right.ToString();
		}else{
			if (left is double || right is double)
				result = isSum? Convert.ToDouble(left) + Convert.ToDouble(right) : Convert.ToDouble(left) - Convert.ToDouble(right);
			else if (left is int || right is int)
				result = isSum? (int) left + (int) right :(int) left - (int) right;
			else{
				// Debug.LogError("Llegaron valores de tipo desconocido");
				Console.WriteLine("Llegaron valores de tipo desconocido");
				// MyConsole.main.AppendText("Llegaron valores de tipo desconocido");
			}
		}

		return result;
	}

	public override object VisitExpressionContentNot(GrammarParser.ExpressionContentNotContext context){
        object value = Visit(context.expressionContent());
		if ( value is bool)
			return  ! (bool) value ;

		// Debug.LogError("Operador ! sólo es aplicable a booleano");
		Console.WriteLine("Operador ! sólo es aplicable a booleano");
		// MyConsole.main.AppendText("Operador ! sólo es aplicable a booleano");
		return null;
	}

	public override object VisitExpressionContentID(GrammarParser.ExpressionContentIDContext context){
		string id = context.ID().GetText();
		if (Exist(id) is MyVariable){
			return ((MyVariable) Exist(id)).value;
		}
		return base.VisitExpressionContentID(context);
	}

	public override object VisitExpressionContentParenthesis(GrammarParser.ExpressionContentParenthesisContext context){
		return Visit(context.expressionContent());
	}

	public override object VisitExpressionContentNegative(GrammarParser.ExpressionContentNegativeContext context){
		object expToNegate = Visit(context.expressionContent());
		object result = null;
		if (expToNegate is double)
			result = - Convert.ToDouble(expToNegate);
		if (expToNegate is int)
			result = - (int)expToNegate;
		if (expToNegate is string || expToNegate is bool){
			// Debug.LogError("No es posible aplicar el operador - a string o bool");
			Console.WriteLine("No es posible aplicar el operador - a string o bool");
			// MyConsole.main.AppendText("No es posible aplicar el operador - a string o bool");
		}

		return result;
	}

	public override object VisitExpressionContentRelational(GrammarParser.ExpressionContentRelationalContext context){

		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		bool leftIsNum  = left   is int || left  is double;
		bool rigthIsNum =  right is int || right is double;
		bool areNums = leftIsNum &&  rigthIsNum;
		bool areStrgs = left is string &&  right is string;

		object result  =  null;

		switch (context.RELATIONAL().GetText() ) {
		    case "menorque":
		    	if(areNums){
		    		result = Convert.ToDouble(left) < Convert.ToDouble(right);
		    	}
		    	else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) < 0;
	    		else {
	    			// Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "menorigual":
		    	if(areNums)
		    		result = Convert.ToDouble(left) <= Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) <= 0;
	    		else {
	    			// Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "mayorque":
		    	if(areNums)
		    		result = Convert.ToDouble(left) > Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) > 0;
	    		else {
	    			// Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "mayorigual":
		    	if(areNums)
		    		result =Convert.ToDouble(left) >= Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) >= 0;
	    		else {
	    			// Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		     	break;
		}

		return result;
	}

	public override object VisitExpressionContentequality(GrammarParser.ExpressionContentequalityContext context){

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
	    			// Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		    case "diferente":
		    	if(areNums)
		    		result = Convert.ToDouble(left) != Convert.ToDouble(right);
	    		else if(areStrgs)
		    		result = String.Compare(left.ToString(), right.ToString()) <= 0;
	    		else {
	    			// Debug.LogError("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			Console.WriteLine("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    			// MyConsole.main.AppendText("No es posible hacer esta operacion relacional entre estos tipos de dato");
	    		}
		      	break;
		}

		return result;
	}

	public override object VisitExpressionContentAnd(GrammarParser.ExpressionContentAndContext context){
		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		object result = null;

		if (left is bool && right is bool)
			result = (bool) left && (bool) right;
		else{
			// Debug.LogError("No se puede aplicar && a tipos no booleanos");
			Console.WriteLine("No se puede aplicar && a tipos no booleanos");
			// MyConsole.main.AppendText("No se puede aplicar && a tipos no booleanos");
		}

		return result;
	}

	public override object VisitExpressionContentContentOr(GrammarParser.ExpressionContentContentOrContext context){

		object left = Visit(context.expressionContent(0));
		object right = Visit(context.expressionContent(1));
		object result = null;

		if (left is bool && right is bool)
			result = (bool) left || (bool) right;
		else{
			// Debug.LogError("No se puede aplicar && a tipos no booleanos");
			Console.WriteLine("No se puede aplicar && a tipos no booleanos");
			// MyConsole.main.AppendText("No se puede aplicar && a tipos no booleanos");
		}

		return result;

	}

	public override object VisitExpressionContentMul(GrammarParser.ExpressionContentMulContext context){
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
			// Debug.LogError("Error en división por cero");
			Console.WriteLine("Error en división por cero");
			// MyConsole.main.AppendText("Error en división por cero");
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


	public override object VisitExpressionContentFunctionCall(GrammarParser.ExpressionContentFunctionCallContext context){
		return VisitFunction_call(context.function_call());
	}

	//TODO : expresionContentArrayPosition
	
	//######################
	// FUNCTIONS
	//######################
	public override object VisitFunction(GrammarParser.FunctionContext context){

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


	public override object VisitFunction_call(GrammarParser.Function_callContext context){
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
					// Debug.LogError("Esta funcion recibe un número diferente de parametros");
					Console.WriteLine("Esta funcion recibe un número diferente de parametros");
					// MyConsole.main.AppendText("Esta funcion recibe un número diferente de parametros");
				}
			} else{
				// Debug.LogError("Este ID no pertenece a una funcion");
				Console.WriteLine("Este ID no pertenece a una funcion");
				// MyConsole.main.AppendText("Este ID no pertenece a una funcion");
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
					// Debug.LogError("Se esperaban cero parametros para esta func.");
					Console.WriteLine("Se esperaban cero parametros para esta func.");
					// MyConsole.main.AppendText("Se esperaban cero parametros para esta func.");
				}
			}
			else{
				// Debug.LogError("No ha sido declarada una funcion con este nombre");
				Console.WriteLine("No ha sido declarada una funcion con este nombre");
				// MyConsole.main.AppendText("No ha sido declarada una funcion con este nombre");
			}
		}

		return null;
	}

	public override object VisitReturn_regular(GrammarParser.Return_regularContext context){
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
	public override object VisitIf_regular(GrammarParser.If_regularContext context){
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
				// Debug.LogError("La expresión a evaluar debe ser booleana");
				Console.WriteLine("La expresión a evaluar debe ser booleana");
				// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_regular().Length > nExpressions && !thrown){
			Visit(context.body_regular(context.body_regular().Length - 1));
		}
		return null;
	}
	
	public override object VisitIf_return(GrammarParser.If_returnContext context){
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
				// Debug.LogError("La expresión a evaluar debe ser booleana");
				Console.WriteLine("La expresión a evaluar debe ser booleana");
				// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_return().Length > nExpressions && !thrown){
			result = Visit(context.body_return(context.body_return().Length - 1));
		}
		return result;
	}


	public override object VisitIf_break_continue(GrammarParser.If_break_continueContext context)
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
				// Debug.LogError("La expresión a evaluar debe ser booleana");
				Console.WriteLine("La expresión a evaluar debe ser booleana");
				// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
				break;
			}
		}
		if (context.body_break_continue().Length > nExpressions && !thrown){
			result = Visit(context.body_break_continue(context.body_break_continue().Length - 1));
		}
		return result;
	}


	public override object VisitIf_return_break_continue(GrammarParser.If_return_break_continueContext context)
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
				// Debug.LogError("La expresión a evaluar debe ser booleana");
				Console.WriteLine("La expresión a evaluar debe ser booleana");
				// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
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

	 public override object VisitSwitch_regular(GrammarParser.Switch_regularContext context)
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



	public override object VisitSwitch_return(GrammarParser.Switch_returnContext context)
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
				}else{
					// Debug.LogError("La expresión a evaluar debe ser booleana");
					Console.WriteLine("La expresión a evaluar debe ser booleana");
					// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
					break;
				}
			}
			if (context.body_return().Length > nCases && !thrown){
				result = Visit(context.body_return(context.body_return().Length - 1));
			}
		}
		return result;
	}
	

	public override object VisitSwitch_break_continue(GrammarParser.Switch_break_continueContext context)
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
				}else{
					// Debug.LogError("La expresión a evaluar debe ser booleana");
					Console.WriteLine("La expresión a evaluar debe ser booleana");
					// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
					break;
				}
			}
			if (context.body_break_continue().Length > nCases && !thrown){
				result = Visit(context.body_break_continue(context.body_break_continue().Length - 1));
			}
		}
		return result;
	}

	public override object VisitSwitch_return_break_continue(GrammarParser.Switch_return_break_continueContext context)
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
				}else{
					// Debug.LogError("La expresión a evaluar debe ser booleana");
					Console.WriteLine("La expresión a evaluar debe ser booleana");
					// MyConsole.main.AppendText("La expresión a evaluar debe ser booleana");	
					break;
				}
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
	public override object VisitWhile_regular(GrammarParser.While_regularContext context)
	{
		object valueExp = VisitExpression( context.expression() );

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
			}

		}
		else
		{
			// Debug.LogError("No es una expresion booleana para while");
			Console.WriteLine("No es una expresion booleana para while");
		}
		return null;
	}

	public override object VisitWhile_return(GrammarParser.While_returnContext context)
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
			// Debug.LogError("No es una expresion booleana para while");
			Console.WriteLine("No es una expresion booleana para while");
		}
		return null;
	}

	//######################
	// BODIES
	//######################
	
	public override object VisitBody(GrammarParser.BodyContext context){
		if (context.print() != null){
			VisitPrint(context.print());
		}else if (context.function_call() != null){
			VisitFunction_call(context.function_call());
		}else if (context.expression() != null){
			// Teb ug.Log("v ASIGNAR VARIABLE");
			string id = context.ID().GetText();
			object value = VisitExpression(context.expression());
			MyVariable var = new MyVariable(id, getType(value),value);
			object varExist = ExistInLast(id);
			if (varExist != null)
			{
				if (!(varExist is MyFunction))
				{
					queue.Last()[id] = var;
				}
			}
			else
			{
				queue.Last().Add(id,var);
			}
		}

		return null;
	}
	
	
	public override object VisitBody_returnBody(GrammarParser.Body_returnBodyContext context){
		VisitBody(context.body());
		return Visit(context.body_return());
	}
	
	
	public override object VisitBody_returnReturnregular(GrammarParser.Body_returnReturnregularContext context){
		return VisitReturn_regular(context.return_regular());
	}

	public override object VisitBody_RBC_Return(GrammarParser.Body_RBC_ReturnContext context)
	{
		return VisitReturn_regular(context.return_regular());
	}

	public override object VisitBody_returnIfReturn(GrammarParser.Body_returnIfReturnContext context){
		object result = VisitIf_return(context.if_return());
		if ( result == null){
			result = Visit(context.body_return());
		}
		return result;
	}

	public override object VisitBody_BC_IfBC(GrammarParser.Body_BC_IfBCContext context)
	{
		object result = VisitIf_break_continue(context.if_break_continue());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_RBC_IfRBC(GrammarParser.Body_RBC_IfRBCContext context)
	{
		object result = VisitIf_return_break_continue(context.if_return_break_continue());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
//		Console.WriteLine("SE OBTUVO para body if RBC: "+result);
		return result;
	}

	public override object VisitBody_BC_Body(GrammarParser.Body_BC_BodyContext context)
	{	
		object result = VisitBody(context.body());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_BC_BC(GrammarParser.Body_BC_BCContext context)
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


	public override object VisitBody_RBC_BC(GrammarParser.Body_RBC_BCContext context)
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

	public override object VisitBody_RBC_Body(GrammarParser.Body_RBC_BodyContext context)
	{
		object result = VisitBody(context.body());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}

	public override object VisitBody_returWhileReturn(GrammarParser.Body_returWhileReturnContext context)
	{
		object result = VisitWhile_return(context.while_return());
		if ( result == null){
			result = Visit(context.body_return());
		}
		return result;
	}

	public override object VisitBody_returnSwitchReturn(GrammarParser.Body_returnSwitchReturnContext context)
	{
		object result = VisitSwitch_return(context.switch_return());
		if ( result == null){
			result = Visit(context.body_return());
		}
		return result;
	}

	public override object VisitBody_BC_WhileRegular(GrammarParser.Body_BC_WhileRegularContext context)
	{
		object result = VisitWhile_regular(context.while_regular());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_BC_SwitchBC(GrammarParser.Body_BC_SwitchBCContext context)
	{
		object result = VisitSwitch_break_continue(context.switch_break_continue());
		if ( result == null){
			result = Visit(context.body_break_continue());
		}
		return result;
	}

	public override object VisitBody_RBC_WhileReturn(GrammarParser.Body_RBC_WhileReturnContext context)
	{
		object result = VisitWhile_return(context.while_return());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}

	public override object VisitBody_RBC_SwitchRBC(GrammarParser.Body_RBC_SwitchRBCContext context)
	{
		object result = VisitSwitch_return_break_continue(context.switch_return_break_continue());
		if ( result == null){
			result = Visit(context.body_return_break_continue());
		}
		return result;
	}
	
	
}

