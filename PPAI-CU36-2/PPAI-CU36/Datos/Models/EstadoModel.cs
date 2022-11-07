using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class EstadoModel
    {

        private string Tabla = "Estado";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];


        public void desmaterializar(Estado estado)
        {

            string consulta = "INSERT INTO " + this.Tabla + " VALUES ('" + estado.ambito + "','"
                                                                         + estado.descripcion + "',"                                       
                                                                         + Convert.ToByte(estado.esCancelable) + ","
                                                                         + Convert.ToByte(estado.esReservable) + ",'"
                                                                         + estado.nombre + "')";

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

        public Estado materializar(int IdEst)
        {
            string consulta = "SELECT * FROM " + this.Tabla + " WHERE id LIKE " + IdEst;
            Estado rta = new Estado();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    string Nombre = Data["nombre"].ToString();
                    string Ambito = Data["ambito"].ToString();
                    string Descripcion = Data["descripcion"].ToString();
                    bool cancelable = (bool) Data["esCancelable"];
                    bool Reservable = (bool) Data["esReservable"];

                    rta.nombre = Nombre;
                    rta.ambito = Ambito;
                    rta.descripcion = Descripcion;
                    rta.esCancelable = cancelable;
                    rta.esReservable = Reservable;
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }

        public List<Estado> ObtenerEstados()
        {
            string consulta = "SELECT * FROM " + this.Tabla ;
            List<Estado> estados = new List<Estado>();
            SqlConnection con = new SqlConnection(this.BDString);
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
                    string Nombre = Data["nombre"].ToString();
                    string Ambito = Data["ambito"].ToString();
                    string Descripcion = Data["descripcion"].ToString();
                    bool cancelable = Convert.ToBoolean(Data["esCancelable"]);
                    bool Reservable = Convert.ToBoolean(Data["esReservable"]);

                    Estado est = new Estado
                    {
                        nombre = Nombre,
                        ambito = Ambito,
                        descripcion = Descripcion,
                        esCancelable = cancelable,
                        esReservable = Reservable
                    };

                    estados.Add(est);
                }
                

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return estados;
        }


    }
}
