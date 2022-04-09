using System.Text.Json.Serialization;

namespace WebApi.Data.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoryType
{
    Service,
    Product,
    Other
}