using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Modern.DataAccessLayer.Models
{
    public partial class ModernDataContext : DbContext
    {
        public ModernDataContext()
        {
        }

        public ModernDataContext(DbContextOptions<ModernDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HomeTitle> HomeTitle { get; set; }
        public virtual DbSet<KeyHasKey> KeyHasKey { get; set; }
        public virtual DbSet<PageContent> PageContent { get; set; }
        public virtual DbSet<PageImages> PageImages { get; set; }
        public virtual DbSet<UserUserInfo> UserUserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Modern Data;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeTitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Home.Title");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TitleId).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KeyHasKey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Key.HasKey");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KeyId).ValueGeneratedOnAdd();

                entity.Property(e => e.KeyText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PageContent>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PK__Page.Con__2907A81E6360E9D2");

                entity.ToTable("Page.Content");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PageImages>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__Page.Ima__7516F70C3A07C695");

                entity.ToTable("Page.Images");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.PageImages)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContentId");
            });

            modelBuilder.Entity<UserUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User.Use__1788CC4C6B558D51");

                entity.ToTable("User.UserInfo");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User.Use__A9D10534A5057571")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
