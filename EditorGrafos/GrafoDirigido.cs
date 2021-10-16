using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    [Serializable]
    class GrafoDirigido : Grafo
    {
        private Grafo grafo;
        List<List<int>> renglones = new List<List<int>>();
        List<int> renglon = new List<int>();
        [NonSerialized]List<NodoP> pila = new List<NodoP>();
        List<NodoP> caminos;
        List<List<NodoP>> DK = new List<List<NodoP>>();
        Pila p;
        int peso;
        public GrafoDirigido(Grafo g)
        {

            grafo = g;
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
                            else
                            {
                                continue;
                            }


                        }

                    }
                }
            }
            
            base.complemento(g);

            return nuevo;
        }
        #region variables BOSQUE ABARCADOR
        public List<NodoP> nodos { get; set; }
        public List<List<NodoP>> bosque { get; set; }
        public List<Arista> arbol { get; set; }
        public List<Arista> avance { get; set; }
        public List<Arista> retroceso { get; set; }
        public List<Arista> cruce { get; set; }
        public List<Arista> visitado;
        public Pila stack = new Pila();
        #endregion

        /****************************************************************************************
         * BOSQUE ABARCADOR EN PROFUNDIDAD
         * 1) Posicionar en el primer nodo
         * 2) Agregar nodo a lista de listas ( bosque )
         * 3) Ciclo que recorre las relaciones del nodo
         * 4) Validar si tiene 
         * 
         ****************************************************************************************/

        public void bosqueAbarcador()
        {
            bosque = new List<List<NodoP>>();
            NodoP aux;
            aux = grafo[0];
            nodos = new List<NodoP>();
            bosque.Add(new List<NodoP>());

            while (aux != null)
            {
               
                NodoP existeP = stack.nodos.Find(x => x.Equals(aux));
                if(existeP == null)
                {
                    bosque[0].Add(aux); // Se añade A
                    stack.push(aux);
                }
                bool tv2 = todoVisitado(aux);
                if (tv2 == true)
                {
                    if (stack.tope == 1)
                        break;
                    stack.pop();
                    aux = stack.ultimo();
                }
                // Se recorren sus relaciones
                foreach (Arista nr in aux.aristas)
                {
                    // Verificar si la arista ha sido visitada 
                    if (visitado == null)
                        visitado = new List<Arista>();
                    Arista existeA = visitado.Find(x => x.Equals(nr));

                    if(existeA == null) // La arista aun no ha sido visitada 
                    {
                        //verificar si nodo destino existe 
                        bool existeNodo = encuentraEnBosque(bosque, nr.destino);

                        if(existeNodo == false)
                        {
                            if (arbol == null)
                                arbol = new List<Arista>();
                            arbol.Add(nr);
                            aux = nr.destino;
                        }
                        else // El nodo ya existe en el bosque 
                        {
                            // validar si es retroceso o avance
                            int posA = damePosicion(bosque, aux);
                            int posB = damePosicion(bosque, nr.destino);

                            if(posA < posB)
                            {
                                // avance
                                if (avance == null)
                                    avance = new List<Arista>();
                                avance.Add(nr);
                            }
                            else if(posA > posB)
                            {
                                // retroceso
                                if (retroceso == null)
                                    retroceso = new List<Arista>();
                                retroceso.Add(nr);
                            }

                        }
                        visitado.Add(nr);
                        // Si todas sus relaciones ya fueron visitadas
                        bool tv = todoVisitado(aux);
                        if(tv == true)
                        {
                            stack.pop();
                            aux = stack.ultimo();
                        }


                        break;
                    }
                }
            }
        }
        private bool todoVisitado(NodoP nodo)
        {
            if (visitado == null)
                visitado = new List<Arista>();
            foreach(Arista nr in nodo.aristas)
            {
                Arista existeA = visitado.Find(x => x.Equals(nr));
                if(existeA == null)
                {
                    return false;
                }
            }
            return true;
        }
        private int damePosicion(List<List<NodoP>> bosque, NodoP nodo)
        {
            int i = 0;
            foreach(List<NodoP> np in bosque)
            {
                i = 0;
                foreach(NodoP np2 in np)
                {
                    if(np2 == nodo)
                    {
                        return i;
                    }
                    i++;
                }
               
            }
            return i;
        }
        private bool encuentraEnBosque(List<List<NodoP>> bosque, NodoP busca)
        {
            foreach(List<NodoP> np1 in bosque)
            {
                foreach(NodoP np2 in np1)
                {
                    if (np2 == busca)
                        return true;
                }
            }
            return false;
        }
        #region ALGORTIMO DE DIJKSTRA

        public List<List<NodoP>> dijkstra(NodoP inicio)
        {
            NodoP aux;
            NodoP primero = this[0];
            caminos = new List<NodoP>();
            //pila.Add(primero);
            p = new Pila();
            bool gradoInterno = false;
            renglon = new List<int>();
            foreach (NodoP np in this) // RECORRE NODO  (RENGLON)
            {
                if (np == inicio)
                {
                    if (np.aristas.Count == 0)
                    {
                        renglon = null;
                        return null;
                    }

                    p.vaciaPila();
                    renglon.Clear();
                    p.push(np);
                    foreach (NodoP np2 in this) // RECORRE NODOS POR SEGUNDA VEZ (COLUMNA)
                    {
                        caminos.Clear();
                        caminos.Add(primero);
                        peso = 0;
                        if (np != np2) // PARA QUE SE EVITEN OREJAS 
                        {
                            if(tieneGradoInterno(np2) == true)
                            {
                                generaRenglon(inicio, np2);
                                renglon.Add(peso);
                                DK.Add(caminos);
                            }
                            else
                            {
                                renglon.Add(10000);
                                DK.Add(caminos);
                            }
                           
                            

                        }
                        else
                            renglon.Add(0);
                    }
                    break;
                }

            }
            return DK;

        }
        public List<int> damePesos()
        {
            return renglon;
        }

        private void generaRenglon(NodoP inicio, NodoP fin)
        {

            NodoP aux = null;
            if (p.tope + 1 > 0)
            aux = encuentraMenor(inicio);
            if (aux != null) // VALIDACIÓN SI ENCONTRO EL PESO MENOR
            {

                pila.Add(aux);
                p.push(aux);
                if (aux != fin && aux.aristas.Count == 0)
                {

                    aux = encuentraMenor(inicio, p.ultimo());
                    p.pop();


                }
                //   if (p.tope > grafo.Count)
                // aux = null;
                foreach (Arista nr in inicio.aristas) // CICLO QUE RECORRE LAS RELACIONES DEL NODO INICIO
                {
                    if (nr.destino == aux) // CUANDO ENCUENTRA A LA ARISTA CON MENOR PESO
                    {

                        peso += nr.peso;
                        NodoP existe = caminos.Find(x => x.Equals(aux));
                        if (existe == null)
                            caminos.Add(nr.destino);
                        if (aux == fin) // SI EL NODO CON MENOR PESO EL ES NODO FIN
                        {

                            break;
                        }
                        else
                        {
                                generaRenglon(aux, fin); // SI NO ECUENTRA EL NODO, AVANZA AL SIGUIENTE 
                        }


                    }

                }
            }







        }
        private bool tieneGradoInterno(NodoP actual)
        {
            foreach(NodoP np in grafo)
            {
                foreach(Arista nr in np.aristas)
                {
                    if(nr.destino == actual)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public NodoP encuentraMenor(NodoP actual)
        {
            if (actual == null)
            {
                peso = 0;
                return null;
            }
              
            try
            {
                NodoP aux = null;
                if (actual != null)
                {
                    if (actual.aristas.Count > 0)
                    {
                        int menor = actual.aristas[0].peso;
                        aux = actual.aristas[0].destino;
                        for (int i = 0; i < actual.aristas.Count; i++)
                        {
                            if (actual.aristas[i].peso < menor)
                            {
                                menor = actual.aristas[i].peso;
                                aux = actual.aristas[i].destino;
                            }
                        }
                    }
                }
                return aux;
            }
            catch
            {
                return null;
            }
            
        }
        private NodoP encuentraMenor(NodoP actual, NodoP ignora)
        {
            if (actual == null)
            {
                peso = 0;
                return null;
            }
               
            NodoP aux = null;
            if (actual.aristas.Count > 0)
            {
                int menor = 0;
                for(int i = 0; i < actual.aristas.Count; i++)
                {
                    if (actual.aristas[i].destino != ignora)
                    {
                        menor = actual.aristas[i].peso;
                        aux = actual.aristas[i].destino;
                    }
                        
                }
                
                for (int i = 0; i < actual.aristas.Count; i++)
                {
                    if(actual.aristas[i].destino != ignora)
                    {
                        if (actual.aristas[i].peso < menor)
                        {
                            menor = actual.aristas[i].peso;
                            aux = actual.aristas[i].destino;
                        }
                    }
                    
                }
            }

            return aux;
        }
        #endregion
        /*fIN CLASE*/
    }

}
