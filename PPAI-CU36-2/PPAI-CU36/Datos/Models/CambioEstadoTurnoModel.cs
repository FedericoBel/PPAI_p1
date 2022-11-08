using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PPAI_CU36.Datos.Models
{
    internal class CambioEstadoTurnoModel
    {
        private string Tabla = "CambioEstadoTurno";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];

        private EstadoModel estModel = new EstadoModel();

        public void desmaterializar(CambioEstadoTurno ceT, int idTurno)
        {

            string consulta;

            if (ceT.fechaHoraHasta == null || ceT.fechaHoraHasta ==  Convert.ToDateTime("1 / 1 / 0001 00:00:00") || ceT.fechaHoraHasta == Convert.ToDateTime(null))
            {
                consulta = "INSERT INTO " + this.Tabla + " (id, fechaHoraDesde,idTurno,idEstado) VALUES (" + ceT.id + ",@FHD," + idTurno + ","
                                            + "(SELECT id FROM Estado WHERE nombre = '" + ceT.estado.nombre + "')" + ")";
            }
            else
            {
               consulta = "INSERT INTO " + this.Tabla + " VALUES (" + ceT.id + ",@FHD,@FHH," + idTurno + ","
                                             + "(SELECT id FROM Estado WHERE nombre = '" + ceT.estado.nombre + "')" + ")";
            }
            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@FHD",ceT.fechaHoraDesde);
                if (ceT.fechaHoraHasta != null && ceT.fechaHoraHasta != Convert.ToDateTime("1 / 1 / 0001 00:00:00") && ceT.fechaHoraHasta != Convert.ToDateTime(null) )
                {
                    cmd.Parameters.AddWithValue("@FHH", ceT.fechaHoraHasta);
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

        public void UpdateUltimoCambioEstado(CambioEstadoTurno cambioEstadoTurno)
        {
            string consulta = "UPDATE " + this.Tabla + " SET FechaHoraHasta = '" + DateTime.Now + "' WHERE id LIKE @idcambio";
            SqlConnection con = new SqlConnection(this.BDString);
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idcambio", cambioEstadoTurno.id);

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

        public List<CambioEstadoTurno> materializar(int idTurno)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE idTurno LIKE " + idTurno;
            List<CambioEstadoTurno> rta = new List<CambioEstadoTurno>();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
                    CambioEstadoTurno CET = new CambioEstadoTurno();

                   if (Data["fechaHoraHasta"] is DBNull){

                        CET.id = (int)Data["id"];
                        CET.fechaHoraDesde = (DateTime)Data["fechaHoraDesde"];
                        CET.estado = estModel.materializar((int)Data["idEstado"]);

                    }
                    else
                    {
                        CET.id = (int)Data["id"];
                        CET.fechaHoraDesde = (DateTime)Data["fechaHoraDesde"];
                        CET.fechaHoraHasta = (DateTime)Data["fechaHoraHasta"];
                        CET.estado = estModel.materializar((int)Data["idEstado"]);

                    }
                    rta.Add(CET);
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


                string consulta = "SELECT MAX(id) FROM CambioEstadoTurno";


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