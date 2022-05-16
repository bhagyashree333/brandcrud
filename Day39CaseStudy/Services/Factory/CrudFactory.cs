using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService;
using Day39CaseStudy.Services.DbService.Interfaces;

namespace Day39CaseStudy.Services.Factory
{
    public static class CrudFactory
    {
        public static ICrudService<T> Create<T>()    //little bit confused abt why used typeof
        {
            if (typeof(T) == typeof(Brand))
                return (ICrudService<T>)new CrudBrandService();

            if (typeof(T) == typeof(Product))
                return (ICrudService<T>)new CrudProductService();

            if(typeof(T) == typeof(Category))
                return (ICrudService<T>)new CrudCategoryService();

            return null;
        }
    }
}