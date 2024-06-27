namespace enozom.API.Dtos
{
    public class BorrowBookDto
    {
        public int BookCopyId { get; set; }
        public int StudentId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}
