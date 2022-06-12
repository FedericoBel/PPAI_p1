using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class AsignacionCientificoDelCI
    {
        public int idAsignacionCientificoDelCI { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public int idPersonalCientifico { get; set; }
        public int idTurno { get; set; }
    }
}
