using Business.Service;
using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Orders Add(Orders entity)
        {
            _manager.Order.Create(entity);
            _manager.Save();
            return entity;
        }

        public void Delete(int id, bool trackChanges)
        {
            var entity = _manager.Order.GetOneOrderById(id, trackChanges);

           
            _manager.Order.DeleteOneOrder(entity);
            _manager.Save();
        }

        public Orders GetById(int id, bool trackChanges)
        {
            var order = _manager.Order.GetOneOrderById(id, trackChanges);
            return order;
        }

        public IEnumerable<Orders> GetList(bool trackChanges)
        {
            var orders = _manager.Order.GetAllOrders(trackChanges);
            return orders;
        }

        public void Update(int id, Orders order, bool trackChanges)
        {
            var entity = _manager.Order.GetOneOrderById(id, trackChanges);
            

            if (order is null)
            {
                throw new ArgumentException(nameof(order));
            }

            entity.orderCarrierCost = order.orderCarrierCost;

            _manager.Order.Update(entity);
            _manager.Save();
        }
    }
}
