using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Marca
    {
        public string nombre { get; set; }

        internal string mostrarMarca()
        {
            return this.nombre;
        }
    }

}

