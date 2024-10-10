using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICarrierRepository : IRepositoryBase<Carriers>
    {
        IQueryable<Carriers> GetAllCarriers(bool trackChanges);
        Carriers GetOneCarrierById(int id, bool trackChanges);
        void CreateOneCarrier(Carriers carrier);
        void UpdateOneCarrier(Carriers carrier);
        void DeleteOneCarrier(Carriers carrier);
    }
}
