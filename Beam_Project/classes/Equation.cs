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
        internal List<Polynomial> polys = new List<Polynomial>();
        internal double start { get; set; }
        internal double finish { get; set; }
        

        //Equation copying if needed
        private Equation Copy()
        {
            var Eqn = new Equation();
            Eqn.sine = this.sine.Copy();

            for (int i = 0; i < this.polys.Count; i++)
            {
                Eqn.polys.Add(this.polys.ElementAt(i));
            }

            Eqn.start = this.start;
            Eqn.finish = this.finish;
            return Eqn;
        }


        //Evaluates the value of the equation
        public double Evaluate(double value)
        {
            double final_result;
            double result = 0;
            for (int i = 0; i < this.polys.Count; i++)
            {
                result += this.polys.ElementAt(i).Evaluate(value);
            }
            final_result = result + this.sine.Evaluate(value);
            return final_result;
        }

        //integration via the simpson's rule with a fidelity of 3000
        public double Integrate()
        {
            double interm_value = 0;
            double result;
            double odd_result=0;
            double even_result=0;
            double value;

            for (int i = 0; i <= n; i++)
            {
                value = (this.finish - this.start) * i / n;
                if (i == 0)
                {
                    interm_value+=this.Evaluate(start);
                }
                else if (i == n)
                {
                    interm_value += this.Evaluate(finish);
                }
                else if (n % i == 1)
                {
                    odd_result += this.Evaluate(value);
                }
                else if (n % i == 0)
                {
                    even_result += this.Evaluate(value);
                }
            }
            result = (finish-start)/3*(interm_value+4*odd_result+2*even_result);
            return result;
        }
        

        //integrate for point load length calculation
        public double Integrate_2()
        {
            double interm_value = 0;
            double result;
            double odd_result = 0;
            double even_result = 0;
            double value;

            for (int i = 0; i <= n; i++)
            {
                value = (this.finish - this.start) * i / n;
                if (i == 0)
                {
                    interm_value += this.Evaluate(start)*start;
                }
                else if (i == n)
                {
                    interm_value += this.Evaluate(finish)*finish;
                }
                else if (n % i == 1)
                {
                    odd_result += this.Evaluate(value)*value;
                }
                else if (n % i == 0)
                {
                    even_result += this.Evaluate(value)*value;
                }
            }
            result = (finish - start) / 3 * (interm_value + 4 * odd_result + 2 * even_result);
            return result;
        }


        //Conversion between distributed force to point force
        public Point_Force DF2PF()
        {
            Point_Force PF = new Point_Force();
            PF.force = this.Integrate();
            PF.point_length = this.Integrate_2() / PF.force;
            return PF;
        }
    }
}
