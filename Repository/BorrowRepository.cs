using MySql.Data.MySqlClient;

public class BorrowRepository
{
    public bool BorrowBook(BorrowRecord record)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO borrow_records 
                                 (book_title, book_author, book_publisher, account, borrow_date)
                                 VALUES (@title, @author, @publisher,
                                         @account, @borrow_date)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", record.BookTitle);
                cmd.Parameters.AddWithValue("@author", record.BookAuthor);
                cmd.Parameters.AddWithValue("@publisher", record.BookPublisher);
                cmd.Parameters.AddWithValue("@account", record.Account);
                cmd.Parameters.AddWithValue("@borrow_date", record.BorrowDate);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("借閱書籍時錯誤：" + ex.Message);
                return false;
            }
        }
    }
}
