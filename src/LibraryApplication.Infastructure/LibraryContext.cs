using LibraryApplication.Domain;
using LibraryApplication.Domain.AggregateModel.EmployeesAggregate;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryApplication.Infastructure
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }
        public DbSet<LibraryItem> LibraryItems { set; get; }
        public DbSet<Book> Books { set; get; }
        public DbSet<AudioBook> AudioBooks { set; get; }
        public DbSet<Dvd> Dvds { set; get; }
        public DbSet<ReferenceBook> ReferenceBooks { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Employee> Employees { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<LibraryItem>().HasDiscriminator<string>("Type");
            modelBuilder.Entity<LibraryItem>()
                .Property(p => p.categoryId)
                .HasColumnName("CategoryId");
            modelBuilder.Entity<ReferenceBook>()
                .Property(p => p.Author)
                .HasColumnName("Author");
            modelBuilder.Entity<ReferenceBook>()
                .Property(p => p.Pages)
                .HasColumnName("Pages");
            modelBuilder.Entity<Book>()
                .Property(p => p.Author)
                .HasColumnName("Author");
            modelBuilder.Entity<Book>()
                .Property(p => p.Pages)
                .HasColumnName("Pages");
            modelBuilder.Entity<Dvd>()
                .Property(p => p.RunTimeMinutes)
                .HasColumnName("RunTimeMinutes");
            modelBuilder.Entity<AudioBook>()
                .Property(p => p.RunTimeMinutes)
                .HasColumnName("RunTimeMinutes");
        }
    }
}
