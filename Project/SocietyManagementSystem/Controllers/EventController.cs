using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly SocietyManagmentContext _context;

        public EventController(SocietyManagmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEvent(Event @event)
        {
            if(ModelState.IsValid)
            {
                var data = new Event()
                {
                    event_name = @event.event_name,
                    event_date = @event.event_date,
                    event_startime = @event.event_startime,
                    event_endtime = @event.event_endtime,
                    event_detail = @event.event_detail,
                    event_venue = @event.event_venue

                };
                _context.Add(@event);
                _context.SaveChanges();
                ModelState.Clear();
                return View();
            }
            return View();
        }

        public IActionResult ManageEvent()
        {
            var data = _context.Event.ToList();
            return View(data);
        }

        public IActionResult EventDetails(int id)
        {
            var data = _context.Event.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult EventDelete(int id)
        {
            var data = _context.Event.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EventDelete(Event @event)
        {
            _context.Event.Remove(@event);
            _context.SaveChanges();
            return RedirectToAction("ManageEvent");
        }

        [HttpGet]
        public IActionResult EventEdit(int id)
        {
            var data = _context.Event.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EventEdit(Event @event)
        {
            _context.Event.Update(@event);
            _context.SaveChanges();
            return RedirectToAction("ManageEvent");
        }

       public IActionResult ViewEvents()
        {
            var data = _context.Event.ToList();
            return View(data);
        }

        public IActionResult ViewEventDetails(int id)
        {
            var data = _context.Event.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
