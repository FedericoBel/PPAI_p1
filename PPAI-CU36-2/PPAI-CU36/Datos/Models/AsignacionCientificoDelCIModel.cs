using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class AsignacionCientificoDelCIModel
    {

        private string Tabla = "AsignacionCientificoCI";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];

        public TurnoModel turnomodel = new TurnoModel();
        public PersonalCientificoModel PCModel = new PersonalCientificoModel();
        public void desmaterializar(AsignacionCientificoDelCI asignacion)
        {

            string consulta = "INSERT INTO " + this.Tabla + " VALUES (" + asignacion.id + ", "
                                                                         + "@FD, @FH,"     
                                                                         + asignacion.personalCientifico.legajo 
                                                                         + ")";

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@FD", asignacion.fechaDesde);
                cmd.Parameters.AddWithValue("@FH",asignacion.fechaHasta);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();

                if (asignacion.turno.Count != 0)
                {
                    foreach (var item in asignacion.turno)
                    {
                        this.turnomodel.HayAsignacionCIxTurno(item, asignacion.id);
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AsignacionCientificoDelCI materializar(int idAsignacion)
        {
            string consulta = "SELECT FROM " + this.Tabla + " WHERE id LIKE" + idAsignacion;
            AsignacionCientificoDelCI rta = new AsignacionCientificoDelCI();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                if (Data.Read())
                {
                    rta.id = (int) Data["id"];
                    rta.fechaDesde = (DateTime)Data["fechaHoraDesde"];
                    rta.fechaHasta = (DateTime)Data["fechaHoraHasta"];
                    rta.personalCientifico = this.PCModel.materializar((int)Data["idPersonalCientifico"]);
                    rta.turno = this.turnomodel.materializar(rta.id, "IdAsignacionCientifico");
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }
        public List<AsignacionCientificoDelCI> ObtenerAsignacionesCientificoDelCI()
        {
            string consulta = "SELECT FROM " + this.Tabla ;
            List<AsignacionCientificoDelCI> rta = new List<AsignacionCientificoDelCI>();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                while (Data.Read())
                {
                    int Id = (int)Data["id"];
                    DateTime fechadesde = (DateTime)Data["fechaHoraDesde"];
                    DateTime fechahasta = (DateTime)Data["fechaHoraHasta"];
                    PersonalCientifico personalcientifico = this.PCModel.materializar((int)Data["idPersonalCientifico"]);
                    List<Turno> turnos = this.turnomodel.materializar((int)Data["id"], "IdAsignacionCientifico");
                    rta.Add(
                        new AsignacionCientificoDelCI
                        {
                            id = Id,
                            fechaDesde = fechadesde,
                            fechaHasta = fechahasta,
                            personalCientifico = personalcientifico,
                            turno = turnos
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
