
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
        private readonly IcopyRepository _bookCopyRepository;
        private readonly IBookStatusRepository _bookCopyStatusRepository;
        

        public LibraryService(IcopyRepository bookCopyRepository, IBookStatusRepository bookCopyStatusRepository )
        {

            _bookCopyRepository = bookCopyRepository;
            _bookCopyStatusRepository = bookCopyStatusRepository;
        
        }

        public async Task BorrowBookCopyAsync(int copyId, DateTime expectedReturnDate)
        {
            var bookCopy = await _bookCopyRepository.GetBookCopyByIdAsync(copyId);
            if (bookCopy == null)
            {
                throw new Exception($"Book copy with ID {copyId} not found.");

            }

           

           

           
            var borrowRecord = new StudentBorrowBook
            {
                CopyId = copyId,

                BorrowDate = DateTime.UtcNow,
                ExpectedReturnDate = expectedReturnDate
                
            };

           
            await _bookCopyRepository.BorrowBookCopyAsync(borrowRecord);
        }

        public async Task ReturnBookCopyAsync(int copyId, DateTime returnDate, string returnStatus)
        {
            var bookCopy = await _bookCopyRepository.GetBookCopyByIdAsync(copyId);
            if (bookCopy == null)
            {
                throw new Exception($"Book copy with ID {copyId} not found.");
            }

            switch (returnStatus.ToLower())
            {
                case "good":
                    var goodStatus = await _bookCopyStatusRepository.GetStatusByNameAsync("Good");
                    if (goodStatus == null)
                    {
                        throw new Exception("Good status not found.");
                    }
                    bookCopy.StatusId = goodStatus.Id;
                    break;

                case "damaged":
                    var damagedStatus = await _bookCopyStatusRepository.GetStatusByNameAsync("Damaged");
                    if (damagedStatus == null)
                    {
                        throw new Exception("Damaged status not found.");
                    }
                    bookCopy.StatusId = damagedStatus.Id;
                    break;

                case "lost":
                    var lostStatus = await _bookCopyStatusRepository.GetStatusByNameAsync("Lost");
                    if (lostStatus == null)
                    {
                        throw new Exception("Lost status not found.");
                    }
                    bookCopy.StatusId = lostStatus.Id;
                    break;

                default:
                    throw new Exception($"Invalid return status: {returnStatus}");
            }

            await _bookCopyRepository.SaveChangesAsync();

            // Update the borrowing record with actual return date
            await _bookCopyRepository.ReturnBookCopyAsync(copyId, returnDate);
        }


        public async Task<IEnumerable<BookCopy>> GetCurrentStatusForAllBooksAsync()
        {
            var bookCopies = await _bookCopyRepository.GetAllBookCopiesAsync();
            if (bookCopies == null)
            {
                return Enumerable.Empty<BookCopy>();
            }
            return bookCopies;
        }




    }
}
