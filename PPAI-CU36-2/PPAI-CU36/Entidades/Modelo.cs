using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Modelo
    {
        public string nombre { get; set; }
        public Marca marca { get; set; }

        internal List<string> mostrarMarcaYModelo()
        {
            List<string> marcaYModelo = new List<string>();
            marcaYModelo.Add(this.nombre);
            marcaYModelo.Add(this.marca.mostrarMarca());

            return marcaYModelo;
        }
    }
}
