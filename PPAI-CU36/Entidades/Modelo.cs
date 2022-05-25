using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Modelo
    {
        private int idModelo;
        private string nombre;
        private int idMarca;
        public Modelo(int idmodelo, string Nombre, int idmarca)
        {
            idModelo = idmodelo;
            nombre = Nombre;
            idMarca = idmarca;
        }

        public int idDeModelo
        {
            get => idModelo;
            set => idModelo = value;
        }
        public string nombreDeModelo
        {
            get => nombre;
            set => nombre = value;
        }
        public int idDeMarca
        {
            get => idMarca;
            set => idMarca = value;
        }
    }
}
