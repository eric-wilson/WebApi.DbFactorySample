using Microsoft.EntityFrameworkCore;

namespace WebApi.DbFactorySample
{
    /// <summary>
    /// This is just used to set up the example in the startup.cs
    /// This context has zero functionality in this project
    /// </summary>
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base()
        {            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}