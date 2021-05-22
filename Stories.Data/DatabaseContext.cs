using Microsoft.EntityFrameworkCore;
using Stories.Data.Entities;

namespace Stories.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\MSSQLSERVER01; database = Stories; integrated security = true");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }      
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ReactionMark> ReactionMarks { get; set;}
        public DbSet<Story> Stories { get; set; }
        public DbSet<Timeline> Timelines { get; set; }       
    }
}
