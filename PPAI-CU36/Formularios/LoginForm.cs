using PPAI_CU36.Entidades;
using PPAI_CU36.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_CU36
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario(1, txtPass.Text, txtUser.Text, true);

            string usuCorrecto = "ppai";
            string claveCorrecta = "123";
            
            if(txtUser.Text.Equals(usuCorrecto) && txtPass.Text.Equals(claveCorrecta))
            {
                Principal ventana = new Principal();
                ventana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ingrese valores correctos");
            }


        }





        // Botones de cerrar, minimizar y maximizar...


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
