using enozom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Repositories.Contracts
{
    public interface IBookRepository
    {
      Task<IEnumerable<Book>> GetAllWithCopiesAndStatus();
        Task<Book> GetBookByIdAsync(int bookId);
    }
}
