using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class CambioEstadoTurno
    {
        public DateTime fechaHoraDesde { get; set; }
        public DateTime fechaHoraHasta { get; set; }
        public Estado estado { get; set; }

        public bool esActual()
        {
            if (this.fechaHoraHasta == Convert.ToDateTime(null))
            {
                return true;
            }
            return false;
        }

        public bool esCancelable()
        {
            if (this.estado.nombre != "Cancelable")
            {
                return true;
            }
            return false;
        }

        internal void setFechaFin()
        {
            this.fechaHoraHasta = DateTime.Now;
        }
    }

   
}
