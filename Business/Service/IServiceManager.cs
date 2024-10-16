﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IServiceManager
    {
        ICarrierService CarrierService { get; }
        ICarrierConfigurationService CarrierConfigurationService { get; }
        IOrderService OrderService { get; }
    }
}
