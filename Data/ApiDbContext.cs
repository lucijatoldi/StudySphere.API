using Microsoft.EntityFrameworkCore;
using StudySphere.API.Models;
using System.Collections.Generic;

namespace StudySphere.API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<StudyRoom> StudyRooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom { Id = 1, Name = "Soba za tihi rad", Capacity = 4, HasWhiteboard = true, HasProjector = false },
                new StudyRoom { Id = 2, Name = "Konferencijska soba A", Capacity = 12, HasWhiteboard = true, HasProjector = true },
                new StudyRoom { Id = 3, Name = "Soba za brainstorming", Capacity = 8, HasWhiteboard = true, HasProjector = false }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Ana Anić", Email = "ana.anic@primjer.com" },
                new User { Id = 2, Name = "Marko Marić", Email = "marko.maric@primjer.com" }
            );
        }
    }
}