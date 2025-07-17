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
    }
}