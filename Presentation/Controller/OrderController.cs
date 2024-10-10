using Business.Service;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GetAllOrder()
        {

            try
            {
                var orders = _manager.OrderService.GetList(false);
                string message = "Liste getirildi.";
                return Ok(new
                {
                    Message = message,
                    Orders = orders
                });
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneOrder([FromBody] Orders order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }

                var carrierConfigs = _manager.CarrierConfigurationService.GetList(false);
                decimal? lowestCost = null;
                CarrierConfigurations nearestCarrierConfig = null;
                decimal? nearestDifference = null;
                decimal? finalCost = null;
                var carrierID = 0;

                

                foreach (var carrierConfig in carrierConfigs)
                {
                    // Eğer desi, kargo firmasının min ve max değerlerine uyuyorsa
                    if (carrierConfig.carrierMinDesi <= order.orderDesi && carrierConfig.carrierMaxDesi >= order.orderDesi)
                    {
                        if (lowestCost == null || carrierConfig.carrierCost < lowestCost)
                        {
                            lowestCost = carrierConfig.carrierCost;
                            carrierID = carrierConfig.carrierID;
                        }
                    }
                    else
                    {
                        // Desi uymazsa, en yakın firmayı bulmak için farkı hesapla
                        var minDifference = Math.Abs(order.orderDesi - carrierConfig.carrierMinDesi);
                        var maxDifference = Math.Abs(order.orderDesi - carrierConfig.carrierMaxDesi);
                        var currentDifference = Math.Min(minDifference, maxDifference);

                        // En yakın firmayı kaydet
                        if (nearestDifference == null || currentDifference < nearestDifference)
                        {
                            nearestDifference = currentDifference;
                            nearestCarrierConfig = carrierConfig;
                        }
                    }
                }

                if (lowestCost.HasValue)
                {
                    // Eğer direkt uygun bir kargo firması bulunduysa, onun maliyetini kullan
                    order.orderCarrierCost = lowestCost.Value;
                    order.carrierID = carrierID;
                }
                else if (nearestCarrierConfig != null)
                {
                    var carrier = _manager.CarrierService.GetById(nearestCarrierConfig.carrierID,false);
                    // Uygun kargo firması yoksa, en yakın firmayı seç
                    var baseCost = nearestCarrierConfig.carrierCost;
                    var extraDesiCost = carrier.carrierPlusDesiCost;
                    var desiDifference = order.orderDesi - nearestCarrierConfig.carrierMaxDesi;

                    if (desiDifference > 0)
                    {
                        // C maddesi: Desi farkı ile +1 desi fiyatını çarp
                        var additionalCost = desiDifference * extraDesiCost;

                        // D maddesi: Temel fiyat ile ek fiyatı topla
                        finalCost = baseCost + additionalCost;
                    }
                    else
                    {
                        // Eğer desi farkı 0 veya negatif ise, yalnızca temel fiyatı ata
                        finalCost = baseCost;
                    }

                    order.orderCarrierCost = finalCost.Value;
                    order.carrierID = nearestCarrierConfig.carrierID;

                }
                else
                {
                    // Uygun veya yakın bir firma bulunamadıysa burada hata yönetimi yap
                    throw new Exception("Uygun bir kargo firması bulunamadı.");
                }

                _manager.OrderService.Add(order);

                return StatusCode(201, order);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateOneOrder([FromRoute(Name = "id")] int id, [FromBody] Orders order)
        {
            try
            {

                if (order is null)
                {
                    string message = "Kayıt Bulunamadı";
                    return BadRequest(message);
                }

                else
                {
                    string message = "Kayıt Silindi";
                    _manager.OrderService.Update(id, order, true);

                    return Ok(message);
                }

                

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneOrder(int id)
        {

            try
            {
                var entity = _manager.OrderService.GetById(id, false);

                if (entity is null)
                {
                    string message = $"{id} numaralı id'ye sahip kayıt bulunamadı.";
                    return NotFound(message);
                }

                else
                {
                    _manager.OrderService.Delete(id, false);
                    string message = $"{id} numaralı id'ye sahip kayıt silindi.";
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
     }
}
