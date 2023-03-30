using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;

namespace MySmartHomeWebApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SensorsController : Controller
    {
        private readonly ILogger<SensorsController> _logger;
        private readonly DbEntityRepository<Sensors> _repository;

        public SensorsController(ILogger<SensorsController> logger, IEntityRepository<Sensors> repository)
        {
            _logger = logger;
            _repository = (DbEntityRepository<Sensors>)repository;
        }

        // GET: api/<SensorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var item = await _repository.GetAll();
            return item.Count() == 0 ? NotFound() : Ok(item);
        }


        // GET api/<SensorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await _repository.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        // POST api/<SensorController>
        [HttpPost]
        public async Task<IActionResult> Post(Sensors sensor)
        {
            sensor.Id = Guid.NewGuid();
            sensor.DateTimeUpdate = DateTime.Now;
            return Ok(await _repository.Add(sensor));
        }

        // PUT api/<SensorController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Sensors sensor)
        {
            return Ok(await _repository.Update(sensor));
            //var oldSensor = await _repository.GetById(id).ConfigureAwait(false);
            //await _repository.Delete(oldSensor!).ConfigureAwait(false);
            //return Ok(await _repository.Add(sensor).ConfigureAwait(false));
        }

        // DELETE api/<SensorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _repository.DeleteById(id));
        }

        [HttpGet("exist/id/{id}")]
        public async Task<IActionResult> ExistId(Guid id)
        {
            return await _repository.ExistId(id) ? Ok(true) : NotFound(false);
        }

    }
}
