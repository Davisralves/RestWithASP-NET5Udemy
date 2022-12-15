using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : Controller
    {
        private readonly ILogger<PersonController> _logger;

        private IBooksBusiness _booksBusiness;

        public BooksController(ILogger<PersonController> logger, IBooksBusiness booksBusiness)
        {
            _logger = logger;
            _booksBusiness = booksBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _booksBusiness.FindByID(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Create(books));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Books books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Update(books));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }


    }
}
