using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{

    class NodoP
    {
        private List<Arista> ARISTAS;
        public List<Arista> aristas { set { ARISTAS = value; } get { return ARISTAS; } }
        private int NOMBRE;
        public int nombre { set { NOMBRE = value; } get { return NOMBRE; } }
        private Point CENTRO;
        public Point centro { set { CENTRO = value; } get { return CENTRO; } }
        private Color COLOR;
        public Color color { set { COLOR = value; }get { return COLOR; } }

        private SolidBrush colornodo;
        public SolidBrush colorN { set { colornodo = value; } get { return colornodo; } }
        public NodoP(int n, Point p)
        {
            ARISTAS = new List<Arista>();
            NOMBRE = n;
            CENTRO = p;
            colorN = new SolidBrush(Color.White);
        }
        public NodoP(int n, Point p, Color colorc)
        {
            ARISTAS = new List<Arista>();
            NOMBRE = n;
            CENTRO = p;
            colorN = new SolidBrush(colorc);
        }
    }
}
