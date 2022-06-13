using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class CambioEstadoRT
    {
        public DateTime fechaHoraDesde { get; set; }
        public DateTime fechaHoraHasta { get; set; }
        public Estado Estado { get; set; }

        public bool esUltimo()
        {
            if (this.fechaHoraHasta == Convert.ToDateTime(null))
            {
                return true;
            }
            return false;
        }
        public bool esActual()
        {
            return esUltimo();
        }

        internal void cambiarEstado()
        {
            this.fechaHoraHasta = DateTime.Now;
        }
    }

}
