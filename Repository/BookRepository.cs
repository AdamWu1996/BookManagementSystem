using MySql.Data.MySqlClient;

public class BookRepository
{
    public bool AddBook(Book book)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO books (title, author, publisher, category, quantity)
                                 VALUES (@title, @author, @publisher, @category, @quantity)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@category", book.Category);
                cmd.Parameters.AddWithValue("@quantity", book.Quantity);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("新增書籍時錯誤：" + ex.Message);
                return false;
            }
        }
    }

    public Book GetBook(string title, string author, string publisher)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"SELECT * FROM books 
                                 WHERE title = @title 
                                 AND author = @author 
                                 AND publisher = @publisher";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Book
                    {
                        Title = reader["title"].ToString(),
                        Author = reader["author"].ToString(),
                        Publisher = reader["publisher"].ToString(),
                        Category = reader["category"].ToString(),
                        Quantity = Convert.ToInt32(reader["quantity"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢書籍時錯誤：" + ex.Message);
                return null;
            }
        }
    }

    public bool UpdateBook(Book book)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"UPDATE books 
                                 SET category = @category, quantity = @quantity
                                 WHERE title = @title 
                                 AND author = @author 
                                 AND publisher = @publisher";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@category", book.Category);
                cmd.Parameters.AddWithValue("@quantity", book.Quantity);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("編輯書籍時錯誤：" + ex.Message);
                return false;
            }
        }
    }

    public bool DeleteBook(string title, string author, string publisher)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM books 
                                 WHERE title = @title 
                                 AND author = @author 
                                 AND publisher = @publisher";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("刪除書籍時錯誤：" + ex.Message);
                return false;
            }
        }
    }

    public bool DecreaseBookQuantity(string title, string author, string publisher)
    {
        using (MySqlConnection conn = DBHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"UPDATE books 
                                 SET quantity = quantity - 1 
                                 WHERE title = @title 
                                 AND author = @author 
                                 AND publisher = @publisher 
                                 AND quantity > 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("更新書籍數量時錯誤：" + ex.Message);
                return false;
            }
        }
    }
}
