using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser;

namespace Beam_Project.classes
{
    class Beam
    {
        List<Point_Force> point_force = new List<Point_Force>();
        List<D_force> d_force = new List<D_force>();
        List<Equation> equations = new List<Equation>();
        internal double total_length { get; set; }

        private Beam(List<Equation> equations, List<D_force> D_force, List<Point_Force> point_force){
            this.equations = equations;
            this.d_force = D_force;
            this.point_force = point_force;
        }
    }
}
