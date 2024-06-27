
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int StatusId { get; set; }
        public BookCopyStatus Status { get; set; }

        public ICollection<StudentBorrowBook> BorrowRecords { get; set; } =  new List<StudentBorrowBook>();
    }
}
