using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Controllers
{
    public class ChargesController : Controller
    {
        private readonly SocietyManagmentContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ChargesController(SocietyManagmentContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult NewCharge()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewCharge(Charges charges)
        {
            var data = new Charges
            {
                charge_name = charges.charge_name,
                charge_amount = charges.charge_amount,
                charge_Date = DateTime.Now
                
            };
            _context.Add(data);
            _context.SaveChanges();
            return RedirectToAction("ManageCharges");
        }

        [Authorize]
        public IActionResult ManageCharges()
        {
            var data = _context.Charges.ToList();
            return View(data);
        }

        [Authorize]
        public IActionResult ChargeEdit(int id)
        {
            var data = _context.Charges.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChargeEdit(Charges charges)
        {
            _context.Charges.Update(charges);
            _context.SaveChanges();
            return RedirectToAction("ManageCharges");
        }

        [Authorize]
        public IActionResult DeleteCharge(int id)
        {
            var data = _context.Charges.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteCharge(Charges charges)
        {
            _context.Charges.Remove(charges);
            _context.SaveChanges();
            return RedirectToAction("ManageCharges");
        }

        
        public IActionResult AddExtraCharge()
        {

          /*  var data = _context.Houses.Select(x => new House
            {
                
                house_no = x.house_no

            }).ToList();*/

          //  var houseno = _context.Houses.Select(x => x.house_no.ToString());
            var data = (from Houses in _context.Houses
                       select new SelectListItem()
                       {
                           Text = Houses.house_no.ToString(),
                           Value = Houses.house_no.ToString()

                       }).ToList();
           // Console.WriteLine(data);
            ViewBag.house_no = data;
           // ViewBag.houseno = houseno;
            return View();
        }

        [HttpPost]
        public IActionResult AddExtraCharge(ExtraCharges extraCharges)
        {
            var data = new ExtraCharges
            {
                house_no = extraCharges.house_no,
                charge_type = extraCharges.charge_type,
                Amount = extraCharges.Amount,
                Charge_date = DateTime.Now,
                status = 0
            };
            _context.Extracharge.Add(data);
            _context.SaveChanges();
            var user = _context.Users.Where(x => x.House_no == data.house_no).FirstOrDefault();
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(user.Email);
            mailMessage.From = new MailAddress("priyanshi.prajapati2019@gmail.com");
            mailMessage.Subject = "Extra Charges";
            mailMessage.IsBodyHtml = false;
            //string body_data = GetEmailBody();
            mailMessage.Body = "Hello," + user.Firstname + "Please kindly pay extra charges";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("priyanshi.prajapati2019@gmail.com", "priyanshi12052001");
            smtpClient.Send(mailMessage);
            return View();
        }

        public async Task<IActionResult> ShowCharges()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var house_no = user.House_no;
            var data = _context.Extracharge.Where(x => x.house_no == house_no).Where(x=>x.status == 0).ToList();
            if(data!=null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("NoExtraCharge");
            }
            
        }

        public IActionResult ChargeDetails(int id)
        {
            var data = _context.Extracharge.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public async Task<IActionResult> CreateOrder(int id)
        {
            var charge = _context.Extracharge.Where(x => x.Id == id).FirstOrDefault();
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_xLEDAQ074DHwtB", "Ks6Icf0844dqCcD2E8SqAfBC");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", charge.Amount * 100);  // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 2 - manual
                                                 //options.Add("notes", "-- You can put any notes here --");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            // Create order model for return on view
            OrderModel orderModel = new OrderModel
            {
                orderId = orderResponse.Attributes["id"],
                razorpayKey = "rzp_test_xLEDAQ074DHwtB",
                amount = charge.Amount * 100,
                currency = "INR",
                name = user.Firstname,
                email = user.Email,
                contactNumber = user.Mobileno,
                address = "Society Managment System",
                description = "Extra Charge",
                chargeid = id

            };
            return View("ExtrachargePaymentPage", orderModel);
        }

        public class OrderModel
        {
            public string orderId { get; set; }
            public string razorpayKey { get; set; }
            public int amount { get; set; }
            public string currency { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string contactNumber { get; set; }
            public string address { get; set; }
            public string description { get; set; }

            public int chargeid { get; set; }
        }


        [HttpPost]
        public IActionResult Complete(IFormCollection fc)
        {

            // Payment data comes in url so we have to get it from url

            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            // @Html.HiddenFor(model => model.)
            string paymentId = fc["rzp_paymentid"];

            // This is orderId
            string orderId = fc["rzp_orderid"];

            string chargeid = fc["chargeid"];

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_xLEDAQ074DHwtB", "Ks6Icf0844dqCcD2E8SqAfBC");

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            //// Check payment made successfully

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                // Create these action method
                return RedirectToAction("ExtrachargeSuccess", new { id = chargeid});
            }
            else
            {
                return RedirectToAction("ExtrachargeFailed");
            }
        }

        public async Task<IActionResult> ExtrachargeSuccess(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var houseno = user.House_no;
            //var chargeid = _context.Extracharge.Where(x => x.house_no == houseno).Select(x => x.Id).FirstOrDefault();
            //var transaction_charge_id = _context.Transaction.Where(x => x.house_no == houseno).Where(x=>x.Maintenance_id == -1).Select(x=>x.Charge_id).ToList(); 
            var housecharge = _context.Extracharge.Where(x=>x.Id.ToString() == id).FirstOrDefault();
            housecharge.status = 1;
            var transaction = new Transaction
            {
                Maintenance_id = -1,
                Charge_id = housecharge.Id,
                transaction_name = "Extra Charge",
                house_no = houseno,
                member_name = user.Firstname,
                member_email = user.Email,
                transaction_amount = housecharge.Amount,
                transaction_date = DateTime.Now
            };
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            var user_extracharge = _context.Extracharge.Where(x=>x.Id.ToString() == id).ToList();
            return new ViewAsPdf(user_extracharge);
        }
        
        public IActionResult ExtrachargeFailed()
        {
            return View();
        }
    }
}
