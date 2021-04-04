﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210326082950_AddPostTableToDb")]
    partial class AddPostTableToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stories.Data.Entities.Address", b =>
                {
                    b.Property<string>("Person_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Others")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Person_Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Stories.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentUserLogin_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CommentUserLogin_Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Stories.Data.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FamilyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Stories.Data.Entities.PersonalInfo", b =>
                {
                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("MobileNumber");

                    b.ToTable("PersonalInfos");

                    b.HasCheckConstraint("CK_PersonalInfos_Sex_Enum_Constraint", "[Sex] IN(1, 2)");
                });

            modelBuilder.Entity("Stories.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Stories.Data.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("ReactionMarksId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommentsId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ReactionMarksId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Stories.Data.Entities.ReactionMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ReactionMarks");
                });

            modelBuilder.Entity("Stories.Data.Entities.SearchContents", b =>
                {
                    b.Property<string>("SearchWord")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SearchWord");

                    b.ToTable("SearchContents");
                });

            modelBuilder.Entity("Stories.Data.Entities.User", b =>
                {
                    b.Property<string>("Login_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Stories.Data.Entities.Comment", b =>
                {
                    b.HasOne("Stories.Data.Entities.User", "CommentUser")
                        .WithMany()
                        .HasForeignKey("CommentUserLogin_Id");
                });

            modelBuilder.Entity("Stories.Data.Entities.Post", b =>
                {
                    b.HasOne("Stories.Data.Entities.Comment", "Comments")
                        .WithMany()
                        .HasForeignKey("CommentsId");

                    b.HasOne("Stories.Data.Entities.Photo", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Stories.Data.Entities.ReactionMark", "ReactionMarks")
                        .WithMany()
                        .HasForeignKey("ReactionMarksId");
                });
#pragma warning restore 612, 618
        }
    }
}