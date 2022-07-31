using PPAI_CU36.Datos;
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

        static public Principal ventanaPrincipal;

        static public String usuario;

        static public String contraseña;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            bool esUsuario = false;
            List<Usuario> listaUsuarios = BD.ListaUsuarios();


            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (txtUser.Text.Equals(listaUsuarios[i].nombreUsuario) && txtPass.Text.Equals(listaUsuarios[i].claveDeUsuario))
                {
                    esUsuario = true;
                }
            }

            if(esUsuario)
            {

                usuario = txtUser.Text;
                contraseña = txtPass.Text;


                Principal ventana = new Principal();
                ventanaPrincipal = ventana;
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
