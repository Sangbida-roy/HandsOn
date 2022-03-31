using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MenuAPI2022.DB
{
    public partial class TrainingDbContext : DbContext
    {
        public TrainingDbContext()
        {
        }

        public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dishes> Dishes { get; set; } = null!;
        public virtual DbSet<FoodChoice> FoodChoice { get; set; } = null!;
        public virtual DbSet<MenuCard> MenuCard { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-AJSES40D;Database=Training;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dishes>(entity =>
            {
                entity.HasKey(e => e.DishId)
                    .HasName("PK__Dishes__18834F7040812768");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.Property(e => e.ChoiceId).HasColumnName("ChoiceID");

                entity.Property(e => e.Dish).IsUnicode(false);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Choice)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.ChoiceId)
                    .HasConstraintName("FK__Dishes__ChoiceID__4E88ABD4");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK__Dishes__MenuID__4D94879B");
            });

            modelBuilder.Entity<FoodChoice>(entity =>
            {
                entity.HasKey(e => e.ChoiceId)
                    .HasName("PK__FoodChoi__76F51686750214EA");

                entity.Property(e => e.ChoiceId).HasColumnName("ChoiceID");

                entity.Property(e => e.Category).IsUnicode(false);
            });

            modelBuilder.Entity<MenuCard>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__MenuCard__C99ED250697576F6");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Cuisine).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
