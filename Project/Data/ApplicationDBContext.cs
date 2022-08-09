using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }

        public DbSet<Audio> Audios { get; set; }
        public DbSet<Video> Videos { get; set; }


    }
}
