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


        var allProducts = (from p in context.Products
                           join
                           b in context.Brands
                           on
                           p.BrandId equals b.BrandId
                           join
                           c in context.Categories
                           on
                           p.CategoryId equals c.CategoryId
                           orderby p.CategoryId, p.BrandId

                           select new Product
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               BrandId = p.BrandId,
                               CategoryId = p.CategoryId,
                               ModelYear = p.ModelYear,
                               ListPrice = p.ListPrice,
                               Brand = b,
                               Category = c
                           }).ToList();

        return allProducts;
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
        var product = from p in context.Products
                      where p.ProductId == productId
                      select p;

        if (product == null)
        {
            Console.WriteLine($"ProductId {productId} not found");
            return;
        }

        var productIwantToDelete = product.First();
        context.Products.Remove(productIwantToDelete);
        context.SaveChanges();
    }


    public void GetProductByBrand(int brandidToSearch)
    {
        using var context = new SampleStoreDbContext();

        var myproducts = from p in (context.Products).ToList()
                         join
                         b in context.Brands
                         on p.BrandId equals b.BrandId
                         where p.BrandId == brandidToSearch
                         select p;

        foreach (var product in myproducts)
        {

            Console.WriteLine(product);
        }

    }
}

//public void brandThenProduct()
//{
//  using var context = new SampleStoreDbContext();
//foreach (var brand in context.Brands)
//{
//    Console.WriteLine($"{brand.BrandId},{brand.BrandName}");

//    var product = (from p in context.Products
//                   where p.BrandId == brand.BrandId
//                   select new Product
//                   {
//                       ProductId = p.ProductId,
//                       ProductName = p.ProductName,
//                       BrandId = p.BrandId,
//                       CategoryId = p.CategoryId,
//                       ModelYear = p.ModelYear,
//                       ListPrice = p.ListPrice

//                   }).ToList();

//}
//var alldata = GetAll();
//var brndwiseproduct = from b in context.Brands
//                      join b2 in alldata
//                      on b.BrandId equals b2.BrandId
//                      where b.BrandId == b2.BrandId
//                      select b;



//public List<Product> GetproductInfoBybrandId()
//{
//using var context = new SampleStoreDbContext();

//var myallProducts = (from p in context.Products
//                     join b in context.Brands
//                     on p.BrandId equals b.BrandId
//                     join
//                     c in context.Categories
//                     on
//                     p.CategoryId equals c.CategoryId
//                     group p.ProductId by p.BrandId into myProds
//                     select new 
//                     {
//                         ProductId = myProds.Key,

//                         brands = myProds.ToList()
//                     }).ToList();

//return myallProducts;

//}


//public class GetProductInfo
//{
//    public int ProductId { get; set; }
//    public string ProductName { get; set; }
//    public string CategoryName { get; set; }

//    public int BrandId { get; set; }
//}

