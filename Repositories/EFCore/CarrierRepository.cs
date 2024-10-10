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
    public class CarrierRepository : RepositoryBase<Carriers>, ICarrierRepository
    {
        public CarrierRepository(RepositoryContext context) : base(context)
        {
        }
        public void CreateOneCarrier(Carriers carrier) => Create(carrier);

        public void DeleteOneCarrier(Carriers carrier) => Delete(carrier);

        public IQueryable<Carriers> GetAllCarriers(bool trackChanges) => FindAll(trackChanges);

        public Carriers GetOneCarrierById(int id, bool trackChanges) => FindByCondition(x => x.ID.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneCarrier(Carriers carrier) => Update(carrier);
    }
}
