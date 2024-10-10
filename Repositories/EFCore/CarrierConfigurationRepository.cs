using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CarrierConfigurationRepository : RepositoryBase<CarrierConfigurations>, ICarrierConfigurationRepository
    {
        public CarrierConfigurationRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCarrierConfiguration(CarrierConfigurations carrierConfiguration) => Create(carrierConfiguration);
        
        public void DeleteOneCarrierConfiguration(CarrierConfigurations carrierConfiguration)  => Delete(carrierConfiguration);
      

        public IQueryable<CarrierConfigurations> GetAllCarrierConfigurations(bool trackChanges) => FindAll(trackChanges);


        public CarrierConfigurations GetOneCarrierConfigurationById(int id, bool trackChanges) => FindByCondition(x => x.ID.Equals(id), trackChanges).SingleOrDefault();


        public void UpdateOneCarrierConfiguration(CarrierConfigurations carrierConfiguration) => Update(carrierConfiguration);

    }
}
