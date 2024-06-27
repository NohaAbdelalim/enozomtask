using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Models
{
    public class BookCopyStatus
    {
        public int Id { get; set; }
        public string Status { get; set; } // Example values: Good, Damaged, Lost

        public ICollection<BookCopy> BookCopies { get; set; }
    }
}
