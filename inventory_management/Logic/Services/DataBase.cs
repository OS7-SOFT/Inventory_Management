using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    public class DataBase
    {
        public static SqlCommand command;
        //Method used to estiblsh the connection with DB
        private static SqlConnection GetconnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Properties.Settings.Default.DbServer;
            builder.InitialCatalog = Properties.Settings.Default.DbName;
            builder.IntegratedSecurity = true;
            return new SqlConnection(builder.ConnectionString);
        }
        //Method used to excute insert,delete and update opreation
        public static bool Excute(string StoredPreName, Action action)
        {
            using (SqlConnection connection = GetconnectionString())
            {
                try
                {
                    command = new SqlCommand(StoredPreName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    action.Invoke();
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        //Method used to Select opreation
        public static DataTable Select(string StoredPreName, Action action)
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();
            using (SqlConnection connection = GetconnectionString())
            {
                try
                {
                    command = new SqlCommand(StoredPreName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    action.Invoke();
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                    adapter.Dispose();
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
            return table;
        }
    }
}
