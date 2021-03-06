﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TedAz.Data.Models;

namespace TedAzApp.Migrations
{
    [DbContext(typeof(TedAzContext))]
    [Migration("20210202090408_File_Upload")]
    partial class File_Upload
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TedAz.Data.Models.NotesAuthor", b =>
                {
                    b.Property<string>("AuthorAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorNickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorSubscribers")
                        .HasColumnType("int");

                    b.Property<string>("AuthorUrl")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("NotesAuthor");
                });

            modelBuilder.Entity("TedAz.Data.Models.NotesChannel", b =>
                {
                    b.Property<string>("ChannelAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ChannelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChannelNickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChannelSubscribers")
                        .HasColumnType("int");

                    b.Property<string>("ChannelUrl")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("NotesChannel");
                });

            modelBuilder.Entity("TedAz.Data.Models.NotesRoot", b =>
                {
                    b.Property<int?>("RootAuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("RootChannelId")
                        .HasColumnType("int");

                    b.Property<string>("RootCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootComments")
                        .HasColumnType("int");

                    b.Property<string>("RootCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootDiscussionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootEngagement")
                        .HasColumnType("int");

                    b.Property<int>("RootI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RootLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootLikes")
                        .HasColumnType("int");

                    b.Property<long?>("RootMentionId")
                        .HasColumnType("bigint");

                    b.Property<string>("RootParentPostId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootPostId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootPostType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RootPublished")
                        .HasColumnType("datetime");

                    b.Property<string>("RootRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootSentiment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootSourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RootSpam")
                        .HasColumnType("bit");

                    b.Property<string>("RootText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootThemeId")
                        .HasColumnType("int");

                    b.Property<string>("RootThemeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootTopicId")
                        .HasColumnType("int");

                    b.Property<string>("RootTopicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootUrl")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("NotesRoot");
                });

            modelBuilder.Entity("TedAz.Data.Models.TestInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TestInfo");
                });

            modelBuilder.Entity("TedAzApp.DataContext.Models.GetReportsInfo", b =>
                {
                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFullName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetReportsInfo");
                });

            modelBuilder.Entity("TedAzApp.DataContext.Models.ReportsMention", b =>
                {
                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorSubscribers")
                        .HasColumnType("int");

                    b.Property<string>("AuthorUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChannelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChannelSubscribers")
                        .HasColumnType("int");

                    b.Property<string>("ChannelUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootComments")
                        .HasColumnType("int");

                    b.Property<string>("RootCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootLikes")
                        .HasColumnType("int");

                    b.Property<string>("RootPostType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootPublishedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootPublishedTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootReposts")
                        .HasColumnType("int");

                    b.Property<string>("RootResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootSentiment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootSourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RootUrl")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ReportsMention");
                });

            modelBuilder.Entity("TedAzApp.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("TedAzApp.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TedAzApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TedAzApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TedAzApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TedAzApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
