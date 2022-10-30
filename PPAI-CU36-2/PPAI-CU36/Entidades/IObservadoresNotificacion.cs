using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
     public interface IObservadoresNotificacion
    {
        string enviarNotificacion(string to, string asunto, string body);
    }
}
