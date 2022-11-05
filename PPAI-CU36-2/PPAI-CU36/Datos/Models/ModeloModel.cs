using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class ModeloModel
    {
        private string Tabla = "Modelo"; 
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
        private MarcaModel marcaModel = new MarcaModel();
        public void desmaterializar(Modelo modelo)
        {
            string consulta = "INSERT INTO Modelo VALUES (" + modelo.nombre + "," +
                            "(SELECT id FROM Marca WHERE Nombre LIKE " + modelo.marca.nombre + "))";
            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Modelo materializar(int Idmodelo)
        {
            string consulta = "SELECT * FROM Modelo WHERE id LIKE "+ Idmodelo;
            Modelo rta = new Modelo();

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
                    rta.marca = this.marcaModel.materializar((int) Data["idMarca"]);

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
