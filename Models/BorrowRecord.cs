public class BorrowRecord
{
    public string BookTitle { get; set; }
    public string BookAuthor { get; set; }
    public string BookPublisher { get; set; }
    public string Account { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}