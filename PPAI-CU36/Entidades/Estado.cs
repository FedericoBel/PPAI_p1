using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Estado
    {
        public int idEstado { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ambito { get; set; }
        public Boolean esReservable { get; set; }
        public Boolean esCancelable { get; set; }
    }
}
