using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EF.NewDB
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ProductDetail Details { get; set; }
    }

    public class ProductDetail
    {
        public int ProductID { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }

        public Product Product { get; set; }
    }

    public class PersonSeq
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PersonTph
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerTph : PersonTph
    {
        public DateTime DateOfBirth { get; set; }
    }

    public class EmployeeTph : PersonTph
    {
        public decimal Salary { get; set; }
    }

    public class PersonTpt
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerTpt:PersonTpt
    {
        public DateTime DateOfBirth { get; set; }
    }

    public class EmployeeTpt : PersonTpt
    {
      
       // public Guid Id { get; set; }
        //public PersonTpt Person { get; set; }
        public decimal Salary { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
    public class BookCategory
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorBiography Biography { get; set; }
    }
    public class AuthorBiography
    {
        public int AuthorBiographyId { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class T
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public T1 DD { get; set; }
    }
    public class T1
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [Table("StudentInfo")]
    public class StudentX
    {
        public StudentX() { }

        [Key]
        public int SID { get; set; }

        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string StudentName { get; set; }

        [NotMapped]
        public int? Age { get; set; }


        public int StdId { get; set; }

        [ForeignKey("StdId")]
        public virtual Course Standard { get; set; }
    }
    public enum SexType
    {
        Unspecified,Male,Female
    }
    public class Student
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public SexType Sex{ get; set; }

        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<DateTime?>("CreateDT").HasDefaultValueSql("GetDate()");
        }
    }
    public class StudentConfiguration : BaseConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.Property(p => p.LastName)
           // .HasColumnName("StdName")
            .HasMaxLength(300)
            .IsFixedLength(true)
            .IsRequired(true);
            builder.Property(p => p.FullName).HasComputedColumnSql("LastName + ' ' + FirstName");
            builder.Property(p => p.Sex)
                .HasMaxLength(1).IsFixedLength().IsUnicode()
                .HasConversion(
                    v => v.ToString()[0].ToString(),
                    v => v == "M" ? SexType.Male
                        : v == "F" ? SexType.Female : SexType.Unspecified
                    );
        }
    }
    public static class ModelBuilderExtensions{
        public static ModelBuilder ConfigureSchoolDb(this ModelBuilder modelBuilder){
            modelBuilder.HasDefaultSchema("School");
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.HasSequence("TestSeq", schema:"School").StartsAt(100).IncrementsBy(2);
            modelBuilder.Entity<PersonSeq>().Property(p => p.Id)
                .HasDefaultValueSql("NEXT VALUE FOR School.TestSeq");

            return modelBuilder;
        }
    }
    public class SchoolContext : DbContext
    {
        public DbSet<PersonSeq> PersonSeq { get; set; }
        public DbSet<T> XX { get; set; }
        public DbSet<PersonTph> Person { get; set; }
        public DbSet<CustomerTph> Customer { get; set; }
        public DbSet<EmployeeTph> Employee { get; set; }
        //public DbSet<PersonTpt> PersonT { get; set; }
        public DbSet<CustomerTpt> CustomerT { get; set; }
        public DbSet<EmployeeTpt> EmployeeT { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> BookCategories { get; set; }
        public DbSet<StudentX> St { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SchoolDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureSchoolDb();
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.Entity<CustomerTph>().ToTable("S");
            modelBuilder.Entity<EmployeeTph>().ToTable("e");
            modelBuilder.Entity<PersonTph>()
                .HasDiscriminator("Type", typeof(byte))
                .HasValue(typeof(PersonTph), (byte)0)
                .HasValue(typeof(CustomerTph), (byte)1)
                .HasValue(typeof(EmployeeTph), (byte)2);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductDetail>().ToTable("Product");
            modelBuilder.Entity<ProductDetail>().HasKey(p => p.ProductID) ;


            modelBuilder.Entity<BookCategory>().ToTable("Category", schema:"dictionary")
                
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
            modelBuilder.Entity<PersonTpt>().ToTable("PersonT");
            modelBuilder.Entity<CustomerTpt>().ToTable("CustomerT");
            modelBuilder.Entity<EmployeeTpt>().ToTable("EmployeeT");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new SchoolContext())
            {
                
                var px = new PersonSeq() { Name = "dfsdf" };
                context.Update(px);
                context.SaveChanges();
                var s= context.Students.ToArray();
                s[0].IsDeleted = true;
                context.Remove(s.Last());
                context.SaveChanges();
                s = context.Students.ToArray();
                s = context.Students.IgnoreQueryFilters().ToArray();
                var p = new Student { LastName = "Zdzisio Kalosz",Sex=SexType.Male };
                context.Students.Add(p);
                //p = context.Students.Find(2);
                //p.Name = "Pigwa Gienia";
                //p = context.Students.Find(3);
                //if (p != null)
                //    context.Students.Remove(p);
                context.SaveChanges();
                
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
