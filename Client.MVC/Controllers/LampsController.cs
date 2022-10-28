using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;
using WebApiClients.Repositories;

namespace Client.MVC.Controllers
{
    public class LampsController : Controller
    {
        private readonly HttpClient _client;
        private readonly WebRepository<Lamps> _repository;

        public LampsController(IEntityRepository<Lamps> repository, HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _repository = (WebRepository<Lamps>)repository;
        }

        // GET: Lamps
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View( await _repository.GetAll());
        }
        
        // GET: Lamps/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!await _repository.ExistId(id ?? Guid.Empty))
                return NotFound();

            var lamps = await _repository.GetById(id ?? Guid.Empty);
            if (lamps == null)
                return NotFound();

            return View(lamps);
        }

        // GET: Lamps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lamps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTimeUpdate,Name,Status,Topic,TopicStatus")] Lamps lamp)
        {
            if (ModelState.IsValid)
            {
                lamp.Id = Guid.NewGuid();
                await _repository.Add(lamp);
                return RedirectToAction(nameof(Index));
            }
            return View(lamp);
        }

        // GET: Lamps/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!await _repository.ExistId(id ?? Guid.Empty))
                return NotFound();

            var lamps = await _repository.GetById(id ?? Guid.Empty);
            if (lamps == null)
                return NotFound();
            return View(lamps);
        }

        // POST: Lamps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Lamps lamp)
        {
            if (id != lamp.Id)
                return NotFound();
            var oldLamp = await _repository.GetAll();
            lamp.DateTimeUpdate = DateTime.Now;
            lamp.RoomName = oldLamp.First(s => s.Name == lamp.Name).RoomName;
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(lamp);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lamp);
        }

        // GET: Lamps/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!await _repository.ExistId(id ?? Guid.Empty))
                return NotFound();

            var lamps = await _repository.GetById(id ?? Guid.Empty);
            if (lamps == null)
                return NotFound();

            return View(lamps);
        }

        // POST: Lamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (!await _repository.ExistId(id))
                return Problem("Entity set 'DataContext.Lamps'  is null.");

            await _repository.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
