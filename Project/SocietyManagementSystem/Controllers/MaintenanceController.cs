using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly SocietyManagmentContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
      //  public readonly IFormCollection _fc;
        // private  Maintenance _maintenance;

        public MaintenanceController(SocietyManagmentContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            //_fc = fc;
            //_maintenance = maintenance;
        }
        public IActionResult Maintenance()
        {
            Maintenance maintenance = new Maintenance();

            var date = _context.Maintenance.OrderByDescending(x=>x.Maintenance_date).Select(x => x.Maintenance_date).FirstOrDefault();

            var NewMaintenanceDate = date.AddMonths(3);
            if (NewMaintenanceDate == DateTime.Now)
            {

                var user = _context.Users.Where(x => x.approve_status == 1).Where(x => x.UserName != "Administrator").Select(x => x.Email).ToList();
                //  var houseno = _context.Users.Where(x=>x.Email == user).Select(x => x.House_no);
                foreach (var items in user)
                {
                    var houseno = _context.Users.Where(x => x.Email == items).Select(x => x.House_no).FirstOrDefault();
                    var housetype = _context.Houses.Where(x => x.house_no == houseno).Select(x => x.house_type).FirstOrDefault();
                    var vehicle = _context.Users.Where(x => x.Email == items).Select(x => x.vechiles).FirstOrDefault();
                    var fname = _context.Users.Where(x => x.Email == items).Select(x => x.Firstname).FirstOrDefault();
               
                    if (housetype.TrimEnd() == "OneBHK")
                    {
                        maintenance.housetype_charge = _context.Charges.Where(x=>x.charge_name == "OneBHK").Select(x => x.charge_amount).FirstOrDefault();
                    }
                    if (housetype.TrimEnd() == "TwoBHK")
                    {
                        maintenance.housetype_charge = _context.Charges.Where(x =>x.charge_name == "TwoBHK").Select(x => x.charge_amount).FirstOrDefault();
                    }
                    if (housetype.TrimEnd() == "ThreeBHK")
                    {
                       maintenance.housetype_charge = _context.Charges.Where(x =>x.charge_name == "ThreeBHK").Select(x => x.charge_amount).FirstOrDefault();
                    }
                    if (vehicle > 2)
                    {
                        maintenance.Parking_charge = 500;

                    }
                    if (vehicle == 2)
                    {
                        maintenance.Parking_charge = _context.Charges.Where(x => x.charge_name == "Parking").Select(x => x.charge_amount).FirstOrDefault();
                    }
                    if (vehicle < 2)
                    {
                        maintenance.Parking_charge = _context.Charges.Where(x => x.charge_name == "Parking").Select(x => x.charge_amount).FirstOrDefault();

                    }
                    maintenance.Member_mail = items;
                    maintenance.house_no = houseno;
                    maintenance.Member_name = fname;
                    maintenance.water_charge = _context.Charges.Where(x => x.charge_name == "Water").Select(x => x.charge_amount).FirstOrDefault();
                    maintenance.service_charge = _context.Charges.Where(x => x.charge_name == "Service").Select(x => x.charge_amount).FirstOrDefault();
                    maintenance.electricity_charge = _context.Charges.Where(x => x.charge_name == "Electricity").Select(x => x.charge_amount).FirstOrDefault();
                    maintenance.Total_Amount = maintenance.water_charge + maintenance.service_charge + maintenance.electricity_charge + maintenance.housetype_charge + maintenance.Parking_charge;
                    var data = new Maintenance
                    {
                        house_no = maintenance.house_no,
                        Member_name = maintenance.Member_name,
                        Member_mail = maintenance.Member_mail,
                        water_charge = maintenance.water_charge,
                        electricity_charge = maintenance.electricity_charge,
                        Parking_charge = maintenance.Parking_charge,
                        service_charge = maintenance.service_charge,
                        housetype_charge = maintenance.housetype_charge,
                        Total_Amount = maintenance.Total_Amount,
                        Maintenance_date = DateTime.Now,
                        Due_Date = DateTime.Now.AddMonths(1),
                        status = 0,
                        sending_status = 0

                    };

                    _context.Maintenance.Add(data);
                }
                _context.SaveChanges();
               
            }
            else
            {
                //  ViewData["Error"] = "Maintenance Already Generated for this month";
                //ModelState.AddModelError("Error", "Maintenance Already Generated For This Month");
               
                return RedirectToAction("MaintenanceMember" ,new { @error = "Maintenance already generated for this month"});
            }
            return RedirectToAction("ManageMaintenance");
        }

        public IActionResult ManageMaintenance()
        {
            var data = _context.Maintenance.Where(x=>x.sending_status == 0).ToList();
            return View(data);
        }

        public IActionResult MaintenanceDetails(int id)
        {
            var data = _context.Maintenance.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult MaintenanceEdit(int id)
        {
            var data = _context.Maintenance.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult MaintenanceEdit(Maintenance maintenance)
        {
            _context.Maintenance.Update(maintenance);
            _context.SaveChanges();
            return RedirectToAction("ManageMaintenance");
        }


        [HttpGet]
         public IActionResult MaintenanceDelete(int id)
        {
            var data = _context.Maintenance.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult MaintenanceDelete(Maintenance maintenance)
        {
            _context.Remove(maintenance);
            _context.SaveChanges();
            return RedirectToAction("ManageMaintenance");
        }
        public IActionResult SendMaintenance()
        {
            var data = _context.Maintenance.Where(x => x.sending_status == 0).ToList();
           // var user_mails = _context.Maintenance.Where(x => x.sending_status == 0).Select(x => x.Member_mail);
            //var user_name = _context.Maintenance.Where(x => x.sending_status == 0).Select(x => x.Member_mail);

            
            foreach (var name in data)
            {
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.To.Add(name.Member_mail);
                        mailMessage.From = new MailAddress("priyanshi.prajapati2019@gmail.com");
                        mailMessage.Subject = "Maintenance";
                        mailMessage.IsBodyHtml = false;
                        //string body_data = GetEmailBody();
                        mailMessage.Body = "Hello," + name.Member_name + " kindly check your Maintenance";
                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Port = 587;
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new System.Net.NetworkCredential("iet026priyanshi@gmail.com", "priyanshi2001");

                        smtpClient.Send(mailMessage);
                        name.sending_status = 1;
            }
            _context.SaveChanges();

            return RedirectToAction("ManageMaintenance");
        }

        public IActionResult MaintenanceMember(string error)
        {
            ViewBag.Maintenance = error;
            var data = _context.Users.Where(x => x.Member_Type != "Admin").Select(x => new Registration
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

        public IActionResult MaintenanceMemberDetails(string id)
        {
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
                house_no = x.House_no

            }).FirstOrDefault();
            return View(data);
        }

        public async Task<IActionResult> PayMaintenance()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var data = _context.Maintenance.Where(x => x.Member_mail == user.Email).Where(x=>x.status == 0).Where(x=>x.sending_status == 1).ToList();
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("NoMaintenance");
            }
           
        }
        public IActionResult PayMaintenanceDetail(int id)
        {
            var data = _context.Maintenance.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public IActionResult NoMaintenance()
        {
            return View();
        }

        
        public IActionResult PayNowMaintenance()
        {
            return View();
        }

        public async Task<IActionResult> CreateOrder(Maintenance maintenance,int id)
        {
            var data = _context.Maintenance.Where(x => x.Id == id).FirstOrDefault();
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_xLEDAQ074DHwtB", "Ks6Icf0844dqCcD2E8SqAfBC");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", data.Total_Amount * 100);  // Amount will in paise
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
                amount = data.Total_Amount * 100,
                currency = "INR",
                name = data.Member_name,
                email = data.Member_mail,
                contactNumber = user.Mobileno,
                address = "Society Managment System",
                description = "Society Maintenance",
                Maintenance_id = id
            };

            // Return on PaymentPage with Order data
            return View("PaymentPage", orderModel);
           
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
            public int Maintenance_id { get; set; }
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

            string maintenance_id = fc["Maintenance_id"];

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
                return RedirectToAction("Success", new { id = maintenance_id});
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }
        public async Task<IActionResult> Success(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var data = _context.Maintenance.Where(x => x.Member_mail == user.Email).FirstOrDefault();
            data.status = 1;
            var transaction = new Transaction
            {
                Maintenance_id= data.Id, 
                Charge_id = -1,
                transaction_name = "Maintenance",
                member_name = data.Member_name,
                member_email = data.Member_mail,
                house_no = data.house_no,
                transaction_amount = data.Total_Amount,
                transaction_date = DateTime.Now,
            };
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            var member_maintenance = _context.Maintenance.Where(x =>x.Id.ToString() == id).ToList();
            return new ViewAsPdf(member_maintenance);
        }

        public IActionResult Failed()
        {
            return RedirectToAction("PayMaintenance");
        }

        public IActionResult MaintenanceReport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MaintenanceReportData(string status,DateTime start_date,DateTime end_date,string filter)
        {
           
            if (filter == "0")
            {
                if (status == "0")
                {
                    var data = _context.Maintenance.Where(x => x.status == 1).ToList();
                    return new ViewAsPdf(data);
                }
                else
                {
                    var data = _context.Maintenance.Where(x => x.status == 0).ToList();
                    return new ViewAsPdf(data);
                }
            }
           else if(filter == "1")
            {
                string startdate = start_date.ToString("dd/MM/yyyy");
                DateTime sdate = DateTime.Parse(startdate);
                string enddate = end_date.ToString("dd/MM/yyyy");
                DateTime edate = DateTime.Parse(enddate);
                var data = _context.Maintenance.Where(x => x.Maintenance_date >= sdate).Where(x=>x.Maintenance_date <= edate).ToList();
                return new ViewAsPdf(data);
            }
            return View();
        }

        public IActionResult TransactionReport()
        {
            return View();
        }

        public IActionResult TransactionReportData(string filter,string transaction_type,DateTime start_date,DateTime end_date)
        {
            if(filter == "0")
            {
                if(transaction_type == "0")
                {
                    var data = _context.Transaction.Where(x => x.transaction_name == "Maintenance").ToList();
                    return new ViewAsPdf(data);
                }
                else
                {
                    var data = _context.Transaction.Where(x => x.transaction_name == "Extra Charge").ToList();
                    return new ViewAsPdf(data);
                }
            }
            else
            {
                string startdate = start_date.ToString("dd/MM/yyyy");
                string enddate = end_date.ToString("dd/MM/yyyy");
                DateTime sdate = DateTime.Parse(startdate);
                DateTime edate = DateTime.Parse(enddate);
                var data = _context.Transaction.Where(x => x.transaction_date >= sdate).Where(x => x.transaction_date <= edate).ToList();
                return new ViewAsPdf(data);
            }
            return View();
        }
    }
}
