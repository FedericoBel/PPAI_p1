using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Marca
    {
        private int idMarca;
        private string nombre;
    

        public Marca(int idmarca, string Nombre )
        {
            idMarca = idmarca;
            nombre = Nombre;

        }

        public int idDeMarca
        {
            get => idMarca;
            set => idMarca = value;
        }
        public string nombreDeMarca
        {
            get => nombre;
            set => nombre = value;
        }


        




    }




}

