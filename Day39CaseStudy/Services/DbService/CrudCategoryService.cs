using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day39CaseStudy.Services.DbService;

public class CrudCategoryService : ICrudService<Category>
{

    public void Add(Category category)
    {
        using var context = new SampleStoreDbContext();
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void Delete(int categoryId)
    {
        using var context = new SampleStoreDbContext();
        var category = from c in context.Categories
                       where c.CategoryId == categoryId
                       select c;
        if (category == null)
        {
            Console.WriteLine($"Category id {categoryId} not found");
            return;
        }
        var categorytodelete = category.First();

        context.Categories.Remove(categorytodelete);
        context.SaveChanges();
    }

    public IEnumerable<Category> GetAll()
    {
        using var context = new SampleStoreDbContext();

        var allcategories = from c in context.Products
                            select c;

        return allcategories as IEnumerable<Category>;
    }

    public Product GetByName(string categoryName)
    {
        using var context = new SampleStoreDbContext();

        var category = from c in context.Categories
                       where c.CategoryName == categoryName
                       select c;

        return category.First();
    }


    public void Update(Category entity)
    {
        throw new NotImplementedException();
    }

    Category ICrudService<Category>.GetByName(string entityName)
    {
        throw new NotImplementedException();
    }
}
