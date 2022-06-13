using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos
{
    public class BD
    {
        public static List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            Usuario usu1 = new Usuario(1,"123","ppai", true, ListaPersonal()[0]);
            Usuario usu2 = new Usuario(2,"123","erik", true, ListaPersonal()[1]);

            listaUsuarios.Add(usu1);
            listaUsuarios.Add(usu2);
            return listaUsuarios;
        }

        public static List<PersonalCientifico> ListaPersonal()
        {
            List<PersonalCientifico> listaPersonalCientifico = new List<PersonalCientifico>();

            var pc1 = new PersonalCientifico
            {
                legajo = 123,
                nombre = "Francisco",
                apellido = "Polta",
                numeroDocumento = 44123,
                correoElectronicoInstitucional = "123@sistemas.frc.utn.edu.ar",
                correoElectronicoPersonal = "Franciscopolta@gmail.com",
                telefonoCelular = 123456,

            };
            var pc2 = new PersonalCientifico
            {
                legajo = 456,
                nombre = "Fede",
                apellido = "Fernadez",
                numeroDocumento = 44159,
                correoElectronicoInstitucional = "456@sistemas.frc.utn.edu.ar",
                correoElectronicoPersonal = "Fedefernandez@gmail.com",
                telefonoCelular = 123456,

            };

            var pc3 = new PersonalCientifico
            {
                legajo = 123,
                nombre = "Erik",
                apellido = "Salva",
                numeroDocumento = 85488,
                correoElectronicoInstitucional = "753@sistemas.frc.utn.edu.ar",
                correoElectronicoPersonal = "erikshalva@gmail.com",
                telefonoCelular = 123456,

            };

            listaPersonalCientifico.Add(pc1);
            listaPersonalCientifico.Add(pc2);
            listaPersonalCientifico.Add(pc3);

            return listaPersonalCientifico;
        }

        public static List<List<Turno>> ListaTurnos()
        {
            List<CambioEstadoTurno> listaCambiosEstadosTurno = new List<CambioEstadoTurno>();
            List<Turno> listaTurnosRecursos1 = new List<Turno>();

            List<Turno> listaTurnosRecursos2 = new List<Turno>();
            List<Turno> listaTurnosRecursos3 = new List<Turno>();


            List<List<Turno>> listaTurnosTotales = new List<List<Turno>>();


            // estados



            // CAMBIOS DE ESTADO PARA RECURSOS........................
            var actual_cambioEstadoTurno = new CambioEstadoTurno
            {
               fechaHoraDesde = Convert.ToDateTime("10/06/2022"),
               fechaHoraHasta = Convert.ToDateTime(null),
               estado = ListaEstados()[2],  //confirmado

            };
            var pasado_cambioEstadoTurno = new CambioEstadoTurno
            {
                fechaHoraDesde = Convert.ToDateTime("07/06/2022"),
                fechaHoraHasta = Convert.ToDateTime("09/06/2022"),
                estado = ListaEstados()[3], //estado pend de confirmar

            };
            listaCambiosEstadosTurno.Add(pasado_cambioEstadoTurno);
            listaCambiosEstadosTurno.Add(actual_cambioEstadoTurno);

            // TURNOS PARA RECURSO 1.............................
            var turno1 = new Turno
            {
                numero = 1,
                fechaGeneracion = Convert.ToDateTime("07/06/2022"),
                fechaHoraInicio = Convert.ToDateTime("27/06/2022"),
                fechaHoraFin = Convert.ToDateTime("29/06/2022"),
                diaSemana = "martes",
                CambioEstadoTurno = listaCambiosEstadosTurno,

            };

            var turno2 = new Turno
            {
                numero = 2,
                fechaGeneracion = Convert.ToDateTime("07/06/2022"),
                fechaHoraInicio = Convert.ToDateTime("15/06/2022"),
                fechaHoraFin = Convert.ToDateTime("18/06/2022"),
                diaSemana = "miercoles",
                CambioEstadoTurno = listaCambiosEstadosTurno,

            };

            listaTurnosRecursos1.Add(turno1);
            listaTurnosRecursos1.Add(turno2);

            // TURNOS PARA RECURSO 2............................19
            var turno3 = new Turno
            {
                numero = 3,
                fechaGeneracion = Convert.ToDateTime("07/06/2022"),
                fechaHoraInicio = Convert.ToDateTime("17/06/2022"),  //....
                fechaHoraFin = Convert.ToDateTime("18/06/2022"),
                diaSemana = "martes",
                CambioEstadoTurno = listaCambiosEstadosTurno,

            };

            var turno4 = new Turno
            {
                numero = 4,
                fechaGeneracion = Convert.ToDateTime("07/06/2022"),
                fechaHoraInicio = Convert.ToDateTime("19/06/2022"), //...
                fechaHoraFin = Convert.ToDateTime("25/06/2022"),
                diaSemana = "miercoles",
                CambioEstadoTurno = listaCambiosEstadosTurno,

            };
            listaTurnosRecursos2.Add(turno3);
            listaTurnosRecursos2.Add(turno4);
            //turnos 5 ,7..

            var turno5 = new Turno
            {
                numero = 5,
                fechaGeneracion = Convert.ToDateTime("10/06/2022"),
                fechaHoraInicio = Convert.ToDateTime("23/06/2022"),  //....
                fechaHoraFin = Convert.ToDateTime("28/06/2022"),
                diaSemana = "martes",
                CambioEstadoTurno = listaCambiosEstadosTurno,

            };

            var turno6 = new Turno
            {
                numero = 6,
                fechaGeneracion = Convert.ToDateTime("13/06/2022"),
                fechaHoraInicio = Convert.ToDateTime("25/06/2022"), //...
                fechaHoraFin = Convert.ToDateTime("29/06/2022"),
                diaSemana = "miercoles",
                CambioEstadoTurno = listaCambiosEstadosTurno,

            };
            listaTurnosRecursos3.Add(turno5);
            listaTurnosRecursos3.Add(turno6);


            listaTurnosTotales.Add(listaTurnosRecursos1);
            listaTurnosTotales.Add(listaTurnosRecursos2);
            listaTurnosTotales.Add(listaTurnosRecursos3);

            //[turnosrecurso1, turnosrecurso2]

            return listaTurnosTotales;
        }



        public static List<Estado> ListaEstados()
        {
            List<Estado> listaEstados = new List<Estado>();

            var estadoIngresoMC = new Estado
            {
                nombre = "Con ingreso en mantenimiento correctivo",
                descripcion = "Un estado en mantenimiento",
                ambito = "CambioEstadoRT",
                esCancelable = true,
                esReservable = false,

            };
            var estadoCanceladoPorMC = new Estado
            {
                nombre = "Cancelado por manteniemto correctivo",
                descripcion = "Un estado cancelado por MC",
                ambito = "CambioEstadoTurno",
                esCancelable = true,
                esReservable = false,

            };

            //turnos
            var estadoConfirmado = new Estado
            {
                nombre = "Confirmado",
                descripcion = "Un estado confirmado",
                ambito = "CambioEstadoTurno",
                esCancelable = true,
                esReservable = true,

            };
            var estadoPendConf = new Estado
            {
                nombre = "Pendiente de confirmacion",
                descripcion = "Un estado pendiente",
                ambito = "CambioEstadoTurno",
                esCancelable = true,
                esReservable = true,

            };
            var estadoDisponible = new Estado
            {
                nombre = "Disponible",
                descripcion = "Un estado disponible",
                ambito = "CambioEstadoRT",
                esCancelable = true,
                esReservable = true,

            };

            listaEstados.Add(estadoIngresoMC);
            listaEstados.Add(estadoCanceladoPorMC);
            listaEstados.Add(estadoConfirmado);
            listaEstados.Add(estadoPendConf);
            listaEstados.Add(estadoDisponible);



            return listaEstados;
        }
   

        public static List<RecursosTecnologicos> ListaRecursos()
        {
            List<RecursosTecnologicos> listaRecursosTecnologicos = new List<RecursosTecnologicos>();
            List<CambioEstadoRT> listaCambiosEstadosRT = new List<CambioEstadoRT>();


            var pasado_cambioEstadoRT = new CambioEstadoRT
            {
                Estado = ListaEstados()[4],
                fechaHoraDesde = Convert.ToDateTime("06/06/2022"),
                fechaHoraHasta = Convert.ToDateTime("07/06/2022"),

            };
            var actual_cambioEstadoRT = new CambioEstadoRT
            {
                Estado = ListaEstados()[4],
                fechaHoraDesde = Convert.ToDateTime("06/06/2022"),
                fechaHoraHasta = Convert.ToDateTime(null),

            };
            listaCambiosEstadosRT.Add(pasado_cambioEstadoRT);
            listaCambiosEstadosRT.Add(actual_cambioEstadoRT);

            var marca = new Marca
            {
                nombre = "Toyota",
            };


            var modelo1 = new Modelo
            {
                nombre = "modelo1",
                marca = marca,
            };
            var modelo2 = new Modelo
            {
                nombre = "modelo2",
                marca = marca,
            };

            var tiporecurso1 = new TipoRecursoTecnologico
            {
                nombre = "tipo1",
                descripcion = "recurso1fede",

            };
            var tiporecurso2 = new TipoRecursoTecnologico
            {
                nombre = "tipo2",
                descripcion = "recurso2kevin",

            };


            List<Mantenimiento> mante1 = new List<Mantenimiento>();
            List<Mantenimiento> mante2 = new List<Mantenimiento>();

            //RECURSO TECNOLOGICO NUMERO 1
            var rt1 = new RecursosTecnologicos
            {
                numeroRT = 1,
                fechaAlta = DateTime.Now,
                imagenes = 1,
                perioricidadMantenimientoPrev = 1,
                duracionMantenimientoPrev = 1,
                fraccionHorarioTurnos = 1,
                cambioEstadoRt = listaCambiosEstadosRT,
                TipoRecursoTecnologico = tiporecurso1,
                Modelo = modelo1,
                mantenimientos = mante1,
                turnos = ListaTurnos()[0], //turnos 1 y 2
            };
            //RECURSO TECNOLOGICO NUMERO 2
            List<Turno> turnos56 = ListaTurnos()[2];

            var rt2 = new RecursosTecnologicos
            {
                numeroRT = 2,
                fechaAlta = DateTime.Now,
                imagenes = 2,
                perioricidadMantenimientoPrev = 2,
                duracionMantenimientoPrev = 2,
                fraccionHorarioTurnos = 2,
                cambioEstadoRt = listaCambiosEstadosRT,
                TipoRecursoTecnologico = tiporecurso2,
                Modelo = modelo2,
                mantenimientos = mante2,
                turnos = ListaTurnos()[1].Concat(turnos56).ToList(),  //turnos 3 y 4, 5 y 6

            };

            listaRecursosTecnologicos.Add(rt1);
            listaRecursosTecnologicos.Add(rt2);

            return listaRecursosTecnologicos;
        }

        public static Sesion ListaSesion()
        {
            var sesion1 = new Sesion
            {
                Usuario = ListaUsuarios()[0],
                fechaHoraInicio = DateTime.Now,
                fechaHoraFin = Convert.ToDateTime(null),
            };

            return sesion1;

        }
        public static List<AsignacionResponsableTecnicoRT> ListaAsignacionesResponsableTecnicoRT()
        {
            List<AsignacionResponsableTecnicoRT> listaAsignacionesResponsableTecnicoRT = new List<AsignacionResponsableTecnicoRT>();
            var asigrt1_vigente = new AsignacionResponsableTecnicoRT
            {
                fechaDesde = Convert.ToDateTime("09/06/2022"),
                fechaHasta = Convert.ToDateTime(null),
                recursosTecnologicos = ListaRecursos(),
                personalCientifico = ListaPersonal()[0],
            };

            var asigrt1_noVigente = new AsignacionResponsableTecnicoRT
            {
                fechaDesde = Convert.ToDateTime("09/06/2022"),
                fechaHasta = Convert.ToDateTime("10/06/2022"),
                recursosTecnologicos = ListaRecursos(),
                personalCientifico = ListaPersonal()[0],
            };

            listaAsignacionesResponsableTecnicoRT.Add(asigrt1_vigente);
            listaAsignacionesResponsableTecnicoRT.Add(asigrt1_noVigente);


            return listaAsignacionesResponsableTecnicoRT;

        }

        public static List<AsignacionCientificoDelCI> ListaAsignacionCien()
        {
            List<AsignacionCientificoDelCI> listaAsignacionesCientifico = new List<AsignacionCientificoDelCI>();


            //recurso 1
            var asigCien_1 = new AsignacionCientificoDelCI
            {
                fechaDesde = Convert.ToDateTime("05/06/2022"),
                fechaHasta = Convert.ToDateTime("20/06/2022"),
                personalCientifico = ListaPersonal()[0], // francisco
                turno = ListaTurnos()[0], // turno 1 y 2
            };

            //recurso 2
            var asigCien_2 = new AsignacionCientificoDelCI
            {
                fechaDesde = Convert.ToDateTime("05/06/2022"),
                fechaHasta = Convert.ToDateTime("20/06/2022"),
                personalCientifico = ListaPersonal()[1], // fede
                turno = ListaTurnos()[1], //turno  3 y 4 
            };

            var asigCien_3 = new AsignacionCientificoDelCI
            {
                fechaDesde = Convert.ToDateTime("05/06/2022"),
                fechaHasta = Convert.ToDateTime("20/06/2022"),
                personalCientifico = ListaPersonal()[2], // erik
                turno = ListaTurnos()[2], //turno  5 y 6 
            };



            listaAsignacionesCientifico.Add(asigCien_1);
            listaAsignacionesCientifico.Add(asigCien_2);
            listaAsignacionesCientifico.Add(asigCien_3);

            return listaAsignacionesCientifico;
        }
    }
}
