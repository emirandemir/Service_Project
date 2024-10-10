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
    public class CarrierManager : ICarrierService
    {
        private readonly IRepositoryManager _manager;

        public CarrierManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Carriers Add(Carriers entity)
        {
            _manager.Carrier.Create(entity);
            _manager.Save();
            return entity;
        }

        public void Delete(int id, bool trackChanges)
        {
            var entity = _manager.Carrier.GetOneCarrierById(id, trackChanges);

            _manager.Carrier.DeleteOneCarrier(entity);
            _manager.Save();
        }

        public Carriers GetById(int id, bool trackChanges)
        {
            var carrier = _manager.Carrier.GetOneCarrierById(id, trackChanges);
            return carrier;
        }

        public IEnumerable<Carriers> GetList(bool trackChanges)
        {
            var carriers = _manager.Carrier.GetAllCarriers(trackChanges);
            return carriers;
        }

        public void Update(int id, Carriers carrier, bool trackChanges)
        {
            var entity = _manager.Carrier.GetOneCarrierById(id, trackChanges);
           
            entity.carrierPlusDesiCost = carrier.carrierPlusDesiCost;

            _manager.Carrier.Update(entity);
            _manager.Save();
        }
    }
}
