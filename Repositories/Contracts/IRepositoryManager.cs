using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarrierRepository Carrier { get; }
        ICarrierConfigurationRepository CarrierConfiguration { get; }
        IOrderRepository Order { get; }
        void Save();
    }
}
