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
    public class BookCopyRepository:IcopyRepository
    {
        private readonly EnozomDbContext _context;

        public BookCopyRepository(EnozomDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
      
        public async Task<BookCopy> GetBookCopyByIdAsync(int copyId)
        {
            return await _context.BooksCopy.FindAsync(copyId);
        }

      

        public async Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync()
        {
            try
            {
                var bookCopies = await _context.BooksCopy
                    .Include(bc => bc.Book)
                    .Include(bc => bc.Status)
                    .ToListAsync();

                Console.WriteLine($"Fetched {bookCopies.Count} book copies from database.");

                return bookCopies;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error fetching book copies: {ex.Message}");
                throw;
            }
        }



        public async Task BorrowBookCopyAsync(StudentBorrowBook borrowRecord)
        {
            _context.StudentBorrowBook.Add(borrowRecord);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnBookCopyAsync(int copyId, DateTime returnDate)
        {
            var borrowRecord = await _context.StudentBorrowBook
                .FirstOrDefaultAsync(sbb => sbb.CopyId == copyId && sbb.ActualReturnDate == null);

            if (borrowRecord != null)
            {
                borrowRecord.ActualReturnDate = returnDate;
            
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
