using Microsoft.EntityFrameworkCore;

namespace DadaAccessLayer.Models
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

        public virtual DbSet<KeyHasKey> KeyHasKey { get; set; }
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

            modelBuilder.Entity<UserUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User.Use__1788CC4CEF11887E");

                entity.ToTable("User.UserInfo");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User.Use__A9D10534F645C1C1")
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
