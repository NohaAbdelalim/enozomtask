using enozom.DAL.Data;
using enozom.Domain.Models;
using enozom.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.DAL.Repositories
{
    public class BookCopyStatusRepository : IBookStatusRepository
    {
        private readonly EnozomDbContext _context;

        public BookCopyStatusRepository(EnozomDbContext context)
        {
            _context = context;
        }
        public async Task<BookCopyStatus> GetStatusByNameAsync(string statusName)
        {
            return await _context.BooksCopyStatus
            .FirstOrDefaultAsync(bcs => bcs.Status == statusName);
        }
        
    }
}
