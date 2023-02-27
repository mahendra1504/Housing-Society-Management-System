using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SocietyManagementSystem.Controllers
{
    public class RegistrationLoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SocietyManagmentContext _context;
        public IEnumerable<House> data { get; set; }


        public RegistrationLoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SocietyManagmentContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
         

        }
        [Route("Registration")]
        public async Task<IActionResult> SignUpAsync()
        {
            /* var data = (from SocietyHouse in _context.SocietyHouse
                         select new SelectListItem()
                         {
                             Text = SocietyHouse.house_no.ToString(),
                             Value = SocietyHouse.house_no.ToString()

                         }).ToList();*/
             var data = await _context.Houses.Select(x => new House()
             {
                 house_no = x.house_no
             }).ToListAsync();
             ViewBag.house_no = data;
            return View();
        }

        [Route("Registration")]
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(Registration registration)
        {
            /*var data = (from SocietyHouse in _context.SocietyHouse
                        select new SelectListItem()
                        {
                            Text = SocietyHouse.house_no.ToString(),
                            Value = SocietyHouse.house_no.ToString()

                        }).ToList();
             ViewBag.house_no = data;*/
            var data = await _context.Houses.Select(x => new House()
            {
                house_no = x.house_no
            }).ToListAsync();
            ViewBag.house_no = data;
            
             ViewBag.house_no = data;
        

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = registration.Email,
                    UserName = registration.Firstname,
                    Firstname = registration.Firstname,
                    Lastname = registration.Lastname,
                    Member_Type = registration.MemberType,
                    House_no = registration.house_no,
                    Mobileno = registration.Mobileno,
                    DateOfBirth = registration.Dob,
                    Total_Members = registration.Total_Members,
                    approve_status = 0,
                    vechiles = registration.vechiles
                };

                var result = await _userManager.CreateAsync(user, registration.Password);

                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View();
                }
                else
                {
                    if(registration.MemberType == "Owner")
                    {
                        await _userManager.AddToRoleAsync(user, "Owner");
                    }
                    else if(registration.MemberType == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Renter");
                    }
                    ModelState.Clear();
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("SignIn");
        }

        [Route("Login")]
       
        public IActionResult SignIn()
        {
            return View();
        }


        [Route("Login")]
       
        [HttpPost]
        public async Task<IActionResult> SignIn(Login login)
        {
            if(ModelState.IsValid)
            {
                var data = _context.Users.Where(x => x.Email == login.Email).Select(x => x.approve_status).FirstOrDefault();
                if (data == 1)
                {
                    IdentityUser identityUser = await _userManager.FindByEmailAsync(login.Email);

                    var result = await _signInManager.PasswordSignInAsync(identityUser.UserName, login.Password, login.RememberMe, false);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You are not approved by secretary");
                }
            }
            return View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "RegistrationLogin");
        }
        public JsonResult getHouses(string myString)
        {
            House model = new House();
           
            if (String.Equals(myString,"Owner"))
            {
                 var data = (from house in _context.Houses
                            where house.allocatioin_status == 0
                            select house.house_no).ToList();
                var json = JsonConvert.SerializeObject(data);
                
                return Json(json);
            }
            else if(String.Equals(myString,"Renter"))
            {

               var  data = (from house in _context.Houses
                            where house.allocatioin_status == 1
                            select house.house_no).ToList();
                var json = JsonConvert.SerializeObject(data);
               
                return Json(json);
            }
           
            return Json(null);

        }
       
    }
}
