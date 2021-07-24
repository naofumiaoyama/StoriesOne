using Microsoft.EntityFrameworkCore;
using Stories.Data.Entities;

namespace Stories.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {
        }

        //Win SQLServer Developer Edition
        public static string DbConnectionString = "server=localhost\\MSSQLSERVER01; database = Stories; integrated security = true";
        // Mac Docker
        //public static string DbConnectionString = "Data Source=localhost;database=Stories; User ID = sa; Password=reallyStrongPwd123;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionString);
        }

        public DbSet<AddressT> Addresses { get; set; }
        public DbSet<CommentT> Comments { get; set; }
        public DbSet<FriendRelationshipT> FriendRelationships { get; set; }
        public DbSet<PersonT> People { get; set; }
        public DbSet<PersonalInfoT> PersonalInfos { get; set; }      
        public DbSet<PictureT> Pictures { get; set; }
        public DbSet<PostT> Posts { get; set; }
        public DbSet<ReactionMarkT> ReactionMarks { get; set;}
        public DbSet<StoryT> Stories { get; set; }
        public DbSet<TimelineT> Timelines { get; set; }
        public DbSet<BodyT> Bodies { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}


