using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Module
{
    public class LoginContext:DbContext
    {
        public LoginContext (DbContextOptions<LoginContext>options):base(options)
        {

        }
        public DbSet<LoginItem> loginItems { get; set; } = null!;
    }
}
