using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
namespace analizador_gramaticaunidad1
{
    class Recorrido
    {
        public static void reolveroperacion(ParseTreeNode root)
        {
          //  MessageBox.Show("El resultado es: " + expresion(root.ChildNodes.ElementAt(0)));
            Program.resultado = Convert.ToString(expresion(root.ChildNodes.ElementAt(0)));
        }
        private static Double expresion(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {

                case 1: //node hoja
                    String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                    return Convert.ToDouble(numero[0]);
                case 3:
                    switch (root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+"://E+E
                            return expresion(root.ChildNodes.ElementAt(0)) + expresion(root.ChildNodes.ElementAt(2));
                        case "-"://e+e
                            return expresion(root.ChildNodes.ElementAt(0)) - expresion(root.ChildNodes.ElementAt(2));
                        case "*"://E+E
                            return expresion(root.ChildNodes.ElementAt(0)) * expresion(root.ChildNodes.ElementAt(2));
                        case "/"://e+e
                            return expresion(root.ChildNodes.ElementAt(0)) / expresion(root.ChildNodes.ElementAt(2));
                        default:
                            return expresion(root.ChildNodes.ElementAt(1));
                    }
            }
            return 0.0;
        }
    }
}
