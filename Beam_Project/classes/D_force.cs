using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class D_force
    {
        double start { get; set; }
        double finish { get; set; }
        double force_ratio { get; set; }

        public static Point_Force DF2PF(D_force D)
        {
            var total_distance = D.start - D.finish;
            Point_Force New_PF = new Point_Force();
            New_PF.force = total_distance * D.force_ratio;
            New_PF.point = (D.start + D.finish) / 2;
            return New_PF;
        }
    }
}
