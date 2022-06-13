using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos
{
    class DBHelper
    {
        private static DBHelper instancia;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlTransaction dbTransaction;

        private string cadenaConexion;

        public DBHelper()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
            cadenaConexion = @"Data Source=DESKTOP-TEK3ILP\SQLEXPRESS01;Initial Catalog=PPAI;Integrated Security=True";

            conexion.ConnectionString = cadenaConexion;
        }

        public void BeginTransaction()
        {
            if (conexion.State == ConnectionState.Open)
            {
                dbTransaction = conexion.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (dbTransaction != null)
                dbTransaction.Commit();
        }

        public void Rollback()
        {
            if (dbTransaction != null)
                dbTransaction.Rollback();
        }
        public void Open()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
        }

        public void Close()
        {
            if (conexion.State != ConnectionState.Closed)
                conexion.Close();
        }

        public static DBHelper ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new DBHelper();

            return instancia;
        }

        public DataTable Ejecutar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public void Actualizar(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
        }

        public int Transaccion(string consultaSQL)
        {
            int resultado = 0;

            try
            {
                comando.Connection = conexion;
                comando.Transaction = dbTransaction;
                comando.CommandType = CommandType.Text;

                // Instrucción a Ejecutar
                comando.CommandText = consultaSQL;

                resultado = comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }


        public object ConsultaSQLScalar(string strSql)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conexion;
                cmd.Transaction = dbTransaction;
                cmd.CommandType = CommandType.Text;
                // Establece la instrucción a ejecutar
                cmd.CommandText = strSql;
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
    }
}

