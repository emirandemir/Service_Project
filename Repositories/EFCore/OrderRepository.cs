using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class OrderRepository : RepositoryBase<Orders>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneOrder(Orders order) => Create(order);

        public void DeleteOneOrder(Orders order) => Delete(order);

        public IQueryable<Orders> GetAllOrders(bool trackChanges) => FindAll(trackChanges);

        public Orders GetOneOrderById(int id, bool trackChanges) => FindByCondition(x => x.ID == id, trackChanges).SingleOrDefault();

        public void UpdateOneOrder(Orders order) => Update(order);
    }
}
