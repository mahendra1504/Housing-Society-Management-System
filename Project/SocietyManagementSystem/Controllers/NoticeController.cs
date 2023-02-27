using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Controllers
{
    public class NoticeController : Controller
    {
        private readonly SocietyManagmentContext _context;
        public NoticeController(SocietyManagmentContext context)
        {
            _context = context;
        }

        [Authorize]
        [Route("GiveNotice")]
        public IActionResult GiveNotice()
        {
            return View();
        }

        [HttpPost]  
        [Route("GiveNotice")]
        public IActionResult GiveNotice(Notice notice)
        {
            if(ModelState.IsValid)
            {
                var data = new Notice()
                {
                    notice_subject = notice.notice_subject,
                    notice_detail = notice.notice_detail,
                    notice_date = DateTime.Now
                };
                _context.Notice.Add(data);
                _context.SaveChanges();
                ModelState.Clear();
            }

            return RedirectToAction("ManageNotice");
        }

        [Route("ManageNotice")]
        [Authorize]
        public IActionResult ManageNotice(Notice notice)
        {
            var data = _context.Notice.ToList();
            return View(data);
        }
        [Route("ViewNotice")]
        [Authorize]
        public IActionResult ViewNotice(Notice notice)
        {
            var data = _context.Notice.ToList();
            return View(data);
        }

        [Route("DeleteNotice")]
        [HttpGet]
        public IActionResult DeleteNotice(int id)
        {
            var data = _context.Notice.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        
        [HttpPost]
        public IActionResult Delete(Notice notice)
        {
            _context.Notice.Remove(notice);
            _context.SaveChanges();
            return RedirectToAction("ManageNotice");
        }

        [Route("EditNotice")]
        [HttpGet]
        public IActionResult EditNotice(int id)
        {
            var data = _context.Notice.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }

        [Route("EditNotice")]
        [HttpPost]
        public IActionResult EditNotice(Notice notice)
        {
            _context.Notice.Update(notice);
            _context.SaveChanges();
            return RedirectToAction("ManageNotice");
        }

    }
}
