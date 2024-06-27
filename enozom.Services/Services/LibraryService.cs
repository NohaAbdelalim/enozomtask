
using enozom.API.Dtos;
using enozom.Domain.Models;
using enozom.Domain.Repositories.Contracts;
using enozom.Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enozom.Services.Services
{
    public class LibraryService : ILibraryService
    {
      
        private readonly IBookRepository _bookRepository;
        

        public LibraryService(IBookRepository bookRepository) { 
            _bookRepository = bookRepository;
        }
        
        

       


        public async Task<IEnumerable<BookCopyDto>> GetBookCurrentStatus()
    {
            var bookCopies = await _bookRepository.GetBookCurrentStatus();

            return bookCopies.Select(bc => new BookCopyDto
            {
                CopyId = bc.Id,
                Status = bc.status,
                Title = bc.book.Title
            }).ToList();
        }




    }
}
