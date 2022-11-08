using PPAI_CU36.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_CU36.Datos;
using PPAI_CU36.Entidades;

namespace PPAI_CU36
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Iterador i = new Iterador();
            Application.Run(new LoginForm());

        }
    }
}
