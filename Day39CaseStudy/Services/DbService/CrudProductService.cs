using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.Services.DbService;

public class CrudProductService : ICrudService<Product>
{
    public void Add(Product product)
    {
        using var context = new SampleStoreDbContext();

        context.Products.Add(product);
        context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        using var context = new SampleStoreDbContext();

        //return context.Products
        //    .Include("Brand")
        //    .Include("Category")
        //    .OrderBy(p => p.BrandId)
        //        .ThenBy(p => p.ProductId)
        //    .ToList();


        var allProducts = from p in context.Products
                           join
                           b in context.Brands
                           on p.BrandId equals b.BrandId
                           join
                           c in context.Categories
                           on p.CategoryId equals c.CategoryId

                           select (p.ProductName + " " + b.BrandName + " " + c.CategoryName).ToList();

        Console.WriteLine(allProducts);
        //foreach(var prod in allProducts)
        //{
        //    Console.WriteLine(allProducts);
        //}

        return allProducts as IEnumerable<Product>;


    }

    public void Update(Product product)
    {
        using var context = new SampleStoreDbContext();

        context.Products.Update(product);
        context.SaveChanges();
    }

    public Product GetByName(string productName)
    {
        using var context = new SampleStoreDbContext();

        // var product = context.Products.SingleOrDefault(b => b.ProductName == productName);
        var product = from p in context.Products
                      where p.ProductName == productName 
                      select p;
                     
        return product.First();
    }

    public void Delete(int productId)
    {
        using var context = new SampleStoreDbContext();

        //var product = context.Products.Find(productId);
        var product= from p in context.Products
                     where p.ProductId == productId
                     select p;

        if (product == null)
        {
            Console.WriteLine($"ProductId {productId} not found");
            return;
        }

        var productIwantToDelete=product.First();
        context.Products.Remove(productIwantToDelete);
        context.SaveChanges();
    }
}
