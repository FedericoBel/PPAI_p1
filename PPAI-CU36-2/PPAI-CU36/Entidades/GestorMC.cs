using PPAI_CU36.Datos;
using PPAI_CU36.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_CU36.Entidades
{
    public class GestorMC
    {
        public DateTime fechaFinPrevista { get; set; }
        public string motivo { get; set; }
        public RecursosTecnologicos recursoTecnologicoSeleccionado { get; set; }
        public DateTime fechaActual { get; set; }

        public List<RecursosTecnologicos> recursosTecnologicosDisponibles { get; set; }
        
        public bool confirmacion { get; set; }

        public bool notificacion { get; set; }
 
         
        public List<List<DataGridViewRow>> filaGrillaTurno { get; set; }

        //CAMBIAR PARA QUE SEA ATRIBUTO
        static public List<DataGridViewRow> filaGrillaRecurso = new List<DataGridViewRow>();

        //public  List<DataGridViewRow> filaGrillaRecursos = new List<DataGridViewRow>();

        public AsignacionResponsableTecnicoRT asignacionVigenteLogueada { get; set; }

        // 
        public List<Estado> listaEstados { get; set; }

        // CAMBIOS

        public Sesion sesion { get; set; }

        public List<AsignacionResponsableTecnicoRT> listaDeAsignacionResponsableTecnicoRT { get; set; } 
        //

        public void nuevoIngresoMantCorrectivo()
        {
            filaGrillaRecurso.Clear();
            PersonalCientifico pc = getUsuarioLogueado();
            
            AsignacionResponsableTecnicoRT art =  getRTDisponiblesRRT(pc);

            List<RecursosTecnologicos> recursosTecnologicosDisponibles = art.obtenerRecursosDisponibles();

            recursosTecnologicosDisponibles = agruparRTPorTipo(recursosTecnologicosDisponibles);
            //
            
            Principal.casoForm.solicitarSeleccionRT(filaGrillaRecurso);

        }

        private List<RecursosTecnologicos> agruparRTPorTipo(List<RecursosTecnologicos> recursosTecnologicosDisponibles)
        {
            // FALTA ORDENARLA

            return recursosTecnologicosDisponibles;


        }

        public AsignacionResponsableTecnicoRT getRTDisponiblesRRT(PersonalCientifico pc)
        {

            int indice = 0;
            for (int i = 0; i < this.listaDeAsignacionResponsableTecnicoRT.Count; i++)
            {
                if (this.listaDeAsignacionResponsableTecnicoRT[i].esDeUsuarioLogueadoYVigente(pc))
                {
                    //this.asignacionVigenteLogueada = BD.ListaAsignacionesResponsableTecnicoRT()[i];
                    //recursosTecnologicosDisponibles = asignacionVigenteLogueada.obtenerRecursosDisponibles();
                    // ASIGNACIONES
                    //recursosTecnologicosDisponibles = (this.listaDeAsignacionResponsableTecnicoRT[i]).obtenerRecursosDisponibles();
                    indice = i;

                    break;
                }

            }

            return this.listaDeAsignacionResponsableTecnicoRT[indice];
        }


        private PersonalCientifico getUsuarioLogueado()
        {
            return this.sesion.mostrarCientificoLogueado();
        }

        public void seleccionRT(int numeroRT)
        {
            //this.numeroRT = numeroRT;
            for (int i = 0; i < recursosTecnologicosDisponibles.Count; i++)
            {
                if (recursosTecnologicosDisponibles[i].numeroRT == numeroRT)
                {
                    recursoTecnologicoSeleccionado = recursosTecnologicosDisponibles[i];
                }
            }
        }

        public void tomarFechaFinYMotivo(DateTime fechaFin, string motivo)
        {

            this.fechaFinPrevista = fechaFin;
            this.motivo = motivo;
            buscarTurnosConfYPendConf();
        }

        private void buscarTurnosConfYPendConf()
        {
            getFechaActual();
            //variable auxiliar
            List<Turno> turnosCompletos = new List<Turno>();
            turnosCompletos = recursoTecnologicoSeleccionado.turnos;

            this.recursoTecnologicoSeleccionado.turnos = this.recursoTecnologicoSeleccionado.getTurnosConfYPendConf();
            getDatosTurnos(turnosCompletos);
        }

        private void getFechaActual()
        {
            this.fechaActual = DateTime.Now;
        
        }

        private void getDatosTurnos(List<Turno> turnosCompletos) 
        {
            this.filaGrillaTurno = (this.recursoTecnologicoSeleccionado.getDatosTurnos());
            this.recursoTecnologicoSeleccionado.turnos = turnosCompletos;
            agruparPorCientifico();
        }

        private void agruparPorCientifico()
        {
            Principal.casoForm.solicitarConfirmacionYNotiMC(filaGrillaTurno);
            this.filaGrillaTurno.Clear();

        }

        public void tomarConfirmacionYNoti(bool confirmacion, bool notificacion)
        {
            this.confirmacion = confirmacion;
            this.notificacion = notificacion;

            crearMantenimiento();

        }

        private void crearMantenimiento()
        {
            recursoTecnologicoSeleccionado.crearMantenimiento(fechaFinPrevista,fechaActual, DateTime.Now, motivo, 1);

            buscarEstados();
        }

        private void buscarEstados()
        {
            int estado1 = 0;
            int estado2 = 0;

            for (int i = 0; i < this.listaEstados.Count; i++)
            {
                if (this.listaEstados[i].esAmbitoRT())
                {
                    if (this.listaEstados[i].esIngresoAMC())
                    {
                        estado1 = i; // recurso
                    }
                }
                if (this.listaEstados[i].esAmbitoTurno())
                {
                    if (this.listaEstados[i].esCanceladoPorMC())
                    {
                        estado2 = i; //turnos

                    }
                }
            }

            buscarEstadoActual(BD.ListaEstados()[estado1], BD.ListaEstados()[estado2]);
        }

        private void buscarEstadoActual(Estado ingresoMC, Estado canceladoMC)
        {
            recursoTecnologicoSeleccionado.getEstadoActual(ingresoMC);
            recursoTecnologicoSeleccionado.cancelarTurnos(canceladoMC);
            generarMail();
        }

        private void generarMail()
        {
            if (!this.notificacion)
            {
                MessageBox.Show("Mail enviado con exito!!", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("What's App enviado con exito!!", "What's App", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finCU();
        }

        private void finCU()
        {
            Principal.casoForm.Close();

        }
    }
}




