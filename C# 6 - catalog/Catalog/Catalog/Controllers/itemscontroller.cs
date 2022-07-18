using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;


[ApiController]
[Route("items")]
public class itemscontroller : ControllerBase
{
    private readonly inMemItemsRepository repository;

    public itemscontroller()
    {
        repository = new inMemItemsRepository();
    }
    
    //GET /items
    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
        var item = repository.GetItems();
        return item;
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id)
    {
        var item = repository.GetItem(id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

}