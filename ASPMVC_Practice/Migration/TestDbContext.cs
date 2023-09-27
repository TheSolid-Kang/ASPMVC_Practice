using ASPMVC_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPMVC_Practice.Migration
{
    public class TestDbContext : DbContext
    {
        public DbSet<BibleModel> _TFBible { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=TwoMites;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
