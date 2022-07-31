using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_CU36.Entidades
{
    public class AsignacionResponsableTecnicoRT
    {
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public List<RecursosTecnologicos> recursosTecnologicos { get; set; }
        public PersonalCientifico personalCientifico { get; set; }


        public bool esDeUsuarioLogueadoYVigente(PersonalCientifico pc)
        {
            if (this.personalCientifico.legajo == pc.legajo)
            {
                return esVigente();

            }

            return false;

        }

        private bool esVigente()
        {
            if (this.fechaHasta == Convert.ToDateTime(null))
            {
                return true;
            }
            return false;
        }

        // Metodo para obtener los recursos disponibles del personal cientifico logueado...
        public List<RecursosTecnologicos> obtenerRecursosDisponibles()
        {
            List<RecursosTecnologicos> recursosTecnologicosDisponibles = new List<RecursosTecnologicos>();

           
            // recorremos todos los recursos tecnologicos....
            for (int i = 0; i < this.recursosTecnologicos.Count; i++)
            {
                // recorremos los cambios de estados de cada recurso...
                for (int j = 0; j < recursosTecnologicos[i].cambioEstadoRt.Count; j++)
                {
                    // verificamos que sea el ultimo estado...
                    if (recursosTecnologicos[i].cambioEstadoRt[j].esUltimo())
                    {
                        // verificamos que el estado sea activo (en estado disponible)...
                        if (recursosTecnologicos[i].cambioEstadoRt[j].Estado.esActivo())
                        {

                            recursosTecnologicos[i].mostrarRT();
                            recursosTecnologicosDisponibles.Add(recursosTecnologicos[i]);
                        }
                        
                    }
                }
            }

            return recursosTecnologicosDisponibles;
        }

    }


     
}
