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
    partial class nPartita : Form
    {
        public string letra;

        public nPartita(List<List<int>> partita, Grafo g)
        {
            InitializeComponent();
            string renglon = "";
            letra = "";
            float i = 0;
            foreach (List<int> aux in partita)
            {
                i++;
                
                foreach (int aux2 in aux)
                {
                    if(!g.edoNom)
                    {
                        renglon += 
                            
                            (aux2) + ", ";
                        
                        
                    }
                    else
                    {
                        renglon += aux2 + ", ";
                        RomanoG(i);
                        
                    }
                    
                        
                }
                if (!g.edoNom)
                    dataGridView1.Rows.Add(i, renglon);
                else
                    dataGridView1.Rows.Add(letra,renglon);
                renglon = "";
                
            }
            if(partita.Count == 2)
                label1.Text = "Bi-Partita";
            else if (partita.Count == 3)
                label1.Text = "Tri-Partita";
            else
                label1.Text = partita.Count.ToString() + " - Partita";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void RomanoG(float numero)
        {
            string valor;
            int unidad,decena,centena;
            int num = (int)numero;
            string cadena = "";

            letra = "";
            unidad  = (num % 100) % 10;
            decena  = (num % 100) /10;
            centena = (num / 100); 

            List<Romano> romano = new List<Romano>();
            romano.Add(new Romano("I",1));
            romano.Add(new Romano("II", 2));
            romano.Add(new Romano("III", 3));
            romano.Add(new Romano("IV", 4));
            romano.Add(new Romano("V", 5));
            romano.Add(new Romano("VI", 6));
            romano.Add(new Romano("VII", 7));
            romano.Add(new Romano("VIII", 8));
            romano.Add(new Romano("IX", 9));
            romano.Add(new Romano("X", 10));
            romano.Add(new Romano("XX",20));
            romano.Add(new Romano("XXX", 30));
            romano.Add(new Romano("XL", 40));
            romano.Add(new Romano("L", 50));
            romano.Add(new Romano("LX", 60));
            romano.Add(new Romano("LXX", 70));
            romano.Add(new Romano("LXXX", 80));
            romano.Add(new Romano("XC", 90));

            int veces = 0;
            if(num < 10)
            {
                foreach(Romano r in romano)
                {
                    if(r.dameNumero() == unidad)
                    {
                        letra = r.dameLetra();
                    }
                }
            }
            else if(num >= 10 && num < 50)
            {
                foreach(Romano r in romano)
                {
                 if(r.dameNumero() == decena*10)
                    {

                            letra += r.dameLetra();
                    }
                }
                
                foreach (Romano r in romano)
                {
                    if (r.dameNumero() == unidad)
                    {
                        letra += r.dameLetra();
                    }
                }
                
                
            }
            else
            {
                
                if(num >= 90)
                {
                    foreach(Romano r in romano)
                    {
                        if(r.dameNumero() == decena*10)
                        {
                            letra += r.dameLetra();
                        }
                    }
                    foreach(Romano r in romano)
                    {
                        if (r.dameNumero() == unidad)
                        {
                            letra += r.dameLetra();
                        }
                    }

                }
                else
                {
                    int aux = num;
                    letra += "L";
                    num = num - 50;
                    foreach (Romano r in romano)
                    {
                        if (r.dameNumero() == 10)
                        {
                            veces = num / 10;
                            for (int cont = 0; cont < veces; cont++)
                                letra += r.dameLetra();
                        }
                    }

                    foreach (Romano r in romano)
                    {
                        if (r.dameNumero() == unidad)
                        {
                            letra += r.dameLetra();
                        }
                    }
                }

                
                if(num == 100)
                {
                    letra = "C";
                 
                }

            }
            

        }
    }
}
