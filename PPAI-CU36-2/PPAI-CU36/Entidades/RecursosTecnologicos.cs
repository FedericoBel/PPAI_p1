using PPAI_CU36.Datos;
using PPAI_CU36.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PPAI_CU36.Entidades
{
    public class RecursosTecnologicos
    {
        public int numeroRT { get; set; }
        public DateTime fechaAlta { get; set; }
        public int imagenes { get; set; }
        public int perioricidadMantenimientoPrev { get; set; }
        public int duracionMantenimientoPrev { get; set; }
        public int fraccionHorarioTurnos { get; set; }
        public List<CambioEstadoRT> cambioEstadoRt { get; set; }
        public TipoRecursoTecnologico TipoRecursoTecnologico { get; set; }
        public Modelo Modelo { get; set; }
        public List<Mantenimiento> mantenimientos { get; set; }
        public List<Turno> turnos { get; set; }


        // Carga de grilla con recursos tecnologicos
        public void mostrarRT()
        {
            DataGridViewRow fila = new DataGridViewRow();
            

            DataGridViewTextBoxCell celdaTipoRecurso = new DataGridViewTextBoxCell();
            celdaTipoRecurso.Value = this.TipoRecursoTecnologico.mostrarTipoRT();
            fila.Cells.Add(celdaTipoRecurso);

            DataGridViewTextBoxCell celdanumerort = new DataGridViewTextBoxCell();
            celdanumerort.Value = this.numeroRT;
            fila.Cells.Add(celdanumerort);


            List<string> marcaYModelo = this.Modelo.mostrarMarcaYModelo();

            DataGridViewTextBoxCell celdaMarca = new DataGridViewTextBoxCell();
            celdaMarca.Value = marcaYModelo[1];
            fila.Cells.Add(celdaMarca);

            DataGridViewTextBoxCell celdaModelo = new DataGridViewTextBoxCell();
            celdaModelo.Value = marcaYModelo[0];
            fila.Cells.Add(celdaModelo);

            GestorMC.filaGrillaRecurso.Add(fila);


        }


        // Obtener turno cancelables 
        public List<Turno> getTurnosConfYPendConf(DateTime fechaFinPrevista)
        {
            List<Turno> turnosConfYPendConf = new List<Turno>();
            for (int i = 0; i < this.turnos.Count; i++)
            {
                if (turnos[i].esCancelable(fechaFinPrevista))
                {
                   turnosConfYPendConf.Add(this.turnos[i]);
                }
                
            }
            return turnosConfYPendConf; 
            
        }
        public List<List<DataGridViewRow>> getDatosTurnos(List<AsignacionCientificoDelCI> asignacionCientificoDelCIs) 
        {
            List<List<DataGridViewRow>> matriz = new List<List<DataGridViewRow>>();

            // RECORRER TURNOS CANCELABLES...
            for (int i = 0; i < this.turnos.Count; i++) // turnos 3 y 4
            {
                matriz.Add(this.turnos[i].mostrarFechaYHora(asignacionCientificoDelCIs)); // asig 1(turnos 1, 2) y la asig 2 (turnos 3 y 4)
                
            }
            return matriz;

        }

        // nuevo mantenimiento correctivo
        public void crearMantenimiento(DateTime fechaFinPrevista, DateTime fechaActual, DateTime fechaInicioPrevista, string motivo, int extension)
        {
            var nuevoManteniento = new Mantenimiento
            {
                fechaInicio = fechaActual,
                fechaFin = fechaFinPrevista,
                fechaInicioPrevista = fechaInicioPrevista,
                motivoMantenimiento = motivo,
                ExtensionMantenimiento = extension,

            };
            this.mantenimientos.Add(nuevoManteniento);
        }

        // Obtencion y cambio de estado
        internal void getEstadoActual(Estado ingresoMC)
        {
            for (int i = 0; i < this.cambioEstadoRt.Count; i++)
            {
                if (this.cambioEstadoRt[i].esActual())
                {
                    this.cambioEstadoRt[i].cambiarEstado();
                }

            }

            var nuevo_CambioEstado = new CambioEstadoRT
            {
                fechaHoraDesde = DateTime.Now,  
                fechaHoraHasta = Convert.ToDateTime(null),
                Estado = ingresoMC,
            };

            this.cambioEstadoRt.Add(nuevo_CambioEstado);

        }

        // cancelar turno
        internal void cancelarTurnos(Estado canceladoMC, DateTime fechaFinPrevista)
        {
            for (int i = 0; i < this.turnos.Count; i++)
            {
                if (this.turnos[i].fechaHoraInicio <= fechaFinPrevista)
                {
                    this.turnos[i].cancelarTurnos(canceladoMC);

                }

            }

         

        }
    }



}
