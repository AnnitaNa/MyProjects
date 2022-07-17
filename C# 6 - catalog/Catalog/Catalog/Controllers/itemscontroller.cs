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
    
    // NOT WORKING!
    
    //GET items/id
    //[HttpGet("{id}")]
    //public Item GetItem(Guid id)
    //{
      //  var item = repository.GetItem(id);
        //return item;
    //}

}