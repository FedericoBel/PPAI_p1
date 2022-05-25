using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class CambioEstadoRT
    {
        public int idCambioEstadoRT { get; set; }
        public DateTime fechaHoraDesde { get; set; }
        public DateTime fechaHoraHasta { get; set; }
        public int idEstado { get; set; }
    }
}
