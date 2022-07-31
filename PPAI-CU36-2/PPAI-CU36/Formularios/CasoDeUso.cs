using PPAI_CU36.Datos;
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
    public partial class CasoDeUso : Form
    {
        public CasoDeUso()
        {
            // habilitar pantalla...
            InitializeComponent();
            // boton para maximizar la pantalla
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
          
        }

        // instaciamos el GestorMC
        // BD: tiene todas las instancias necesarias

        GestorMC gestorMC = new GestorMC
        {
            listaEstados = BD.ListaEstados(),
            // CAMBIAR -> Los datos deben venir del Login

            sesion = BD.ListaSesion(),
            listaDeAsignacionResponsableTecnicoRT = BD.ListaAsignacionesResponsableTecnicoRT(),
            listaAsignacionCientificos = BD.ListaAsignacionCien(),

        };


        private void CasoDeUso_Load(object sender, EventArgs e)
        {
            // nuevo ingreso a mantenimiento correctivo...
            gestorMC.nuevoIngresoMantCorrectivo();

            // habilitar rd de mail...
            rdMail.Checked = true;

        }

        // Metodo para cargar la grilla de recursos del CU...
        public void solicitarSeleccionRT(List<DataGridViewRow> fila)
        {
            gdrRecursos.Rows.Clear();
            for (int i = 0; i < fila.Count; i++)
            {
                gdrRecursos.Rows.Add(fila[i]);
            }

            limpiarGrilla(); 

        }

        // Metodo que toma el recurso tecnologico seleccionado...
        private void gdrRecursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                DataGridViewRow filaseleccionada = gdrRecursos.Rows[indice];
                int numeroRT = int.Parse(filaseleccionada.Cells["numero"].Value.ToString());
                gestorMC.seleccionRT(numeroRT);
            }
            
        }

        // Metodo para ingresar la fecha...
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DateTime fechaFinPrevista = Convert.ToDateTime(txtFechaFin.Text);
            String motivo = txtRazon.Text;
            gestorMC.tomarFechaFinYMotivo(fechaFinPrevista, motivo);
        }

        // Metodo que limpia la grilla del CU...
        private void limpiarGrilla()
        {
            gdrTurnos.Rows.Clear();
            gdrTurnos.Refresh();
        }

        // Metodo para cargar la grilla de turnos...
        public void solicitarConfirmacionYNotiMC(List<DataGridViewRow> fila)
        {
            limpiarGrilla();
            for (int i = 0; i < fila.Count; i++)
            {
                gdrTurnos.Rows.Add(fila[i]);
            }

        }

        // Metodo para confirmar el ingreso a mantenimiento correctivo del recurso seleccionado...
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult QuestionResult = MessageBox.Show("¿Está seguro que desea confimar el ingreso a mantenimiento correctivo?", "Confirmar mantenimiento", botones, MessageBoxIcon.Information);

            if (QuestionResult == DialogResult.Yes)
            {
                bool confirmacion = true;
                bool notificacion = false;

                if (rdWhatsApp.Checked)
                {
                    notificacion = true;
                }
                gestorMC.tomarConfirmacionYNoti(confirmacion, notificacion);      
            }
          
        }

        // Metodo para limpiar los campos de la pantalla del CU...
        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtFechaFin.Text = "";
            txtRazon.Text = "";
            rdMail.Checked = true;
            limpiarGrilla();
        }



        // BOTONES VENTANA...
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void titleBar_Paint(object sender, PaintEventArgs e)
        {

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
