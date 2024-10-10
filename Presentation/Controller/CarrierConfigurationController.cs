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
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CarrierConfigurationController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCarrierConfigurations()
        {

            try
            {
                var carrierConfigurations = _manager.CarrierConfigurationService.GetList(false);
                string message = "Liste getirildi.";
                return Ok(new
                {
                    Message = message,
                    CarrierConfigurations = carrierConfigurations
                });
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpPost]
        public IActionResult CreateOneCarrierConfiguration([FromBody] CarrierConfigurations carrierConfigurations)
        {
            try
            {
                
                if (carrierConfigurations == null) 
                {
                    string message = "Kargo Konfigürasyonu Oluşturulamadı";
                    return BadRequest(message);
                }
                else
                {
                    _manager.CarrierConfigurationService.Add(carrierConfigurations);

                    string message = "Kargo Konfigürasyonu oluşturuldu";
                    return StatusCode(201, message);
                }
                
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateOneCarrierConfiguration([FromRoute(Name = "id")] int id, [FromBody] CarrierConfigurations carrierConfiguration)
        {
            try
            {

                if (carrierConfiguration is null)
                {
                    string message = $"{id} numaralı id'ye sahip kayıt güncellenemedi.";
                    return BadRequest(message);
                }
                else
                {
                    _manager.CarrierConfigurationService.Update(id, carrierConfiguration, true);
                    string message = $"{id} numaralı id'ye sahip kayıt güncellendi.";

                    return Ok(message);
                }
                

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCarrierConfiguration(int id)
        {

            try
            {
                var entity = _manager.CarrierConfigurationService.GetById(id, false);

                if (entity is null)
                {
                    string message = $"{id} numaralı id'ye sahip kayıt bulunamadı.";
                    return NotFound(message);
                }

                else
                {
                    _manager.CarrierConfigurationService.Delete(id, false);
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
