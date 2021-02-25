using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TedAzApp.DataContext.Models;
using TedAzApp.Models;
using TedAzApp.Models.Mentions;

#nullable disable

namespace TedAz.Data.Models
{
    public partial class TedAzContext : IdentityDbContext<User>
    {
        public TedAzContext()
        {
        }

        public TedAzContext(DbContextOptions<TedAzContext> options)
              : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<FileUsers> FileUsers { get; set; }
        public virtual DbSet<FileMentions> FileMentions { get; set; }
        public virtual DbSet<NotesAuthor> NotesAuthors { get; set; }
        public virtual DbSet<NotesChannel> NotesChannels { get; set; }
        public virtual DbSet<NotesRoot> NotesRoots { get; set; }
        public virtual DbSet<TestInfo> TestInfos { get; set; }
        public virtual DbSet<ReportsMention> ReportsMention { get; set; }
        public virtual DbSet<GetReportsInfo> GetReportsInfo { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<AnalyticData> AnalyticData { get; set; }
        public virtual DbSet<LinksData> LinkData { get; set; }
        public virtual DbSet<AuthorViewModel> AuthorViewModels { get; set; }
        public virtual DbSet<MentionReport> MentionReport { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                        optionsBuilder.UseSqlServer("Server=SQL5097.site4now.net;Database=DB_A50752_webhook;User Id = DB_A50752_webhook_admin; Password=webHook@002;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<NotesAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NotesAuthor");

                entity.Property(e => e.AuthorId).ValueGeneratedOnAdd();
            });
   


            modelBuilder.Entity<NotesChannel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NotesChannel");

                entity.Property(e => e.ChannelId).ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<NotesRoot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NotesRoot");

                entity.Property(e => e.RootI).ValueGeneratedOnAdd();

                entity.Property(e => e.RootPublished).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestInfo");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ReportsMention>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<GetReportsInfo>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<AnalyticData>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<LinksData>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<AuthorViewModel>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<MentionReport>(entity =>
            {
                entity.HasNoKey();

            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
