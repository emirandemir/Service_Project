using Business.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICarrierService> _carrierService;
        private readonly Lazy<ICarrierConfigurationService> _carrierConfigurationService;
        private readonly Lazy<IOrderService> _orderService;


        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _carrierService = new Lazy<ICarrierService>(() => new CarrierManager(repositoryManager));
            _carrierConfigurationService = new Lazy<ICarrierConfigurationService>(() => new CarrierConfigurationManager(repositoryManager));
            _orderService = new Lazy<IOrderService>(() => new OrderManager(repositoryManager));
        }

        public ICarrierService CarrierService => _carrierService.Value;

        public ICarrierConfigurationService CarrierConfigurationService => _carrierConfigurationService.Value;

        public IOrderService OrderService => _orderService.Value;
    }
}
