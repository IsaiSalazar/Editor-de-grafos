using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    partial class Propiedades : Form
    {
        public Propiedades(Grafo grafo)
        {
            InitializeComponent();
            foreach(NodoP nod in grafo)
            {
                dataGridView1.Rows.Add();
            }
            for(int i = 0; i<grafo.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = grafo[i].nombre;
                dataGridView1.Rows[i].Cells[1].Value = grafo[i].aristas.Count;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
