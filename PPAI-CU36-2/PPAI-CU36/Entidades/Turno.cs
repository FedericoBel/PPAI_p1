using PPAI_CU36.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_CU36.Entidades
{
    public class Turno
    {
        public int numero { get; set; }
        public DateTime fechaGeneracion { get; set; }
        public string diaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public List<CambioEstadoTurno> CambioEstadoTurno { get; set; }

        public bool esCancelable(DateTime fechaFinPrevista)
        {
            for (int i = 0; i < this.CambioEstadoTurno.Count; i++)
            {
                if (CambioEstadoTurno[i].esActual() && this.fechaHoraInicio <= fechaFinPrevista)
                {
                    if (CambioEstadoTurno[i].esCancelable())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<DataGridViewRow> mostrarFechaYHora(List<AsignacionCientificoDelCI> asig) //asig 1(fran)-turnos 1y2  y asig 2(fede)-  3 y4
        {
            List<DataGridViewRow> listaFilas = new List<DataGridViewRow>();

            for (int i = 0; i < asig.Count; i++)
            {
                for (int j = 0; j < asig[i].turno.Count; j++)
                {
                    if (asig[i].turno[j].numero == this.numero)
                    {
                        DataGridViewRow fila = new DataGridViewRow();

                        List<string> nombreYMail = asig[i].mostrarCientifico();

                        DataGridViewTextBoxCell celdaCientifico = new DataGridViewTextBoxCell();
                        celdaCientifico.Value = nombreYMail[0];
                        fila.Cells.Add(celdaCientifico);

                        DataGridViewTextBoxCell celdaMail = new DataGridViewTextBoxCell();
                        celdaMail.Value = nombreYMail[1];
                        fila.Cells.Add(celdaMail);


                        DataGridViewTextBoxCell celdaFechaInicio = new DataGridViewTextBoxCell();
                        celdaFechaInicio.Value = this.fechaHoraInicio; // turno 3-- turno 4
                        fila.Cells.Add(celdaFechaInicio);




                        listaFilas.Add(fila);

                    }
                }
   
            }
            

            return listaFilas;
          
        }

        // cancelar turnos
        internal void cancelarTurnos(Estado canceladoMC)
        {
            for (int i = 0; i < this.CambioEstadoTurno.Count; i++)
            {
                if (this.CambioEstadoTurno[i].esActual())
                {
                    this.CambioEstadoTurno[i].setFechaFin();
                }
            }

            var nuevoCambioEstado = new CambioEstadoTurno
            {
                fechaHoraDesde = DateTime.Now,
                fechaHoraHasta = Convert.ToDateTime(null),
                estado = canceladoMC,
            };

            CambioEstadoTurno.Add(nuevoCambioEstado);

        }
    }

    
}
