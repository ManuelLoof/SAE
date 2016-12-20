using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Example
{
    /// <summary>
    /// Datenbankverbindungsklasse.
    /// </summary>
    public class DBProvider
    {
        /// <summary>
        /// My connection string.
        /// </summary>
        const string CConnectionString = "Server=INSPIRON;" +
                                        "Database=SAE_RolePlayingGame;" +
                                        "Integrated Security=True";


        /// <summary>
        /// Simple example.
        /// </summary>
        public void DBSimpleSample()
        {
            using (var sqlCon = new SqlConnection(CConnectionString))
            {
                sqlCon.Open();

                using (SqlCommand sqlCommand = new SqlCommand("Select * from players;", sqlCon))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write("{0}|", (reader.GetValue(i).ToString().PadLeft(10)));
                            }
                            Console.WriteLine();
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Opens the db connection.
        /// </summary>
        /// <returns>An opened SqlConnection.</returns>
        public SqlConnection OpenDB()
        {
            SqlConnection sqlCon = new SqlConnection(CConnectionString);
            sqlCon.Open();
            return sqlCon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="sqlDataReader"></param>
        public int DoCommandNonQuery(string command)
        {
            using (SqlConnection sqlCon = OpenDB())
            {
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlCon))
                {
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="sqlDataReader"></param>
        public void DoCommand(string command, Action<SqlDataReader> sqlDataReader, List<SqlParameter> parameters = null)
        {
            using (SqlConnection sqlCon = OpenDB())
            {
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlCon))
                {

                    if (parameters != null)
                        parameters.ForEach(p => sqlCommand.Parameters.Add(p)); 

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader(reader);
                    }
                }
            }
        }

        public void DoCommand(string command, Action<Object> fieldValue)
        {
            DoCommand(command, reader =>
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.
                    }
                }
            });

        }

        public void DataSet()
        {
            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            // A table mapping names the DataTable.
            adapter.TableMappings.Add("Table", "players");

            // Open the connection.
            var connection = OpenDB(); 

            // Create a SqlCommand to retrieve Suppliers data.
            SqlCommand command = new SqlCommand(
                "Select * from players;",
                connection);
            command.CommandType = CommandType.Text;

            // Set the SqlDataAdapter's SelectCommand.
            adapter.SelectCommand = command;

            // Fill the DataSet.
            DataSet dataset = new DataSet("players");
            adapter.Fill(dataset);


            DataTable table = dataset.Tables["players"];

            // For each row, print the values of each column.
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("{0}|", (row[column].ToString().PadRight(15)));
                }
                Console.WriteLine(); 
            }

        }
    }
}
