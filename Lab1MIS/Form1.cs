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

namespace Lab1MIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public long factorial(int num)
        {
            long res = 1;
            for (int i = num; i > 1; i--)
                res *= i;
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            String b = (String)comboBox1.SelectedItem;
           double a = double.Parse(b);

            String c = (String)comboBox2.SelectedItem;
            int T = int.Parse(c);

            int n = 150;

            
            int[] mass = new int[n];
            double y = 0;
            double xi = 0;
            
           
            bool flag = false;

            Random rand = new Random();
            for (int j = 0; j < n; j++)
            {
                while ((flag != true) && (y <= T))
                {
                    
                    xi = (-1.0 / a) * Math.Log(rand.NextDouble());
                    
                    if ((y + xi) > T)
                    {
                        flag = true;
                    }
                    
                    else
                    {
                        mass[j]++;
                        y += xi;
                    }

                    xi = 0;
                }
                flag = false;
                y = 0;
            }
            var ilist = new List<int>();
            ilist.AddRange(mass);
            ilist.Sort();

            
            listBox1.Items.Clear();
            for (int i = 0; i < n; i++)
            {
                listBox1.Items.Add(ilist[i]);
            }

            var newilist = new List<int>(ilist.Distinct());
            var chastota = new List<int>();
            int k = 0;
           
            for (int i = 0; i < newilist.Count; i++)
            {
                chastota.Add(0);
                while ((k < ilist.Count) && (ilist[k] == newilist[i]))
                {
                    k++;
                    chastota[i] = chastota[i] + 1;
                }
            }

            
            listBox2.Items.Clear();
            for (int i = 0; i < chastota.Count; i++)
            {
                listBox2.Items.Add(i + 1 + ")   " + chastota[i]);
            }

            double tchastota = 0;
            double ati = 0;
            long fact = 0;
            double exp = 0;
            double atiexp = 0;

            var teorchastota = new List<double>();
            exp = Math.Pow(Math.E, (-(a * T)));
            for (int i = 0; i < newilist.Count; i++)
            {
                ati = Math.Pow((a * T), newilist[i]);
                fact = factorial(newilist[i]);
                atiexp = (ati * exp);
                tchastota = atiexp / (double)fact;
                tchastota *= newilist.Count;
                teorchastota.Add(tchastota * 10);
                tchastota = 0; ati = 0; fact = 0;
            }


            listBox3.Items.Clear();
            for (int i = 0; i < teorchastota.Count; i++)
            {
                listBox3.Items.Add(i + 1 + ") " + (int)teorchastota[i]);
            }

            
            double xi2 = 0;
            for (int i = 0; i < teorchastota.Count; i++)
            {
                xi2 += Math.Pow((double)chastota[i] - teorchastota[i], 2) / teorchastota[i];

            }
            if ((xi2 < 23.2)&&(xi2>0))
            { textBox1.Text = "Критерий Пирсона в пределах нормы, равен:"+xi2+". Гипотеза о Пуассоновском распределении принимается."; }
            else { textBox1.Text = "Критерий Пирсона  равен:" + xi2; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
