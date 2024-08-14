using Microsoft.EntityFrameworkCore;
using ServiciosWebCaso.Models;

namespace ServiciosWebCaso.Context
{
    public class ApiWebContext : DbContext
    {
        public ApiWebContext(DbContextOptions<ApiWebContext>options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

    }
}
