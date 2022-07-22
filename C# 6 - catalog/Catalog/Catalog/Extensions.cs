using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog;

public static class Extensions
{
    public static itemDto AsDto(this Item item)
    {
        return new itemDto
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate
        };
    }
}
