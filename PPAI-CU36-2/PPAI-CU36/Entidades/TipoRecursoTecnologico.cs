using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class TipoRecursoTecnologico
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string mostrarTipoRT()
        {
            return this.nombre;
        }
    }

    
}
