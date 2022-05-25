using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Sesion
    {
        public int idSesion { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
    }
}
