using Antlr4.Runtime;
using Antlr4.Runtime.Misc;	
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fa : Singleton<Fa> {


	public void EvalCode(string code){
		// Debug.Log("Solicitado:  "+code);
		CustomErrorListener errorListener = new CustomErrorListener(false);
		AntlrInputStream inputStream = new AntlrInputStream(code);
	    FaLexer FaLexer = new FaLexer(inputStream);
	    CommonTokenStream commonTokenStream = new CommonTokenStream(FaLexer);
	    FaParser parser = new FaParser(commonTokenStream);

		parser.AddErrorListener(errorListener);

	    FaParser.PrincipalContext context = parser.principal();
	    MyVisitor loader = new MyVisitor();
		loader.Visit(context);
		
	}
	public void EvalFromTxtComponent(InputField tcpm){
		EvalCode(tcpm.text);
	}


}
