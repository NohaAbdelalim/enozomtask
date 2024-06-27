using enozom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Repositories.Contracts
{
    public interface IcopyRepository
    {
        Task<BookCopy> GetBookCopyByIdAsync(int copyId);
        Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync();
        Task BorrowBookCopyAsync(StudentBorrowBook borrowRecord);
        Task ReturnBookCopyAsync(int copyId, DateTime returnDate);
        Task SaveChangesAsync();
    }
}
