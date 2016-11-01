using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase5_TP
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            CargarComboOperacion();
        }
        /// <summary>
        /// este metodo lo cree para poder elegir la operacion a realizar
        /// </summary>

        private void CargarComboOperacion()
        {
            cmbOperacion.Items.Add("+");
            cmbOperacion.Items.Add("*");
            cmbOperacion.Items.Add("/");
            cmbOperacion.Items.Add("-");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textNumero1.Clear();
            textNumero2.Clear();
        }

        private void textNumero2_TextChanged(object sender, EventArgs e)
        {
            
            //double num2 = double.Parse(textNumero1.Text);
        }

        private void textNumero1_TextChanged(object sender, EventArgs e)
        {
            //double num1 = double.Parse(textNumero1.Text);
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string operacion = "";




        }
        /// <summary>
        /// creo un objeto de tipo calculadora para poder llamar al metodo que carga
        /// y en el que valida si por error ingreso un caracter en ves de numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
         
            Calculadora Calcular = new Calculadora();
           
            Numero num1 = new Numero(double.Parse(textNumero1.Text));
            Numero num2 = new Numero(double.Parse(textNumero2.Text));
            double n1 = num1.getNumero();
            double n2 = num1.getNumero();
             

         
              
            if (!double.TryParse(textNumero1.Text, out n1))
            {
                lblResultado.Text = "ERROR INGRESE UN NUMERICO:";
            }

            if (!double.TryParse(textNumero1.Text, out n2))
            {
                lblResultado.Text = "ERROR INGRESE UN NUMERICO:";
            }



            double num = 0;
            double.TryParse(textNumero1.Text, out num);

            string oper = cmbOperacion.Text;
            oper = Calculadora.validarOperador(oper);



            double resultado = 0;
            resultado = Calculadora.Operar(num1, num2, oper);


            lblResultado.Text = resultado.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
