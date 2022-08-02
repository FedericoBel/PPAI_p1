using PPAI_CU36.Datos;
using PPAI_CU36.Formularios;
using System;
using System.Collections;
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
        public int indiceRTS { get; set; }
        public DateTime fechaActual { get; set; }
        public List<RecursosTecnologicos> recursosTecnologicosDisponibles { get; set; } 
        public bool confirmacion { get; set; }
        public bool notificacion { get; set; }  
        
        public List<List<DataGridViewRow>> filaGrillaTurno { get; set; }

        static public List<DataGridViewRow> filaGrillaRecurso = new List<DataGridViewRow>();

        public AsignacionResponsableTecnicoRT asignacionVigenteLogueada { get; set; }
        public List<Estado> listaEstados { get; set; }
        public Sesion sesion { get; set; }
        public List<AsignacionResponsableTecnicoRT> listaDeAsignacionResponsableTecnicoRT { get; set; }
        public List<AsignacionCientificoDelCI> listaAsignacionCientificos { get; set; }
         
        public void nuevoIngresoMantCorrectivo()
        {
            filaGrillaRecurso.Clear();

            // Buscamos el personal cientifico del usuario actualmente logueado...
            PersonalCientifico personalCientificoLogueado = getUsuarioLogueado();
            
            // Metodo para obtener la asignacion de recursos para el personal cientifico logueado...

            AsignacionResponsableTecnicoRT asignacionResponsableTecnicoLogueado =  getRTDisponiblesRRT(personalCientificoLogueado);

            this.asignacionVigenteLogueada = asignacionResponsableTecnicoLogueado;
           

            // Metodo para obtener los recursos en estado disponible de la asignacionResponsableTecnicoLogueado y cargar la grilla...

            List<RecursosTecnologicos> recursosTecnologicosDisponibles = this.asignacionVigenteLogueada.obtenerRecursosDisponibles();
            
            this.recursosTecnologicosDisponibles = recursosTecnologicosDisponibles;

            // Ordenar los recursosTecnologicosDisponibles por tipo de recurso...

            agruparRTPorTipo();
            
            // Metodo para enviar la grilla a la pantalla...

            Principal.casoDeUso.solicitarSeleccionRT(filaGrillaRecurso);

        }

        // Ordenar la grilla por tipo de recurso
        private void agruparRTPorTipo()
        {
            filaGrillaRecurso = filaGrillaRecurso.OrderBy(x => x.Cells[0].Value.ToString()).ToList();
        }


        // Metodo para obtener la asignacion de recursos para el personal cientifico logueado...
        public AsignacionResponsableTecnicoRT getRTDisponiblesRRT(PersonalCientifico pc)
        {

            int indice = 0;
            for (int i = 0; i < this.listaDeAsignacionResponsableTecnicoRT.Count; i++)
            {
                if (this.listaDeAsignacionResponsableTecnicoRT[i].esDeUsuarioLogueadoYVigente(pc))
                {
                    indice = i;
                    break;
                }

            }

            return this.listaDeAsignacionResponsableTecnicoRT[indice];
        }

        // Metodo que devuelve el personal cientifico del usuario actualmente logueado...
        private PersonalCientifico getUsuarioLogueado()
        {
            return this.sesion.mostrarCientificoLogueado();
        }

        // Metodo que guarda el indice donde se ubica el recurso tecnologico seleccionado en la lista de recursos...
        public void seleccionRT(int numeroRT)
        {
            for (int i = 0; i < recursosTecnologicosDisponibles.Count; i++)
            {
                if (recursosTecnologicosDisponibles[i].numeroRT == numeroRT)
                {
                    this.indiceRTS = i;
                }
            }
        }

        // Metdo que guarda la fecha y motivo ingresado por el usuario...
        public void tomarFechaFinYMotivo(DateTime fechaFin, string motivo)
        {
            this.fechaFinPrevista = fechaFin;
            this.motivo = motivo;
            buscarTurnosConfYPendConf();
        }

        // Metodo apra buscar los turnos confirmados y pendientes de confirmacion del recurso tecnologico seleccionado...
        private void buscarTurnosConfYPendConf()
        {
            getFechaActual();

            // variable auxiliar, para no perder todos los turnos...
            List<Turno> turnosCompletos = new List<Turno>();
            turnosCompletos = recursosTecnologicosDisponibles[indiceRTS].turnos;

            // metodo para conseguir todos los turnos confirmados y pendiente de confirmacion del recurso tecnoligico seleccionado y los sobreescribo...
            this.recursosTecnologicosDisponibles[indiceRTS].turnos = this.recursosTecnologicosDisponibles[indiceRTS].getTurnosConfYPendConf(this.fechaFinPrevista);

            getDatosTurnos(turnosCompletos);
        }

        private void getFechaActual()
        {
            this.fechaActual = DateTime.Now;
        
        }

        // Metodo para cargar la grilla con los datos de los turnos del recurso tecnologico seleccionado...
        private void getDatosTurnos(List<Turno> turnosCompletos) 
        {
            this.filaGrillaTurno = (this.recursosTecnologicosDisponibles[indiceRTS].getDatosTurnos(listaAsignacionCientificos));
            // Cargo todos los turnos para el recurso tecnologico seleccionado... VERIFICAR...
            this.recursosTecnologicosDisponibles[indiceRTS].turnos = turnosCompletos;
            agruparPorCientifico();
        }

        // Metodo que agrupa los turnos por cientifico....
        private void agruparPorCientifico()
        {
            List<DataGridViewRow> listaAuxiliar = new List<DataGridViewRow>();

            for (int i = 0; i < filaGrillaTurno.Count; i++)
            {
                for (int j = 0; j < filaGrillaTurno[i].Count; j++)
                {
                    listaAuxiliar.Add(filaGrillaTurno[i][j]);
                }
            }
            listaAuxiliar = listaAuxiliar.OrderBy(x => x.Cells[0].Value.ToString()).ToList();

            Principal.casoDeUso.solicitarConfirmacionYNotiMC(listaAuxiliar);

            //this.filaGrillaTurno.Clear();

        }

        // Metodo que guarda la confirmacion y notificacion...
        public void tomarConfirmacionYNoti(bool confirmacion, bool notificacion)
        {
            this.confirmacion = confirmacion;
            this.notificacion = notificacion;

            crearMantenimiento();
            List<int> listaIndicesEstados = buscarEstados();
            buscarEstadoActual(this.listaEstados[listaIndicesEstados[0]], this.listaEstados[listaIndicesEstados[1]]);
        }

        // Metodo para crear un mantenimiento...
        private void crearMantenimiento()
        {
            recursosTecnologicosDisponibles[indiceRTS].crearMantenimiento(fechaFinPrevista,fechaActual, DateTime.Now, motivo, 1);
        }

        // Metodo para buscar los estados de Ingreso a mantenimiento correctivo y cancelado por mantenimeitno correctivo...
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
                        indice1 = i;
                    }
                }
                if (this.listaEstados[i].esAmbitoTurno())
                {
                    if (this.listaEstados[i].esCanceladoPorMC())
                    {
                        indice2 = i; 
                    }
                }
            }
            listaIndicesEstados.Add(indice1);
            listaIndicesEstados.Add(indice2);

            return listaIndicesEstados;

        }

        // Metodo que cambia el estado del recurso tecnologico seleccionado y de sus turnos...
        private void buscarEstadoActual(Estado ingresoMC, Estado canceladoMC)
        {
            this.recursosTecnologicosDisponibles[indiceRTS].getEstadoActual(ingresoMC);
            this.recursosTecnologicosDisponibles[indiceRTS].cancelarTurnos(canceladoMC, this.fechaFinPrevista);

            generarMail();
        }

        // Metodo para generar el mail y cargar la grilla de recursos...
        private void generarMail()
        {

           
            if (!this.notificacion)
            {

                for (int i = 0; i < filaGrillaTurno.Count; i++)
                {
                    for (int j = 0; j < filaGrillaTurno[i].Count; j++)
                    {
                        InterfazMail interfezParaMail = new InterfazMail();
                        string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>Su turno para " + this.recursosTecnologicosDisponibles[indiceRTS].TipoRecursoTecnologico.nombre.ToString() + " en fecha: " + filaGrillaTurno[i][j].Cells[2].Value.ToString() + " fue cancelado por motivos de mantenimiento</h1></br>" +
                            "<h2>Disculpe las molestias, muchas gracias!</h2>";
                        interfezParaMail.mailDeCancelacion(filaGrillaTurno[i][j].Cells[1].Value.ToString(), "Cancelación turno recurso tecnologico", body);


                    }
                }

               
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
            Principal.casoDeUso.Close();
        }
    }
}




