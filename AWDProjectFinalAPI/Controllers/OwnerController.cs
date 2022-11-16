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
        [HttpGet]
        public async Task<IEnumerable<OwnerApartment>> Get()//เอาข้อมูลออกมาโชว์
        {
            return await _context.OwnerApartments.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)//ค้นหาตาม ID นั้น
        {
            var owner = await _context.OwnerApartments.FindAsync(id);
            return owner == null ? NotFound() : Ok(owner);
        }
        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(OwnerApartment owner)
        {
            await _context.OwnerApartments.AddAsync(owner);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = owner.Id},owner);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
           OwnerApartment? owner = await _context.OwnerApartments.FindAsync(id);
            if (owner == null) return NotFound();
            _context.OwnerApartments.Remove(owner);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
