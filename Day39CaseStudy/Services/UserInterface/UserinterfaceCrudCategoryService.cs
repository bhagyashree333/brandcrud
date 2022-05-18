using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Day39CaseStudy.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day39CaseStudy.Services.UserInterface;

public class UserinterfaceCrudCategoryService
{
    readonly ICrudService<Category> _categoryservice;

    public UserinterfaceCrudCategoryService()
    {
        _categoryservice = CrudFactory.Create<Category>();
    }

    public void Add()
    {
        Console.WriteLine("Add New Category");
        Console.WriteLine("----------------");

        Console.WriteLine("Enetr New Category name:");
        var categoryName = Console.ReadLine();

        var category = new Category { CategoryName = categoryName };

        _categoryservice.Add(category); 

    }

    public IEnumerable<Category> GetAll()
    { 
    return _categoryservice.GetAll();   
    }

    public void Update()
    {
        Console.WriteLine("Updating existing Category");
        Console.WriteLine("-----------------------");

        Console.Write("Enter Category Name to Update: ");
        var categoryNameText = Console.ReadLine();

        var category=_categoryservice.GetByName(categoryNameText);

        if(category == null)
        {
            Console.WriteLine($"Category Name {categoryNameText} not found");
            return;
        }
        Console.WriteLine("Found Category you entered");

        Console.WriteLine("Enetr Category Name to cange :");
        var changedCategoryName=Console.ReadLine();

        category.CategoryName=changedCategoryName;

        _categoryservice.Update(category);  

    }

    public void Delete()
    {
        Console.WriteLine("Deleting existing category");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the Category Id to delete: ");
        var categoryIdText= Console.ReadLine();

        var categoryId=int.Parse(categoryIdText);
        try
        {
            _categoryservice.Delete(categoryId);
        }
        catch(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Delete category failer !{e.Message}");
            Console.ResetColor();
        }

    }
    public void Show()
    {
        var categories = _categoryservice.GetAll();

        Console.WriteLine("category List");
        Console.WriteLine("|-----------------------------|");

        Console.WriteLine(Category.Header);
        Console.WriteLine("|-----------------------------|");

        
        foreach(var cats in categories)
        {
            Console.WriteLine(cats);
        }
        Console.WriteLine("------------------------------|");
    
    }

}
