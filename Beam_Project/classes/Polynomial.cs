using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Polynomial
    {
        internal double coefficent;
        internal double order;
        private double Evaluate(double value)
        {
            return coefficent * Math.Pow(value, order);
        }
    }
}
