using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public interface ISujeto
    {
        List<IObservadoresNotificacion> observadores { get; set; }
        void notificar();
        void quitar(IObservadoresNotificacion o);
        void suscribir(IObservadoresNotificacion o);
    }
}
