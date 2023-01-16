using SalesAPI.Models;

namespace SalesAPI.Interfaces
{
    public interface ISalesDiscountRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<SalesDiscount> All { get; }
        SalesDiscount Find(string id);
        void Insert(SalesDiscount item);
        void Update(SalesDiscount item);
        void Delete(string id);
    }
}
