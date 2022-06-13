using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_CU36.Entidades
{
    public class AsignacionCientificoDelCI
    {
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public PersonalCientifico personalCientifico { get; set; }
        public List<Turno> turno { get; set; }

        public string mostrarCientifico()
        {
            return this.personalCientifico.nombre;

        }
    }

    
}
