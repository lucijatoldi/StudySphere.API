using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudySphere.API.Data;
using StudySphere.API.Models;

namespace StudySphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyRoomsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public StudyRoomsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/StudyRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyRoom>>> GetStudyRooms()
        {
            var rooms = await _context.StudyRooms.ToListAsync();
            return Ok(rooms);
        }
    }
}