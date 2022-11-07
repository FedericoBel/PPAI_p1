using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class RecursoTecnologicoModel
    {
        private string Tabla = "RecursoTecnologico";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];

        private ModeloModel modelosModel = new ModeloModel();
        private TipoRecursoTecnologicoModel TipoRTModel = new TipoRecursoTecnologicoModel();
        private MantenimientoModel MantenimientoModel = new MantenimientoModel();
        private CambioEstadoRTModel cambioRTModel = new CambioEstadoRTModel();
        private TurnoModel turnoModel = new TurnoModel();
        public void desmaterializar(RecursosTecnologicos RT)
        {
            
            string consulta = "INSERT INTO "+ this.Tabla +" VALUES (" + RT.numeroRT + ", "
                                                            + RT.duracionMantenimientoPrev + ", "
                                                            + "@Fal, "
                                                            + RT.fraccionHorarioTurnos + ", "
         + "(SELECT id FROM TipoRecursoTecnologico WHERE nombre LIKE '" + RT.TipoRecursoTecnologico.nombre +"'), " 
         + "(SELECT id FROM Modelo WHERE nombre LIKE '" + RT.Modelo.nombre + "')" + ", " + RT.imagenes + ", " 
         + RT.perioricidadMantenimientoPrev+")";

            try
            {

                foreach (var item in RT.mantenimientos)
                {
                    this.MantenimientoModel.desmaterializar(item, RT.numeroRT);
                }

                this.TipoRTModel.desmaterializar(RT.TipoRecursoTecnologico);
            
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Fal", RT.fechaAlta);
                cmd.ExecuteNonQuery();
                con.Close();
         
                foreach (var item in RT.cambioEstadoRt)
                {
                    this.cambioRTModel.desmaterializar(item, RT.numeroRT);
                }
                foreach (var item in RT.turnos)
                {
                    this.turnoModel.desmaterializar(item, RT.numeroRT);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public RecursosTecnologicos materializar(int idRecursoTecnologico)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE numero LIKE " + idRecursoTecnologico;
            RecursosTecnologicos rta = new RecursosTecnologicos();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    int Numero = (int)Data["numero"];
                    int Duracion = (int)Data["duracionMantenimientoPrev"];
                    DateTime FechaAlta = Convert.ToDateTime(Data["fechaAlta"]);
                    int FraccionHS = (int)Data["fraccionHorariosTurnos"];
                    int TipoRT =(int) Data["idTipoRT"];
                    int modelo = (int)Data["modelo"];
                    int img =(int) Data["imagenes"];
                    int periodicidad = (int) Data["periodicidadMantenimientoPrev"];

                    rta.numeroRT = Numero;
                    rta.duracionMantenimientoPrev = Duracion;
                    rta.fechaAlta = FechaAlta;
                    rta.fraccionHorarioTurnos = FraccionHS;
                    rta.TipoRecursoTecnologico = this.TipoRTModel.materializar(TipoRT);
                    rta.Modelo = this.modelosModel.materializar(modelo);
                    rta.imagenes = img;
                    rta.perioricidadMantenimientoPrev = periodicidad;
                    rta.mantenimientos = this.MantenimientoModel.materializar(Numero);
                    rta.cambioEstadoRt = this.cambioRTModel.materializar(Numero);
                    rta.turnos = this.turnoModel.materializar(Numero, "IdRecursoTecnologico");

                }

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }




        public List<RecursosTecnologicos> ObtenerListaRecursosTecnologicosMaterializar(int idAsignacionRT)
        {
            string consulta = "SELECT rt.* FROM RecursoTecnologico rt JOIN AsignacionResponsableTecnicoRT art on (rt.numero = art.IdRecursoTecnologico) " +
                "WHERE art.id = @idasigrt";
            List<RecursosTecnologicos> listaRecursos = new List<RecursosTecnologicos>();
            SqlConnection con = new SqlConnection(this.BDString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idasigrt", idAsignacionRT);


                cmd.ExecuteNonQuery();
                
                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
                    int Numero = (int)Data["numero"];
                    int Duracion = (int)Data["duracionMantenimientoPrev"];
                    DateTime FechaAlta = Convert.ToDateTime(Data["fechaAlta"]);
                    int FraccionHS = (int)Data["fraccionHorariosTurnos"];
                    int TipoRT = (int)Data["idTipoRT"];
                    int modelo = (int)Data["modelo"];
                    int img = (int)Data["imagenes"];
                    int periodicidad = (int)Data["periodicidadMantenimientoPrev"];

                    RecursosTecnologicos rta = new RecursosTecnologicos();

                    rta.numeroRT = Numero;
                    rta.duracionMantenimientoPrev = Duracion;
                    rta.fechaAlta = FechaAlta;
                    rta.fraccionHorarioTurnos = FraccionHS;
                    rta.TipoRecursoTecnologico = this.TipoRTModel.materializar(TipoRT);
                    rta.Modelo = this.modelosModel.materializar(modelo);
                    rta.imagenes = img;
                    rta.perioricidadMantenimientoPrev = periodicidad;
                    rta.mantenimientos = this.MantenimientoModel.materializar(Numero);
                    rta.cambioEstadoRt = this.cambioRTModel.materializar(Numero);
                    rta.turnos = this.turnoModel.materializar(Numero, "IdRecursoTecnologico");


                    listaRecursos.Add(rta);




                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();

            }
            return listaRecursos;
        }
    }
}
