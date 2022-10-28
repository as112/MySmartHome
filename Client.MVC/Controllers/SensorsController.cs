using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;
using WebApiClients.Repositories;

namespace Client.MVC.Controllers
{
    public class SensorsController : Controller
    {
        private readonly HttpClient _client;
        private readonly WebRepository<Sensors> _repository;

        public SensorsController(IEntityRepository<Sensors> repository, HttpClient client)
        {
            _client = client;
            _repository = (WebRepository<Sensors>)repository;
        }

        // GET: Sensors
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        // GET: Sensors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!await _repository.ExistId(id ?? Guid.Empty))
            {
                return NotFound();
            }

            var sensor = await _repository.GetById(id ?? Guid.Empty);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }

        // GET: Sensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sensors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTimeUpdate,Name,Value,Topic,TopicStatus")] Sensors sensor)
        {
            if (ModelState.IsValid)
            {
                sensor.Id = Guid.NewGuid();
                await _repository.Add(sensor);
                return RedirectToAction(nameof(Index));
            }
            return View(sensor);
        }

        // GET: Sensors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!await _repository.ExistId(id ?? Guid.Empty))
            {
                return NotFound();
            }

            var sensor = await _repository.GetById(id ?? Guid.Empty);
            if (sensor == null)
            {
                return NotFound();
            }
            return View(sensor);
        }

        // POST: Sensors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DateTimeUpdate,Name,Value,Topic,TopicStatus")] Sensors sensors)
        {
            if (id != sensors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(sensors);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sensors);
        }

        // GET: Sensors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!await _repository.ExistId(id ?? Guid.Empty))
            {
                return NotFound();
            }

            var sensors = await _repository.GetById(id ?? Guid.Empty);
            if (sensors == null)
            {
                return NotFound();
            }

            return View(sensors);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (!await _repository.ExistId(id))
            {
                return Problem("Entity set 'DataContext.Sensors'  is null.");
            }
            await _repository.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
