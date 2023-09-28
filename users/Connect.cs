using MySql.Data.MySqlClient;
using System.Reflection;

namespace users
{
    public class Connect //for connecting new data to database
    {
        public MySqlConnection connection;
        private string Host;
        private string Port;
        private string DbName;
        private string Username;
        private string Password;
        private string ConnectionString;

        public Connect()
        {
            Host = "192.168.50.54";
            Port = "3017";
            DbName = "db_user";
            Username = "root";
            Password = "password";

            ConnectionString = $"Host={Host};Port={Port};Database={DbName};User={Username};Password={Password};SSLMode=none"; //database details
            connection = new MySqlConnection(ConnectionString);
        }
    }
}
