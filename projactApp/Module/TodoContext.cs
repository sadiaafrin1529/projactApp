using Microsoft.EntityFrameworkCore;
using ProjectApp.Module;

namespace ProjectApp.Module
{
    public class TodoContext :DbContext
    {
        public TodoContext(DbContextOptions<TodoContext>options):base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<ProjectApp.Module.LoginItem> LoginItem { get; set; } = default!;
    }
    //public static class DbContextHelper
    //{
    //    public static DbContextOptions<TodoContext> GetDbContextOptions()
    //    {
    //        IConfiguration configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();


    //        return new DbContextOptionsBuilder<TodoContext>()
    //              .UseSqlServer(new SqlConnection(configuration.GetConnectionString("local"))).Options;

    //    }
    //}
}
