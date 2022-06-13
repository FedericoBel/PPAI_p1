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

        static public GestorMC gestorMC = new GestorMC();

        //public CasoDeUso(string nombreUsu, string claveUsu)

        public CasoDeUso()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
        }


        private void CasoDeUso_Load(object sender, EventArgs e)
        {

            gestorMC.nuevoIngresoMantCorrectivo();
            rdMail.Checked = true;

        }

        public void solicitarSeleccionRT(List<DataGridViewRow> fila)
        {
            for (int i = 0; i < fila.Count; i++)
            {
                gdrRecursos.Rows.Add(fila[i]);
            }
             

        }

        private void gdrRecursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice != -1)
            {
                DataGridViewRow filaseleccionada = gdrRecursos.Rows[indice];
                int numero = int.Parse(filaseleccionada.Cells["numero"].Value.ToString());
                gestorMC.seleccionRT(numero);
            }
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //LimpiarGrilla();
            DateTime fechaFinPrevista = Convert.ToDateTime(txtFechaFin.Text);
            String motivo = txtRazon.Text;
            gestorMC.tomarFechaFinYMotivo(fechaFinPrevista, motivo);
        }

        private void LimpiarGrilla()
        {
            gdrTurnos.Rows.Clear();
            gdrTurnos.Refresh();
        }

        public void solicitarConfirmacionYNotiMC(List<List<DataGridViewRow>> superGrilla)
        {
            LimpiarGrilla();
            for (int i = 0; i < superGrilla.Count; i++)
            {
                for(int j = 0; j < superGrilla[i].Count; j++)
                {
                    gdrTurnos.Rows.Add(superGrilla[i][j]);
                }
            }
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult QuestionResult = MessageBox.Show("¿Está seguro que desea confimar el ingreso a mantenimiento correctivo?", "Confirmar mantenimiento", botones, MessageBoxIcon.Information);

            if (QuestionResult == DialogResult.Yes)
            {
                //mail false, whatsapp true
                bool confirmacion = true;

                bool notificacion = false;

                if (rdWhatsApp.Checked)
                {
                    notificacion = true;
                }

                gestorMC.tomarConfirmacionYNoti(confirmacion, notificacion);
                
            }
            else
            {
                this.Close();
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtFechaFin.Text = "";
            txtRazon.Text = "";
            rdMail.Checked = true;
            LimpiarGrilla();
        }



        // BOTONES VENTANA

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
