using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProiectStatie
{
    public partial class Form1 : Form
    {
        double lambda;
        int n;
        double[] intervalSosire;

        private void Button1_Click(object sender, EventArgs e)
        {
            double t = 2;
            int nrClientiDupaT = 0;
            Random r = new Random((int)DateTime.Now.Ticks);
            lambda = 1.25;
            n = Convert.ToInt32(textBox2.Text);
            intervalSosire = new double[n];
            textBox6.Clear();

            for(int i = 0; i < n; i++)
            {
                double U = r.NextDouble();
                double x = -Math.Log(1 - U) / lambda;
                intervalSosire[i] = x;
                if (i > 0 && intervalSosire[i] > t)
                {
                    nrClientiDupaT++;
                }
                textBox6.AppendText("\r\nTimpul dintre sosirile clientului " + (i + 1) + ": " + intervalSosire[i].ToString());
            }
            double probabilitateTeoretica = Math.Exp(-lambda * t) * Math.Pow(lambda * t, nrClientiDupaT) / Factorial(nrClientiDupaT);
            double probabilitateEmpirica = (double)nrClientiDupaT / (n - 1);

            textBox6.AppendText("\r\nProbabilitatea teoretica = " + probabilitateTeoretica.ToString("0.00000"));
            textBox6.AppendText("\r\nProbabilitatea empirica = " + probabilitateEmpirica.ToString("0.00000"));

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] x;
            double s = 0;
            int i;
            for (i = 0; i < n; i++)
            {
                s += intervalSosire[i];
            }
            s = s / n;
            textBox6.AppendText("\r\nMedia teoretica=" + (1 / lambda).ToString());
            textBox6.AppendText("\r\nMedia empririca = " + s.ToString()) ; 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        double F(double d, double lambda)
        {
            return 1 - Math.Exp(-lambda * d);
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}
