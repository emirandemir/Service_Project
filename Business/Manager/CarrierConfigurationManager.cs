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
    public class CarrierConfigurationManager : ICarrierConfigurationService
    {
        private readonly IRepositoryManager _manager;

        public CarrierConfigurationManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public CarrierConfigurations Add(CarrierConfigurations entity)
        {
            _manager.CarrierConfiguration.Create(entity);
            _manager.Save();
            return entity;
        }

        public void Delete(int id, bool trackChanges)
        {
            var entity = _manager.CarrierConfiguration.GetOneCarrierConfigurationById(id, trackChanges);

            _manager.CarrierConfiguration.DeleteOneCarrierConfiguration(entity);
            _manager.Save();
        }

        public CarrierConfigurations GetById(int id, bool trackChanges)
        {
            var carrierConfiguration = _manager.CarrierConfiguration.GetOneCarrierConfigurationById(id, trackChanges);
            return carrierConfiguration;
        }

        public IEnumerable<CarrierConfigurations> GetList(bool trackChanges)
        {
            var carrierConfiguration = _manager.CarrierConfiguration.GetAllCarrierConfigurations(trackChanges);
            return carrierConfiguration;
        }

        public void Update(int id, CarrierConfigurations carrierConfigurations, bool trackChanges)
        {
            var entity = _manager.CarrierConfiguration.GetOneCarrierConfigurationById(id, trackChanges);
            

            if (carrierConfigurations is null)
            {
                throw new ArgumentException(nameof(carrierConfigurations));
            }

            entity.carrierCost = carrierConfigurations.carrierCost;

            _manager.CarrierConfiguration.Update(entity);
            _manager.Save();
        }
    }
}
