using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Controllers
{
    public class Feedback : Controller
    {
        private readonly SocietyManagmentContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public Feedback(SocietyManagmentContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        [Route("GiveFeedback")]
        
        public IActionResult GiveFeedback()
        {
            return View();
        }

        [Authorize]
        [Route("GiveFeedback")]
        [HttpPost]
        public async Task<IActionResult> GiveFeedback(GiveFeedback giveFeedback)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var user_email = user.Email;
                var houseno = user.House_no;
                var data = new GiveFeedback()
                {
                    feedback_subject = giveFeedback.feedback_subject,
                    feedback_detail = giveFeedback.feedback_detail,
                    owner_email = user_email,
                    houseno = houseno
                };
                _context.Feedback.Add(data);
                _context.SaveChanges();
                ModelState.Clear();
                
              //  string script = "<script type = 'text/javascript'>alert('Feedback sent successfully');</script>";

            }
            else
            {
                ModelState.AddModelError("", "");

            }
            return View();
        }

        [Authorize]
        [Route("ViewFeedback")]

        public IActionResult ViewFeedback()
        {
            var data = _context.Feedback.ToList();
            return View(data);
        }

    }
}
