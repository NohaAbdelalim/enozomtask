using enozom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Domain.Repositories.Contracts
{
    public interface IBookStatusRepository
    {
       Task<BookCopyStatus> GetStatusByNameAsync(string statusName);
      
    }
}
