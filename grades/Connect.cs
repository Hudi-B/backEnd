using MySql.Data.MySqlClient;


namespace grades
{
    public class Connect
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
            DbName = "db_grades";
            Username = "root";
            Password = "password";

            ConnectionString = $"Host={Host};Database={DbName};User={Username};Password={Password}";
            connection = new MySqlConnection(ConnectionString);
        }
    }
}
