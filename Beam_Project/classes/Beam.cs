using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Beam
    {
        List<Point_Force> point_force = new List<Point_Force>();
        List<Equation> equations = new List<Equation>();
        internal double total_length { get; set; }

        internal Beam(List<Equation> equations, List<Point_Force> point_force){
            this.equations = equations;
            this.point_force = point_force;
        }
    }
}
