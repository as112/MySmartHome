﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Repositories.Interfaces;
using MySmartHome.DAL.Models;
using MySmartHome.DAL.Data;

namespace MySmartHomeWebApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryRepository<HistoryData> _repository;

        public HistoryController(IHistoryRepository<HistoryData> repository)
        {
            _repository = repository;
        }

        // POST: api/History/name
        [HttpPost("name")]
        public async Task<ActionResult> GetAllByName([FromBody] string name)
        {
            return Ok(await _repository.GetAllByName(name));
        }

        // POST: api/History/topic
        [HttpPost("topic")]
        public async Task<ActionResult> GetAllByTopic([FromBody] string topic)
        {
            return Ok(await _repository.GetAllByTopic(topic));
        }

        // POST: api/History/name
        [HttpPost("name/last")]
        public async Task<ActionResult> GetLastByName([FromBody] string name)
        {
            return Ok(await _repository.GetLastByName(name));
        }

        // GET: api/History/last/name/7
        [HttpGet("last/{name}/{take}")]
        public async Task<ActionResult> GetLastNByName(string name, int take)
        {
            return Ok(await _repository.GetLastNByName(name, take));
        }
        // POST: api/History
        [HttpPost]
        public async Task<ActionResult> PostHistoryData(HistoryData historyData)
        {
            historyData.DateTimeUpdate = DateTime.Now;
            return Ok(await _repository.Add(historyData));
        }

        // DELETE: api/History/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryData(Guid id)
        {
            return Ok(await _repository.DeleteById(id));
        }

        // DELETE: api/History/5
        [HttpDelete("delete/{daysAgo}")]
        public async Task<IActionResult> DeleteHistoryData(int daysAgo)
        {
            return Ok(await _repository.DeleteAllUntilDate(daysAgo));
        }

        // POST: api/History/filter
        [HttpPost("filter")]
        public async Task<ActionResult> GetData(DataForHistoryFilter data)
        {
            if (data.HourAgoFrom < data.HourAgoTo)
                return NoContent();
            var result = await _repository
                .GetAllWithPredicate(s =>
                    s.Name == data.Name &&
                    s.DateTimeUpdate >= DateTime.Now.ToUniversalTime().AddHours(-1 * data.HourAgoFrom) &&
                    s.DateTimeUpdate <= DateTime.Now.ToUniversalTime().AddHours(-1 * data.HourAgoTo))
                .ConfigureAwait(false);
            return Ok(result);
        }

    }
}
