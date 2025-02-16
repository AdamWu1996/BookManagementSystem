public class BorrowController
{
    BorrowRepository borrowRepo = new BorrowRepository();
    BookRepository bookRepo = new BookRepository();

    public void BorrowBook(User user)
    {
        try
        {
            Console.Write("請輸入要借閱的書名：");
            string title = Console.ReadLine();
            Console.Write("請輸入作者：");
            string author = Console.ReadLine();
            Console.Write("請輸入出版社：");
            string publisher = Console.ReadLine();

            Book book = bookRepo.GetBook(title, author, publisher);
            if (book == null)
            {
                Console.WriteLine("找不到書籍");
                return;
            }
            if (book.Quantity <= 0)
            {
                Console.WriteLine("書籍數量為 0，無法借閱");
                return;
            }

            BorrowRecord record = new BorrowRecord
            {
                BookTitle = book.Title,
                BookAuthor = book.Author,
                BookPublisher = book.Publisher,
                Account = user.Account,
                BorrowDate = DateTime.Now,
                ReturnDate = null
            };

            if (borrowRepo.BorrowBook(record))
            {
                if (bookRepo.DecreaseBookQuantity(book.Title, book.Author, book.Publisher))
                    Console.WriteLine("借閱成功");
                else
                    Console.WriteLine("借閱記錄新增成功，但更新書籍數量失敗");
            }
            else
            {
                Console.WriteLine("借閱失敗");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"借閱書籍時發生錯誤：{ex.Message}");
        }
    }
}
