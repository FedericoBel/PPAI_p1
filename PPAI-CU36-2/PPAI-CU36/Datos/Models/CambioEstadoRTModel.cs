using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class CambioEstadoRTModel
    {

        private string Tabla = "CambioEstadoRT";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];

        public EstadoModel estadoModel = new EstadoModel();
        public void desmaterializar(CambioEstadoRT cambio, int IdRT)
        {


            string consulta = "INSERT INTO " + this.Tabla; 

            if (cambio.fechaHoraHasta == Convert.ToDateTime(null))
            {

                consulta += " (id, fechaHoraDesde, idEstado,idRecursoTecnologico) VALUES (" + cambio.id + ", CAST(@FHD AS DATETIME), "
                                                          + "(SELECT id FROM Estado WHERE nombre = '" + cambio.Estado.nombre + "')," + IdRT + ")";
            }
            else
            {
                consulta = "INSERT INTO " + this.Tabla + " (id, fechaHoraDesde,fechaHoraHasta,idEstado,idRecursoTecnologico) VALUES (" + cambio.id + ", CAST(@FHD AS DATETIME), CAST(@FHH AS DATETIME), "
                                                      + "(SELECT id FROM Estado WHERE nombre = '" + cambio.Estado.nombre + "')," + IdRT + ")";

            }
           
            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@FHD",cambio.fechaHoraDesde);
                if (cambio.fechaHoraHasta != Convert.ToDateTime(null))
                {
                    cmd.Parameters.AddWithValue("@FHH", cambio.fechaHoraHasta);

                }
               
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal void UpdateUltimoCambioEstado(CambioEstadoRT cambioEstadoRT)
        {
            string consulta = "UPDATE " + this.Tabla + " SET FechaHoraHasta = '" + DateTime.Now + "' WHERE id LIKE @idcambio";
            SqlConnection con = new SqlConnection(this.BDString);
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idcambio", cambioEstadoRT.id);
                cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
               con.Close();
            }
        }

        public List<CambioEstadoRT> materializar(int idRT)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE idRecursoTecnologico LIKE " + idRT;
            List<CambioEstadoRT> rta = new List<CambioEstadoRT>();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
                   DateTime fechaHoraDesde = (DateTime)Data["fechaHoraDesde"];
                   Estado estado = estadoModel.materializar((int)Data["idEstado"]);
                    CambioEstadoRT CERT = new CambioEstadoRT();


                    if (Data["fechaHoraHasta"] is DBNull)
                    {
                        CERT.id = (int)Data["id"];
                        CERT.fechaHoraDesde = fechaHoraDesde;
                        CERT.Estado = estado;
                    }
                    else
                    {
                        CERT.id = (int)Data["id"];
                        CERT.fechaHoraDesde = fechaHoraDesde;
                        CERT.Estado = estado;
                        CERT.fechaHoraHasta = (DateTime)Data["fechaHoraHasta"];
                    }


                    rta.Add(CERT);
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }

        public int ObtenerUltimoId()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT MAX(id) FROM CambioEstadoRT";


                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                int resultado = (int)cmd.ExecuteScalar();
                return resultado;


            }
            catch (Exception)
            {

                return 0;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
