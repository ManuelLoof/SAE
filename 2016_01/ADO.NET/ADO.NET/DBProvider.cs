using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    /// <summary>
    /// Stellt über ADO.Net eine Verbindung zu einer Datenbank her und liefert Abfrage und manipulations möglichkeiten.
    /// </summary>
    public class DBProvider : IDisposable
    {

        private SqlConnection _connection; 
      
        /// <summary>
        /// Stellt Verbindung zur Datenbank her.
        /// </summary>
        /// <param name="_connectionString">Einen gültigen SQL Connection String.</param>
        /// <returns>True, falls Verbindung erfolgreich.</returns>
        public bool Connect(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open(); 

            return true;  
            

        }

        /// <summary>
        /// Beim schliessen zum aufräumen bitte aufrufen.
        /// </summary>
        public void Dispose()
        {
            _connection.Dispose(); 
        }

        /// <summary>
        /// Führt einen SQL Befehl aus.
        /// </summary>
        /// <param name="sql">Der auszuführende SQL Befehl.</param>
        /// <returns>-1 im Fehlerfall.</returns>
        public int DoCommand(string sql)
        {
            if (_connection == null)
                return -1;

            var sqlCommand = new SqlCommand(sql, _connection);
            return sqlCommand.ExecuteNonQuery(); 

        }

        /// <summary>
        /// Führt ein Select Statement aus und liefert uns einen SqlDataReader zurück.
        /// </summary>
        /// <param name="sql">Ein gültiges SQL Select Statement.</param>
        /// <returns>Null, falls Fehler.</returns>
        public SqlDataReader DoCommandSqlDataReader(string sql, List<SqlParameter> parameters = null)
        {
            if (_connection == null)
                return null;
            
            var sqlCommand = new SqlCommand(sql, _connection);

            if (parameters != null)
                parameters.ForEach(p => sqlCommand.Parameters.Add(p));

            return sqlCommand.ExecuteReader();

        }
    }
}
