using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICarrierConfigurationRepository : IRepositoryBase<CarrierConfigurations>
    {
        IQueryable<CarrierConfigurations> GetAllCarrierConfigurations(bool trackChanges);
        CarrierConfigurations GetOneCarrierConfigurationById(int id, bool trackChanges);
        void CreateOneCarrierConfiguration(CarrierConfigurations carrierConfiguration);
        void UpdateOneCarrierConfiguration(CarrierConfigurations carrierConfiguration);
        void DeleteOneCarrierConfiguration(CarrierConfigurations carrierConfiguration);
    }
}
