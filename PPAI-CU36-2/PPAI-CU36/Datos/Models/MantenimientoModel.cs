using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class MantenimientoModel
    {
        private string Tabla = "Mantenimiento";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];


        public void desmaterializar(Mantenimiento mantenimiento, int idRT)
        {

            string consulta = "INSERT INTO " + this.Tabla + " VALUES ( @FI,@FF,@FIP, '"
                                                                        + mantenimiento.motivoMantenimiento + "', "
                                                                        +  idRT + ")";
            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FI", mantenimiento.fechaInicio);
                cmd.Parameters.AddWithValue("@FF", mantenimiento.fechaFin);
                cmd.Parameters.AddWithValue("@FIP", mantenimiento.fechaInicioPrevista);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Mantenimiento> materializar(int RT)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE idRecursoTecnologico LIKE " + RT;
            List<Mantenimiento> rta = new List<Mantenimiento> { };

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
   
                    DateTime FechaInicio =  (DateTime) Data["fechaInicio"];
                    DateTime FechaInicioPrevista = (DateTime) Data["fechaInicioPrevista"];
                    DateTime FechaFin =(DateTime) Data["fechaFin"];
                    string Motivo = Data["motivoMantenimiento"].ToString();
                    int extension = (int) 1;

                    rta.Add(new Mantenimiento
                    {
                        fechaInicio = FechaInicio,
                        fechaInicioPrevista = FechaInicioPrevista,
                        fechaFin = FechaFin,
                        motivoMantenimiento = Motivo,
                        ExtensionMantenimiento = extension
                    });
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
