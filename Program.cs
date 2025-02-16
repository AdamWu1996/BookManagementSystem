class Program
{
    // 當前登入的使用者
    static User? currentUser = null;
    static BookController bookController = new BookController();
    static UserController userController = new UserController();
    static BorrowController borrowController = new BorrowController();

    static void Main(string[] args)
    {
        while (true)
        {
            if (currentUser == null)
            {
                Console.WriteLine("\n=== 歡迎進入圖書管理系統 ===");
                Console.WriteLine("1. 註冊");
                Console.WriteLine("2. 登入");
                Console.WriteLine("3. 離開");
                Console.Write("請選擇：");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        userController.Register();
                        break;
                    case "2":
                        currentUser = userController.Login();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("輸入錯誤，請重新選擇");
                        break;
                }
            }
            else
            {
                // 根據使用者權限顯示不同選單
                if (currentUser.IsAdmin)
                {
                    Console.WriteLine("\n=== 管理員功能 ===");
                    Console.WriteLine("1. 新增書籍");
                    Console.WriteLine("2. 編輯書籍");
                    Console.WriteLine("3. 刪除書籍");
                    Console.WriteLine("4. 查詢書籍");
                    Console.WriteLine("5. 借閱書籍");
                    Console.WriteLine("6. 登出");
                    Console.Write("請選擇：");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            bookController.AddBook();
                            break;
                        case "2":
                            bookController.EditBook();
                            break;
                        case "3":
                            bookController.DeleteBook();
                            break;
                        case "4":
                            bookController.SearchBook();
                            break;
                        case "5":
                            borrowController.BorrowBook(currentUser);
                            break;
                        case "6":
                            currentUser = null;
                            break;
                        default:
                            Console.WriteLine("輸入錯誤，請重新選擇");
                            break;
                    }
                }
                else // 一般使用者
                {
                    Console.WriteLine("\n=== 使用者功能 ===");
                    Console.WriteLine("1. 查詢書籍");
                    Console.WriteLine("2. 借閱書籍");
                    Console.WriteLine("3. 登出");
                    Console.Write("請選擇：");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            bookController.SearchBook();
                            break;
                        case "2":
                            borrowController.BorrowBook(currentUser);
                            break;
                        case "3":
                            currentUser = null;
                            break;
                        default:
                            Console.WriteLine("輸入錯誤，請重新選擇");
                            break;
                    }
                }
            }
        }
    }
}