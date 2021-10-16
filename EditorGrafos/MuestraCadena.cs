using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    public partial class MuestraCadena : Form
    {
        string nombre;
        string cadena;
        public bool band;

        public MuestraCadena(string nombre, string cadena)
        {
            this.nombre = nombre;
            this.cadena = cadena;
            InitializeComponent();
            
        }

        private void MuestraCadena_Load(object sender, EventArgs e)
        {
           
            label1.Text = nombre;
            textBox1.Text = cadena;
            band = true;
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (band)
            {
                button1.Text = "Pause";
                timer1.Enabled = true;
                band = false;
            }
            else{
                button1.Text = "Play";
                timer1.Enabled = false;
                band = true;
            }
            
           
            
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        { 
        }

        public bool activa()
        {
            return band;
        }

        public void MuestraCadena_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   e.Cancel = true;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value) * 100;
        }
    }
}
