using ASPMVC_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPMVC_Practice.Migration
{
    public class MMDBContext : DbContext
    {
        public DbSet<_TMMMaster> _TMMMaster { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=MaterialManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
