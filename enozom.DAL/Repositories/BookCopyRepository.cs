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
    public class BookCopyRepository : IBookRepository
    {
        private readonly EnozomDbContext _context;

        public BookCopyRepository(EnozomDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookCopy>> GetBookCurrentStatus()
        {
            return await _context.BooksCopy.Include(b => b.book).ToListAsync();
        }
    }
}