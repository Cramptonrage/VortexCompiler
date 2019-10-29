using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Ast;
using Irony.Parsing;
using Analizador;
using System.Threading.Tasks;

namespace analizador_gramaticaunidad1.sql.com.analizador
{
    class sintatico2
    {
        ControlDOT lol = new ControlDOT();
        public static ParseTreeNode analizar(String cadena)
        {

            Gramatica2 gramatica = new Gramatica2();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            return arbol.Root;

        }

    }
}
