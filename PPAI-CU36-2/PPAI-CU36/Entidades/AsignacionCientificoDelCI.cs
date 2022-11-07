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
        public int id { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public PersonalCientifico personalCientifico { get; set; }
        public List<Turno> turno { get; set; }

        public List<string> mostrarCientifico()
        {
            List<string> nombreYMail = new List<string>();
            nombreYMail.Add(this.personalCientifico.nombre);
            nombreYMail.Add(this.personalCientifico.correoElectronicoInstitucional);
            return nombreYMail;

        }
        //public string mostrarCientifico()
        //{
        //    return this.personalCientifico.nombre;

        //}
    }

    
}
