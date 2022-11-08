using AWDProjectFinal.Data;
using AWDProjectFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWDProjectFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly AWDProjectFinalAPIContext _context;

        public OwnerController(AWDProjectFinalAPIContext context) {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var owner = await _context.OwnerApartments.FindAsync(id);
            return owner == null ? NotFound() : Ok(owner);
        }

        [HttpGet]
        public async Task<IEnumerable<OwnerApartment>> Get()
        {
            return await _context.OwnerApartments.ToListAsync();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, OwnerApartment owner) {
            if (id != owner.Id) return BadRequest();
            _context.Entry(owner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
