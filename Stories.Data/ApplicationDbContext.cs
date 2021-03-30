using Microsoft.EntityFrameworkCore;
using Stories.Data.Entities;

namespace Stories.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SearchContents> SearchContents { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReactionMark> ReactionMarks { get; set;}
        public DbSet<Post> Posts { get; set; }
        
    }
}
