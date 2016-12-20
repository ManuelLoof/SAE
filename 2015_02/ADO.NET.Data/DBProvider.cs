using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Data
{
    /// <summary>
    /// Stellt Methoden zum Datenbankzugrif bereit.
    /// 
    /// Autor: Manuel Loof
    /// Email: manuel.loof@gmx.de
    /// 
    /// Date: 17.12.2015
    /// </summary>
    public class DBProvider
    {

        #region Class variables

        /// <summary>
        /// My connection string.
        /// </summary>
        readonly string CConnectionString = "Server=INSPIRON;" +
                                        "Database=AdventureWorks2014;" +
                                        "Integrated Security=True";

        #endregion

        #region constructor

        public DBProvider()
        { }

        public DBProvider(string connectionString)
        {
            CConnectionString = connectionString; 
        }

        #endregion


        #region public methods

        /// <summary>
        /// Führt unseren SQL Command auf dem Server aus.
        /// </summary>
        /// <param name="command">Die SQL Abfrage welche ausgeführt werden soll.</param>
        /// <param name="sqlDataReader"></param>
        public void DoCommand(string command, Action<SqlDataReader> sqlDataReader)
        {
            // Baut die Verbindung zur Datenbank auf
            using (var connection = OpenConnection())
            {

                connection.Open();

                // Der SQL Command für meine SQL aus.
                using (var sqlCommand = new SqlCommand(command, connection))
                {
                    // Der SQL Data Reader liest sequenziell meine Daten.
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader(reader); 
                    }
                }
                connection.Close();
            }
        }



        #endregion

        #region private methods

        /// <summary>
        /// Oeffnet meine Verbindung zur Datenbank.
        /// </summary>
        /// <returns></returns>
        private SqlConnection OpenConnection()
        {
            return new SqlConnection(CConnectionString);
        }

        #endregion
    }
}
