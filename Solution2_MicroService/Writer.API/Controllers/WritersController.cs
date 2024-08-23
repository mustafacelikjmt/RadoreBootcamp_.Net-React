using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Writer.API.Models;
using Writer.API.Repositories.Data;

namespace Writer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterRepository _writerRepository;
        private readonly AppDbContext _context;

        public WritersController(IWriterRepository writerRepository, AppDbContext context)
        {
            _writerRepository = writerRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWritersAsync()
        {
            return Ok(await _writerRepository.GetAll().ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWriterDetailAsync(int id)
        {
            //if (_writerRepository.Get(id) == null) return NotFound();
            var detailWriter = await _writerRepository.GetByIdAsync(id);
            if (detailWriter is null) return NotFound();
            return Ok(detailWriter);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] WriterModel writer)
        {
            //var result = _writerRepository.AddAsync(writer);
            //return Created($"/get/{result.Id}", result);

            await _writerRepository.AddAsync(writer);
            return Ok(writer);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync(WriterModel entity)
        {
            await _writerRepository.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var removeWriter = await _writerRepository.GetByIdAsync(id);
            if (removeWriter == null) return NotFound();
            await _writerRepository.DeleteAsync(removeWriter);
            return NoContent();
        }
    }
}