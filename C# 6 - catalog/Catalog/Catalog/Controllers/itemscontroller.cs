using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;


[ApiController]
[Route("items")]
public class itemscontroller : ControllerBase
{
    private readonly IitemsRepository repository;

    public itemscontroller(IitemsRepository repository)
    {
        this.repository = repository;
    }
    
    //GET /items
    [HttpGet]
    public IEnumerable<itemDto> GetItems()
    {
        var item = repository.GetItems().Select(item => item.AsDto());
        return item;
    }

    [HttpGet("{id}")]
    public ActionResult<itemDto> GetItem(Guid id)
    {
        var item = repository.GetItem(id);
        if (item == null)
        {
            return NotFound();
        }
        return item.AsDto();
    }
    
    [HttpPost]
    public ActionResult<itemDto> CreateItem(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };
        repository.Createitem((item));
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());

    }

    [HttpPut("{id}")] //not working
    public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
    {
        var existingItem = repository.GetItem(id);
        if (existingItem is null)
        {
            return NotFound();
        }

        Item updateItem = existingItem with
        {
            Name = itemDto.Name,
            Price = itemDto.Price
        };
        repository.UpdateItem((updateItem));
        return NoContent();
    }

}
