using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
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
            string consulta = "SELECT * FROM " + this.Tabla ;
            List<AsignacionResponsableTecnicoRT> rta = new List<AsignacionResponsableTecnicoRT>();

            try
            {
                SqlConnection con = new SqlConnection(this.BDString);
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();

                SqlDataReader Data = cmd.ExecuteReader();

                int indice = 1;
                Dictionary<int,List<RecursosTecnologicos>> rts = new Dictionary<int,List<RecursosTecnologicos>>();
                while (Data.Read()) {
                    /*                    AsignacionResponsableTecnicoRT ART = new AsignacionResponsableTecnicoRT();
                                        List<List<RecursosTecnologicos>> rts = new List<List<RecursosTecnologicos>>();
                                        if ((int)Data["id"] == indice)
                                        {
                                            rts[indice - 1].Add(this.RTM.materializar((int)Data["IdRecursoTecnologico"]));

                                        }
                                        else
                                        {
                                            rta.Add(ART);
                                            if (Data["FechaHoraHasta"] is DBNull)
                                            {

                                                rta[indice - 1].fechaDesde = (DateTime)Data["FechaHoraDesde"];
                                                rta[indice - 1].personalCientifico = this.PCM.materializar((int)Data["IdPersonalCientifico"]);
                                                rta[indice - 1].recursosTecnologicos = rts[indice - 1];


                                            }
                                            else
                                            {
                                                rta[indice - 1].fechaDesde = (DateTime)Data["FechaHoraDesde"];
                                                rta[indice - 1].fechaHasta = (DateTime)Data["FechaHoraHasta"];
                                                rta[indice - 1].personalCientifico = this.PCM.materializar((int)Data["IdPersonalCientifico"]);
                                                rta[indice - 1].recursosTecnologicos = rts[indice - 1];
                                            }
                                            indice++;
                    }
                    */

                    RecursosTecnologicos RT = this.RTM.materializar((int)Data["IdRecursoTecnologico"]);
                    List<RecursosTecnologicos> LRT = new List<RecursosTecnologicos> ();
                    LRT.Add(RT);
                    rts.Add((int)Data["id"],LRT);


                    if ((int)Data["id"] != indice)
                    {
                        AsignacionResponsableTecnicoRT ARTRT = new AsignacionResponsableTecnicoRT();
                        if (Data["FechaHoraHasta"] is DBNull)
                        {

                            ARTRT.fechaDesde = (DateTime)Data["FechaHoraDesde"];
                            ARTRT.personalCientifico = this.PCM.materializar((int)Data["IdPersonalCientifico"]);
                            ARTRT.recursosTecnologicos = rts[(int)Data["id"]];


                        }
                        else
                        {
                            ARTRT.fechaDesde = (DateTime)Data["FechaHoraDesde"];
                            ARTRT.fechaHasta = (DateTime)Data["FechaHoraHasta"];
                            ARTRT.personalCientifico = this.PCM.materializar((int)Data["IdPersonalCientifico"]);
                            ARTRT.recursosTecnologicos = rts[(int)Data["id"] - 1];
                        }
                        rta.Add(ARTRT);
                    }
 
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
