using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Sesion
    {
        public Usuario Usuario { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }

        public PersonalCientifico mostrarCientificoLogueado(string usuario, string clave)
        {

            return this.Usuario.getCientifico(usuario, clave);
        
        }

    }
}
