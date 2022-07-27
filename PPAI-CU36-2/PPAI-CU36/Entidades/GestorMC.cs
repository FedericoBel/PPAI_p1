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

        // ... cambiamos a indice
        public RecursosTecnologicos recursoTecnologicoSeleccionado { get; set; }

        public int indiceRTS { get; set; }
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
        public List<AsignacionCientificoDelCI> listaAsignacionCientificos { get; set; }

        public void nuevoIngresoMantCorrectivo()
        {
            filaGrillaRecurso.Clear();


            //getUsuarioLogueado ... metodo para buscar el personal cientifico logueado

            PersonalCientifico personalCientificoLogueado = getUsuarioLogueado();
            
            // metodo para obtener los recursos tecnologicos disponibles....

            AsignacionResponsableTecnicoRT asignacionResponsableTecnicoLogueado =  getRTDisponiblesRRT(personalCientificoLogueado);

            this.asignacionVigenteLogueada = asignacionResponsableTecnicoLogueado;

            // metodo para obtejer los recursos en estado disponible de la asignacionResponsableTecnicoLogueado

            List<RecursosTecnologicos> recursosTecnologicosDisponibles = asignacionResponsableTecnicoLogueado.obtenerRecursosDisponibles();
            this.recursosTecnologicosDisponibles = recursosTecnologicosDisponibles;

            // ordenar los recursosTecnologicosDisponibles por tipo de recurso...
            recursosTecnologicosDisponibles = agruparRTPorTipo(this.recursosTecnologicosDisponibles);
            
            
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
                    //recursoTecnologicoSeleccionado = recursosTecnologicosDisponibles[i];
                    this.indiceRTS = i;
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

            //variable auxiliar, para no perder todos los turnos

            List<Turno> turnosCompletos = new List<Turno>();
            //turnosCompletos = recursoTecnologicoSeleccionado.turnos;
            turnosCompletos = recursosTecnologicosDisponibles[indiceRTS].turnos;
            // metodo para conseguir todos los turnos confirmados y pendiente de confirmacion del recurso tecnoligico seleccionado y los sobreescribo...

            //recurso tecno seleccionado
            this.recursosTecnologicosDisponibles[indiceRTS].turnos = this.recursosTecnologicosDisponibles[indiceRTS].getTurnosConfYPendConf(this.fechaFinPrevista);

            getDatosTurnos(turnosCompletos);
        }

        private void getFechaActual()
        {
            this.fechaActual = DateTime.Now;
        
        }

        private void getDatosTurnos(List<Turno> turnosCompletos) 
        {
            this.filaGrillaTurno = (this.recursosTecnologicosDisponibles[indiceRTS].getDatosTurnos(listaAsignacionCientificos));
            // Cargo todos los turnos para el recurso tecnologico seleccionado... VERIFICAR...

            this.recursosTecnologicosDisponibles[indiceRTS].turnos = turnosCompletos;


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
            List<int> listaIndicesEstados = buscarEstados();
            buscarEstadoActual(this.listaEstados[listaIndicesEstados[0]], this.listaEstados[listaIndicesEstados[1]]);
        }

        private void crearMantenimiento()
        {
            recursosTecnologicosDisponibles[indiceRTS].crearMantenimiento(fechaFinPrevista,fechaActual, DateTime.Now, motivo, 1);

        }

        private List<int> buscarEstados()
        {
            int indice1 = 0;
            int indice2 = 0;
            List<int> listaIndicesEstados = new List<int>();

            for (int i = 0; i < this.listaEstados.Count; i++)
            {
                if (this.listaEstados[i].esAmbitoRT())
                {
                    if (this.listaEstados[i].esIngresoAMC())
                    {
                        indice1 = i; // recurso
                    }
                }
                if (this.listaEstados[i].esAmbitoTurno())
                {
                    if (this.listaEstados[i].esCanceladoPorMC())
                    {
                        indice2 = i; //turnos

                    }
                }
            }
            listaIndicesEstados.Add(indice1);
            listaIndicesEstados.Add(indice2);

            return listaIndicesEstados;

        }

        private void buscarEstadoActual(Estado ingresoMC, Estado canceladoMC)
        {
            recursosTecnologicosDisponibles[indiceRTS].getEstadoActual(ingresoMC);
            recursosTecnologicosDisponibles[indiceRTS].cancelarTurnos(canceladoMC);
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




