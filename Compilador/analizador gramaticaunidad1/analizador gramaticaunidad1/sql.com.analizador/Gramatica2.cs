using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Ast;
using Irony.Parsing;
using System.Threading.Tasks;

namespace analizador_gramaticaunidad1.sql.com.analizador
{
    class Gramatica2 : Grammar
    {
        public Gramatica2() : base(caseSensitive: false)
        {

            #region ER
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");
            IdentifierTerminal id = new IdentifierTerminal("id");
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
             E = new NonTerminal("E"),
             T = new NonTerminal("T"),
             F = new NonTerminal("F");

            #endregion

            #region Gramatica

            S.Rule = E;
            E.Rule = E + mas + E
                     | E + menos + E
                     | E + por + E
                     | E + div + E
                     | ToTerm("(") + E + ToTerm(")")
                     | ToTerm("(") + E + ToTerm(")") + ToTerm("^") + E
                     | numero + ToTerm("^") + E
                     | numero
                     | id;

            /* //Gramatica no ambigua
             S.Rule = E;
             E.Rule = E + mas + T
                      | E + menos + T
                      | T;
             T.Rule = T + por + F
                      | T + div + F
                      | F;
             F.Rule = id
                 | numero;*/

            #endregion

            #region Preferencias
            this.Root = S;
            #endregion
        }
    }
}