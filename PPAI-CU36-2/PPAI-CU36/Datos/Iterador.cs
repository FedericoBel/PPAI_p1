using PPAI_CU36.Datos.Models;
using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos
{
    class Iterador
    {
        public BD db = new BD();


       public void iteradorMarca()
        {
            MarcaModel marcaDB = new MarcaModel();
            List<Marca> m = new List<Marca> { new Marca { nombre = "Shidmazu "} , new Marca { nombre = "Nikon"} };
            for (int i = 0; i < m.Count; i++)
            {
                marcaDB.desmaterializar(m[i]);
            }
        }

    }
}
