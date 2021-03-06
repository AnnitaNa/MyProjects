using Catalog.Entities;

namespace Catalog.Repositories;



public class inMemItemsRepository : IitemsRepository
{
    private readonly List<Item> items = new()
    {
        new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Sword", Price = 100, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "shield", Price = 50, CreatedDate = DateTimeOffset.UtcNow },
    };

    public IEnumerable<Item> GetItems()
    {
        return items;
    }

    //Get /items/{id}
    public Item GetItem(Guid id)
    {
        return items.Where(item => item.Id == id).SingleOrDefault();
    }
    
    public void Createitem(Item item)
    {
       items.Add(item);
    }

    public void UpdateItem(Item item)
    {
        var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
        items[index] = item;
    }
}