using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class PersonalCientificoModel
    {
        private string Tabla = "PersonalCientifico";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];


        public void desmaterializar(PersonalCientifico personalCientifico)
        {

            string consulta = "INSERT INTO " + this.Tabla + " VALUES ('" + personalCientifico.legajo + "," 
                                                            + personalCientifico.apellido + ","
                                                            + personalCientifico.correoElectronicoInstitucional + ","
                                                            + personalCientifico.correoElectronicoPersonal + ","
                                                            + personalCientifico.nombre + ","
                                                            + personalCientifico.numeroDocumento + ","
                                                            + personalCientifico.telefonoCelular + ","
                                                            + "')";
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

        public PersonalCientifico materializar(int legajo)
        {
            string consulta = "SELECT FROM " + this.Tabla + " WHERE legajo LIKE" + legajo;
            PersonalCientifico rta = new PersonalCientifico();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    string apellido = Data["apellido"].ToString();
                    string correoElectronicoInstitucional = Data["correoElectronicoInstitucional"].ToString();
                    string correoElectronicoPersonal = Data["correoElectronicoPersonal"].ToString();
                    string nombre = Data["nombre"].ToString();
                    int numeroDocumento = (int)Data["numeroDocumento"];
                    int telefonoCelular = (int)Data["telefonoCelular"];

                    rta.legajo = legajo;
                    rta.apellido = apellido;
                    rta.correoElectronicoInstitucional = correoElectronicoInstitucional;
                    rta.correoElectronicoPersonal = correoElectronicoPersonal; 
                    rta.nombre = nombre;
                    rta.numeroDocumento = numeroDocumento; 
                    rta.telefonoCelular = telefonoCelular;
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
