﻿/* *********************************************************
FileName: CustomErrorListener.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
         Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Sharpen;
using UnityEngine;


public class CustomErrorListener : DiagnosticErrorListener {
    private readonly List<string> _errorMessages = new List<string>();
    public IList<string> ErrorMessages { get { return _errorMessages; } }

    private readonly List<string> _warningMessages = new List<string>();
    public IList<string> WarningMessages { get { return _warningMessages; } }

    public bool HasErrors { get { return _errorMessages.Count > 0; } }
    public bool HasWarnings { get { return _warningMessages.Count > 0; } }

    private readonly bool _captureDiagnostics;

    public CustomErrorListener(bool captureDiagnosticWarnings) {
        _captureDiagnostics = captureDiagnosticWarnings;
    }


   public override void SyntaxError(TextWriter jaja, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, String msg, RecognitionException e) {
        _errorMessages.Add(string.Format("line {0}:{1} {2} at: {3}", line, charPositionInLine, msg, offendingSymbol.Text));
        Debug.Log(string.Format("line {0}:{1} {2} at: {3}", line, charPositionInLine, msg, offendingSymbol.Text));
        MyConsole.main.AppendText(string.Format("line {0}:{1} {2} at: {3}", line, charPositionInLine, msg, offendingSymbol.Text));
    }


    public override void ReportAmbiguity(Parser recognizer, Antlr4.Runtime.Dfa.DFA dfa, int startIndex, int stopIndex, bool exact, Antlr4.Runtime.Sharpen.BitSet  ambigAlts, Antlr4.Runtime.Atn.ATNConfigSet configs) {
        if (_captureDiagnostics) {
            _warningMessages.Add(string.Format("reportAmbiguity d={0}: ambigAlts={1}, input='{2}'", GetDecisionDescription(recognizer, dfa), GetConflictingAlts(ambigAlts, configs), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
            Debug.Log(string.Format("reportAmbiguity d={0}: ambigAlts={1}, input='{2}'", GetDecisionDescription(recognizer, dfa), GetConflictingAlts(ambigAlts, configs), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
            MyConsole.main.AppendText(string.Format("reportAmbiguity d={0}: ambigAlts={1}, input='{2}'", GetDecisionDescription(recognizer, dfa), GetConflictingAlts(ambigAlts, configs), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
        }
    }

    public override void ReportAttemptingFullContext(Parser recognizer, Antlr4.Runtime.Dfa.DFA dfa, int startIndex, int stopIndex, Antlr4.Runtime.Sharpen.BitSet conflictingAlts, Antlr4.Runtime.Atn.SimulatorState conflictState) {
        if (_captureDiagnostics) {
            _warningMessages.Add(string.Format("reportAttemptingFullContext d={0}, input='{1}'", GetDecisionDescription(recognizer, dfa), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
            Debug.Log(string.Format("reportAttemptingFullContext d={0}, input='{1}'", GetDecisionDescription(recognizer, dfa), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
            MyConsole.main.AppendText(string.Format("reportAttemptingFullContext d={0}, input='{1}'", GetDecisionDescription(recognizer, dfa), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
        }
    }

    public override void ReportContextSensitivity(Parser recognizer, Antlr4.Runtime.Dfa.DFA dfa, int startIndex, int stopIndex, int prediction, Antlr4.Runtime.Atn.SimulatorState acceptState) {
        if (_captureDiagnostics) {
            _warningMessages.Add(string.Format("reportContextSensitivity d={0}, input='{1}'", GetDecisionDescription(recognizer, dfa), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
            Debug.Log(string.Format("reportContextSensitivity d={0}, input='{1}'", GetDecisionDescription(recognizer, dfa), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
            MyConsole.main.AppendText(string.Format("reportContextSensitivity d={0}, input='{1}'", GetDecisionDescription(recognizer, dfa), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex, stopIndex))));
        }
    }
}