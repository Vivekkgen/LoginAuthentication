using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChatBotBackend.Data
{
    public class ChatbotDbContext : IdentityDbContext<User>
    {
        public ChatbotDbContext(DbContextOptions options) : base(options)
        { 
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
                       
        }

    }
}
