using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EditorGrafos
{
   
    class GrafoNoDirigido : Grafo
    {
        #region Constructor
        public GrafoNoDirigido(Grafo g)
        {
            foreach (NodoP n in g)
            {
                this.Add(n);
            }
            actualizaPropiedades(g);
        }
        public void actualizaPropiedades(Grafo g)
        {
            this.penN = new Pen(g.cNodo);
            this.penA = new Pen(g.cArista);
            this.width = g.width;
            this.widthA = g.widthA;
            this.font = g.font;
            this.brushN = new SolidBrush(g.cRelleno);
            //  this.brushF = new SolidBrush(g.)
        }
        #endregion
        #region complemento

        public override Grafo complemento(Graphics g)
        {
            NodoP nn;
            Arista nnr;
            Grafo nuevo = new Grafo();
            foreach (NodoP np in this)
            {
                nn = new NodoP(np.nombre, np.centro);
                nuevo.Add(nn);
            }
            nuevo = new GrafoNoDirigido(nuevo);

            foreach (NodoP aux1 in this) // Ciclo que recorre los nodos del grafo
            {
                if (aux1.aristas.Count == 0) // si el nodo no tiene aristas
                {
                    foreach (NodoP aux2 in nuevo) // Ciclo que recorre los nodos del grafo "copia"
                    {
                        if (aux1.nombre != aux2.nombre) // Condición para que el nodo no apunte a si mismo
                        {
                            nnr = new Arista(0);
                            nnr.origen = nuevo.Find(x => x.nombre.Equals(aux1.nombre));
                            nnr.destino = aux2;
                            nuevo.Find(x => x.nombre.Equals(aux1.nombre)).aristas.Add(nnr);
                        }
                    }
                }

                else // Si el nodo ya tiene Aristas
                {
                    foreach (NodoP aux2 in nuevo) // Ciclo que recorre los nodos 
                    {
                        if (aux1.nombre != aux2.nombre) // Compara que el nodo no se apunte a si mismo
                        {
                            Arista r = new Arista(0);
                            r = aux1.aristas.Find(x => x.destino.nombre.Equals(aux2.nombre));
                            if (r == null)
                            {
                                nnr = new Arista(0);
                                nnr.origen = nuevo.Find(x => x.nombre.Equals(aux1.nombre));
                                nnr.destino = aux2;
                                if (nnr != null)
                                    nuevo.Find(x => x.nombre.Equals(aux1.nombre)).aristas.Add(nnr);
                            }
                        }
                    }
                }
            }

            //base.complemento(g);

            return nuevo;
        }
        #endregion
        #region nPartita
        public override List<List<int>> nPartita(Graphics g)
        {
            bool band = false;
            bool band2 = false;
            bool band3 = false;
            /*Hacer una lista de arreglos */
            List<int> lista;
            List<List<int>> partitas = new List<List<int>>();
            /*Crear metodo para saber si existe el elemento */

            lista = new List<int>();
            foreach (NodoP np in this)
            {


                foreach (Arista nr in np.aristas)
                {
                    lista = new List<int>();
                    foreach (NodoP np2 in this)
                    {
                        if (nr.destino.nombre == np2.nombre)
                        {
                            band2 = true;
                        }
                        else
                        {

                            band = encuentraLista(lista, np2.nombre);
                            if (band == false)
                            {
                                band3 = buscaRelacion(np, np2.nombre, this, lista);
                                if (band3 == false)
                                {
                                    band2 = encuentraNombre(partitas, np2.nombre);
                                    if (band2 == false)
                                    {
                                        lista.Add(np2.nombre);
                                    }


                                }


                            }

                        }
                    }

                }
                if (lista.Count > 0)
                {
                    band2 = encuentraNombre(partitas, np.nombre);
                    if (band2 == false)
                        partitas.Add(lista);
                }

            }
            return partitas;

        }
        public  List<List<int>> nPartitaG(Graphics g, Grafo actual)
        {
            bool band = false;
            bool band2 = false;
            bool band3 = false;
            /*Hacer una lista de arreglos */
            List<int> lista;
            List<List<int>> partitas = new List<List<int>>();
            /*Crear metodo para saber si existe el elemento */

            lista = new List<int>();
            foreach (NodoP np in actual)
            {


                foreach (Arista nr in np.aristas)
                {
                    lista = new List<int>();
                    foreach (NodoP np2 in actual)
                    {
                        if (nr.destino.nombre == np2.nombre)
                        {
                            band2 = true;
                        }
                        else
                        {

                            band = encuentraLista(lista, np2.nombre);
                            if (band == false)
                            {
                                band3 = buscaRelacion(np, np2.nombre, actual, lista);
                                if (band3 == false)
                                {
                                    band2 = encuentraNombre(partitas, np2.nombre);
                                    if (band2 == false)
                                    {
                                        lista.Add(np2.nombre);
                                    }


                                }


                            }

                        }
                    }

                }
                if (lista.Count > 0)
                {
                    band2 = encuentraNombre(partitas, np.nombre);
                    if (band2 == false)
                        partitas.Add(lista);
                }

            }
            return partitas;

        }
        public bool buscaRelacion(NodoP np, int nombre, Grafo g, List<int> lista)
        {
            bool existe = false;
            foreach (NodoP aux in g)
            {
                foreach (int l in lista)
                {
                    if (l == aux.nombre)
                    {
                        foreach (Arista nr in aux.aristas)
                        {
                            if (nr.destino.nombre == nombre)
                            {
                                existe = true;
                            }
                        }
                    }
                }
            }
            /* 
            foreach(Arista nr in np.aristas)
            {
                if(nr.destino.nombre == nombre)
                {
                    existe = true;
                }
            }
            */
            return existe;
        }
        public bool encuentraLista(List<int> lista, int nombre)
        {
            bool existe = false;
            foreach (int aux in lista)
            {
                if (aux == nombre)
                {
                    existe = true;
                }
            }
            return existe;
        }
        public bool encuentraNombre(List<List<int>> partitas, int nombre)
        {
            bool existe = false;
            foreach (List<int> aux in partitas)
            {
                foreach (int aux2 in aux)
                {
                    if (aux2 == nombre)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }
        #endregion
        #region  GrafosEspeciales
        public override void grafoKn(int nodos, Graphics g)
        {
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1, a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);

            for (a = 0; a < nodos; a++)
            {
                if (a == 0) {
                    posx = (int)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy = (int)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else {

                    angulo = (float)(angulo + angulo2);
                    posx = (int)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (int)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                }
                this.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb > 27)
                {
                    this.edoNom = true;
                }
            }
            foreach (NodoP np in this)
            {
                foreach (NodoP np2 in this)
                {
                    if (np != np2)
                    {
                        aux = new Arista(0);
                        aux.origen = np;
                        aux.destino = np2;
                        np.aristas.Add(aux);
                    }
                }
            }
            //this.ImprimirGrafo(g);
        }
        public override void grafoCn(int nodos, Graphics g)
        {
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1, a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);

            for (a = 0; a < nodos; a++)
            {
                if (a == 0)
                {
                    posx = (int)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy = (int)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else
                {

                    angulo = (double)(angulo + angulo2);
                    posx = (int)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (int)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                }
                this.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb > 27) {
                    this.edoNom = true;
                }
                if (a > 0)
                {
                    aux = new Arista(0);
                    aux.origen = this[a - 1];
                    aux.destino = this[a];
                    this[a - 1].aristas.Add(aux);
                    aux = new Arista(0);
                    aux.origen = this[a];
                    aux.destino = this[a - 1];
                    this[a].aristas.Add(aux);
                }
            }
            aux = new Arista(0);
            aux.origen = this[a - 1];
            aux.destino = this[0];
            this[a - 1].aristas.Add(aux);
            aux = new Arista(0);
            aux.origen = this[0];
            aux.destino = this[a - 1];
            this[0].aristas.Add(aux);
            // this.ImprimirGrafo(g);

        }
        public override List<int> nodoPendiente()
        {
            List<int> pendiente = new List<int>();

            foreach (NodoP np in this)
            {
                if (np.aristas.Count == 1)
                {
                    pendiente.Add(np.nombre);
                }
            }
            return pendiente;
        }
        public override List<int> verticeCut()
        {
            List<int> cut = new List<int>();
            Arista nBand;
            Arista nBand2;
            bool band = false;
            foreach (NodoP np in this)
            {

                foreach (NodoP aux in this)
                {
                    if (aux != np)
                    {
                        nBand = np.aristas.Find(x => x.destino.Equals(aux));

                        if (nBand == null) {
                            int cont = 0;
                            foreach (Arista nr in np.aristas) {
                                foreach (Arista nn in nr.destino.aristas)
                                {
                                    if (nn.destino == aux)
                                    {

                                        cont++;
                                    }
                                }
                            }
                            if (cont == 1)
                            {
                                cut.Add(aux.nombre);
                            }


                        }

                    }


                }





            }
            return cut;
        }
        public bool buscaSigRelacion(NodoP nodo, NodoP actual)
        {
            bool band = false;



            foreach (NodoP aux in this)
            {

                if (aux == actual)
                {
                    foreach (Arista nr in aux.aristas)
                    {
                        if (nr.destino == nodo)
                            band = true;
                        else
                            band = false;
                    }
                }

            }
            return band;
        }
        public override void grafoWn(int nodos, Graphics g)
        {
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1, a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);
            for (a = 0; a < nodos; a++)
            {
                if (a == 0)
                {
                    posx = (double)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy = (double)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else
                {

                    angulo = angulo + angulo2;
                    posx = (double)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (double)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                }
                this.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb >= 27)
                {
                    this.edoNom = true;
                }
                if (a > 0)
                {
                    aux = new Arista(0);
                    aux.origen = this[a - 1];
                    aux.destino = this[a];
                    this[a - 1].aristas.Add(aux);
                    aux = new Arista(0);
                    aux.origen = this[a];
                    aux.destino = this[a - 1];
                    this[a].aristas.Add(aux);

                }
            }
            aux = new Arista(0);
            aux.origen = this[a - 1];
            aux.destino = this[0];
            this[a - 1].aristas.Add(aux);
            aux = new Arista(0);
            aux.origen = this[0];
            aux.destino = this[a - 1];
            this[0].aristas.Add(aux);

            Point center = new Point((int)centrox, (int)centroy);
            this.Add(new NodoP(nomb, center));
            a++;

            foreach (NodoP np in this)
            {
                if (np != this[a - 1])
                {
                    aux = new Arista(0);
                    aux.origen = np;
                    aux.destino = this[a - 1];
                    np.aristas.Add(aux);

                    aux = new Arista(0);
                    aux.origen = this[a - 1];
                    aux.destino = np;
                    this[a - 1].aristas.Add(aux);

                }

            }
            //this.ImprimirGrafo(g);
        }
        #endregion


        #region CIRCUTO Y CAMINO EULERIANO
        public override void pintaEuler(Graphics g,List<NodoP> nodos)
        {
            coloreate();
            ImprimirGrafo(g, true);
            for(int i = 0; i < nodos.Count; i++)
            {
                NodoP aux = this.Find(x => x.Equals(nodos[i]));
                if(aux!=null)
                {
                    aux.colorN = new SolidBrush(Color.LightBlue);
                    ImprimirGrafo(g, true);
                    if( i < nodos.Count-1)
                    {
                        Arista aux2 = aux.aristas.Find(x => x.destino.Equals(nodos[i + 1]));
                        if (aux2 != null)
                        {
                            aux2.colorA = new Pen(Color.Red, 5);

                        }
                    }
                    
                    
                    Thread.Sleep(700);
                    ImprimirGrafo(g, true);
                }
            }
            

        }
        public override void coloreate()
        {
            foreach (NodoP np in this)
            {
                try
                {
                    np.colorN = new SolidBrush(Color.White);
                    foreach (Arista E in np.aristas)
                    {
                        E.colorA = new Pen(Color.Black, 1);
                    }
                }
                catch
                {
                    break;
                }
                
            }
       
        }
        // ***************************************************************************************************** CIRCUITO EULERIANO
        public override List<NodoP> circuitoEuleriano()
        {
            List<NodoP> circuito = new List<NodoP>();
            string cad = "";
            List<Arista> caminos = new List<Arista>();
            int nodos = 0;
            NodoP aux;
            NodoP primero;
            Random srand;
            srand = new Random();
            coloreate();
            int ariA = 0; 
            aux = this[0];
            primero = aux;
            int j = 0;
            Arista compara;
            int grado = 0;
            foreach (NodoP np in this) {
                grado = grado + np.aristas.Count;
            }
            j = 0;
            caminos.Clear();
            circuito.Clear();
            while (nodos < grado)// grado / 2)
            {
                j = srand.Next(0, aux.aristas.Count);
                compara = caminos.Find(x => x.Equals(aux.aristas[j]));
                if (aux.aristas[j].destino == this[0])
                    ariA++;


                if (compara == null)
                {

                    caminos.Add(aux.aristas[j]);
                    Arista invertida = buscaInvertida(aux, aux.aristas[j].destino);
                    caminos.Add(invertida);
                    circuito.Add(aux);
                    aux = aux.aristas[j].destino;
                    nodos += 2;
                }
                else
                    ariA++;
                if (ariA > 1000)
                {
                    caminos.Clear();
                    circuito.Clear();
                    nodos = 0;
                    ariA = 0;
                }
                    

                
                
           






            }
            circuito.Add(aux);
           // circuito.Add(primero);

            return circuito;

        }
        public void pintaGrafoDefault()
        {
            foreach(NodoP np in this)
            {
                foreach(Arista nr in np.aristas)
                {
                    nr.colorA = new Pen(Color.Black,1);
                }
                np.colorN = new SolidBrush(Color.White);
                
            }

        }
        // ********************************************************************************************************************CAMNINO EULERIANO
        public override List<NodoP> caminoEuleriano()
        {

            string cad = "";
            List<NodoP> cirucuto = new List<NodoP>();
            List<Arista> caminos = new List<Arista>();
            int pos = 0;
            int nodos = 0;
            NodoP aux;
           // pintaGrafoDefault();

            foreach (NodoP np in this)
            {
                np.colorN = new SolidBrush(Color.White);
                foreach (Arista E in np.aristas)
                {
                    E.colorA = new Pen(Color.Black, 1);
                }
            }
            Random srand;
            srand = new Random();

            foreach (NodoP np in this)
            {
                if (np.aristas.Count % 2 != 0 && np.aristas.Count > 0)
                {
                    break;
                }
                pos++;
            }

            aux = this[pos];
            int j = 0;
            Arista compara;
            int grado = 0;
            NodoP anterior;
            foreach (NodoP np in this)
            {
                grado = grado + np.aristas.Count;
            }
            j = 0;
            while (nodos  < grado/2)
            {
                j = srand.Next(0, aux.aristas.Count);
                compara = caminos.Find(x => x.Equals(aux.aristas[j]));
                if(compara == null)
                {
                    anterior = aux;
                    caminos.Add(aux.aristas[j]);
                    Arista invertida = buscaInvertida(aux,aux.aristas[j].destino);
                    caminos.Add(invertida);
                    cirucuto.Add(aux);     
                    aux = aux.aristas[j].destino;
                    nodos++;
                }
                
            }
            cad += (char)(aux.nombre + 64);
            cirucuto.Add(aux);
            return cirucuto; 
        }
        private Arista buscaInvertida(NodoP origen, NodoP destino)
        {
            foreach(Arista nr in destino.aristas)
            {
                if(nr.destino == origen)
                {
                    return nr;
                }
            }
            return null;
        }
        #endregion
        #region  Algoritmo Warner
        public void eliminaNodo(Grafo grafo,NodoP p)
        {
            NodoP nodoP;
            List<Arista> l = new List<Arista>();
            nodoP = p;
            if (nodoP != null)
            {
                //nodoP.aristas.Clear();
                foreach (NodoP n in grafo)
                {
                    foreach (Arista nr in n.aristas)
                    {
                        if (nr.destino.nombre == nodoP.nombre)
                        {
                            n.aristas.Remove(nr);

                            break;
                        }
                            
                    }
                    foreach (Arista nr in n.aristas)
                    {
                        if (nr.origen.nombre == nodoP.nombre)
                        {
                            n.aristas.Remove(nr);

                            break;
                        }

                    }

                }
                grafo.Remove(nodoP);
                grafo.RemoveAt(nodoP.nombre - 1);
            }
           
        }

        public override int warner(Graphics g, NodoP pNodo)
        {
            Grafo copia = new Grafo();
            Grafo K5, K33;
            NodoP aux;
            NodoP elimina;
            Arista arista;
            bool band;
            List<List<int>> partita = new List<List<int>>();
            
            foreach(NodoP np in this){
                aux = new NodoP(np.nombre, np.centro);
                foreach(Arista nr in np.aristas)
                {
                    arista = new Arista(0);
                    arista.destino = nr.destino;
                    arista.origen = nr.origen;
                    aux.aristas.Add(arista);
                }
                copia.Add(aux);
            }

            eliminaNodo(copia, pNodo);

            if (copia.Count >= 6)
            {
                if (copia.Count == 6){
                    // verificar si todas tienen el mismo grafo
                    int grado = copia[0].aristas.Count;
                    bool bandera = false;
                    foreach (NodoP np in copia)
                    {
                        if (grado == np.aristas.Count)
                        {
                            bandera = true;
                        }
                        else
                        {
                            bandera = false;
                            break;
                        }
                    }
                    if (bandera)
                    {
                        partita = nPartitaG(g, copia);
                        if (partita.Count == 2)
                        {
                            return 2;
                        }
                    }

                }
            }
            else
            {
                // compara con un K5
                K5 = creaKn(5);
                //K33 = creaKmn(3,3);
                band = isomorfico(copia, K5);
                if (band == true)
                {
                    return 1;
                }
                else
                {
                    //se verifica con un K33


                    return 0;
                }
            }
            return 0;
               
        }
        public Grafo creaKmn(int v, int e)
        {
            Grafo nuevo = new Grafo();
            NodoP aux;
            List<NodoP> dominio = new List<NodoP>();
            List<NodoP> rango = new List<NodoP>();
            int j = v;
            for(int i = 0; i < v; i++)
            {
                aux = new NodoP(i,new Point());
                dominio.Add(aux);
            }
            for(int i = 0; i < e; i++)
            {
                aux = new NodoP(j, new Point());
                rango.Add(aux);
                j++;
            }
            // AGREGAR REALCIONES 
            foreach(NodoP np in dominio)
                nuevo.Add(np);
            foreach (NodoP np in rango)
                nuevo.Add(np);
            
       
       


            return nuevo;
        }
        // ALGORITMO ENCARGADO DE ENCONTRAR SI 2 GRAFOS SON ISOMORFICOS
        public bool isomorfico(Grafo actual, Grafo compara)
        {
            bool band = false;
            int nodosA = 0;
            int nodosC = 0;
            int gradoA = 0;
            int gradoC = 0;
            foreach(NodoP np in actual)
            {
                nodosA++;
                gradoA += np.aristas.Count;
            }
            foreach(NodoP np in compara)
            {
                nodosC++;
                gradoC += np.aristas.Count;
            }
            
            if(nodosA == nodosC)
            {
                if(gradoC == gradoA)
                {
                    return true;
                }

            }
            return band;
        }
        public Grafo creaKn(int nodos)
        {
            Grafo grafo = new Grafo();
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1, a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);

            for (a = 0; a < nodos; a++)
            {
                if (a == 0)
                {
                    posx = (int)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy = (int)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else
                {

                    angulo = (float)(angulo + angulo2);
                    posx = (int)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (int)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                }
                grafo.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb > 27)
                {
                    grafo.edoNom = true;
                }
            }
            foreach (NodoP np in grafo)
            {
                foreach (NodoP np2 in grafo)
                {
                    if (np != np2)
                    {
                        aux = new Arista(0);
                        aux.origen = np;
                        aux.destino = np2;
                        np.aristas.Add(aux);
                    }
                }
            }
            return grafo;
        }
        public List<List<NodoP>> kruskal()
        {
            // 1) Crear lista de aristas y lista de listas que serviran como las componentes
            List<Arista> temp;
            List<NodoP> nodos;
            List<List<NodoP>> comp = new List<List<NodoP>>();
            int i = 0;
            List<List<Arista>> componentes = new List<List<Arista>>();
            
            // 2) Agregar TODAS las relaciones del grafo a la lista relaciones
            List<Arista> relaciones = new List<Arista>();
            foreach(NodoP np in this){
                foreach (Arista nr in np.aristas){
                    if(nr.peso != 0)
                        relaciones.Add(nr);
                }
            }
    //        int i;
            // Ordena la lista por peso
            relaciones = relaciones.OrderBy(x => x.peso).ToList();

            // 3) Se procede a recorrer la lista de relaciones
            foreach(Arista nr in relaciones)
            {
                if(nr == relaciones[0])
                {
                    nodos = new List<NodoP>();
                    temp = new List<Arista>();
                    temp.Add(nr);
                    componentes.Add(temp);
                    nodos.Add(nr.origen);
                    nodos.Add(nr.destino);
                    comp.Add(nodos);
                }
                else
                {
                    // Encontrar nodo origen en lista de listas

                    NodoP origen  = buscaComponente(comp, nr.origen);
                    NodoP destino = buscaComponente(comp, nr.destino);
                    if(origen == null && destino == null) // Si no se encuentra ningun nodo entonces se agregan a un nuevo componente
                    {
                        nodos = new List<NodoP>();
                        nodos.Add(nr.origen);
                        nodos.Add(nr.destino);
                        comp.Add(nodos);
                    }
                    else if( origen != null && destino == null)// Si se encuentra origen, busca su posicion y se agrega al que ya existe
                    {
                        int pos = encuentraPosicion(comp, origen);
                        comp[pos].Add(nr.origen);
                        comp[pos].Add(nr.destino);
                        

                    }
                    else if (origen == null && destino != null)
                    {
                        int pos = encuentraPosicion(comp, destino);
                        comp[pos].Add(nr.origen);
                        comp[pos].Add(nr.destino);
                    }
                    else if(origen != null && destino != null) // Existe en ambos
                    {
                        int posA = encuentraPosicion(comp, origen);
                        int posB = encuentraPosicion(comp, destino);
                        if (posA != posB)
                        {
                            comp[posA].Add(nr.origen);
                            comp[posA].Add(nr.destino);
                            foreach (NodoP np in comp[posB])
                            {
                                comp[posA].Add(np);
                            }
                        
                            comp[posB].Clear();
                            comp.RemoveAt(posB);
                        }
                         //   break;
                        
                      
                       



                    }
                    /*
                     i = 0;

                    foreach(List<Arista> busca in componentes)
                    {
                        foreach(Arista busca2 in busca)
                        {
                            if(busca2.origen == nr.origen)
                            {
                                 
                            }
                        }
                        i++;
                        
                    }
                    */
                }
            }
            return comp;
        }
        private int encuentraPosicion(List<List<NodoP>> com, NodoP nodo)
        {
            int i = 0;
            foreach(List<NodoP> lnp in com)
            {
                foreach(NodoP np in lnp)
                {
                    if (np == nodo)
                        return i;
                }
                i++;
            }
            return 0;
        }
        private NodoP buscaComponente(List<List<NodoP>> comp, NodoP nodo)
        {
            foreach(List<NodoP> lnp in comp)
            {
                foreach(NodoP np in lnp)
                {
                    if (np == nodo)
                        return np;
                }
            }
            return null;
        }
        // ALGORITMO PARA DETECTAR SI UN GRAFO PUEDE LLEGAR A TENER UN CICLO SI SE LE AÑADE UNA ARISTA
        // Se coloca aux al nodo inicio y desde ahi se empieza a buscar si puede llegar a nodo final
       
        private bool encuentraCiclo( Grafo grafo,NodoP inicio, NodoP final)
        {
            NodoP aux = inicio;
            while (aux.aristas.Count > 0)
            {
                foreach(Arista nr in aux.aristas)
                {
                    if (nr.destino == final)
                        return true;
                    else
                        aux = nr.destino;
                }
                
            }
            return false;
        }
        // Metodo encargado de encontrar si dos nodos estan en la misma posición
        public NodoP nodoIgual(Grafo grafo)
        {
            NodoP igual = null;
            NodoP compara;
            igual = grafo[0];
            foreach(NodoP np in grafo)
            {
                if(np != igual)
                {
                    compara = grafo.Find(x => x.centro.Equals(igual.centro));
                    if (compara != null && compara != np)
                    {
                        return igual;
                    }
                }
                
            }
            return igual;
        }
        #endregion
    }
}
