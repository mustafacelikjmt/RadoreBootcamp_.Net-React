using CodeFirstRadoreOrnek.Data;
using CodeFirstRadoreOrnek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRadoreOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            List<Book> bookList;
            bookList = await _context.Book.ToListAsync();

            return bookList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            Book bookDetail = await _context.Book.FindAsync(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            return bookDetail;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            try
            {
                _context.Book.Add(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Book>> EditBook(Book book)
        {
            try
            {
                var findBook = await _context.Book.FindAsync(book.Id);
                if (findBook == null)
                {
                    return NotFound();
                }
                findBook.BookName = book.BookName;
                findBook.NumberOfPages = book.NumberOfPages;
                findBook.Price = book.Price;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            Book bookDelete = await _context.Book.FindAsync(id);

            if (bookDelete == null)
            {
                return NotFound();
            }

            _context.Remove(bookDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}