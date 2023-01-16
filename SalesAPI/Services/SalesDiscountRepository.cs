using Microsoft.EntityFrameworkCore;
using SalesAPI.Interfaces;
using SalesAPI.Models;

namespace SalesAPI.Services
{
    public class SalesDiscountRepository : ISalesDiscountRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public SalesDiscountRepository(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            InitializeData();
            
        }

        public IEnumerable<SalesDiscount> All
        {
            get
            {
                using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
                return context.SalesDiscountSet.ToList();
            }
        }

        public bool DoesItemExist(string id)
        {
            using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
            return context.SalesDiscountSet.Any(item => item.ID == id);
        }

        public void Delete(string id)
        {
            using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
            context.SalesDiscountSet.Remove(this.Find(id));
            context.SaveChanges();
        }

        public SalesDiscount Find(string id)
        {
            using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
            return context.SalesDiscountSet.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(SalesDiscount item)
        {
            using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
            item.ID= Guid.NewGuid().ToString();
            context.SalesDiscountSet.Add(item);
            context.SaveChanges();
        }

        public void Update(SalesDiscount item)
        {
            using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
            context.SalesDiscountSet.Update(item);
            context.SaveChanges();
        }

        private void InitializeData()
        {
            var saleDiscountItem1 = new SalesDiscount
            {
                Name = "Bananen",
                Description = "Im Supermarkt die nächste Woche um 10% günstiger!",
                Avavible = true
            };

            var saleDiscountItem2 = new SalesDiscount
            {
                Name = "Fleisch",
                Description = "Im Supermarkt die nächste Woche um 30% günstiger!",
                Avavible = false
            };

            using var context = _serviceProvider.GetRequiredService<SalesDiscountContext>();
            context.SalesDiscountSet.Add(saleDiscountItem1);
            context.SalesDiscountSet.Add(saleDiscountItem2);
            context.SaveChanges();
        }
    }
}
