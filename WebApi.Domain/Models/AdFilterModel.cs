using WebApi.Data.Models.Entities;
using WebApi.Domain.Repositories.Enums;

namespace WebApi.Domain.Models;

public class AdFilterModel
{
    public string? Title { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public int? CategoryId { get; set; }
    public string? County { get; set; }
    public string? City { get; set; }
}

public static class AdFilterExtensionMethods
{
    public static IQueryable<Ad> ApplyFilter(this IQueryable<Ad> adQueryable, AdFilterModel filter)
    {
        return adQueryable
            .Where(ad =>
                (ad.Title == filter.Title || filter.Title == null)
                && (ad.Price >= filter.MinPrice || filter.MinPrice == null)
                && (ad.Price <= filter.MaxPrice || filter.MaxPrice == null)
                && (ad.CategoryId == filter.CategoryId || filter.CategoryId == null)
                && (ad.County == filter.County || filter.County == null)
                && (ad.City == filter.City || filter.City == null)
            );
    }

    public static IQueryable<Ad> ApplySort(this IQueryable<Ad> adQueryable, SortType? sort)
    {
        switch (sort)
        {
            case SortType.PriceAsc:
                return adQueryable.OrderBy(ad => ad.Price);
            
            case SortType.PriceDesc:
                return adQueryable.OrderByDescending(ad => ad.Price);

            case SortType.CreatedAtAsc:
                return adQueryable.OrderBy(ad => ad.CreatedAt);
            
            case SortType.CreatedAtDesc:
                return adQueryable.OrderByDescending(ad => ad.CreatedAt);
            
            default:
                return adQueryable;
        }
    }
}