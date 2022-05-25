using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Mantenimiento
    {
        public int idMantenimiento { get; set; }
        public DateTime fechaFin { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaInicioPrevista { get; set; }
        public string motivoMantenimiento { get; set; }
        public int idExtensionMantenimiento { get; set; }
    }
}
