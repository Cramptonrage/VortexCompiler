using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
namespace analizador_gramaticaunidad1.sql.com.analizador
{
    class Gramatica : Grammar
    {
        public Gramatica()
            : base(caseSensitive: true)
        {
            IdentifierTerminal id = new IdentifierTerminal("id");
            RegexBasedTerminal numeroentero = new RegexBasedTerminal("[0-9]+");
            RegexBasedTerminal numerodecimal = new RegexBasedTerminal("[0-9]+[.][0-9]");
            StringLiteral STRING = new StringLiteral("STRING", "\"", StringOptions.IsTemplate);




            CommentTerminal comentarioenlinea = new CommentTerminal("comentario linea", "//", "\n", "\r\n");
            CommentTerminal comentariobloque = new CommentTerminal("comentario bloque", "/*", "*/");
            base.NonGrammarTerminals.Add(comentarioenlinea);
            base.NonGrammarTerminals.Add(comentariobloque);

            #region TERMINALES
            var reservadaclass = "class";
            var reservadapublic = "public";
            var reservadaprivate = "private";
            var reservadaabstract = "abstract";
            var reservadaassert = "assert";
            var reservadaboolean = ":boolean";
            var reservadabreak = "break";
            var reservadabyte = "byte";
            var reservadacase = "case";
            var reservadacatch = "catch";
            var reservadachar = ":char";
            var reservadaconst = "const";
            var reservadacontinue = "continue";
            var reservadadefault = "default";
            var reservadado = "do";
            var reservadadouble = ":double";
            var reservadaelse = "else";
            var reservadaenum = "enum";
            var reservadaextends = "extends";
            var reservadafinal = "final";
            var reservadafinally = "finally";
            var reservadapackage = "package";
            var reservadaprotected = "protected";
            var reservadareturn = "return";
            var reservadashort = "short";
            var reservadastatic = "static";
            var reservadastricftp = "stricftp";
            var reservadasuper = "super";
            var reservadaswitch = "switch";
            var reservadasynchronized = "synchronized";
            var reservadathis = "this";
            var reservadathrow = "throw";
            var reservadathrows = "throws";
            var reservadatransient = "transient";
            var reservadatry = "try";
            var reservadavoid = "void";
            var reservadavolatile = "volatile";
            var reservadawhile = "while";
            var reservadafloat = "float";
            var reservadafor = "for";
            var reservadagoto = "goto";
            var reservadaif = "if";
            var reservadaimplements = "implements";
            var reservadaimport = "import";
            var reservadainstanceof = "instanceof";
            var reservadaint = ":int";
            var reservadalong = ":long";
            var reservadanative = "native";
            var reservadanew = "new";
            var reservadastring = "string";
            var reservadallaveabrir = "{";
            var reservadallavecerrar = "}";
            var reservadapuntoycoma = ";";
            var reservadadospuntos = ":";
            var reservadaparentesisabrir = "(";
            var reservadaparentesiscerrar = ")";
            var reservadastringargs = "String [] args";
            var reservadamayorque = ">";
            var reservadamenorque = "<";
            var reservadamayorigual = ">=";
            var reservadamenorigual = "<=";
            var reservadaigualigual = "==";
            var reservadaigual = "=";
            var reservadadiferente = "!=";
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var multiplicacion = ToTerm("*");
            var division = ToTerm("/");
            var and = ToTerm("&&");
            var or = ToTerm("||");
            var reservadamain = "main";
            var incremento = ToTerm("++");
            var decremento = ToTerm("--");
            var reservadavector = "[]";
            var reservadamatriz = "[][]";
            var reservadacorcheteabrir = "[";
            var reservadacorchetecerrar = "]";
            #endregion

            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal VISIBILIDAD = new NonTerminal("VISIBILIDAD");
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal MAIN = new NonTerminal("MAIN");
            NonTerminal SENTENCIAS = new NonTerminal("SENTENCIAS");
            NonTerminal MENSAJE = new NonTerminal("MENSAJE");
            NonTerminal WHILE = new NonTerminal("WHILE");
            NonTerminal IF = new NonTerminal("IF");
            NonTerminal E = new NonTerminal("E");
            NonTerminal R = new NonTerminal("R");
            NonTerminal FOR = new NonTerminal("FOR");
            NonTerminal SWITCH = new NonTerminal("SWITCH");
            NonTerminal CASE = new NonTerminal("CASE");
            NonTerminal DECLARACION = new NonTerminal("DECLARACION");
            NonTerminal OPERACIONES = new NonTerminal("OPERACIONES");
            NonTerminal TIPOOPERACIONIF = new NonTerminal("TIPOOPERACIONIF");
            NonTerminal SALIDAMENSAJE = new NonTerminal("OPERACIONES");
            NonTerminal IMPRIMIRMENSAJE = new NonTerminal("IMPRIMIRMENSAJE");
            NonTerminal IMPRIMIRMENSAJEFOR = new NonTerminal("IMPRIMIRMENSAJE");
            SALIDAMENSAJE.Rule = id + SALIDAMENSAJE
          | Empty;

            TIPOOPERACIONIF.Rule = ToTerm(">")
                | ToTerm("<")
                | ToTerm("==");

            TIPO.Rule = TIPO
                | reservadashort
                | reservadafloat
                | reservadastring
                | reservadaint
                | reservadalong
                | reservadachar
                | reservadabyte
                | reservadaboolean
                | reservadadouble
                | reservadashort;

            OPERACIONES.Rule = multiplicacion + id + OPERACIONES
                | mas + id + OPERACIONES
                | menos + id + OPERACIONES
                | division + id + OPERACIONES
                | Empty;
            //int val=d+e-r+s;
            VISIBILIDAD.Rule = Empty
                | reservadapublic
                | reservadaprivate
                | reservadaprotected;

            SENTENCIAS.Rule = SENTENCIAS + MENSAJE
                | SENTENCIAS + WHILE
                | SENTENCIAS + IF
                | SENTENCIAS + FOR
                | SENTENCIAS + SWITCH
                | SENTENCIAS + DECLARACION
                | FOR
                | MENSAJE
                | WHILE
                | SWITCH
                | DECLARACION
                | IF
                | Empty;


            INICIO.Rule = VISIBILIDAD + reservadaclass + id + reservadallaveabrir + MAIN + reservadallavecerrar;

            IMPRIMIRMENSAJE.Rule = ToTerm("print(\"") + SALIDAMENSAJE + ToTerm("\")") + ToTerm(";") + IMPRIMIRMENSAJE
                | Empty;
            IMPRIMIRMENSAJEFOR.Rule = ToTerm("print(\"") + SALIDAMENSAJE + ToTerm("\")") + ToTerm(";") + IMPRIMIRMENSAJEFOR
                | ToTerm("print(") + id + ToTerm(")") + ToTerm(";") + IMPRIMIRMENSAJEFOR
                | Empty;

            INICIO.Rule = ToTerm("import java.util.*;") + VISIBILIDAD + ToTerm("class") + id + ToTerm("{") + MAIN + ToTerm("}")
            | VISIBILIDAD + ToTerm("class") + id + ToTerm("{") + Empty + ToTerm("}");
            INICIO.ErrorRule = SyntaxError + Eof;


            // MAIN.Rule = ToTerm("public static void main(String []args){") + DECLARACION + ToTerm("}");
            MAIN.Rule = ToTerm("public static void main(String []args){") + DECLARACION + ToTerm("}endmain");



            //MENSAJE.ErrorRule = SyntaxError + ToTerm(";");
            IF.Rule = ToTerm("startif") + ToTerm("(") + id + TIPOOPERACIONIF + id + ToTerm(")") + ToTerm("{") + IMPRIMIRMENSAJE + ToTerm("}endif")
                | ToTerm("startif") + ToTerm("(") + id + TIPOOPERACIONIF + id + ToTerm(")") + ToTerm("{") + IMPRIMIRMENSAJE + ToTerm("}")
                + ToTerm("else") + ToTerm("{") + IMPRIMIRMENSAJE + ToTerm("}endif");


            FOR.Rule = ToTerm("startfor") + ToTerm("(") + ToTerm("int") + ToTerm("i") + ToTerm("=") + numeroentero + ToTerm(";")
                + ToTerm("i") + ToTerm("<") + numeroentero + ToTerm(";")
                + ToTerm("i++") + ToTerm(")") + ToTerm("{") + IMPRIMIRMENSAJEFOR + ToTerm("}endfor")
                | ToTerm("startfor") + ToTerm("(") + ToTerm("int") + ToTerm("i") + ToTerm("=") + numeroentero + ToTerm(";")
                + ToTerm("i") + ToTerm(">") + numeroentero + ToTerm(";")
                + ToTerm("i--") + ToTerm(")") + ToTerm("{") + IMPRIMIRMENSAJEFOR + ToTerm("}endfor");


            DECLARACION.Rule = ToTerm(":String") + id + ToTerm("=") + STRING + ToTerm(";")
            | reservadaint + id + reservadaigual + numeroentero + reservadapuntoycoma + DECLARACION
            | reservadadouble + id + reservadaigual + numerodecimal + reservadapuntoycoma + DECLARACION
            | reservadadouble + id + reservadaigual + numeroentero + reservadapuntoycoma + DECLARACION
            | reservadaboolean + id + reservadaigual + ToTerm("true") + reservadapuntoycoma + DECLARACION
            | reservadaboolean + id + reservadaigual + ToTerm("false") + reservadapuntoycoma + DECLARACION
            | ToTerm(":") + id + ToTerm("=") + numeroentero + ToTerm(";") + DECLARACION
            | ToTerm(":") + id + ToTerm("=") + numerodecimal + ToTerm(";") + DECLARACION
            | ToTerm(":") + id + ToTerm("=") + ToTerm("true") + ToTerm(";") + DECLARACION
            | ToTerm(":") + id + ToTerm("=") + ToTerm("false") + ToTerm(";") + DECLARACION
            | ToTerm(":") + id + ToTerm("=") + STRING + ToTerm(";") + DECLARACION
            | ToTerm(":") + id + ToTerm("=") + id + ToTerm(";") + DECLARACION
            | reservadaint + id + ToTerm(";") + DECLARACION
            | reservadadouble + id + ToTerm(";") + DECLARACION
            | reservadaboolean + id + ToTerm(";") + DECLARACION
            | ToTerm(":String") + id + ToTerm(";") + DECLARACION
            | reservadaint + id + reservadaigual + id + OPERACIONES + ToTerm(";") + DECLARACION
            | ToTerm("print") + ToTerm("(") + id + ToTerm(")") + reservadapuntoycoma + DECLARACION
            | ToTerm("print") + ToTerm("(") + ToTerm("\"") + id + ToTerm("\"") + ToTerm(")") + reservadapuntoycoma + DECLARACION
            | id + reservadaigual + ToTerm("ReadConsole()") + ToTerm(";") + DECLARACION
            | IF + DECLARACION
            | FOR + DECLARACION
            | Empty;

            //DECLARACION.ErrorRule = SyntaxError + ToTerm(".String") + id + ToTerm("=") + STRING + ToTerm(";");

            R.Rule = E + ToTerm("<") + E
                | E + ToTerm(">") + E
                | E + ToTerm(">=") + E
                | E + ToTerm("<=") + E
                | E + ToTerm("==") + E
                | E + ToTerm("!=") + E;

            E.Rule = E + ToTerm("+") + E
                    | E + ToTerm("-") + E
                    | E + ToTerm("*") + E
                    | E + ToTerm("/") + E
                    | E + ToTerm("%") + E
                    | (E)
                    | id
                    | numeroentero
                    | numerodecimal;

            this.Root = INICIO; //RAIZ DE INICIO



            #region PALABRAS RESERVADAS
            //Palabras reservadas.
            this.MarkReservedWords(reservadaabstract, reservadaassert, reservadaboolean, reservadabreak, reservadabyte, reservadacase, reservadacatch, reservadachar, reservadaclass, reservadaconst, reservadacontinue, reservadadefault, reservadado, reservadadouble, reservadaelse, reservadaenum, reservadaextends, reservadafinal, reservadafinally, reservadafloat, reservadafor, reservadagoto, reservadaif, reservadaimplements, reservadaimport, reservadainstanceof, reservadaint, reservadalong, reservadamain, reservadamatriz, reservadanative, reservadanew, reservadapackage, reservadaprivate, reservadaprotected, reservadapublic, reservadareturn, reservadashort, reservadastatic, reservadastricftp, reservadastring, reservadastringargs, reservadasuper, reservadaswitch, reservadasynchronized, reservadathis, reservadathrow, reservadathrows, reservadatransient, reservadatry, reservadavector, reservadavoid, reservadavolatile, reservadawhile);
            #endregion


        }


    }
}
