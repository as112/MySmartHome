using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Models;

namespace Client.MVC.Controllers
{
    public class RoomsController : Controller
    {
        private readonly DataContext _context;

        public RoomsController(DataContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rooms?
                  .AsNoTracking()
                  .Include(r => r.Lamps)
                  .Include(r => r.Sensors)
                  .ToListAsync()!);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .AsNoTracking()
                .Include(r => r.Lamps)
                .Include(r => r.Sensors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Rooms/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Rooms room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        room.Id = Guid.NewGuid();
        //        _context.Add(room);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(room);
        //}

        //// GET: Rooms/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Rooms == null)
        //    {
        //        return NotFound();
        //    }

        //    var room = await _context.Rooms
        //        .FindAsync(id);

        //    if (room == null)
        //    {
        //        return NotFound();
        //    }
        //    var lampSelectList = await _context.Lamps.OrderBy(s => s.TopicUp).ToListAsync();
        //    ViewBag.AllLamps = new MultiSelectList(lampSelectList);
        //    var sensorSelectList = await _context.Sensors.OrderBy(s => s.TopicUp).ToListAsync();
        //    ViewBag.AllSensors = new MultiSelectList(sensorSelectList);
        //    return View(room);
        //}

        //// POST: Rooms/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, string[] selectedLamps, string[] selectedSensors, Rooms room)
        //{
        //    if (id != room.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var lampList = new List<Lamps>();
        //            var sensorList = new List<Sensors>();
        //            foreach (var lampName in selectedLamps)
        //            {
        //                var lamp = _context.Lamps?.Where(s => s.Name.Equals(lampName)).FirstOrDefault();
        //                if(lamp is not null)
        //                {
        //                    lamp.Room = room;
        //                    _context.Update(lamp);
        //                    lampList.Add(lamp);
        //                }
        //            }
        //            foreach (var sensorName in selectedSensors)
        //            {
        //                var sensor = _context.Sensors?.Where(s => s.Name.Equals(sensorName)).FirstOrDefault();
        //                if(sensor is not null)
        //                {
        //                    sensor.Room = room;
        //                    _context.Update(sensor);
        //                    sensorList.Add(sensor);
        //                }
        //            }
        //            room.Lamps = (lampList.Count > 0) ? lampList : null;
        //            room.Sensors = (sensorList.Count > 0) ? sensorList : null;
        //            _context.Update(room);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoomsExists(room.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(room);
        //}

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'RoomContext.Rooms'  is null.");
            }
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms != null)
            {
                _context.Rooms.Remove(rooms);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomsExists(Guid id)
        {
          return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
