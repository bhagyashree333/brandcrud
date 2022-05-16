// See https://aka.ms/new-console-template for more information

using Day39CaseStudy.Services.Menu;
using Day39CaseStudy.Services.UserInterface;

Console.WriteLine("Hello, World!");
/*
Requirement: 
1. Create a CRUD Screen for Brand & Product
2. Display a report of brand wise products
 */


IMenuService menuService = new MenuService();
var uiBrandService = new UserInterfaceCrudBrandService();
var uiProductService = new UserInterfaceCrudProductService();
var uiCategoryService=new UserinterfaceCrudCategoryService();



do
{
    var menuOptions = menuService.Show();

    switch (menuOptions)
    {
        case MenuOptions.Exit:
            return;
        case MenuOptions.BrandAdd:
            uiBrandService.Add();
            break;
        case MenuOptions.BrandUpdate:
            uiBrandService.Update();
            break;
        case MenuOptions.BrandDelete:
            uiBrandService.Delete();
            break;
        case MenuOptions.BrandShow:
            uiBrandService.Show();
            break;
        case MenuOptions.ProductAdd:
            uiProductService.Add();
            break;
        case MenuOptions.ProductUpdate:
            uiProductService.Update();
            break;
        case MenuOptions.ProductDelete:
            uiProductService.Delete();
            break;
        case MenuOptions.ProductShow:
            uiProductService.Show();                         //GetProductByBrand();
            break;
        case MenuOptions.CategoryAdd:
            uiCategoryService.Add();
            break;
        case MenuOptions.CategoryUpdate:
            uiCategoryService.Update();
            break;
        case MenuOptions.CategoryShow:
            uiCategoryService.show();
            break;
        case MenuOptions.CategoryDelete:
            uiCategoryService.Delete();
            break;
           
    }

} while (true);