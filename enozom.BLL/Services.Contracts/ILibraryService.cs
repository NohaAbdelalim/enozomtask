using enozom.API.Dtos;
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
        //Task BorrowBookAsync(int bookCopyId, int studentId, DateTime expectedReturnDate);
        //Task ReturnBookAsync(int bookCopyId, string status);
        Task<IEnumerable<BookCopyDto>> GetBookCurrentStatus();

    }
}
