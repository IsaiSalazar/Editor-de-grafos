using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    [Serializable]
    class Pila
    {
        public List<NodoP> nodos;
        public int tope { get; set; }
        public Pila()
        {
            tope = 0;
            nodos = new List<NodoP>();
        }
        public void push(NodoP nuevo)
        {
            nodos.Add(nuevo);
            tope = nodos.Count-1;
        }
        public void pop()
        {
            nodos.RemoveAt(tope);
            tope = nodos.Count-1;
        }
        public void vaciaPila()
        {
            nodos.Clear();
            tope = 0;
        }
        public NodoP ultimo()
        {
            return nodos[tope];
        }
    }
}
