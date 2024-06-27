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
       
       
        [HttpGet("status")]
      
        public async Task<IActionResult> GetAvailableCopies()
        {
            var availableCopies = await _libraryService.GetBookCurrentStatus();
            return Ok(availableCopies);
        }
       
       

    }
}
