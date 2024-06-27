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
    public class BookRepository :  IBookRepository
    {
        private readonly EnozomDbContext _context;

        public BookRepository(EnozomDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _context.Books.Include(B => B.BookCopies).ThenInclude(C => C.Status).FirstOrDefaultAsync(e=>e.Id==bookId);
        }

       

        public async  Task<IEnumerable<Book>> GetAllWithCopiesAndStatus()
        {
            return await _context.Books.Include(B=>B.BookCopies).ThenInclude(C=>C.Status).ToListAsync();
        }
    }
}
