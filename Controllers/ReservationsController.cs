using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudySphere.API.Data;
using StudySphere.API.Models;
using StudySphere.API.DTOs;


namespace StudySphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ReservationsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations
                                 .Include(r => r.StudyRoom)
                                 .Include(r => r.User)
                                 .ToListAsync();
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(CreateReservationDto reservationDto)
        {
            // --- KORAK 1: PROVJERA PREKLAPANJA ---
            // "Postoji li ijedna (Any) rezervacija u bazi za ovu sobu (r.StudyRoomId == reservation.StudyRoomId)
            //  koja se preklapa s vremenom nove rezervacije?"
            //
            // Logika preklapanja:
            // Dva termina (A i B) se preklapaju ako:
            // (Kraj termina A je NAKON početka termina B) I (Početak termina A je PRIJE kraja termina B)

            var isOverlapping = await _context.Reservations
                .AnyAsync(r =>
                    r.StudyRoomId == reservationDto.StudyRoomId &&
                    r.EndTime > reservationDto.StartTime &&
                    r.StartTime < reservationDto.EndTime);
            
            if (isOverlapping)
            {
                return Conflict("The requested time slot is already booked for this room.");
            }

            // --- KORAK 2: AKO NEMA PREKLAPANJA, SPREMI REZERVACIJU ---
            var newReservation = new Reservation
            {
                StartTime = reservationDto.StartTime,
                EndTime = reservationDto.EndTime,
                StudyRoomId = reservationDto.StudyRoomId,
                UserId = reservationDto.UserId
            };

            _context.Reservations.Add(newReservation);
            await _context.SaveChangesAsync();

            return Ok(newReservation);
        }
    }
}
