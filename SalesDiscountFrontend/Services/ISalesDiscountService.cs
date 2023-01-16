using SaveMoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoneyApp.Services
{
    public interface ISalesDiscountService
    {
        Task<List<SalesDiscount>> GetTasksAsync();
        Task<SalesDiscount> CreateTaskAsync(SalesDiscount item);
        Task<SalesDiscount> UpdateTaskAsync(SalesDiscount item);
        Task DeleteTaskAsync(string id);
    }
}
