using Catalog.Entities;

namespace Catalog.Repositories;

public interface IitemsRepository
{

        IEnumerable<Item> GetItems();
        Item GetItem(Guid id);

}