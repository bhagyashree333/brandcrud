using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day39CaseStudy.DataAccess.Models;

[Table("products", Schema = "production")]
public class Product
{
    [Key]
    [Column("product_id")]
    public int? ProductId { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; }

    [Column("brand_id")]
    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [Column("model_year")]
    public short ModelYear { get; set; }

    [Column("list_price")]
    public decimal ListPrice { get; set; }

    public static string Header => "ProductId, ProductName, BrandId, BrandName, CategoryId, CategoryName, ModelYear, ListPrice";

    public override string ToString()
    {
        return $"{ProductId}, {ProductName}, {BrandId}, {Brand?.BrandName}, {CategoryId}, {Category?.CategoryName}, {ModelYear}, {ListPrice}";
    }
}
