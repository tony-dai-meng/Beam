using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beam_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            classes.Equation equation = new classes.Equation();
            equation.equation = "5 - x^2";
            equation.start = -2;
            equation.finish = 2;
            Console.WriteLine("{0}", classes.Equation.Integrate(equation));
            textBox1.AppendText("classes.Equation.Integrate(equation)");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            classes.Equation equation = new classes.Equation();
            equation.equation = "5 - x*x";
            equation.start = -2;
            equation.finish = 2;
            Double result = classes.Equation.Integrate(equation);
            label1.Text = result.ToString();

        }
    }
}
