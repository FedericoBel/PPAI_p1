using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Turno
    {
        public int idTurno { get; set; }
        public DateTime fechaGeneracion { get; set; }
        public int diaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public int idCambioEstadoTurno { get; set; }
    }
}
