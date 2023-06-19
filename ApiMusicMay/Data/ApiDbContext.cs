using ApiMusicMay.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMusicMay.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }
        public DbSet<SongClass> songclass { get; set; }
    }
}
