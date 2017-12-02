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

        internal double Evaluate(double value) {
            return amplitude*Math.Sin(value*frequency+phase);
        }

        internal Sinusoid Copy()
        {
            var S_2 = new Sinusoid();
            S_2.amplitude = this.amplitude;
            S_2.phase = this.phase;
            S_2.frequency = this.frequency;
            return S_2;
        }
    }
}
