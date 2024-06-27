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
        public DbSet<BookCopyStatus> BooksCopyStatus;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentBorrowBook>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.BorrowDate)
                    .IsRequired();

                entity.Property(e => e.ExpectedReturnDate)
                    .IsRequired();

               

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.BorrowedBooks)
                    .HasForeignKey(e => e.StudentId);


                entity.HasOne(e => e.BookCopy)
                    .WithMany(bc => bc.BorrowRecords)
                    .HasForeignKey(e => e.CopyId);
                  
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasKey(e => e.Id);

               

                entity.HasOne(e => e.Book)
                    .WithMany(b => b.BookCopies)
                    .HasForeignKey(e => e.BookId);

                entity
               .HasOne(bc => bc.Status)
               .WithMany(bcs => bcs.BookCopies)
               .HasForeignKey(bc => bc.StatusId);
              
                // Seeding initial data
                entity.HasData(
                    new BookCopy { Id = 1, BookId = 1, StatusId = 1 },
                    new BookCopy { Id = 2, BookId = 1, StatusId = 2 },
                    new BookCopy { Id = 3, BookId = 2, StatusId = 1 }
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
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasData(
              new Book { Id = 1, Title = "Clean code", Author = "Author A" },
              new Book { Id = 2, Title = "Algorithms", Author = "Author B" }
              
              );
            
            
            });
            modelBuilder.Entity<BookCopyStatus>(entity =>
            {
                entity.HasKey(bcs => bcs.Id);

                entity.Property(bcs => bcs.Status)
                    .IsRequired();

                // Seed initial data for BookCopyStatus
                entity.HasData(
                    new BookCopyStatus { Id = 1, Status = "Good" },
                    new BookCopyStatus { Id = 2, Status = "Damaged" },
                    new BookCopyStatus { Id = 3, Status = "Lost" }
                );
            });
        }
    }
}
