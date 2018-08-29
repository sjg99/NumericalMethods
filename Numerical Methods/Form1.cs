using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_Methods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<double> DList = new List<double>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {
                DList.Add(Convert.ToDouble(textBox1.Text));
            }
            textBox1.Clear();
            textBox2.Text = "1";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Data = "Data Inserted: | ",AE="Absolute Error \n";
            double avg = 0,var=0,sd=0,AAE=0;
            foreach(double x in DList)
            {
                Data = Data +x+" | ";
            }            
            foreach(double x in DList)
            {
                avg = avg + x;
            }
            avg = avg / DList.Count();
            foreach(double x in DList)
            {
                var = var + Math.Pow(x - avg, 2);
            }
            var = var / DList.Count();
            sd = Math.Sqrt(var);
            foreach (double x in DList)
            {
                AE = AE + "Absolute Error for " + x + ": " + Math.Abs(x - avg)+"\n";
                AAE = AAE + Math.Abs(x - avg);
            }            
            AE = AE + "Total Absulute Error :" + AAE / DList.Count()+"\n";
            AE = AE + "Relative Error: " + ((AAE/DList.Count())/avg)*100 + "%";
            label2.Text = Data;
            label3.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            label4.Text = Convert.ToString(avg);
            label6.Text = Convert.ToString(var);
            label8.Text = Convert.ToString(sd);
            label10.Text = AE;
            DList.Clear();

        }

        
    }
}
