using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class SesionModel
    {

        private string tabla = "Sesion";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
        UsuarioModel usuarioModel = new UsuarioModel();

        public void desmaterializar(Sesion sesion)
        {
            string consulta = "INSERT INTO " + this.tabla + " (fechaHoraInicio,fechaHoraFin,idUsuario ) VALUES ( @FHI,@FHF,"
            + "(SELECT id FROM Usuario WHERE usuario LIKE '" + sesion.Usuario.nombreUsuario + "'))";

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FHI",sesion.fechaHoraInicio);
                cmd.Parameters.AddWithValue("@FHf",sesion.fechaHoraFin);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Sesion materializar(int idSesion)
        {
            string consulta = "SELECT * FROM " + this.tabla + " WHERE id LIKE " + idSesion + "";

            Sesion rta = new Sesion();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    Usuario usuario = this.usuarioModel.materializar((int)Data["idUsuario"]);
                    DateTime fechaHoraInicio = (DateTime)Data["fechaHoraInicio"];
                    DateTime fechaHoraFin = (DateTime)Data["fechaHoraFin"];

                    rta.Usuario = usuario;
                    rta.fechaHoraInicio = fechaHoraInicio;
                    rta.fechaHoraFin = fechaHoraFin;

                    //string clave = Data["Clave"].ToString();
                    //Boolean habilitado = (bool)Data["habilitado"];
                    //string usuario = Data["usuario"].ToString();
                    //PersonalCientifico personalCientifico = this.personalCientificoModel.materializar((int)Data["idPersonalCientifico"]);

                    //rta.idDeUsuario = idUsuario;
                    //rta.claveDeUsuario = clave;
                    //rta.estahabilitado = habilitado;
                    //rta.nombreUsuario = usuario;
                    //rta.personalcientifico = personalCientifico;

                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }
        public Sesion ObtenerSesion()
        {
            string consulta = "SELECT TOP(1) * FROM "+this.tabla+" ORDER BY fechaHoraInicio DESC";
            Sesion session = new Sesion();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {

                    Usuario usuario = this.usuarioModel.materializar((int)Data["idUsuario"]);
                    DateTime fechaHoraInicio = (DateTime)Data["fechaHoraInicio"];
                    DateTime fechaHoraFin = (DateTime)Data["fechaHoraFin"];

                    session.Usuario = usuario;
                    session.fechaHoraInicio = fechaHoraInicio;
                    session.fechaHoraFin = fechaHoraFin;

          
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return session;
        }

    }
}
