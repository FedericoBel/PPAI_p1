using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
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
                consulta = "INSERT INTO " + this.Tabla + " (fechaHoraDesde,idTurno,idEstado) VALUES (@FHD," + idTurno + ","
                                            + "(SELECT id FROM Estado WHERE nombre LIKE '" + ceT.estado.nombre + "'))";
            }
            else
            {
               consulta = "INSERT INTO " + this.Tabla + " VALUES (@FHD,@FHH," + idTurno + ","
                                            + "(SELECT id FROM Estado WHERE nombre LIKE '" + ceT.estado.nombre + "'))";
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

                        CET.fechaHoraDesde = (DateTime)Data["fechaHoraDesde"];
                        CET.estado = estModel.materializar((int)Data["idEstado"]);

                    }
                    else
                    {

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


    }
}