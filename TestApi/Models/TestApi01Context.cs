using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestApi.Models
{
    public partial class TestApi01Context : DbContext
    {

        public TestApi01Context()
        {
        }

        public TestApi01Context(DbContextOptions<TestApi01Context> options)
            : base(options)
        {
            
        }

        public virtual DbSet<PersonsModel> Persons { get; set; }

        // Unable to generate entity type for table 'dbo.Persons'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:sitthinon01.database.windows.net,1433;Initial Catalog=TestApi01;Persist Security Info=False;User ID=TestApi01;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonsModel>(entity =>
            {
                entity.Property(e => e.PersonID).IsRequired();
            });
        }
    }
}
