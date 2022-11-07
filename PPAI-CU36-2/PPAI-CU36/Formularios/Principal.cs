using PPAI_CU36.Datos.Models;
using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PPAI_CU36.Formularios
{
    public partial class Principal : Form
    {
        static public CasoDeUso casoDeUso;
        public Usuario usuariologeado { get; set; }
        public Principal()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }




        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int m, mx, my;
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }


        private void btnRegistrarIngresoDeRTEnManteniemientoCorrectivo_Click(object sender, EventArgs e)
          {
            CasoDeUso caso = new CasoDeUso ();
            casoDeUso = caso;
            caso.ShowDialog();

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            SesionModel sm = new SesionModel();
            Sesion sesion = new Sesion
            {
                Usuario = usuariologeado,
                fechaHoraInicio = DateTime.Now,
                fechaHoraFin = Convert.ToDateTime(DateTime.Now.AddHours(1))
            };
            sm.desmaterializar(sesion);
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
