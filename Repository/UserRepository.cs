using MySql.Data.MySqlClient;

public class UserRepository
{
    public bool Register(User user)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO users (account, password, role)
                                     VALUES (@account, @password, @role)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@account", user.Account);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.IsAdmin);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("註冊使用者時錯誤：" + ex.Message);
                return false;
            }
        }
    }

    public User GetUser(string account)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE account=@account";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@account", account);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User
                    {
                        Account = reader["account"].ToString(),
                        Password = reader["password"].ToString(),
                        IsAdmin = Convert.ToBoolean(reader["role"])
                    };
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢使用者時錯誤：" + ex.Message);
                return null;
            }
        }
    }
}