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
        //public static string DbConnectionString = "server=localhost\\MSSQLSERVER01; database = Stories; integrated security = true";
        // Mac Docker
        public static string DbConnectionString = "Data Source=localhost;database=Stories; User ID = sa; Password=reallyStrongPwd123;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionString);
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<FriendRelationshipEntity> FriendRelationships { get; set; }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<PersonalInfoEntity> PersonalInfos { get; set; }      
        public DbSet<PictureEntity> Pictures { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReactionMarkEntity> ReactionMarks { get; set;}
        public DbSet<StoryEntity> Stories { get; set; }
        public DbSet<TimelineEntity> Timelines { get; set; }
        public DbSet<BodyEntity> Bodies { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}


