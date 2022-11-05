using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class TipoRecursoTecnologicoModel
    {
        private string Tabla = "TipoRecursoTecnologico";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];


        public void desmaterializar(TipoRecursoTecnologico tipoRT)
        {

            string consulta = "INSERT INTO " + this.Tabla + " VALUES (" + tipoRT.nombre + ", " + tipoRT.descripcion +")";

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TipoRecursoTecnologico materializar(int idTipoRT)
        {
            string consulta = "SELECT FROM " + this.Tabla + " WHERE id LIKE" + idTipoRT;
            TipoRecursoTecnologico rta = new TipoRecursoTecnologico();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    string Nombre = Data["Nombre"].ToString();
                    string Descripcion = Data["descripción"].ToString();
                    rta.nombre = Nombre;
                    rta.descripcion = Descripcion;
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
