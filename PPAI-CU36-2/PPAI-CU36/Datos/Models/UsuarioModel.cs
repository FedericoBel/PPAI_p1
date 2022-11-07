using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class UsuarioModel
    {

        private string tabla = "Usuario";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
        private PersonalCientificoModel personalCientificoModel = new PersonalCientificoModel();

        public void desmaterializar(Usuario usuario)
        {
            string consulta = "INSERT INTO " + this.tabla + " VALUES ('" + usuario.claveDeUsuario + "',"
                                                            + Convert.ToByte(usuario.estahabilitado) + ",'"
                                                            + usuario.nombreUsuario + "',"
                                                            + usuario.personalcientifico.legajo + ")";
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

        public Usuario materializar(int idUsuario)
        {
            string consulta = "SELECT * FROM " + this.tabla +" WHERE id LIKE " + idUsuario + "";

            Usuario rta = new Usuario();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    // private int idUsuario;
                    // private string clave;
                    // private string usuario;
                    // private Boolean habilitado;
                    // private PersonalCientifico personalCientifico;
                    string clave = Data["Clave"].ToString();
                    Boolean habilitado = (bool)Data["habilitado"];
                    string usuario = Data["usuario"].ToString();
                    PersonalCientifico personalCientifico = this.personalCientificoModel.materializar((int)Data["idPersonalCientifico"]);

                    rta.idDeUsuario = idUsuario;
                    rta.claveDeUsuario = clave;
                    rta.estahabilitado = habilitado;
                    rta.nombreUsuario = usuario;
                    rta.personalcientifico = personalCientifico;

                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }


            return rta;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            string consulta = "SELECT * FROM Usuario ";
            List<Usuario> usuarios = new List<Usuario>();
            try {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while(Data.Read())
                {
                    int idUsuario = (int)Data["id"];
                    string clave = Data["Clave"].ToString();
                    Boolean habilitado = (bool)Data["habilitado"];
                    string usuario = Data["usuario"].ToString();
                    PersonalCientifico personalCientifico = this.personalCientificoModel.materializar((int)Data["idPersonalCientifico"]);

                    Usuario usu = new Usuario
                    {
                        idUsuario = idUsuario,
                        claveDeUsuario = clave,
                        estahabilitado = habilitado,
                        nombreUsuario = usuario,
                        personalcientifico = personalCientifico
                    };
                    usuarios.Add(usu);
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return usuarios;
        }




    }
}
