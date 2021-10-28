using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Modern.DataAccessLayer.Models
{
    public partial class Modern_DataContext : DbContext
    {
        //public Modern_DataContext()
        //{
        //}

        public Modern_DataContext(DbContextOptions<Modern_DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KeyHasKey> KeyHasKey { get; set; }
        public virtual DbSet<PageContent> PageContent { get; set; }
        public virtual DbSet<PageImages> PageImages { get; set; }
        public virtual DbSet<PageTitle> PageTitle { get; set; }
        public virtual DbSet<UserUserInfo> UserUserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=192.168.1.7,1433;Initial Catalog=Modern_Data;MultipleActiveResultSets=true;User ID=admin;Password=Ram@1170");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KeyHasKey>(entity =>
            {
                entity.HasKey(e => e.KeyId)
                    .HasName("PK__Key.HasK__21F5BE471AF0738A");

                entity.ToTable("Key.HasKey");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyText)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PageContent>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PK__Page.Con__2907A81E70AFD9AC");

                entity.ToTable("Page.Content");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PageImages>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__Page.Ima__7516F70C36E6F33F");

                entity.ToTable("Page.Images");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.PageImages)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ImageFK");
            });

            modelBuilder.Entity<PageTitle>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .HasName("PK__Page.Tit__757589868C1983FE");

                entity.ToTable("Page.Title");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User.Use__1788CC4C26BA65B9");

                entity.ToTable("User.UserInfo");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User.Use__A9D105347A2946B1")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
