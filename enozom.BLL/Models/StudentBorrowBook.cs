using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Models
{
    public class StudentBorrowBook
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CopyId { get; set; }
        public BookCopy BookCopy { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public int? ReturnStatusId { get; set; }
        public BookCopyStatus ReturnStatus { get; set; }


    }
}
