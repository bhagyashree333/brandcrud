using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day39CaseStudy.DataAccess.Models;

[Table("categories", Schema = "production")]
public class Category
{
    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("category_name")]
    public string CategoryName { get; set; }

    public static string Header => "CATEGORYID   CATEGORYNAME";


    public override string ToString()
    {
        return $"|{CategoryId,6}|{CategoryName,-21} |";
    }
}