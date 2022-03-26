using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interpolacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelx.Text = "";
            labely.Text = "";
            first.Text = "";
            second.Text = "";
            third.Text = "";
            fought.Text = "";
            x_i.Text = "";
            result.Text = "";

            label10.Text = "x0-x_i";
            label9.Text = "x1-x_i";
            label12.Text = "x2-x_i";
            label11.Text = "x3-x_i";
            double[,] tablica = new double[4, 7];

            double x = Double.Parse(liczba.Text);

            tablica[0, 0] = Double.Parse(x_0_x.Text);
            tablica[1, 0] = Double.Parse(x_1_x.Text);
            tablica[2, 0] = Double.Parse(x_2_x.Text);
            tablica[3, 0] = Double.Parse(x_3_x.Text);

            tablica[0, 1] = Double.Parse(x_0_y.Text);
            tablica[1, 1] = Double.Parse(x_1_y.Text);
            tablica[2, 1] = Double.Parse(x_2_y.Text);
            tablica[3, 1] = Double.Parse(x_3_y.Text);

            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 2] = tablica[0,0] - tablica[i, 0];
            }

            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 3] = tablica[1, 0] - tablica[i, 0];
            }

            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 4] = tablica[2, 0] - tablica[i, 0];
            }

            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 5] = tablica[3, 0] - tablica[i, 0];
            }

            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 6] = x - tablica[i, 0];
            }

            double f_x = tablica[0, 1] * (tablica[1, 6] * tablica[2, 6] * tablica[3, 6]) / (tablica[1, 2] * tablica[2, 2] * tablica[3, 2]) +
                 tablica[1, 1] * (tablica[0, 6] * tablica[2, 6] * tablica[3, 6]) / (tablica[0, 3] * tablica[2, 3] * tablica[3, 3]) +
                 tablica[2, 1] * (tablica[0, 6] * tablica[1, 6] * tablica[3, 6]) / (tablica[0, 4] * tablica[1, 4] * tablica[3, 4]) +
                 tablica[3, 1] * (tablica[0, 6] * tablica[2, 6] * tablica[1, 6]) / (tablica[0, 5] * tablica[2, 5] * tablica[1, 5]);
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                labelx.Text += tablica[i, 0]+"\n";
                labely.Text += tablica[i, 1] + "\n";
                first.Text += tablica[i, 2] + "\n";
                second.Text += tablica[i, 3] + "\n";
                third.Text += tablica[i, 4] + "\n";
                fought.Text += tablica[i, 5] + "\n";
                x_i.Text += tablica[i, 6] + "\n";

            }
            result.Text = $"f(x) = {f_x}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelx.Text = "";
            labely.Text = "";
            first.Text = "";
            second.Text = "";
            third.Text = "";
            fought.Text = "";
            x_i.Text = "";
            result.Text = "";

            label10.Text = "x_i,x_i+1";
            label9.Text = "x_i,x_i+1,x_i+2";
            label12.Text = "x_i,x_i+1,x_i+2,x_i+3";
            label11.Text = "";
            double[,] tablica = new double[4, 6];

            double x = Double.Parse(liczba.Text);

            tablica[0, 0] = Double.Parse(x_0_x.Text);
            tablica[1, 0] = Double.Parse(x_1_x.Text);
            tablica[2, 0] = Double.Parse(x_2_x.Text);
            tablica[3, 0] = Double.Parse(x_3_x.Text);

            tablica[0, 1] = Double.Parse(x_0_y.Text);
            tablica[1, 1] = Double.Parse(x_1_y.Text);
            tablica[2, 1] = Double.Parse(x_2_y.Text);
            tablica[3, 1] = Double.Parse(x_3_y.Text);

            for (int i = 0; i < tablica.GetLength(0) - 1; i++)
            {
                tablica[i, 2] = (tablica[i + 1, 1] - tablica[i, 1]) / (tablica[i + 1, 0] - tablica[i, 0]);
            }

            for (int i = 0; i < tablica.GetLength(0) - 2; i++)
            {
                tablica[i, 3] = (tablica[i + 1, 2] - tablica[i, 2]) / (tablica[i + 2, 0] - tablica[i, 0]);
            }
            tablica[0, 4] = (tablica[1, 3] - tablica[0, 3]) / (tablica[3, 0] - tablica[0, 0]);
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 5] = x - tablica[i, 0];
            }

            double f_x = tablica[0, 1] + tablica[0, 2] * tablica[0, 5] + tablica[0, 3] * tablica[0, 5] * tablica[1, 5] + tablica[0, 4] * tablica[0, 5] *
                tablica[1, 5] * tablica[2, 5];
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                labelx.Text += tablica[i, 0] + "\n";
                labely.Text += tablica[i, 1] + "\n";
                x_i.Text += tablica[i, 5] + "\n";
            }
            for (int i = 0; i < tablica.GetLength(0) - 1; i++)
            {
                first.Text += tablica[i, 2] + "\n";
            }
            for (int i = 0; i < tablica.GetLength(0) - 2; i++)
            {
                second.Text += tablica[i, 3] + "\n";
            }
            for (int i = 0; i < tablica.GetLength(0) - 3; i++)
            {
                third.Text += tablica[i, 4] + "\n";
            }
            result.Text = $"f(x) = {f_x}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
