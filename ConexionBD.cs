using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace web_parcial
{
    public class ConexionBD
    {
        private string contenido = "server=localhost;port=3306;; database=db_parcial; user=root; password=Empres@123";
        public MySqlConnection conectar = new MySqlConnection();
        public MySqlDataAdapter adaptador = new MySqlDataAdapter();

        public MySqlConnection con = new MySqlConnection();

        public void AbrirConexion()
        {
            try
            {
                string sConn;
                sConn = contenido;
                conectar = new MySqlConnection();
                conectar.ConnectionString = sConn;
                conectar.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }

        }
        public void CerarConexion()
        {

            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }

        }

    }
}