using Business.Service;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrierController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CarrierController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCarrier()
        {

            try
            {
                var carriers = _manager.CarrierService.GetList(false);
                if(carriers.FirstOrDefault() is null)
                {
                    string message = "Listelenecek Kargo Bulunamadı";
                    return Ok(new
                    {
                        Message = message,
                        Carriers = carriers
                    });
                }
                else
                {
                    string message = "Kargolar Listelendi";
                    return Ok(new
                    {
                        Message = message,
                        Carriers = carriers
                    });
                }
                
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpPost]
        public IActionResult CreateOneCarriers([FromBody] Carriers carrier)
        {
            try
            {
                if (carrier == null)
                {
                    return BadRequest();
                }

                _manager.CarrierService.Add(carrier);
                string message = "Kargo eklendi";
                return StatusCode(201, message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateOneCarrier([FromBody] Carriers carrier)
        {
            try
            {

                var entity = _manager.CarrierService.GetById(carrier.ID,false);

                if (entity is null)
                {
                    string message = $"{entity.ID} numaralı id'ye sahip kayıt bulunamadı.";
                    return NotFound(message);
                }

                else
                {
                    _manager.CarrierService.Update(entity.ID, carrier, true);
                    string message = $"{entity.ID} numaralı id'ye sahip kayıt güncellendi.";
                    return Ok(message);
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCarrier(int id)
        {
            try
            {
                var entity = _manager.CarrierService.GetById(id, false);

                if (entity is null)
                {
                    string message = $"{id} numaralı id'ye sahip kayıt bulunamadı.";
                    return NotFound(message);
                }

                else
                {
                    _manager.CarrierService.Delete(id, false);
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

