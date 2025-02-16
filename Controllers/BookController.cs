public class BookController
{
    BookRepository repo = new BookRepository();

    public void AddBook()
    {
        try
        {
            Console.Write("輸入書名：");
            string title = Console.ReadLine();
            Console.Write("輸入作者：");
            string author = Console.ReadLine();
            Console.Write("輸入出版社：");
            string publisher = Console.ReadLine();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(publisher))
            {
                Console.WriteLine("書名、作者、出版社不可為空");
                return;
            }

            if (repo.GetBook(title, author, publisher) != null)
            {
                Console.WriteLine("已存在相同書籍");
                return;
            }

            Console.Write("輸入分類：");
            string category = Console.ReadLine();
            Console.Write("輸入數量：");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("數量格式錯誤");
                return;
            }

            Book book = new Book
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                Category = category,
                Quantity = quantity
            };

            if (repo.AddBook(book))
                Console.WriteLine("新增成功");
            else
                Console.WriteLine("新增失敗");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"新增書籍時發生錯誤：{ex.Message}");
        }
    }

    public void EditBook()
    {
        try
        {
            Console.Write("請輸入書名：");
            string title = Console.ReadLine();
            Console.Write("請輸入作者：");
            string author = Console.ReadLine();
            Console.Write("請輸入出版社：");
            string publisher = Console.ReadLine();

            // 根據三個主鍵查找書籍
            Book book = repo.GetBook(title, author, publisher);
            if (book == null)
            {
                Console.WriteLine("找不到書籍");
                return;
            }

            Console.Write($"分類 (按 Enter 保留 [{book.Category}]): ");
            string newCategory = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCategory))
                book.Category = newCategory;

            Console.Write($"數量 (按 Enter 保留 [{book.Quantity}]): ");
            string qtyInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(qtyInput))
            {
                if (int.TryParse(qtyInput, out int newQty))
                    book.Quantity = newQty;
                else
                {
                    Console.WriteLine("數量格式錯誤");
                    return;
                }
            }

            if (repo.UpdateBook(book))
                Console.WriteLine("編輯成功");
            else
                Console.WriteLine("編輯失敗");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"編輯書籍時發生錯誤：{ex.Message}");
        }
    }

    public void DeleteBook()
    {
        try
        {
            Console.Write("請輸入書名：");
            string title = Console.ReadLine();
            Console.Write("請輸入作者：");
            string author = Console.ReadLine();
            Console.Write("請輸入出版社：");
            string publisher = Console.ReadLine();

            if (repo.DeleteBook(title, author, publisher))
                Console.WriteLine("刪除成功");
            else
                Console.WriteLine("刪除失敗");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"刪除書籍時發生錯誤：{ex.Message}");
        }
    }

    public void SearchBook()
    {
        try
        {
            Console.Write("請輸入書名：");
            string title = Console.ReadLine();
            Console.Write("請輸入作者：");
            string author = Console.ReadLine();
            Console.Write("請輸入出版社：");
            string publisher = Console.ReadLine();

            Book book = repo.GetBook(title, author, publisher);
            if (book != null)
            {
                Console.WriteLine("書籍資訊：");
                Console.WriteLine($"書名：{book.Title}");
                Console.WriteLine($"作者：{book.Author}");
                Console.WriteLine($"出版社：{book.Publisher}");
                Console.WriteLine($"分類：{book.Category}");
                Console.WriteLine($"數量：{book.Quantity}");
            }
            else
            {
                Console.WriteLine("找不到書籍");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"查詢書籍時發生錯誤：{ex.Message}");
        }
    }
}
