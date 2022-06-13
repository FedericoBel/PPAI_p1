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
        public int numeroRT { get; set; }
        public DateTime fechaFinPrevista { get; set; }
        public string motivo { get; set; }
        public Sesion Sesion { get; set; }

        public RecursosTecnologicos recursoTecnologicoSeleccionado { get; set; }
        public DateTime fechaActual { get; set; }

        public List<RecursosTecnologicos> recursosTecnologicosDisponibles { get; set; }
        
        public bool confirmacion { get; set; }

        public bool notificacion { get; set; }
 
         
        public List<List<DataGridViewRow>> filaGrillaTurno { get; set; }

        //CAMBIAR PARA QUE SEA ATRIBUTO
        static public List<DataGridViewRow> filagrilla = new List<DataGridViewRow>();

        //public  List<DataGridViewRow> filaGrillaRecursos = new List<DataGridViewRow>();

        public AsignacionResponsableTecnicoRT asignacionVigenteLogueada { get; set; }

        public void nuevoIngresoMantCorrectivo()
        {
            //List<RecursosTecnologicos> listaRecursosTecnologicos = BD.ListaRecursos();
            //List<PersonalCientifico> listaPersonalCientifico = BD.ListaPersonal();
            //List<Usuario> listaUsuarios = BD.ListaUsuarios();

            filagrilla.Clear();
            PersonalCientifico pc = getUsuarioLogueado(BD.ListaSesion());
            getRTDisponiblesRRT(pc);
            agruparRTPorTipo();


        }

        private void agruparRTPorTipo()
        {
            
            Principal.casoForm.solicitarSeleccionRT(filagrilla);
        }

        public void getRTDisponiblesRRT(PersonalCientifico pc)
        {
            for (int i = 0; i < BD.ListaAsignacionesResponsableTecnicoRT().Count; i++)
            {
                if (BD.ListaAsignacionesResponsableTecnicoRT()[i].esDeUsuarioLogueadoYVigente(pc))
                {
                    this.asignacionVigenteLogueada = BD.ListaAsignacionesResponsableTecnicoRT()[i];

                    recursosTecnologicosDisponibles = asignacionVigenteLogueada.obtenerRecursosDisponibles();

                    break;
                }
            }





        }

        private PersonalCientifico getUsuarioLogueado(Sesion sesion)
        {
            return sesion.mostrarCientificoLogueado(sesion.Usuario.nombreUsuario, sesion.Usuario.claveDeUsuario);
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
        }

        private void getFechaActual()
        {
            this.fechaActual = DateTime.Now;
            //variable auxiliar
            List<Turno> turnosCompletos = new List<Turno>();
            turnosCompletos = recursoTecnologicoSeleccionado.turnos;

            this.recursoTecnologicoSeleccionado.turnos = this.recursoTecnologicoSeleccionado.getTurnosConfYPendConf();
            getDatosTurnos(turnosCompletos);
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

            for (int i = 0; i < BD.ListaEstados().Count; i++)
            {
                if (BD.ListaEstados()[i].esAmbitoRT())
                {
                    if (BD.ListaEstados()[i].esIngresoAMC())
                    {
                        estado1 = i;
                    }
                }
                if (BD.ListaEstados()[i].esAmbitoTurno())
                {
                    if (BD.ListaEstados()[i].esCanceladoPorMC())
                    {
                        estado2 = i;

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
