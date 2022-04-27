using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Company.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coworker> Coworkers { get; set; }
        public virtual DbSet<Notebook> Notebooks { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=workplace;user=root;password=;SSL mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coworker>(entity =>
            {
                entity.ToTable("coworker");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Notebook>(entity =>
            {
                entity.ToTable("notebook");

                entity.HasIndex(e => e.CoworkerId, "coworker_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("brand");

                entity.Property(e => e.CoworkerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("coworker_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("type");

                entity.HasOne(d => d.Coworker)
                    .WithMany(p => p.Notebooks)
                    .HasForeignKey(d => d.CoworkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notebook_ibfk_1");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.HasIndex(e => e.CoworkerId, "coworker_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("brand");

                entity.Property(e => e.CoworkerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("coworker_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("type");

                entity.HasOne(d => d.Coworker)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.CoworkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phone_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
