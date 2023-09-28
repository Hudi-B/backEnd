using MySql.Data.MySqlClient;

namespace users
{
    public class Connect //for connecting new data to database
    {
        public MySqlConnection connection;
        private string Host;
        private string DbName;
        private string Username;
        private string Password;
        private string ConnectionString;

        public Connect()
        {
            Host = "localhost";
            DbName = "db_user";
            Username = "root";
            Password = "";

            ConnectionString = $"Host={Host};Database={DbName};User={Username};Password={Password};SslMode=none"; //database details
            connection = new MySqlConnection(ConnectionString);
        }
    }
}
