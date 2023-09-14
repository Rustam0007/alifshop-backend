using System.ComponentModel.DataAnnotations.Schema;

namespace market_place.Models;

public sealed class Category : BaseEntity
{
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public int ParentCategoryId { get; set; }
    
    public ICollection<Product> Products { get; set; }
}

