using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Sinusoid
    {
        internal double amplitude { get; set; }
        internal double phase { get; set; }
        internal double frequency { get; set; }

        private double Evaluate(double value) {
            return amplitude*Math.Sin(value*frequency+phase);
        }
    }
}
