using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    class Romano
    {
        int val;
        string nombre;
        public Romano(string n, int val)
        {
            this.nombre = n;
            this.val = val;
        }
        public string dameLetra()
        {
            return nombre;
        }
        public int dameNumero()
        {
            return val;
        }
    }
}
