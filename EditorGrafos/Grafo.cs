using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EditorGrafos
{
    class Grafo : List<NodoP>
    {
        public Font font;
        public Pen penA, penN;
        public SolidBrush brushN, brushF;
        public int tipo { get; set; }

        private NodoP nodoP;
        public bool bpar;
        private Color CNODO;
        public Color cNodo { set { CNODO = value; } get { return CNODO; } }
        private float WIDTH;
        public float width { set { WIDTH = value; } get { return WIDTH; } }
        private Color CRELLENO;
        public Color cRelleno { set { CRELLENO = value; } get { return CRELLENO; } }
        private int RADIO;
        public int radio { set { RADIO = value; } get { return RADIO; } }

        private Color CARISTA;
        public Color cArista { set { CARISTA = value; } get { return CARISTA; } }
        private float WIDTHA;
        public float widthA { set { WIDTHA = value; } get { return WIDTHA; } }

        private Color COLORFUENTE;
        public Color colorFuente { set { COLORFUENTE = value; } get { return COLORFUENTE; } }
        private String NAMEF;
        public string nameF { set { NAMEF = value; } get { return NAMEF; } }
        private float SIZEF;
        public float sizeF { set { SIZEF = value; } get { return SIZEF; } }
        private FontStyle STYLEF;
        public FontStyle styleF { set { STYLEF = value; } get { return STYLEF; } }

        public int numN;
        public bool edoNom;

        public int nomb { get; set; }

        // TIPO
        // 1 GRAFO
        // 2 NO DIRIGIDO
        // 3 DIRIGIDO
        public Grafo()
        {
        
            numN = 1;
            edoNom = false;
            bpar = false;
            RADIO = 25;
            CNODO = Color.Black;
            WIDTH = 1;
            CRELLENO = Color.White;

            WIDTHA = 1;
            CARISTA = Color.Black;

            COLORFUENTE = Color.Black;
            nameF = "Times New Roman";
            sizeF = 10;
            styleF = FontStyle.Bold;

            font = new Font(nameF, sizeF, styleF);
            penN = new Pen(CNODO, WIDTH);
            penA = new Pen(CARISTA, WIDTHA);
            brushF = new SolidBrush(COLORFUENTE);
            brushN = new SolidBrush(CRELLENO);
        }

        public NodoP BuscaNodo(Point pt)
        {
            foreach (NodoP n in this)
            {
                if (Math.Sqrt(Math.Pow(n.centro.X - pt.X, 2) + Math.Pow(n.centro.Y - pt.Y, 2)) <= radio)
                    return n;
            }
            return null;
        }

        public void MueveGrafo(int dx, int dy)
        {
            Point p = new Point();
            foreach(NodoP n in this)
            {
                p.X = n.centro.X + dx;
                p.Y = n.centro.Y + dy;
                
                n.centro = p;
            }
        }

        public Arista encuentraArista(Point p)
        {
            double m, b, y;
            double xp, yp, xn, yn, xnr, ynr;
            xp = p.X;
            yp = p.Y;
            int sensibilidad = 5;
            Arista temp = null;

            foreach (NodoP n in this)
            {
                foreach (Arista nr in n.aristas)
                {
                    xn = n.centro.X;
                    yn = n.centro.Y;
                    xnr = nr.destino.centro.X;
                    ynr = nr.destino.centro.Y;

                    if (n.Equals(nr.destino))
                    {
                        NodoP nAux = BuscaNodo(p);
                        if (nAux != null && nAux.Equals(n))
                        {
                            //n.aristas.Remove(nr);
                            temp = nr;
                            return temp;
                        }
                    }

                    if ((xnr - xn) == 0)
                    {
                        if ((yp < yn && yp > ynr) || (yp > yn && yp < ynr))
                        {
                            if ((xp < xnr + sensibilidad && xp > xn - sensibilidad) || (xp > xnr - sensibilidad && xp < xn + sensibilidad))
                            {
                                //n.aristas.Remove(nr);
                                temp = nr;
                                return temp;
                            }
                        }
                    }

                    m = (ynr - yn) / (xnr - xn);
                    b = yn - (m * xn);
                    y = m * xp + b;

                    if (yp >= y - sensibilidad && yp <= y + sensibilidad)
                    {
                        if ((xp < xnr + sensibilidad && xp > xn - sensibilidad) || (xp > xnr - sensibilidad && xp < xn + sensibilidad))
                        {
                           
                            return nr;

                        }
                    }
                }
            }
            return null;
        }

        public Arista encuentraSegundaArista(Point p)
        {
            int cont = 0;
            double m, b, y;
            double xp, yp, xn, yn, xnr, ynr;
            xp = p.X;
            yp = p.Y;
            int sensibilidad = 2;
            Arista temp = null;

            foreach (NodoP n in this)
            {
                foreach (Arista nr in n.aristas)
                {
                    xn = n.centro.X;
                    yn = n.centro.Y;
                    xnr = nr.destino.centro.X;
                    ynr = nr.destino.centro.Y;

                    if (n.Equals(nr.destino))
                    {
                        NodoP nAux = BuscaNodo(p);
                        if (nAux != null && nAux.Equals(n))
                        {
                            if (cont > 0)
                            {
                                temp = nr;
                                return temp;
                                
                            }
                            else
                            {
                                cont++;
                            }
                        }
                    }

                    if ((xnr - xn) == 0)
                    {
                        if ((yp < yn && yp > ynr) || (yp > yn && yp < ynr))
                        {
                            if ((xp < xnr + sensibilidad && xp > xn - sensibilidad) || (xp > xnr - sensibilidad && xp < xn + sensibilidad))
                            {
                                if (cont > 0)
                                {
                                    temp = nr;
                                    return temp;
                                }
                                else
                                {
                                    cont++;
                                }
                            }
                        }
                    }

                    m = (ynr - yn) / (xnr - xn);
                    b = yn - (m * xn);
                    y = m * xp + b;

                    if (yp >= y - sensibilidad && yp <= y + sensibilidad)
                    {
                        if ((xp < xnr + sensibilidad && xp > xn - sensibilidad) || (xp > xnr - sensibilidad && xp < xn + sensibilidad))
                        {
                            if (cont > 0)
                                return nr;
                            else
                                cont++;

                        }
                    }
                }
            }
            return null;
        }

        public void BorrarNodo(Point p)
        {
            List<Arista> l = new List<Arista>();
            nodoP = this.BuscaNodo(p);
            if (nodoP != null)
            {
                foreach (NodoP n in this)
                {
                    foreach (Arista nr in n.aristas)
                    {
                        if (nr.destino.Equals(nodoP))
                            l.Add(nr);
                    }
                    foreach (Arista nr in l)
                        n.aristas.Remove(nr);
                }
                this.Remove(nodoP);
            }
        }

        public int BorrarArista(Point p)
        {
            double m, b, y;
            double xp, yp, xn, yn, xnr, ynr;
            xp = p.X;
            yp = p.Y;
            int sensibilidad = 5;

            
            foreach (NodoP n in this)
            {
                foreach (Arista nr in n.aristas)
                {
                    xn = n.centro.X;
                    yn = n.centro.Y;
                    xnr = nr.destino.centro.X;
                    ynr = nr.destino.centro.Y;

                    if(n.Equals(nr.destino))
                    {
                        NodoP nAux = BuscaNodo(p);
                        if(nAux != null && nAux.Equals(n))
                        {
                            n.aristas.Remove(nr);
                            return 1;
                        }
                    }

                    if ((xnr - xn) == 0)
                    {
                        if ((yp < yn && yp > ynr) || (yp > yn && yp < ynr))
                        {
                            if ((xp < xnr + sensibilidad && xp > xn - sensibilidad) || (xp > xnr - sensibilidad && xp < xn + sensibilidad))
                            {
                                n.aristas.Remove(nr);
                                return 1;
                            }
                        }
                    }

                    m = (ynr - yn) / (xnr - xn);
                    b = yn - (m * xn);
                    y = m * xp + b;
                    
                    if (yp >= y - sensibilidad && yp <= y + sensibilidad)
                    {
                        if((xp < xnr + sensibilidad && xp > xn - sensibilidad) || (xp > xnr - sensibilidad && xp < xn + sensibilidad))
                        {
                            n.aristas.Remove(nr);
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        public Point BuscaInterseccion(Point po, Point pd)
        {
            Point p = new Point();
            double m;
            double cordX = 0, cordY = 0;
            double pox, poy, pdx, pdy;

            pox = (double)po.X;
            poy = (double)po.Y;
            pdx = (double)pd.X;
            pdy = (double)pd.Y;

            if ((pdx - pox) != 0)
            {
                m = ((pdy - poy) / (pdx - pox));
                m = (double)Math.Atan(m);
                cordY = (double)Math.Sin(m) * radio;
                cordX = (double)Math.Cos(m) * radio;

                cordY = (double)Math.Round(cordY);
                cordX = (double)Math.Round(cordX);
            }

            if (pox == pdx)
            {
                p.X = (int)(pox + 0);
                if(pdy > poy)
                    p.Y = (int)(poy + radio);
                else
                    p.Y = (int)(poy - radio);
            }

            if (pox < pdx)
            {
                p.X = (int)(pox + cordX);
                p.Y = (int)(poy + cordY);
            }

            if (po.X > pd.X)
            {
                p.X = (int)(pox - cordX);
                p.Y = (int)(poy - cordY);
            }

            return p;
        }
        #region Metodos
        public virtual Grafo complemento(Graphics g)
        {            
            //this.ImprimirGrafo(g);   
            return this;
        }
        public virtual List<List<int>> nPartita(Graphics g) { return new List<List<int>>(); }

        #endregion


        public void ImprimirGrafo(Graphics g, bool band)
        {
            bpar = band;   
            if(bpar == false)
            {
                foreach (NodoP n in this)
                {
                    foreach (Arista nR in n.aristas)
                    {
                        if (nR.destino.Equals(n))
                            g.DrawBezier(penA, n.centro.X - 15, n.centro.Y - 15, n.centro.X - 20, n.centro.Y - 60, n.centro.X + 20, n.centro.Y - 60, n.centro.X + 15, n.centro.Y - 15);
                        else
                            g.DrawLine(penA, BuscaInterseccion(n.centro, nR.destino.centro), BuscaInterseccion(nR.destino.centro, n.centro));
                    }

                    g.FillEllipse(brushN, n.centro.X - radio, n.centro.Y - radio, radio * 2, radio * 2);
                    g.DrawEllipse(penN, n.centro.X - radio + (penN.Width / 2), n.centro.Y - radio + (penN.Width / 2), radio * 2 - (penN.Width / 2), radio * 2 - (penN.Width / 2));
                    g.DrawString(n.nombre.ToString(), font, brushF, n.centro.X - 6, n.centro.Y - 6);

                }

            }
            else
            {
               // Thread.Sleep(1000);
                foreach (NodoP n in this)
                {
                    foreach (Arista nR in n.aristas)
                    {
                        if (nR.destino.Equals(n))
                            g.DrawBezier(penA, n.centro.X - 15, n.centro.Y - 15, n.centro.X - 20, n.centro.Y - 60, n.centro.X + 20, n.centro.Y - 60, n.centro.X + 15, n.centro.Y - 15);
                        else
                            g.DrawLine(nR.colorA, BuscaInterseccion(n.centro, nR.destino.centro), BuscaInterseccion(nR.destino.centro, n.centro));
                    }

                    g.FillEllipse(n.colorN, n.centro.X - radio, n.centro.Y - radio, radio * 2, radio * 2);
                    g.DrawEllipse(penN, n.centro.X - radio + (penN.Width / 2), n.centro.Y - radio + (penN.Width / 2), radio * 2 - (penN.Width / 2), radio * 2 - (penN.Width / 2));
                    if (numN > 27 || edoNom)
                        g.DrawString(n.nombre.ToString(), font, brushF, n.centro.X - 6, n.centro.Y - 6);
                    else
                        g.DrawString(((char)(n.nombre + 64)).ToString(), font, brushF, n.centro.X - 6, n.centro.Y - 6);

                }
            }
            
        }/*
        public void ImprimirGrafo(Graphics g, int i)
        {
            foreach (NodoP n in this)
            {
                foreach (Arista nR in n.aristas)
                {
                    if (nR.destino.Equals(n))
                        g.DrawBezier(penA, n.centro.X - 15, n.centro.Y - 15, n.centro.X - 20, n.centro.Y - 60, n.centro.X + 20, n.centro.Y - 60, n.centro.X + 15, n.centro.Y - 15);
                    else
                        g.DrawLine(penA, BuscaInterseccion(n.centro, nR.destino.centro), BuscaInterseccion(nR.destino.centro, n.centro));
                }

                g.FillEllipse(n.colorN, n.centro.X - radio, n.centro.Y - radio, radio * 2, radio * 2);
                g.DrawEllipse(penN, n.centro.X - radio + (penN.Width / 2), n.centro.Y - radio + (penN.Width / 2), radio * 2 - (penN.Width / 2), radio * 2 - (penN.Width / 2));
                if (numN > 27 || edoNom)
                    g.DrawString(n.nombre.ToString(), font, brushF, n.centro.X - 6, n.centro.Y - 6);
                else
                    g.DrawString(((char)(n.nombre + 64)).ToString(), font, brushF, n.centro.X - 6, n.centro.Y - 6);

            }

        }
        */
        #region GrafosEspeciales
        public virtual void grafoKn(int nodos, Graphics g) { }
        public virtual void grafoCn(int nodos, Graphics g) { }
        public virtual void grafoWn(int nodos, Graphics g) { }
        public virtual List<int> nodoPendiente() { return  new List<int>(); }
        public virtual List<int> verticeCut() { return new List<int>(); }

        public virtual List<NodoP> circuitoEuleriano() { return new List<NodoP>();}
        public virtual List<NodoP> caminoEuleriano() { return new List<NodoP>(); }
        public virtual void pintaEuler(Graphics g, List<NodoP> listaNodos) { }
        public virtual void coloreate() { }
        public virtual int warner(Graphics g, NodoP pNodo) { return 0; }
         

        #endregion
    }
}
