using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Estado
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ambito { get; set; }
        public Boolean esReservable { get; set; }
        public Boolean esCancelable { get; set; }


        public bool esActivo()
        {
            if (this.nombre.Equals("Disponible"))
            {
                return true;
            }
            return false;
        }

        internal bool esAmbitoRT()
        {
            if (this.ambito.Equals("CambioEstadoRT"))
            {
                return true;
            }
            return false;
        }

        internal bool esIngresoAMC()
        {
            if (this.nombre.Equals("Con ingreso en mantenimiento correctivo"))
            {
                return true;
            }
            return false;
        }

        internal bool esAmbitoTurno()
        {
            if (this.ambito.Equals("CambioEstadoTurno"))
            {
                return true;
            }
            return false;
        }

        internal bool esCanceladoPorMC()
        {
            if (this.nombre.Equals("Cancelado por manteniemto correctivo"))
            {
                return true;
            }
            return false;
        }

 
    }


}
