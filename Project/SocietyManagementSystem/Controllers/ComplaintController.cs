using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly SocietyManagmentContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ComplaintController(SocietyManagmentContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       public IActionResult GiveComplaint()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GiveComplaintAsync(Complaint complaint)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            // ApplicationUser applicationUser = await _userManager.FindByEmailAsync(User.ToString());
            // string userEmail = applicationUser.Email.ToString();
            var data = new Complaint
            {
                complaint_subject = complaint.complaint_subject,
                complaint_detail = complaint.complaint_detail,
                Member_mail = user.Email,
                house_no = user.House_no,
                complaint_status = "Pending",
                complaint_date = DateTime.Now,
                solution = complaint.solution
            };
            _context.Add(data);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("MyComplaint");
        }

        public IActionResult AllComplaints()
        {
            var data = _context.Complaint.ToList();
            return View(data);
        }

        public IActionResult ComplaintDetails(int id)
        {
            var data = _context.Complaint.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public IActionResult ComplaintSolution(int id)
        {
            var data = _context.Complaint.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult ComplaintSolution(Complaint complaint)
        {
            complaint.complaint_status = "Replied";
            _context.Complaint.Update(complaint);
            _context.SaveChanges();
            return View();
        }

        public async Task<IActionResult> MyComplaint()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var data = _context.Complaint.Where(x => x.Member_mail == user.Email.ToString());
            return View(data);
        }

        public IActionResult MyComplaintDetails(int id)
        {
            var data = _context.Complaint.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public IActionResult EditComplaint(int id)
        {
            var data = _context.Complaint.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditComplaint(Complaint complaint)
        {
            _context.Update(complaint);
            _context.SaveChanges();
            return RedirectToAction("MyComplaint");
        }

        public IActionResult DeleteComplaint(int id)
        {
            var data = _context.Complaint.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult DeleteComplaint(Complaint complaint)
        {
            _context.Remove(complaint);
            _context.SaveChanges();
            return RedirectToAction("MyComplaint");
        }

        public IActionResult ComplaintReport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComplaintReportData(string filter)
        {
            if(filter == "0")
            {
                var data = _context.Complaint.Where(x => x.complaint_status == "Replied").ToList();
                return new ViewAsPdf(data);
            }
            else
            {
                var data = _context.Complaint.Where(x => x.complaint_status == "Pending").ToList();
                return new ViewAsPdf(data);
            }
           
        }
    }
}
