using Microsoft.Data.SqlClient;

namespace Trainee360App.Helper
{
    public class ConnectionHelper
    {
        private static SqlConnection? _connection;

        public static SqlConnection GetConnection(string connectionString)
        {
            try
            {
                if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                {
                    _connection = new SqlConnection(connectionString);
                    _connection.Open();
                }
                return _connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at creating connection: " + ex.Message);
                return null;
            }
        }

        public static void CloseConnection()
        {
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
    }
}
