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
    partial class MatrizPesos : Form
    {
        public MatrizPesos(Grafo grafo, int tipo)
        {
            InitializeComponent();
            if(tipo == 2)
            {
                foreach (NodoP nodo in grafo)
                {
                    dataGridView1.Columns.Add(nodo.nombre.ToString(), nodo.nombre.ToString());
                }
                foreach (NodoP nodo in grafo)
                {
                    dataGridView1.Rows.Add();

                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = grafo[i].nombre.ToString();
                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    for (int j = 0; j < grafo[i].aristas.Count; j++)
                    {
                        dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = grafo[i].aristas[j].peso;
                        //dataGridView1.Rows[grafo[i].aristas[j].destino.nombre - 1].Cells[grafo[i].aristas[j].origen.nombre - 1].Value = grafo[i].aristas[j].peso;
                        
                    }

                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    for (int j = 0; j < grafo[i].aristas.Count; j++)
                    {
                        //dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = grafo[i].aristas[j].peso;
                        dataGridView1.Rows[grafo[i].aristas[j].destino.nombre - 1].Cells[grafo[i].aristas[j].origen.nombre - 1].Value = grafo[i].aristas[j].peso;
                        
                    }

                }
                for (int i = 0; i < grafo.Count; i++)
                {
                    for (int j = 0; j < grafo.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = -1;
                        }
                    }

                }
            }
            else
            {
                if(tipo == 3)
                {
                    foreach (NodoP nodo in grafo)
                    {
                        dataGridView1.Columns.Add(nodo.nombre.ToString(), nodo.nombre.ToString());
                    }
                    foreach (NodoP nodo in grafo)
                    {
                        dataGridView1.Rows.Add();

                    }
                    for (int i = 0; i < grafo.Count; i++)
                    {
                        dataGridView1.Rows[i].HeaderCell.Value = grafo[i].nombre.ToString();
                    }
                    for (int i = 0; i < grafo.Count; i++)
                    {
                        for (int j = 0; j < grafo[i].aristas.Count; j++)
                        {
                            dataGridView1.Rows[grafo[i].aristas[j].origen.nombre - 1].Cells[grafo[i].aristas[j].destino.nombre - 1].Value = grafo[i].aristas[j].peso;
                        }

                    }
                    for (int i = 0; i < grafo.Count; i++)
                    {
                        for (int j = 0; j < grafo.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value == null)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = -1;
                            }
                        }

                    }
                }
            }
        }
            

         
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
