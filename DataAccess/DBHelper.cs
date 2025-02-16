using MySql.Data.MySqlClient;

public static class DBHelper
{
    public static string ConnectionString = "Server=localhost;Database=library;Uid=root;Pwd=password;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }
}