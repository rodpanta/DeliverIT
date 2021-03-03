using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RestAPI.Models
{
    public partial class TesteDeliverItContext : DbContext
    {
        public TesteDeliverItContext()
        {
        }

        public TesteDeliverItContext(DbContextOptions<TesteDeliverItContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContasApagar> ContasApagars { get; set; }
        public virtual DbSet<Fornecedore> Fornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TesteDeliverIt;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ContasApagar>(entity =>
            {
                entity.ToTable("ContasAPagar");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.ValorCorrigido).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorOriginal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.fornecedor)
                    .WithMany(p => p.ContasApagars)
                    .HasForeignKey(d => d.Idfornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContasAPagar_Fornecedores");
            });

            modelBuilder.Entity<Fornecedore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }




        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
