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
        internal Polynomial(double coefficent,double order)
        {
            this.coefficent=coefficent;
            this.order=order;
        }
        internal double Evaluate(double value)
        {
            return coefficent * Math.Pow(value, order);
        }
        internal Polynomial Copy()
        {
            var P = new Polynomial(this.coefficent, this.order);
            return P;
        }
    }
}
