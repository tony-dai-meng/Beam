using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Equation
    {
        public const int n = 1000; //iterations to integration
        internal Sinusoid sines { get; set; }
        internal Polynomial poly { get; set; }
        internal double start { get; set; }
        internal double finish { get; set; }

        public static Equation Copy(Equation Eqn)
        {
            var Eqn_2 = new Equation();
            Eqn_2.equation = String.Copy(Eqn.equation);
            Eqn_2.start = Eqn.start;
            Eqn_2.finish = Eqn.finish;
            return Eqn_2;
        }
        public static Point_Force DF2PF(Equation Eqn)
        {
            var PF = new Point_Force();
            var Eqn_2 = Equation.Copy(Eqn);
            Eqn_2.equation.Insert(0, "(");
            Eqn_2.equation.Insert(Eqn.equation.Length - 1, ")*x");

            PF.force = Integrate(Eqn);
            PF.point = Integrate(Eqn_2)/PF.force;
            return PF;
        }

        /*integration via the trapizoid rule with a fidelity of 1000*/
        public static double Integrate(Equation Eqn)
        {
            double value;
            double inter_value = 0;
            double a = Eqn.start;
            double b = Eqn.finish;
            var parser = new Parser("x");
            var parsingResult = parser.Parse(Eqn.equation);
            double f_a = parsingResult.Evaluate(a);
            double f_b = parsingResult.Evaluate(b);

            for (int k = 1; k < n; k++)
            {
                value = a + k * (b - a) / n;
                inter_value += parsingResult.Evaluate(value);
            }
            double result = (b - a) / n * (f_a / 2 + inter_value + f_b / 2);
            return result;
        }
    }
}
