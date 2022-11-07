using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class TurnoModel
    {
        private string Tabla = "Turno";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];

        private CambioEstadoTurnoModel cambioEstadoTModel = new CambioEstadoTurnoModel();


        public void desmaterializar(Turno turno, int IdRt)
        {

            string consulta = "INSERT INTO " + this.Tabla + " (id,diasemana,fechaGeneracion,fechaHoraFin,fechaHoraInicio,IdRecursoTecnologico) " +
                                                                "VALUES (@id,@ds,@fg,@fhf,@fhi,@idRT)";
            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",turno.numero);
                cmd.Parameters.AddWithValue("@ds",turno.diaSemana);
                cmd.Parameters.AddWithValue("@fg",turno.fechaGeneracion);
                cmd.Parameters.AddWithValue("@fhf",turno.fechaHoraFin);
                cmd.Parameters.AddWithValue("@fhi",turno.fechaHoraInicio);
                cmd.Parameters.AddWithValue("@idRT",IdRt);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();

                foreach (var item in turno.CambioEstadoTurno)
                {
                    this.cambioEstadoTModel.desmaterializar(item, turno.numero);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void HayAsignacionCIxTurno(Turno turno, int idAsig)
        {
            string consulta = "UPDATE " + this.Tabla + " SET idAsignacionCientifico = " + idAsig + " WHERE id LIKE " + turno.numero;

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();

                foreach (var item in turno.CambioEstadoTurno)
                {
                    this.cambioEstadoTModel.desmaterializar(item, turno.numero);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Turno> materializar(int idRT, string Id)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE "+ Id +" LIKE " + idRT;
            List<Turno> rta = new List<Turno>();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
                    Turno t = new Turno
                    {
                        numero = (int)Data["id"],
                        fechaGeneracion = (DateTime)Data["fechaGeneracion"],
                        fechaHoraFin = (DateTime)Data["fechaHoraFin"],
                        fechaHoraInicio = (DateTime)Data["fechaHoraInicio"],
                        diaSemana = (string)Data["diasemana"],
                        CambioEstadoTurno = this.cambioEstadoTModel.materializar((int)Data["id"]),
                    };

                    rta.Add(t);
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }



    }
}
