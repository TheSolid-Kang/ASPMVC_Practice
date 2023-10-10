
using ASPMVC_Practice.Models.MMAS.Configurations;
using ASPMVC_Practice.Models.MMAS.dboSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
namespace ASPMVC_Practice.Models.MMAS
{
    public partial class MMASContext : DbContext
    {
        public virtual DbSet<MIGRATION_TMMaster> MIGRATION_TMMasters { get; set; } = null!;
        public virtual DbSet<SampleOrder> SampleOrders { get; set; } = null!;
        public virtual DbSet<_TMMajor> _TMMajors { get; set; } = null!;
        public virtual DbSet<_TMMaster> _TMMasters { get; set; } = null!;
        public virtual DbSet<_TMMinor> _TMMinors { get; set; } = null!;
        public virtual DbSet<_TMUser> _TMUsers { get; set; } = null!;

        public MMASContext()
        {
        }

        public MMASContext(DbContextOptions<MMASContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.225.88.69,1433;Initial Catalog=MMAS;Persist Security Info=True;User ID=sa;Password=yonwoo*230908;Trust Server Certificate=True;Command Timeout=300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.MIGRATION_TMMasterConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.SampleOrderConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations._TMMajorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations._TMMasterConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations._TMMinorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations._TMUserConfiguration());

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingGeneratedFunctions(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

