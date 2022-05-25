using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class RecursosTecnologicos
    {
        public int numeroRT { get; set; }
        public DateTime fechaAlta { get; set; }
        public int imagenes { get; set; }
        public int perioricidadMantenimientoPrev { get; set; }
        public int duracionMantenimientoPrev { get; set; }
        public int fraccionHorarioTurnos { get; set; }
        public int idTurno { get; set; }
        public int idTipoRecursoTecnologico { get; set; }
        public int idModelo { get; set; }
        public int idMantenimiento { get; set; }
        public int idCambioEstadoRT { get; set; }
    }
}
