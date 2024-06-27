using enozom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace enozom.DAL.Data
{
    public class EnozomDbContext : DbContext
    {
        public EnozomDbContext(DbContextOptions<EnozomDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students;
        public DbSet<Book> Books;
        public DbSet<BookCopy> BooksCopy;
        public DbSet<StudentBorrowBook> StudentBorrowBook;
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentBorrowBook>(entity =>
            {
                
                entity.HasOne(e => e.student)
                    .WithMany(s => s.StudentBorrowBook)
                    .HasForeignKey(e => e.StudentId);


               entity.HasOne(br => br.bookCopy)
                .WithMany(bc => bc.StudentBorrowBook)
                .HasForeignKey(br => br.CopyId);

            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                 entity.HasOne(bc => bc.book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.BookId);


              
                // Seeding initial data
                entity.HasData(
                new BookCopy { Id = 1, status = "Good", BookId = 1 },
                new BookCopy { Id = 2, status = "Good", BookId = 2 },
                new BookCopy { Id = 3, status = "Good", BookId = 1 }
                );

            });



            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

               
                entity.HasData(
                      new Student { Id = 1, Name = "Ali", Email = "Ali@enozom.com", Phone = "0122224400" },
                      new Student { Id = 2, Name = "Mohamed", Email = "Mohamed@enozom.com", Phone = "0111155000" },
                      new Student { Id = 3, Name = "Ahmed", Email = "ahmed@enozom.com", Phone = "0155553311" }
                  );
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Author)
                   
                    .HasMaxLength(100);
                entity.HasData(
               new Book { Id = 1, Title = "Clean Code" },
                new Book { Id = 2, Title = "Algorithms" }

              );
            
            
            });
           
        }
    }
}
