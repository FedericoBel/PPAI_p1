using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
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

            string consulta = "INSERT INTO " + this.Tabla + " (fechaHoraDesde,idEstado,idRecursoTecnologico) VALUES ( CAST(@FHD AS DATETIME), "
                                                          + "(SELECT id FROM Estado WHERE nombre LIKE '"+  cambio.Estado.nombre + "')," +IdRT+ ")";

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@FHD",cambio.fechaHoraDesde);
            
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw e;
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
                        CERT.fechaHoraDesde = fechaHoraDesde;
                        CERT.Estado = estado;
                    }
                    else
                    {
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

    }
}
