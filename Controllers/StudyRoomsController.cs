using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudySphere.API.Data;
using StudySphere.API.Models;
using StudySphere.API.DTOs;

namespace StudySphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyRoomsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public StudyRoomsController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/StudyRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyRoomDto>>> GetStudyRooms()
        {
            var roomsFromDb = await _context.StudyRooms.ToListAsync();
            var roomsDto = _mapper.Map<IEnumerable<StudyRoomDto>>(roomsFromDb);
            return Ok(roomsDto);
        }

        // GET: api/StudyRooms/5
        // Dohvaća jednu specifičnu sobu po ID-u
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyRoomDto>> GetStudyRoom(int id)
        {
            var studyRoomFromDb = await _context.StudyRooms.FindAsync(id);

            if (studyRoomFromDb == null)
            {
                return NotFound(); 
            }

            var studyRoomDto = _mapper.Map<StudyRoomDto>(studyRoomFromDb);

            return Ok(studyRoomDto);
        }

        // POST: api/StudyRooms
        // Kreira novu sobu za učenje
        [HttpPost]
        public async Task<ActionResult<StudyRoom>> PostStudyRoom(StudyRoom studyRoom)
        {
            _context.StudyRooms.Add(studyRoom);
            await _context.SaveChangesAsync();

            // Vraća 201 Created i link na novokreiranu sobu
            return CreatedAtAction(nameof(GetStudyRoom), new { id = studyRoom.Id }, studyRoom);
        }

        // PUT: api/StudyRooms/5
        // Ažurira postojeću sobu   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyRoom(int id, StudyRoom studyRoom)
        {
            if (id != studyRoom.Id)
            {
                return BadRequest(); 
            }

            _context.Entry(studyRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyRoomExists(id))
                {
                    return NotFound(); // Ako soba ne postoji, vraća 404 Not Found
                }
                else
                {
                    throw; // Inače baca iznimku
                }
            }
            return NoContent(); // Vraća 204 No Content ako je uspješno ažurirano
        }

        // DELETE: api/StudyRooms/5
        // Briše sobu po ID-u
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyRoom(int id)
        {
            var studyRoom = await _context.StudyRooms.FindAsync(id);
            if (studyRoom == null)
            {
                return NotFound(); // Ako soba ne postoji, vraća 404 Not Found
            }
            _context.StudyRooms.Remove(studyRoom);
            await _context.SaveChangesAsync();
            return NoContent(); // Vraća 204 No Content ako je uspješno obrisano
        }

        // Pomoćna privatna metoda da provjerimo postoji li soba
        private bool StudyRoomExists(int id)
        {
            return _context.StudyRooms.Any(e => e.Id == id);
        }
    }
}