using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class AsignacionResponsableTecnicoRT
    {
        public int idAsignacionResponsableTecnicoRT { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public int idRecursoTecnologico { get; set; }
        public int legajoPersonalCientifico { get; set; }
    }
}
