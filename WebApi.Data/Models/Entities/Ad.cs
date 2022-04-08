namespace WebApi.Data.Models.Entities;

public class Ad
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public string City { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public int CategoryId { get; set; }
    public AdCategory? Category { get; set; }
    
    public int OwnerId { get; set; }
    public AdOwner? Owner { get; set; }
}