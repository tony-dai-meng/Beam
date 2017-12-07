using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Joint {roller, pin, wall};


namespace Beam_Project.classes
{
    class Internal_force
    {
        private double moment { get; set; }
        private double x_force { get; set; }
        private double y_force { get; set; }

        internal Internal_force(int joint_type)
        {
            if(joint_type == (int) Joint.roller) //roller joint
            {
                this.moment = 0;
                this.x_force = 0;
            } else if (joint_type == (int) Joint.pin) //pin joint
            {
                this.moment = 0;
            }
        }
    }
}
