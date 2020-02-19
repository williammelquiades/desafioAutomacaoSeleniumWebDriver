using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Helpers
{
    public class DataBaseHelpers
    {
        private static MySqlConnection GetDBConnection()
        {
            string connectionString = "Data Source=" + ConfigurationManager.AppSettings["URL_ACESSO_BD"].ToString() + 
                                      "," + ConfigurationManager.AppSettings["PORTA_ACESSO_BD"].ToString() + ";" +
                                      "Initial Catalog=" + ConfigurationManager.AppSettings["NOME_BANCO_DE_DADOS"].ToString() + ";" +
                                      "User ID=" + ConfigurationManager.AppSettings["USUARIO_BD"].ToString() + "; " +
                                      "Password=" + ConfigurationManager.AppSettings["PASSAWORD_BD"].ToString() + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

        public static void ExecuteQuery(string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["TIMEOUT_CONNECTION_BD"].ToString());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public static List<string> RetornaDadosQuery(string query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (MySqlCommand cmd = new MySqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["TIMEOUT_CONNECTION_BD"].ToString());
                cmd.Connection.Open();

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);

                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }
    }
}
