using Catalog.Entities;

namespace Catalog.Repositories;

public interface IitemsRepository
{
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void Createitem(Item item);
        void UpdateItem(Item item);

}