using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApiShop.Data;
using WebApiShop.DLL.Entites;
using WebApiShop.Dtos.GroupDtos;
using WebApiShop.Mappers;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly WebApiShopContext _context;

        public GroupController(WebApiShopContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var groups = await _context.Groups
                .Include(g=>g.Students)
                .ToListAsync();
            return Ok(groups);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var existGroup = await _context.Groups
                .Include(g => g.Students)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (existGroup == null) return NotFound();
                return Ok(existGroup);
        }

        [HttpPost("")]
        public async Task<IActionResult>Create(GroupCreateDto groupCreateDto)
        {
            if(await _context.Groups.AnyAsync(g=>g.Name.ToLower()== groupCreateDto.Name.ToLower()))
            return BadRequest("Dublicate Group Name....");
          
            await _context.Groups.AddAsync(GroupMapper.GroupCreateDtoToGroup(groupCreateDto));
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, Group group)
        {
            var existGroup =await _context.Groups.FirstOrDefaultAsync(g=> g.Id == id);
            if (existGroup == null) return NotFound();

            if (existGroup.Name!=group.Name&&await _context.Groups.AnyAsync(g => g.Name.ToLower() == group.Name.ToLower() && g.Id != id))
                return BadRequest("Dublicate Group Name.........");


            existGroup.Name= group.Name;
            existGroup.Limit = group.Limit;
           await _context.SaveChangesAsync();
            return Ok(existGroup);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Group group)
        {
            var existGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if (existGroup == null) return NotFound();
           _context.Groups.Remove(existGroup);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
