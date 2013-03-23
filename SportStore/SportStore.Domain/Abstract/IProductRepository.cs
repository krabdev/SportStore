using System.Linq;
using SportStore.Domain.Entities;

/*
 *  This interface allow a sequence of Product objects to be obtained
 *  A class that use the IProductRepository interface can obtain Product objects
 *  without knowing anythink about where they are coming from or how they will be delivered!
 */

namespace SportStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; set; }
    }
}
