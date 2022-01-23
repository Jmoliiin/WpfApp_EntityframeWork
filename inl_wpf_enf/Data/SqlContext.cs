using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using inl_wpf_enf.Entities;

namespace inl_wpf_enf.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Costumer> Costumers { get; set; } = null!;
        public virtual DbSet<Errand> Errands { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning /*To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.*/
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jessi\\Desktop\\DataLagring\\WpfApp_EntityframeWork\\inl_wpf_enf\\Data\\enf_wpf_baseFirst.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.PostalCode).IsFixedLength();
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.Property(e => e.MobileNumber).IsFixedLength();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Costumers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Costumers__Addre__208CD6FA");
            });

            modelBuilder.Entity<Errand>(entity =>
            {
                entity.HasOne(d => d.Admins)
                    .WithMany(p => p.Errands)
                    .HasForeignKey(d => d.AdminsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Errands__AdminsI__245D67DE");

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.Errands)
                    .HasForeignKey(d => d.CostumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Errands__Costume__236943A5");

                entity.HasOne(d => d.Satus)
                    .WithMany(p => p.Errands)
                    .HasForeignKey(d => d.SatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Errands__SatusId__25518C17");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
