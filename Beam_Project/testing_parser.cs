using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project
{
    class Testing_parser
    {
        public static void main(String[] args)
        {
            classes.Equation equation = new classes.Equation();
            equation.equation = "5 - x^2";
            equation.start = -2;
            equation.finish = 2;
            Console.WriteLine("{0} here", classes.Equation.Integrate(equation));
        }
    }
}
