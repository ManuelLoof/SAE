using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET.Example
{
    public class SqlAdoReader
    {
        #region class members


        private readonly string _connectionString;
        private SqlConnection _sqlConnection; 

        #endregion

        #region constructior

        /// <summary>
        /// Erzeugt ein SqlAdoReader.
        /// </summary>
        /// <param name="connectionString">Einen gültigen Connection.</param>
        public SqlAdoReader(string connectionString)
        {
            _connectionString = connectionString;

        }

        #endregion

        #region public methods

        /// <summary>
        /// Stellt eine Verbindung zur Datenbank her. Um Abfragen zu starten,
        /// muss diese Methode ausgeführt werden.
        /// </summary>
        /// <returns>True, falls wir erfolgreich uns mit der Datenbank
        /// verbinden konnten.</returns>
        public bool Connect()
        {
            try
            {
                _sqlConnection = new SqlConnection(_connectionString);
                _sqlConnection.Open();
                return true;
            }
            catch
            {
                return false; 
            }
        }

        /// <summary>
        /// Liest Daten aus der Datenbank.
        /// </summary>
        /// <param name="sql">Ein gültiges SQL Statement.</param>
        /// <returns>Die geforderten Daten. Null, falls Abfrage fehlgeschlagen ist.</returns>
        public string GetData(string sql)
        {
            var erg = new StringBuilder(); 

            using (var sqlCommand = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        erg.Append($"{reader[i]};");
                    }
                    erg.AppendLine();
                }

            }

            return erg.ToString();

        }


        #endregion



    }
}
