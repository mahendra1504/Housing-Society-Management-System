using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;

namespace SocietyManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly SocietyManagmentContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private string path = @"Views/EmailTemplate.html";
     
        //  private readonly SMTPConfigModel _sMTPConfigModel;

        //   private readonly IEmailServices _emailServices;

        public MembersController(SocietyManagmentContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
          //  _sMTPConfigModel = sMTPConfigModel;
        }
        
        [Authorize(Roles ="Admin")]
        [Route("ViewMembers")]
        public IActionResult ViewMembers()
        {
            var data = _context.Users.Where(x=>x.Member_Type!="Admin").Select(x => new Registration
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Mobileno = x.Mobileno,
                Dob = x.DateOfBirth,
                Email = x.Email,
                MemberType = x.Member_Type,
                Total_Members = x.Total_Members,
                house_no = x.House_no

            }).ToList();

            return View(data);
            
        }
        [Authorize(Roles ="Admin")]
        public IActionResult MembersDetail(string id)
        {
            var data1 = _context.Users.Where(x => x.Email == id).Select(x => new Registration
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Mobileno = x.Mobileno,
                Dob = x.DateOfBirth,
                Email = x.Email,
                MemberType = x.Member_Type,
                Total_Members = x.Total_Members,
                house_no = x.House_no

            }).FirstOrDefault();
            return View(data1);
        }

        public IActionResult RemoveUserAsync(string id)
        {
            var data = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
            
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(data.Email);
            mailMessage.From = new MailAddress("no-reply@societymanagement.com");
            mailMessage.Subject = "Registration Request";
            mailMessage.IsBodyHtml = true;
            //string body_data = GetEmailBody();
            mailMessage.Body = "Sorry,"+data.Firstname+"you are not approved by secretary";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.mailtrap.io";
            smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("d70ccb617b1eae", "b5661db267029f");
            smtpClient.Send(mailMessage);
            return RedirectToAction("ViewMembers");
        }
        public IActionResult ApproveMemberAsync(string id)
        {
            var user_data = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            // var house_data = _context.Houses.Where(x => x.house_no == user_data.House_no).FirstOrDefault();
            var house_data = _context.Houses.Where(x => x.house_no == user_data.House_no).FirstOrDefault();
            user_data.approve_status = 1;
            house_data.allocatioin_status = 1;
            _context.SaveChanges();

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(user_data.Email);
            mailMessage.From = new MailAddress("priyanshi.prajapati2019@gmail.com");
            mailMessage.Subject = "Registration Request";
            mailMessage.IsBodyHtml = true;
            string data = GetEmailBody();
            mailMessage.Body = "Hello ,"+user_data.Firstname+"  you are approved by secretary";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("iet026priyanshi@gmail.com", "priyanshi2001");
            smtpClient.Send(mailMessage);

            return RedirectToAction("ViewMembers");
        }

        private string GetEmailBody()
        {
            var data = System.IO.File.ReadAllText(string.Format(path));
            return data;
        }

        public async Task<IActionResult> MyProfile()
        {
            var current_user_data = await _userManager.GetUserAsync(HttpContext.User);
            var data = _context.Users.Where(x => x.Id == current_user_data.Id).Select(x => new Registration
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Mobileno = x.Mobileno,
                Dob = x.DateOfBirth,
                Email = x.Email,
                MemberType = x.Member_Type,
                Total_Members = x.Total_Members,
                house_no = x.House_no,
                vechiles = x.vechiles

            }).FirstOrDefault();
            return View(data);
        }

        public IActionResult EditProfile(string id)
        {

           //  var current_user_data = await _userManager.GetUserAsync(HttpContext.User);
            // ApplicationUser user =  await _userManager.FindByIdAsync(current_user_data.Id);
            var data = _context.Users.Where(x => x.Id == id).Select(x => new Registration
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Mobileno = x.Mobileno,
                Dob = x.DateOfBirth,
                Email = x.Email,
                MemberType = x.Member_Type,
                Total_Members = x.Total_Members,
                house_no = x.House_no,
                vechiles = x.vechiles

            }).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(Registration registration)
        {
            Registration user = new Registration
            {
                Id = registration.Id,
               Firstname = registration.Firstname,
               Lastname = registration.Lastname,
                Mobileno = registration.Mobileno,
                DateOfBirth = registration.Dob,
                Email = registration.Email,
                MemberType = registration.MemberType,
                Total_Members = registration.Total_Members,
               House_no = registration.house_no,
                vechiles = registration.vechiles
            };
            //_context.Users.Update(registration);

          //  IdentityResult result = await _userManager.UpdateAsync(user);
            return RedirectToAction("MyProfile");
        }
    }
}
