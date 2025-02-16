using System.Data;
using MySql.Data.MySqlClient;
public class UserController
{
    UserRepository repo = new UserRepository();

    public void Register()
    {
        try
        {
            Console.Write("請輸入帳號：");
            string account = Console.ReadLine();

            // 檢查帳號是否已存在
            User existingUser = repo.GetUser(account);
            if (existingUser != null)
            {
                Console.WriteLine("該帳號已被使用，請選擇其他帳號。");
                return;
            }

            Console.Write("請輸入密碼：");
            string password = Console.ReadLine();
            Console.Write("是否為管理員（y/n）：");
            bool isAdmin = Console.ReadLine().ToLower() == "y";

            User user = new User { Account = account, Password = password, IsAdmin = isAdmin };
            if (repo.Register(user))
                Console.WriteLine("註冊成功");
            else
                Console.WriteLine("註冊失敗");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"註冊時發生錯誤：{ex.Message}");
        }
    }

    public User Login()
    {
        try
        {
            Console.Write("請輸入帳號：");
            string account = Console.ReadLine();
            Console.Write("請輸入密碼：");
            string password = Console.ReadLine();

            User user = repo.GetUser(account);
            if (user != null && user.Password == password)
            {
                Console.WriteLine($"登入成功，歡迎：{user.Account}！");
                return user;
            }
            else
            {
                Console.WriteLine("登入失敗");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"登入時發生錯誤：{ex.Message}");
            return null;
        }
    }
}