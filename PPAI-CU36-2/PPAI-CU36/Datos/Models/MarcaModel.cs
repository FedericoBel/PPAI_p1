using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class MarcaModel
    {
        private string Tabla = "Marca"; 
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];


        public void desmaterializar(Marca marca)
        {

            string consulta = "INSERT INTO " + this.Tabla + " VALUES ('"+marca.nombre+"')";

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

        public Marca materializar(int idMarca)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE id LIKE "+ idMarca;
            Marca rta = new Marca();

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
                    rta.nombre = Nombre;
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

