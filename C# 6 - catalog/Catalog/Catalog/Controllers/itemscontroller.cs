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

}