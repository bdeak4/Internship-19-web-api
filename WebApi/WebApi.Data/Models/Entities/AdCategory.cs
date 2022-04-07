using WebApi.Data.Models.Enums;

namespace WebApi.Data.Models.Entities;

public class AdCategory
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public CategoryType Type { get; set; } = CategoryType.Other;
    public DateTime CreatedAt { get; } = DateTime.Now;
    
    public ICollection<Ad> Ads { get; set; } = new List<Ad>();
}