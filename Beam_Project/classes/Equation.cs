using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Equation
    {
        public const int n = 3000; //iterations to integration
        internal Sinusoid sine { get; set; }
        internal Polynomial poly { get; set; }
        internal D_force d_force { get; set; }

        private Equation Copy()
        {
            var Eqn = new Equation();
            Eqn.sine = this.sine.Copy();
            Eqn.d_force = this.d_force.Copy();
            Eqn.poly = this.poly.Copy();
            return Eqn;
        }

        
        /*integration via the trapizoid rule with a fidelity of 1000
        public static double Integrate(Equation Eqn)
        {
            double value;
            double inter_value = 0;
            double a = Eqn.start;
            double b = Eqn.finish;
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
        */
    }
}
