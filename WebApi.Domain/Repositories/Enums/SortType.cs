using System.Text.Json.Serialization;

namespace WebApi.Domain.Repositories.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortType
{
    PriceAsc,
    PriceDesc,
    CreatedAtAsc,
    CreatedAtDesc
}