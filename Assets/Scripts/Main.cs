using Antlr4.Runtime;
using Antlr4.Runtime.Misc;	
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour {





	public void EvalCode(Text textObj){
	
		CustomErrorListener errorListener = new CustomErrorListener(false);
		AntlrInputStream inputStream = new AntlrInputStream(textObj.text);
	    GrammarLexer GrammarLexer = new GrammarLexer(inputStream);
	    CommonTokenStream commonTokenStream = new CommonTokenStream(GrammarLexer);
	    GrammarParser parser = new GrammarParser(commonTokenStream);

		parser.AddErrorListener(errorListener);

	    GrammarParser.PrincipalContext context = parser.principal();
	    MyVisitor loader = new MyVisitor();
		loader.Visit(context);


	}
	

}
