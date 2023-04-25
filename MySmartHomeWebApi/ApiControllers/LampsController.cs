using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySmartHome.DAL.Models;
using MySmartHome.DAL.Repositories.Interfaces;
using MySmartHomeWebApi.Servises;

namespace MySmartHomeWebApi.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LampsController : ControllerBase
    {
        private readonly ILogger<LampsController> _logger;
        private readonly IEntityRepository<Lamps> _repository;
        private readonly MQTTClient _mqtt;

        public LampsController(ILogger<LampsController> logger, IEntityRepository<Lamps> repository, MQTTClient mqtt)
        {          
            _logger = logger;
            _repository = repository;
            _mqtt = mqtt;
        }

        // GET api/<LampController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var item = await _repository.GetAll();
            return item == null ? NotFound() : Ok(item);
        }


        // GET api/<LampController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await _repository.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }


        // POST api/<LampController>
        [HttpPost]
        public async Task<IActionResult> Post(Lamps lamp)
        {
            return Ok(await _repository.Add(lamp));
        }


        // PUT api/<LampController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Lamps lamp)
        {
            //lamp.DateTimeUpdate = DateTime.Now;
            //await _repository.Update(lamp).ConfigureAwait(false);
            var value = lamp.Status ? "1" : "0";
            await _mqtt.PublishAsync(lamp.TopicUp, value);
            return Ok(lamp);
        }

        // DELETE api/<LampController>/5
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