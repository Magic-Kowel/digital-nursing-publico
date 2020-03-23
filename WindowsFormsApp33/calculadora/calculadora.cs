using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp33.calculadora
{
    public partial class calculadora : Form
    {
        double primero;
        double segundo;
        string operador;
        public calculadora()
        {
            InitializeComponent();
        }
        ClaseSuma obj1 = new ClaseSuma();
        ClaseResta obj2 = new ClaseResta();
        ClaseMultiplicar obj3 = new ClaseMultiplicar();
        ClaseDividir obj4 = new ClaseDividir();
        
        private void button13_Click(object sender, EventArgs e)
        {

            try
            {
                segundo = double.Parse(Pantalla.Text);
                double sum;
                double Res;
                double Mul;
                double Div;
                switch (operador)
                {
                    case "+":
                        sum = primero + segundo;
                        Pantalla.Text = sum.ToString();
                        break;
                    case "-":
                        Res = primero - segundo;
                        Pantalla.Text = Res.ToString();
                        break;
                    case "*":
                        Mul= primero *segundo;
                        Pantalla.Text = Mul.ToString();
                        break;
                    case "/":
                        Div = primero/segundo;
                        Pantalla.Text = Div.ToString();
                        break;
                }
            }
            catch (Exception)
            {
                Pantalla.Text = Pantalla.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "9";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "4";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "5";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "6";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "2";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "3";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Pantalla.Text += "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Pantalla.Text += ".";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pantalla.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pantalla.Text.Length == 1)
                {
                    Pantalla.Text = "";
                }
                else
                {
                    Pantalla.Text = Pantalla.Text.Substring(0, Pantalla.Text.Length - 1);
                }
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "+";
                primero = Convert.ToDouble(Pantalla.Text);
                //Pantalla.Text +="+";
                Pantalla.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "-";
                primero = Convert.ToDouble(Pantalla.Text);
                //Pantalla.Text += "-";
                Pantalla.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "*";
                primero = Convert.ToDouble(Pantalla.Text);
                //Pantalla.Text += "*";
                Pantalla.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                operador = "/";
                primero = Convert.ToDouble(Pantalla.Text);
                //Pantalla.Text += "/";
                Pantalla.Clear();
            }
            catch (Exception)
            {

            }
        }
    }
}
