using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos.Models
{
    class AsignacionResponsableTecnicoModel
    {


        private string Tabla = "AsignacionResponsableTecnicoRT";
        public string BDString = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];

        private PersonalCientificoModel PCM = new PersonalCientificoModel();
        private RecursoTecnologicoModel RTM = new RecursoTecnologicoModel();

        public void desmaterializar(AsignacionResponsableTecnicoRT asignacion)
        {

            string consulta; 

            if (asignacion.fechaHasta == null
                || asignacion.fechaHasta == Convert.ToDateTime("1 / 1 / 0001 00:00:00") 
                || asignacion.fechaHasta == Convert.ToDateTime(null))
            {
                consulta = "INSERT INTO " + this.Tabla + " (id,FechaHoraDesde,IdRecursoTecnologico,IdPersonalCientifico) VALUES ";

                for (int i = 0; i < (asignacion.recursosTecnologicos.Count); i++)
                {
                    if (i < asignacion.recursosTecnologicos.Count -1 )
                    {
                       consulta = consulta + "(" + asignacion.id + ",@FD," + asignacion.recursosTecnologicos[i].numeroRT + ", " + asignacion.personalCientifico.legajo + "),";
                    }
                    else
                    {
                        consulta = consulta + "(" + asignacion.id + ",@FD," + asignacion.recursosTecnologicos[i].numeroRT + ", " + asignacion.personalCientifico.legajo + ")";
                    }
                   
                }

            }
            else
            {
                consulta = "INSERT INTO " + this.Tabla + " VALUES ";
                for (int i = 0; i < (asignacion.recursosTecnologicos.Count); i++)
                {
                    if (i < asignacion.recursosTecnologicos.Count-1)
                    {
                        consulta = consulta + "(" + asignacion.id + ", @FD,@FH," + asignacion.recursosTecnologicos[i].numeroRT + ", " + asignacion.personalCientifico.legajo + "),";
                    }
                    else
                    {
                        consulta = consulta + "(" + asignacion.id + ", @FD,@FH," + asignacion.recursosTecnologicos[i].numeroRT + ", " + asignacion.personalCientifico.legajo + ")";
                    }
                   
                }

            }




            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@FD",asignacion.fechaDesde);
                if (asignacion.fechaHasta != null && asignacion.fechaHasta != Convert.ToDateTime("1 / 1 / 0001 00:00:00") && asignacion.fechaHasta != Convert.ToDateTime(null))
                {
                    cmd.Parameters.AddWithValue("@Fh", asignacion.fechaHasta);
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

        public AsignacionResponsableTecnicoRT materializar(int idAsignacionRT)
        {
            string consulta = "SELECT FROM " + this.Tabla + " WHERE id LIKE" + idAsignacionRT;
            AsignacionResponsableTecnicoRT rta = new AsignacionResponsableTecnicoRT();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();
          
                List<RecursosTecnologicos> rts = new List<RecursosTecnologicos>();
                while (Data.Read())
                {
                    rts.Add(this.RTM.materializar((int)Data["IdRecursoTecnologico"]));

                }

                rta.fechaDesde = (DateTime)Data["FechaHoraDesde"];
                rta.fechaHasta = (DateTime)Data["FechaHoraHasta"];
                rta.personalCientifico = this.PCM.materializar((int)Data["IdPersonalCientifico"]);
                rta.recursosTecnologicos = rts;
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rta;
        }


        public List<AsignacionResponsableTecnicoRT> ObtenerAsignacionesResponsableTecnicoRT()
        {
            string consulta = "SELECT art.id, art.FechaHoraDesde, art.FechaHoraHasta, art.IdPersonalCientifico " +
                "FROM AsignacionResponsableTecnicoRT art " +
                "GROUP BY art.id, art.FechaHoraDesde, art.FechaHoraHasta, art.IdPersonalCientifico"  ;
    
            SqlConnection con = new SqlConnection(this.BDString);

            List<AsignacionResponsableTecnicoRT> rta = new List<AsignacionResponsableTecnicoRT>();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr != null && dr.Read())
                {
                    AsignacionResponsableTecnicoRT asignacion = new AsignacionResponsableTecnicoRT();

                    if (dr["FechaHoraHasta"] is DBNull)
                    {
                        asignacion.fechaDesde = (DateTime)(dr["FechaHoraDesde"]);
                    }
                    else
                    {
                        asignacion.fechaDesde = (DateTime)(dr["FechaHoraDesde"]);
                        asignacion.fechaHasta = (DateTime)(dr["FechaHoraHasta"]);
                    }


                    asignacion.recursosTecnologicos = (this.RTM.ObtenerListaRecursosTecnologicosMaterializar((int)dr["id"]));
                    asignacion.personalCientifico= (this.PCM.materializar((int)dr["IdPersonalCientifico"]));


                    rta.Add(asignacion);

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

            return rta;

        }

    }
}
