using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursProjectISP31.Model;

public partial class KursovayaContext : DbContext
{
    public KursovayaContext()
    {
        Database.EnsureCreated();
    }

    public KursovayaContext(DbContextOptions<KursovayaContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PrintingHouse> PrintingHouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Kursovaya.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor);

            entity.ToTable("Author");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer);

            entity.ToTable("Customer");

            entity.HasIndex(e => e.IdPerson, "IX_Customer_idPerson");

            entity.Property(e => e.IdPerson).HasColumnName("idPerson");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Edition>(entity =>
        {
            entity.HasKey(e => e.IdEdition);

            entity.ToTable("Edition");

            entity.HasIndex(e => e.IdAuthor, "IX_Edition_IdAuthor");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Editions)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order");

            entity.HasIndex(e => e.IdCustomer, "IX_Order_IdCustomer");

            entity.HasIndex(e => e.IdEdition, "IX_Order_IdEdition");

            entity.HasIndex(e => e.IdPrintingHouse, "IX_Order_IdPrintingHouse");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.IdEditionNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEdition)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.IdPrintingHouseNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPrintingHouse)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Idperson);

            entity.ToTable("Person");

            entity.Property(e => e.Idperson).HasColumnName("IDPerson");
        });

        modelBuilder.Entity<PrintingHouse>(entity =>
        {
            entity.HasKey(e => e.IdPrintingHouse);

            entity.ToTable("PrintingHouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
