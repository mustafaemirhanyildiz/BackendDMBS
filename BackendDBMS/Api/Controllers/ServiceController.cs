using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using DataAccess.Concrete;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        GenericRepository<Service> genericRepository = new GenericRepository<Service>();

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            //
            List<Service> list = genericRepository.GetAll();

            return Ok(list);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById(string id)
        {
            int myId = int.Parse(id);

            Service obj = genericRepository.GetById(o => o.Id == myId);

            if(obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Service employee)
        {
            if(employee == null)
                return BadRequest();

            genericRepository.Add(employee);

            return Ok(employee);
        }
        [HttpGet]
        [Route("getbystationid/{id}")]
        public IActionResult GetByStationId(int id)
        {
            GenericRepository<Device> deviceGenericRepository = new GenericRepository<Device>();
            GenericRepository<Station> stationGenericRepository = new GenericRepository<Station>();
            List<MyServiceModel> serviceModels = new List<MyServiceModel>();
            
            List<Service> services = genericRepository.GetAll();

            foreach (Service service in services)
            {
                List<Device> devices = deviceGenericRepository.GetAll();
                Device device = deviceGenericRepository.GetById(o => o.Id == service.DeviceId);
                if(device == null)
                    return Ok(new List<MyServiceModel>());

                Station station = stationGenericRepository.GetById(o => o.Id == id);
                if(station == null)
                    return Ok(new List<MyServiceModel>());

                MyServiceModel serviceModel = new MyServiceModel();
                serviceModel.ServiceTitle = service.ServiceTitle;
                serviceModel.ServiceDesc = service.ServiceDesc;
                serviceModel.DeviceName = device.Name;
                serviceModel.DeviceStatus = service.DeviceStatus;
                serviceModel.Time = service.Time;

                serviceModels.Add(serviceModel);
            }

            return Ok(serviceModels);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Service employee)
        {
            if(employee == null)
                return BadRequest();

            genericRepository.Update(employee);

            return Ok(employee);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(string id)
        {
            int deletedId = int.Parse(id);

            Service deletedObj = genericRepository.GetById(o => o.Id == deletedId);

            if(deletedObj == null)
                return BadRequest();

            genericRepository.Delete(o => o.Id == deletedId);

            return Ok(deletedObj);
        }
    }
}