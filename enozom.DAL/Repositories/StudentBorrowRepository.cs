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
    public class StudentBorrowRepository : IBookBorrowRepository
    {
        private readonly EnozomDbContext _context;

        public StudentBorrowRepository(EnozomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentBorrowBook>> GetBorrowedBooksAsync()
        {
            return await _context.StudentBorrowBook
                .Include(sbb => sbb.BookCopy)
                .ThenInclude(sbb => sbb.Book)
                .ToListAsync();
        }
    }
}
