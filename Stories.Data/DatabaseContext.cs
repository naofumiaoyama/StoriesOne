﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRelationship> FriendRelationships { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }      
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ReactionMark> ReactionMarks { get; set;}
        public DbSet<Story> Stories { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Comment>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<FriendRelationship>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Person>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<PersonalInfo>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Picture>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Post>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<ReactionMark>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Story>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Timeline>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Body>()
                .HasKey(e => e.Id)
                .IsClustered(false);
            modelBuilder.Entity<Character>()
                .HasKey(e => e.Id)
                .IsClustered(false);
        }
    }
}


