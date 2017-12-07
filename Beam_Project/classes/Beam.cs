using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Beam
    {
        List<Point_Force> point_forces = new List<Point_Force>();
        List<Equation> equations = new List<Equation>();
        List<Internal_force> internal_forces = new List<Internal_force>();
        internal double total_length { get; set; }

        internal Beam(List<Equation> equations, List<Point_Force> point_forces, List<Internal_force> internal_forces){
            this.equations = equations;
            this.point_forces = point_forces;
            this.internal_forces = internal_forces;
        }

        internal Beam(Equation equation)
        {
            this.equations.Add(equation);
        }
        internal Beam(Point_Force point_force)
        {
            this.point_forces.Add(point_force);
        }
        internal Beam(Internal_force internal_force)
        {
            this.internal_forces.Add(internal_force);
        }
        internal Beam(double total_length)
        {
            this.total_length = total_length;
        }
    }
}
