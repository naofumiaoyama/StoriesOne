using Microsoft.EntityFrameworkCore;
using Stories.Data.Entities;

namespace Stories.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Win SQLServer Developer Edition
            optionsBuilder.UseSqlServer("server=localhost\\MSSQLSERVER01; database = Stories; integrated security = true");
            // Mac Docker
            /// optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;database=Stories; User ID=sa;Password=reallyStrongPwd123;");

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }      
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ReactionMark> ReactionMarks { get; set;}
        public DbSet<Story> Stories { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
