using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Day39CaseStudy.Services.Factory;

namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudProductService
{
    readonly ICrudService<Product> _productService;
    readonly ICrudService<Brand> _brandService;

    public UserInterfaceCrudProductService()
    {
        _productService = CrudFactory.Create<Product>();
        _brandService = CrudFactory.Create<Brand>();

    }

    public void Add()
    {
        var product = new Product();

        Console.WriteLine("Adding New Product");
        Console.WriteLine("----------------");

        Console.Write("Enter Product Name: ");
        var productNameText = Console.ReadLine();
        product.ProductName = productNameText;

        Console.Write("Enter Brand Id: ");
        var brandIdText = Console.ReadLine();
        product.BrandId = int.Parse(brandIdText);

        Console.Write("Enter CategoryId: ");
        var categoryIdText = Console.ReadLine();
        product.CategoryId = int.Parse(categoryIdText);

        Console.Write("Enter Model Year: ");
        var modelYearText = Console.ReadLine();
        product.ModelYear = short.Parse(modelYearText);

        Console.Write("Enter List Price: ");
        var listPriceText = Console.ReadLine();
        product.ListPrice = int.Parse(listPriceText);

        try
        {
            _productService.Add(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Adding product: {ex.Message}");
        }
    }

    public IEnumerable<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public void Update()
    {
        Console.WriteLine("Updating existing Product");
        Console.WriteLine("-----------------------");

        Console.Write("Enter Product Name to Update: ");
        var productNameText = Console.ReadLine();

        var product = _productService.GetByName(productNameText);

        if (product == null)
        {
            Console.WriteLine($"Product Name {productNameText} not found!!");
            return;
        }

        Console.WriteLine($"Found Product: {product}");
        Console.WriteLine("-------------------------------------------------------");

        Console.Write("Enter Product Name to change: ");
        product.ProductName = Console.ReadLine();

        Console.Write("Enter Brand Id to change: ");
        var brandIdText = Console.ReadLine();
        product.BrandId = int.Parse(brandIdText);

        Console.Write("Enter CategoryId to change: ");
        var categoryIdText = Console.ReadLine();
        product.CategoryId = int.Parse(categoryIdText);

        Console.Write("Enter Model Year to change: ");
        var modelYearText = Console.ReadLine();
        product.ModelYear = short.Parse(modelYearText);

        Console.Write("Enter List Price to change: ");
        var listPriceText = Console.ReadLine();
        product.ListPrice = int.Parse(listPriceText);

        _productService.Update(product);
    }

    public void Delete()
    {
        Console.WriteLine("Deleting existing Product");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the Product Id to delete: ");
        var productIdText = Console.ReadLine();
        var productId = int.Parse(productIdText);

        _productService.Delete(productId);
    }

    public void Show()
    {
        var prods = _productService.GetAll();

        var mybrands = _brandService.GetAll();

        Console.WriteLine("------------------------|");
        Console.WriteLine("Brand Details");
        Console.WriteLine(Brand.Header);
        //foreach ( var br in mybrands)
        //{
        //    Console.WriteLine(br);
        //}
        //Console.WriteLine("------------------------");


        Console.WriteLine("Product List");
        Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|");

        Console.WriteLine(Product.Header);
        Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|");

        // var tempbrandid = 1;
        //foreach (var brands in mybrands)
        //{
        //    foreach (var product in prods)
        //    {
        //        if(brands.BrandId == product.BrandId)
        //        { 

        //            Console.WriteLine(brands);
        //            Console.WriteLine(product);

        //        }


        //    }

        //}
        //int brandcount=mybrands.Count();
        foreach (var product in prods)
        {
            foreach (var brand in mybrands)
            {
                for (int i = 0; i < mybrands.Count(); i++)
                {
                    if (product.BrandId == i)
                    {
                        Console.WriteLine(brand);
                        Console.WriteLine(product);
                    }
                }
            }
        }




        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
    }

    public void GetProductByBrand()
    {
        Console.WriteLine("Enter brand id");
        var brandidToSearch = int.Parse(Console.ReadLine());
        // var prods = _productService.GetAll();

        if (brandidToSearch == null)
        {
            Console.WriteLine($"No product exists related to brand {brandidToSearch}");
            return;
        }
        Console.WriteLine(Product.Header);
        _productService.GetProductByBrand(brandidToSearch);

    }
}
