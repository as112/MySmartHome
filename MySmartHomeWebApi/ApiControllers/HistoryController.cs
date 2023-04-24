using Microsoft.AspNetCore.Mvc;
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
        private readonly DbHistoryRepository<HistoryData> _repository;

        public HistoryController(IHistoryRepository<HistoryData> repository)
        {
            _repository = (DbHistoryRepository<HistoryData>)repository;
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

        // POST: api/History
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        //// POST: api/History/filter
        //[HttpPost("filter")]
        //public async Task<ActionResult> GetData([FromBody] string name, int hourAgoFrom, int hourAgoTo)
        //{
        //    if(hourAgoFrom < hourAgoTo)
        //        return NoContent();
        //    var result = await _repository
        //        .GetAllWithPredicate(s =>
        //            s.Name == name &&
        //            s.DateTimeUpdate >= DateTime.Now.AddHours(-1 * hourAgoFrom) &&
        //            s.DateTimeUpdate <= DateTime.Now.AddHours(-1 * hourAgoTo))
        //        .ConfigureAwait(false);
        //    return Ok(result);
        //}

        // POST: api/History/filter
        [HttpPost("filter")]
        public async Task<ActionResult> GetData(DataForFilter data)
        {
            if (data.hourAgoFrom < data.hourAgoTo)
                return NoContent();
            var result = await _repository
                .GetAllWithPredicate(s =>
                    s.Name == data.name &&
                    s.DateTimeUpdate >= DateTime.Now.ToUniversalTime().AddHours(-1 * data.hourAgoFrom) &&
                    s.DateTimeUpdate <= DateTime.Now.ToUniversalTime().AddHours(-1 * data.hourAgoTo))
                .ConfigureAwait(false);
            return Ok(result);
        }

    }
    public class DataForFilter
    {
        public string name { get; set; }
        public int hourAgoFrom { get; set; }
        public int hourAgoTo { get; set; }
    }
}
