using AutoMapper;
using enozom.API.Dtos;
using enozom.Domain.Models;
using enozom.Domain.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace enozom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryService libraryService,IMapper mapper )
        {
            _libraryService = libraryService;
            _mapper = mapper;
        }
        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBookCopy([FromBody] BorrowBookDto borrowBookDto)
        {
            await _libraryService.BorrowBookCopyAsync(borrowBookDto.CopyId, borrowBookDto.ExpectedReturnDate);
            return Ok();
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBookCopy([FromBody] returnBookDto returnBookDto)
        {
            await _libraryService.ReturnBookCopyAsync(returnBookDto.CopyId, returnBookDto.ReturnDate,returnBookDto.Statusname);
            return Ok();
        }
        [HttpGet("status")]
        public async Task<IActionResult> GetCurrentStatusForAllBooks()
        {
            var bookCopies = await _libraryService.GetCurrentStatusForAllBooksAsync();
            if (bookCopies == null)
            {
                return BadRequest("notfound");
            }
            var toReturn = _mapper.Map<Dto>(bookCopies);
            return Ok(toReturn);
        }


    }
}
