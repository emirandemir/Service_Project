using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Orders>
    {
        IQueryable<Orders> GetAllOrders(bool trackChanges);
        Orders GetOneOrderById(int id, bool trackChanges);
        void CreateOneOrder(Orders order);
        void UpdateOneOrder(Orders order);
        void DeleteOneOrder(Orders order);

    }
}
