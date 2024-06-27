using enozom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Services.Contracts
{
    public interface ILibraryService
    {
        Task<IEnumerable<BookCopy>> GetCurrentStatusForAllBooksAsync();
        Task ReturnBookCopyAsync(int CopyId, DateTime ReturnDate, string Statusname);
        Task BorrowBookCopyAsync(int copyId, DateTime expectedReturnDate);

    }
}
