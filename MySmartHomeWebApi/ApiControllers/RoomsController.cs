using Microsoft.AspNetCore.Mvc;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Models;
using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Data.Interfaces;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySmartHomeWebApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private readonly ILogger<RoomsController> _logger;
        private readonly DbEntityRepository<Rooms> _repository;

        public RoomsController(ILogger<RoomsController> logger, IEntityRepository<Rooms> repository)
        {
            _logger = logger;
            _repository = (DbEntityRepository<Rooms>)repository;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var item = await _repository.GetWithInclude(s => s.Sensors!, l => l.Lamps!);
            return item.Count() == 0 ? NotFound() : Ok(item);
        }

        
        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await _repository.GetWithInclude(p => p.Id == id, s => s.Sensors!, l => l.Lamps!);
            return item.Count() == 0 ? NotFound() : Ok(item.FirstOrDefault());
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<IActionResult> Post(Rooms room)
        {
            return Ok(await _repository.Add(room));
        }

        // PUT api/<RoomsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Rooms room)
        {
            return Ok(await _repository.Update(room));
            //var oldRoom = await _repository.GetById(id).ConfigureAwait(false);
            //await _repository.Delete(oldRoom!).ConfigureAwait(false);
            //return Ok(await _repository.Add(room).ConfigureAwait(false));
        }

        // DELETE api/<RoomsController>/5
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
