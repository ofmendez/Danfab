//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/ofmendez/DataDocs/Work/Ubuntu/LENGUAJES/Danfab/projectUnity/Danfab/Assets/Antlr4/Fa.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class FaLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		TRUE=25, FALSE=26, NOT=27, RELATIONAL=28, EQUALITY_NUMERIC=29, AND=30, 
		OR=31, ID=32, COMMENT=33, DOUBLE=34, INTEGER=35, STRING=36, MUL=37, SUM=38, 
		NEGATIVE=39, WS=40, ErrorChar=41;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "TRUE", 
		"FALSE", "NOT", "RELATIONAL", "EQUALITY_NUMERIC", "AND", "OR", "ID", "COMMENT", 
		"DOUBLE", "INTEGER", "STRING", "MUL", "SUM", "NEGATIVE", "WS", "ErrorChar"
	};


	public FaLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public FaLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'usa'", "'nada'", "','", "'en'", "'imprima'", "'tama\u00F1o'", 
		"'de'", "'si'", "'entonces'", "'o_si'", "'sino'", "'fin'", "'cuando'", 
		"'escoge'", "'caso'", "'mientras'", "'como'", "':'", "'lista'", "'responde'", 
		"'interrumpir'", "'continuar'", "'('", "')'", "'verdadero'", "'falso'", 
		"'negar'", null, null, "'y_logico'", "'o_logico'", null, null, null, null, 
		null, null, "'+'", "'-'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "TRUE", "FALSE", "NOT", "RELATIONAL", "EQUALITY_NUMERIC", "AND", 
		"OR", "ID", "COMMENT", "DOUBLE", "INTEGER", "STRING", "MUL", "SUM", "NEGATIVE", 
		"WS", "ErrorChar"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Fa.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static FaLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '+', '\x171', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', 
		'\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', 
		'\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x5', '\x1D', '\x116', '\n', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1E', '\x5', '\x1E', '\x126', '\n', '\x1E', '\x3', '\x1F', 
		'\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', 
		'\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', 
		' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', 
		' ', '\x3', '!', '\x3', '!', '\a', '!', '\x13C', '\n', '!', '\f', '!', 
		'\xE', '!', '\x13F', '\v', '!', '\x3', '\"', '\x3', '\"', '\a', '\"', 
		'\x143', '\n', '\"', '\f', '\"', '\xE', '\"', '\x146', '\v', '\"', '\x3', 
		'\"', '\x3', '\"', '\x3', '#', '\x6', '#', '\x14B', '\n', '#', '\r', '#', 
		'\xE', '#', '\x14C', '\x3', '#', '\x3', '#', '\x6', '#', '\x151', '\n', 
		'#', '\r', '#', '\xE', '#', '\x152', '\x3', '$', '\x6', '$', '\x156', 
		'\n', '$', '\r', '$', '\xE', '$', '\x157', '\x3', '%', '\x3', '%', '\a', 
		'%', '\x15C', '\n', '%', '\f', '%', '\xE', '%', '\x15F', '\v', '%', '\x3', 
		'%', '\x3', '%', '\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', 
		'(', '\x3', '(', '\x3', ')', '\x6', ')', '\x16A', '\n', ')', '\r', ')', 
		'\xE', ')', '\x16B', '\x3', ')', '\x3', ')', '\x3', '*', '\x3', '*', '\x3', 
		'\x15D', '\x2', '+', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', 
		'\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', 
		'\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', 
		'\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', 
		'+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', 
		'\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', ' ', 
		'?', '!', '\x41', '\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', '&', 
		'K', '\'', 'M', '(', 'O', ')', 'Q', '*', 'S', '+', '\x3', '\x2', '\t', 
		'\x4', '\x2', '\x43', '\\', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', 
		'\\', '\x61', '\x61', '\x63', '|', '\x4', '\x2', '\f', '\f', '\xF', '\xF', 
		'\x3', '\x2', '\x32', ';', '\x3', '\x2', '\x30', '\x30', '\x5', '\x2', 
		'\'', '\'', ',', ',', '\x31', '\x31', '\x5', '\x2', '\v', '\f', '\xF', 
		'\xF', '\"', '\"', '\x2', '\x17B', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', 
		'\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 'Q', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', '\x3', 'U', '\x3', 
		'\x2', '\x2', '\x2', '\x5', 'Y', '\x3', '\x2', '\x2', '\x2', '\a', '^', 
		'\x3', '\x2', '\x2', '\x2', '\t', '`', '\x3', '\x2', '\x2', '\x2', '\v', 
		'\x63', '\x3', '\x2', '\x2', '\x2', '\r', 'k', '\x3', '\x2', '\x2', '\x2', 
		'\xF', 'r', '\x3', '\x2', '\x2', '\x2', '\x11', 'u', '\x3', '\x2', '\x2', 
		'\x2', '\x13', 'x', '\x3', '\x2', '\x2', '\x2', '\x15', '\x81', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '\x86', '\x3', '\x2', '\x2', '\x2', '\x19', 
		'\x8B', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x8F', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', '\x96', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x9D', '\x3', 
		'\x2', '\x2', '\x2', '!', '\xA2', '\x3', '\x2', '\x2', '\x2', '#', '\xAB', 
		'\x3', '\x2', '\x2', '\x2', '%', '\xB0', '\x3', '\x2', '\x2', '\x2', '\'', 
		'\xB2', '\x3', '\x2', '\x2', '\x2', ')', '\xB8', '\x3', '\x2', '\x2', 
		'\x2', '+', '\xC1', '\x3', '\x2', '\x2', '\x2', '-', '\xCD', '\x3', '\x2', 
		'\x2', '\x2', '/', '\xD7', '\x3', '\x2', '\x2', '\x2', '\x31', '\xD9', 
		'\x3', '\x2', '\x2', '\x2', '\x33', '\xDB', '\x3', '\x2', '\x2', '\x2', 
		'\x35', '\xE5', '\x3', '\x2', '\x2', '\x2', '\x37', '\xEB', '\x3', '\x2', 
		'\x2', '\x2', '\x39', '\x115', '\x3', '\x2', '\x2', '\x2', ';', '\x125', 
		'\x3', '\x2', '\x2', '\x2', '=', '\x127', '\x3', '\x2', '\x2', '\x2', 
		'?', '\x130', '\x3', '\x2', '\x2', '\x2', '\x41', '\x139', '\x3', '\x2', 
		'\x2', '\x2', '\x43', '\x140', '\x3', '\x2', '\x2', '\x2', '\x45', '\x14A', 
		'\x3', '\x2', '\x2', '\x2', 'G', '\x155', '\x3', '\x2', '\x2', '\x2', 
		'I', '\x159', '\x3', '\x2', '\x2', '\x2', 'K', '\x162', '\x3', '\x2', 
		'\x2', '\x2', 'M', '\x164', '\x3', '\x2', '\x2', '\x2', 'O', '\x166', 
		'\x3', '\x2', '\x2', '\x2', 'Q', '\x169', '\x3', '\x2', '\x2', '\x2', 
		'S', '\x16F', '\x3', '\x2', '\x2', '\x2', 'U', 'V', '\a', 'w', '\x2', 
		'\x2', 'V', 'W', '\a', 'u', '\x2', '\x2', 'W', 'X', '\a', '\x63', '\x2', 
		'\x2', 'X', '\x4', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\a', 'p', '\x2', 
		'\x2', 'Z', '[', '\a', '\x63', '\x2', '\x2', '[', '\\', '\a', '\x66', 
		'\x2', '\x2', '\\', ']', '\a', '\x63', '\x2', '\x2', ']', '\x6', '\x3', 
		'\x2', '\x2', '\x2', '^', '_', '\a', '.', '\x2', '\x2', '_', '\b', '\x3', 
		'\x2', '\x2', '\x2', '`', '\x61', '\a', 'g', '\x2', '\x2', '\x61', '\x62', 
		'\a', 'p', '\x2', '\x2', '\x62', '\n', '\x3', '\x2', '\x2', '\x2', '\x63', 
		'\x64', '\a', 'k', '\x2', '\x2', '\x64', '\x65', '\a', 'o', '\x2', '\x2', 
		'\x65', '\x66', '\a', 'r', '\x2', '\x2', '\x66', 'g', '\a', 't', '\x2', 
		'\x2', 'g', 'h', '\a', 'k', '\x2', '\x2', 'h', 'i', '\a', 'o', '\x2', 
		'\x2', 'i', 'j', '\a', '\x63', '\x2', '\x2', 'j', '\f', '\x3', '\x2', 
		'\x2', '\x2', 'k', 'l', '\a', 'v', '\x2', '\x2', 'l', 'm', '\a', '\x63', 
		'\x2', '\x2', 'm', 'n', '\a', 'o', '\x2', '\x2', 'n', 'o', '\a', '\x63', 
		'\x2', '\x2', 'o', 'p', '\a', '\xF3', '\x2', '\x2', 'p', 'q', '\a', 'q', 
		'\x2', '\x2', 'q', '\xE', '\x3', '\x2', '\x2', '\x2', 'r', 's', '\a', 
		'\x66', '\x2', '\x2', 's', 't', '\a', 'g', '\x2', '\x2', 't', '\x10', 
		'\x3', '\x2', '\x2', '\x2', 'u', 'v', '\a', 'u', '\x2', '\x2', 'v', 'w', 
		'\a', 'k', '\x2', '\x2', 'w', '\x12', '\x3', '\x2', '\x2', '\x2', 'x', 
		'y', '\a', 'g', '\x2', '\x2', 'y', 'z', '\a', 'p', '\x2', '\x2', 'z', 
		'{', '\a', 'v', '\x2', '\x2', '{', '|', '\a', 'q', '\x2', '\x2', '|', 
		'}', '\a', 'p', '\x2', '\x2', '}', '~', '\a', '\x65', '\x2', '\x2', '~', 
		'\x7F', '\a', 'g', '\x2', '\x2', '\x7F', '\x80', '\a', 'u', '\x2', '\x2', 
		'\x80', '\x14', '\x3', '\x2', '\x2', '\x2', '\x81', '\x82', '\a', 'q', 
		'\x2', '\x2', '\x82', '\x83', '\a', '\x61', '\x2', '\x2', '\x83', '\x84', 
		'\a', 'u', '\x2', '\x2', '\x84', '\x85', '\a', 'k', '\x2', '\x2', '\x85', 
		'\x16', '\x3', '\x2', '\x2', '\x2', '\x86', '\x87', '\a', 'u', '\x2', 
		'\x2', '\x87', '\x88', '\a', 'k', '\x2', '\x2', '\x88', '\x89', '\a', 
		'p', '\x2', '\x2', '\x89', '\x8A', '\a', 'q', '\x2', '\x2', '\x8A', '\x18', 
		'\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\a', 'h', '\x2', '\x2', '\x8C', 
		'\x8D', '\a', 'k', '\x2', '\x2', '\x8D', '\x8E', '\a', 'p', '\x2', '\x2', 
		'\x8E', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x8F', '\x90', '\a', '\x65', 
		'\x2', '\x2', '\x90', '\x91', '\a', 'w', '\x2', '\x2', '\x91', '\x92', 
		'\a', '\x63', '\x2', '\x2', '\x92', '\x93', '\a', 'p', '\x2', '\x2', '\x93', 
		'\x94', '\a', '\x66', '\x2', '\x2', '\x94', '\x95', '\a', 'q', '\x2', 
		'\x2', '\x95', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x96', '\x97', '\a', 
		'g', '\x2', '\x2', '\x97', '\x98', '\a', 'u', '\x2', '\x2', '\x98', '\x99', 
		'\a', '\x65', '\x2', '\x2', '\x99', '\x9A', '\a', 'q', '\x2', '\x2', '\x9A', 
		'\x9B', '\a', 'i', '\x2', '\x2', '\x9B', '\x9C', '\a', 'g', '\x2', '\x2', 
		'\x9C', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x9D', '\x9E', '\a', '\x65', 
		'\x2', '\x2', '\x9E', '\x9F', '\a', '\x63', '\x2', '\x2', '\x9F', '\xA0', 
		'\a', 'u', '\x2', '\x2', '\xA0', '\xA1', '\a', 'q', '\x2', '\x2', '\xA1', 
		' ', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA3', '\a', 'o', '\x2', '\x2', 
		'\xA3', '\xA4', '\a', 'k', '\x2', '\x2', '\xA4', '\xA5', '\a', 'g', '\x2', 
		'\x2', '\xA5', '\xA6', '\a', 'p', '\x2', '\x2', '\xA6', '\xA7', '\a', 
		'v', '\x2', '\x2', '\xA7', '\xA8', '\a', 't', '\x2', '\x2', '\xA8', '\xA9', 
		'\a', '\x63', '\x2', '\x2', '\xA9', '\xAA', '\a', 'u', '\x2', '\x2', '\xAA', 
		'\"', '\x3', '\x2', '\x2', '\x2', '\xAB', '\xAC', '\a', '\x65', '\x2', 
		'\x2', '\xAC', '\xAD', '\a', 'q', '\x2', '\x2', '\xAD', '\xAE', '\a', 
		'o', '\x2', '\x2', '\xAE', '\xAF', '\a', 'q', '\x2', '\x2', '\xAF', '$', 
		'\x3', '\x2', '\x2', '\x2', '\xB0', '\xB1', '\a', '<', '\x2', '\x2', '\xB1', 
		'&', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xB3', '\a', 'n', '\x2', '\x2', 
		'\xB3', '\xB4', '\a', 'k', '\x2', '\x2', '\xB4', '\xB5', '\a', 'u', '\x2', 
		'\x2', '\xB5', '\xB6', '\a', 'v', '\x2', '\x2', '\xB6', '\xB7', '\a', 
		'\x63', '\x2', '\x2', '\xB7', '(', '\x3', '\x2', '\x2', '\x2', '\xB8', 
		'\xB9', '\a', 't', '\x2', '\x2', '\xB9', '\xBA', '\a', 'g', '\x2', '\x2', 
		'\xBA', '\xBB', '\a', 'u', '\x2', '\x2', '\xBB', '\xBC', '\a', 'r', '\x2', 
		'\x2', '\xBC', '\xBD', '\a', 'q', '\x2', '\x2', '\xBD', '\xBE', '\a', 
		'p', '\x2', '\x2', '\xBE', '\xBF', '\a', '\x66', '\x2', '\x2', '\xBF', 
		'\xC0', '\a', 'g', '\x2', '\x2', '\xC0', '*', '\x3', '\x2', '\x2', '\x2', 
		'\xC1', '\xC2', '\a', 'k', '\x2', '\x2', '\xC2', '\xC3', '\a', 'p', '\x2', 
		'\x2', '\xC3', '\xC4', '\a', 'v', '\x2', '\x2', '\xC4', '\xC5', '\a', 
		'g', '\x2', '\x2', '\xC5', '\xC6', '\a', 't', '\x2', '\x2', '\xC6', '\xC7', 
		'\a', 't', '\x2', '\x2', '\xC7', '\xC8', '\a', 'w', '\x2', '\x2', '\xC8', 
		'\xC9', '\a', 'o', '\x2', '\x2', '\xC9', '\xCA', '\a', 'r', '\x2', '\x2', 
		'\xCA', '\xCB', '\a', 'k', '\x2', '\x2', '\xCB', '\xCC', '\a', 't', '\x2', 
		'\x2', '\xCC', ',', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xCE', '\a', 
		'\x65', '\x2', '\x2', '\xCE', '\xCF', '\a', 'q', '\x2', '\x2', '\xCF', 
		'\xD0', '\a', 'p', '\x2', '\x2', '\xD0', '\xD1', '\a', 'v', '\x2', '\x2', 
		'\xD1', '\xD2', '\a', 'k', '\x2', '\x2', '\xD2', '\xD3', '\a', 'p', '\x2', 
		'\x2', '\xD3', '\xD4', '\a', 'w', '\x2', '\x2', '\xD4', '\xD5', '\a', 
		'\x63', '\x2', '\x2', '\xD5', '\xD6', '\a', 't', '\x2', '\x2', '\xD6', 
		'.', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD8', '\a', '*', '\x2', '\x2', 
		'\xD8', '\x30', '\x3', '\x2', '\x2', '\x2', '\xD9', '\xDA', '\a', '+', 
		'\x2', '\x2', '\xDA', '\x32', '\x3', '\x2', '\x2', '\x2', '\xDB', '\xDC', 
		'\a', 'x', '\x2', '\x2', '\xDC', '\xDD', '\a', 'g', '\x2', '\x2', '\xDD', 
		'\xDE', '\a', 't', '\x2', '\x2', '\xDE', '\xDF', '\a', '\x66', '\x2', 
		'\x2', '\xDF', '\xE0', '\a', '\x63', '\x2', '\x2', '\xE0', '\xE1', '\a', 
		'\x66', '\x2', '\x2', '\xE1', '\xE2', '\a', 'g', '\x2', '\x2', '\xE2', 
		'\xE3', '\a', 't', '\x2', '\x2', '\xE3', '\xE4', '\a', 'q', '\x2', '\x2', 
		'\xE4', '\x34', '\x3', '\x2', '\x2', '\x2', '\xE5', '\xE6', '\a', 'h', 
		'\x2', '\x2', '\xE6', '\xE7', '\a', '\x63', '\x2', '\x2', '\xE7', '\xE8', 
		'\a', 'n', '\x2', '\x2', '\xE8', '\xE9', '\a', 'u', '\x2', '\x2', '\xE9', 
		'\xEA', '\a', 'q', '\x2', '\x2', '\xEA', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '\xEB', '\xEC', '\a', 'p', '\x2', '\x2', '\xEC', '\xED', '\a', 
		'g', '\x2', '\x2', '\xED', '\xEE', '\a', 'i', '\x2', '\x2', '\xEE', '\xEF', 
		'\a', '\x63', '\x2', '\x2', '\xEF', '\xF0', '\a', 't', '\x2', '\x2', '\xF0', 
		'\x38', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xF2', '\a', 'o', '\x2', 
		'\x2', '\xF2', '\xF3', '\a', 'g', '\x2', '\x2', '\xF3', '\xF4', '\a', 
		'p', '\x2', '\x2', '\xF4', '\xF5', '\a', 'q', '\x2', '\x2', '\xF5', '\xF6', 
		'\a', 't', '\x2', '\x2', '\xF6', '\xF7', '\a', 's', '\x2', '\x2', '\xF7', 
		'\xF8', '\a', 'w', '\x2', '\x2', '\xF8', '\x116', '\a', 'g', '\x2', '\x2', 
		'\xF9', '\xFA', '\a', 'o', '\x2', '\x2', '\xFA', '\xFB', '\a', 'g', '\x2', 
		'\x2', '\xFB', '\xFC', '\a', 'p', '\x2', '\x2', '\xFC', '\xFD', '\a', 
		'q', '\x2', '\x2', '\xFD', '\xFE', '\a', 't', '\x2', '\x2', '\xFE', '\xFF', 
		'\a', 'k', '\x2', '\x2', '\xFF', '\x100', '\a', 'i', '\x2', '\x2', '\x100', 
		'\x101', '\a', 'w', '\x2', '\x2', '\x101', '\x102', '\a', '\x63', '\x2', 
		'\x2', '\x102', '\x116', '\a', 'n', '\x2', '\x2', '\x103', '\x104', '\a', 
		'o', '\x2', '\x2', '\x104', '\x105', '\a', '\x63', '\x2', '\x2', '\x105', 
		'\x106', '\a', '{', '\x2', '\x2', '\x106', '\x107', '\a', 'q', '\x2', 
		'\x2', '\x107', '\x108', '\a', 't', '\x2', '\x2', '\x108', '\x109', '\a', 
		's', '\x2', '\x2', '\x109', '\x10A', '\a', 'w', '\x2', '\x2', '\x10A', 
		'\x116', '\a', 'g', '\x2', '\x2', '\x10B', '\x10C', '\a', 'o', '\x2', 
		'\x2', '\x10C', '\x10D', '\a', '\x63', '\x2', '\x2', '\x10D', '\x10E', 
		'\a', '{', '\x2', '\x2', '\x10E', '\x10F', '\a', 'q', '\x2', '\x2', '\x10F', 
		'\x110', '\a', 't', '\x2', '\x2', '\x110', '\x111', '\a', 'k', '\x2', 
		'\x2', '\x111', '\x112', '\a', 'i', '\x2', '\x2', '\x112', '\x113', '\a', 
		'w', '\x2', '\x2', '\x113', '\x114', '\a', '\x63', '\x2', '\x2', '\x114', 
		'\x116', '\a', 'n', '\x2', '\x2', '\x115', '\xF1', '\x3', '\x2', '\x2', 
		'\x2', '\x115', '\xF9', '\x3', '\x2', '\x2', '\x2', '\x115', '\x103', 
		'\x3', '\x2', '\x2', '\x2', '\x115', '\x10B', '\x3', '\x2', '\x2', '\x2', 
		'\x116', ':', '\x3', '\x2', '\x2', '\x2', '\x117', '\x118', '\a', 'k', 
		'\x2', '\x2', '\x118', '\x119', '\a', 'i', '\x2', '\x2', '\x119', '\x11A', 
		'\a', 'w', '\x2', '\x2', '\x11A', '\x11B', '\a', '\x63', '\x2', '\x2', 
		'\x11B', '\x126', '\a', 'n', '\x2', '\x2', '\x11C', '\x11D', '\a', '\x66', 
		'\x2', '\x2', '\x11D', '\x11E', '\a', 'k', '\x2', '\x2', '\x11E', '\x11F', 
		'\a', 'h', '\x2', '\x2', '\x11F', '\x120', '\a', 'g', '\x2', '\x2', '\x120', 
		'\x121', '\a', 't', '\x2', '\x2', '\x121', '\x122', '\a', 'g', '\x2', 
		'\x2', '\x122', '\x123', '\a', 'p', '\x2', '\x2', '\x123', '\x124', '\a', 
		'v', '\x2', '\x2', '\x124', '\x126', '\a', 'g', '\x2', '\x2', '\x125', 
		'\x117', '\x3', '\x2', '\x2', '\x2', '\x125', '\x11C', '\x3', '\x2', '\x2', 
		'\x2', '\x126', '<', '\x3', '\x2', '\x2', '\x2', '\x127', '\x128', '\a', 
		'{', '\x2', '\x2', '\x128', '\x129', '\a', '\x61', '\x2', '\x2', '\x129', 
		'\x12A', '\a', 'n', '\x2', '\x2', '\x12A', '\x12B', '\a', 'q', '\x2', 
		'\x2', '\x12B', '\x12C', '\a', 'i', '\x2', '\x2', '\x12C', '\x12D', '\a', 
		'k', '\x2', '\x2', '\x12D', '\x12E', '\a', '\x65', '\x2', '\x2', '\x12E', 
		'\x12F', '\a', 'q', '\x2', '\x2', '\x12F', '>', '\x3', '\x2', '\x2', '\x2', 
		'\x130', '\x131', '\a', 'q', '\x2', '\x2', '\x131', '\x132', '\a', '\x61', 
		'\x2', '\x2', '\x132', '\x133', '\a', 'n', '\x2', '\x2', '\x133', '\x134', 
		'\a', 'q', '\x2', '\x2', '\x134', '\x135', '\a', 'i', '\x2', '\x2', '\x135', 
		'\x136', '\a', 'k', '\x2', '\x2', '\x136', '\x137', '\a', '\x65', '\x2', 
		'\x2', '\x137', '\x138', '\a', 'q', '\x2', '\x2', '\x138', '@', '\x3', 
		'\x2', '\x2', '\x2', '\x139', '\x13D', '\t', '\x2', '\x2', '\x2', '\x13A', 
		'\x13C', '\t', '\x3', '\x2', '\x2', '\x13B', '\x13A', '\x3', '\x2', '\x2', 
		'\x2', '\x13C', '\x13F', '\x3', '\x2', '\x2', '\x2', '\x13D', '\x13B', 
		'\x3', '\x2', '\x2', '\x2', '\x13D', '\x13E', '\x3', '\x2', '\x2', '\x2', 
		'\x13E', '\x42', '\x3', '\x2', '\x2', '\x2', '\x13F', '\x13D', '\x3', 
		'\x2', '\x2', '\x2', '\x140', '\x144', '\a', '%', '\x2', '\x2', '\x141', 
		'\x143', '\n', '\x4', '\x2', '\x2', '\x142', '\x141', '\x3', '\x2', '\x2', 
		'\x2', '\x143', '\x146', '\x3', '\x2', '\x2', '\x2', '\x144', '\x142', 
		'\x3', '\x2', '\x2', '\x2', '\x144', '\x145', '\x3', '\x2', '\x2', '\x2', 
		'\x145', '\x147', '\x3', '\x2', '\x2', '\x2', '\x146', '\x144', '\x3', 
		'\x2', '\x2', '\x2', '\x147', '\x148', '\b', '\"', '\x2', '\x2', '\x148', 
		'\x44', '\x3', '\x2', '\x2', '\x2', '\x149', '\x14B', '\t', '\x5', '\x2', 
		'\x2', '\x14A', '\x149', '\x3', '\x2', '\x2', '\x2', '\x14B', '\x14C', 
		'\x3', '\x2', '\x2', '\x2', '\x14C', '\x14A', '\x3', '\x2', '\x2', '\x2', 
		'\x14C', '\x14D', '\x3', '\x2', '\x2', '\x2', '\x14D', '\x14E', '\x3', 
		'\x2', '\x2', '\x2', '\x14E', '\x150', '\t', '\x6', '\x2', '\x2', '\x14F', 
		'\x151', '\t', '\x5', '\x2', '\x2', '\x150', '\x14F', '\x3', '\x2', '\x2', 
		'\x2', '\x151', '\x152', '\x3', '\x2', '\x2', '\x2', '\x152', '\x150', 
		'\x3', '\x2', '\x2', '\x2', '\x152', '\x153', '\x3', '\x2', '\x2', '\x2', 
		'\x153', '\x46', '\x3', '\x2', '\x2', '\x2', '\x154', '\x156', '\t', '\x5', 
		'\x2', '\x2', '\x155', '\x154', '\x3', '\x2', '\x2', '\x2', '\x156', '\x157', 
		'\x3', '\x2', '\x2', '\x2', '\x157', '\x155', '\x3', '\x2', '\x2', '\x2', 
		'\x157', '\x158', '\x3', '\x2', '\x2', '\x2', '\x158', 'H', '\x3', '\x2', 
		'\x2', '\x2', '\x159', '\x15D', '\a', '$', '\x2', '\x2', '\x15A', '\x15C', 
		'\v', '\x2', '\x2', '\x2', '\x15B', '\x15A', '\x3', '\x2', '\x2', '\x2', 
		'\x15C', '\x15F', '\x3', '\x2', '\x2', '\x2', '\x15D', '\x15E', '\x3', 
		'\x2', '\x2', '\x2', '\x15D', '\x15B', '\x3', '\x2', '\x2', '\x2', '\x15E', 
		'\x160', '\x3', '\x2', '\x2', '\x2', '\x15F', '\x15D', '\x3', '\x2', '\x2', 
		'\x2', '\x160', '\x161', '\a', '$', '\x2', '\x2', '\x161', 'J', '\x3', 
		'\x2', '\x2', '\x2', '\x162', '\x163', '\t', '\a', '\x2', '\x2', '\x163', 
		'L', '\x3', '\x2', '\x2', '\x2', '\x164', '\x165', '\a', '-', '\x2', '\x2', 
		'\x165', 'N', '\x3', '\x2', '\x2', '\x2', '\x166', '\x167', '\a', '/', 
		'\x2', '\x2', '\x167', 'P', '\x3', '\x2', '\x2', '\x2', '\x168', '\x16A', 
		'\t', '\b', '\x2', '\x2', '\x169', '\x168', '\x3', '\x2', '\x2', '\x2', 
		'\x16A', '\x16B', '\x3', '\x2', '\x2', '\x2', '\x16B', '\x169', '\x3', 
		'\x2', '\x2', '\x2', '\x16B', '\x16C', '\x3', '\x2', '\x2', '\x2', '\x16C', 
		'\x16D', '\x3', '\x2', '\x2', '\x2', '\x16D', '\x16E', '\b', ')', '\x2', 
		'\x2', '\x16E', 'R', '\x3', '\x2', '\x2', '\x2', '\x16F', '\x170', '\v', 
		'\x2', '\x2', '\x2', '\x170', 'T', '\x3', '\x2', '\x2', '\x2', '\f', '\x2', 
		'\x115', '\x125', '\x13D', '\x144', '\x14C', '\x152', '\x157', '\x15D', 
		'\x16B', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
