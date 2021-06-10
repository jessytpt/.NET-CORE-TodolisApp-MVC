using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Todolist_App.Models
{
    public partial class TodolistContext : DbContext
    {
        public TodolistContext()
        {
        }

        public TodolistContext(DbContextOptions<TodolistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tarea> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Todolist;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea);

                entity.ToTable("tarea");

                entity.Property(e => e.IdTarea).HasColumnName("id_tarea");

                entity.Property(e => e.DescripcionTarea)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_tarea");

                entity.Property(e => e.EstadoTarea).HasColumnName("estado_tarea");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
