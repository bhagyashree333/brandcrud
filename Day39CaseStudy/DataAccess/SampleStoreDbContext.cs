using Day39CaseStudy.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.DataAccess;

public class SampleStoreDbContext : DbContext
{
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    //public virtual DbSet<Commission> Commissions { get; set; }
    //public virtual DbSet<Customer> Customers { get; set; }
    //public virtual DbSet<Order> Orders { get; set; }
    //public virtual DbSet<OrderItem> OrderItems { get; set; }
    //public virtual DbSet<Person> Persons { get; set; }
    //public virtual DbSet<Staff> Staffs { get; set; }
    //public virtual DbSet<Stock> Stocks { get; set; }
    //public virtual DbSet<Store> Stores { get; set; }
    //public virtual DbSet<Target> Targets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=WAIDESK01\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True");
    }
}
