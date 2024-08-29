using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiShop.Data;
using WebApiShop.DLL.Entites;
using WebApiShop.Dtos.StudentDto;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly WebApiShopContext _context;
        private readonly IMapper _mapper;
        public StudentController(WebApiShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          

            var existStudent = await _context.Students
                .Include(s=>s.Group)
                .FirstOrDefaultAsync(x => x.Id == id);
                

            if (existStudent == null) return NotFound();
            return Ok(_mapper.Map<StudentRetrunDto>(existStudent));
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(StudentCreateDto studentCreateDto)
        {
            if(!await _context.Groups.AnyAsync(g=>g.Id==studentCreateDto.GroupId))
           return Conflict();
            Student student = _mapper.Map<Student>(studentCreateDto);
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync(); 
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
