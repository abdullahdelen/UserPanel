using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MernisService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UserPanelAPP.Models;
using UserPanelAPP.Models.DTOs;
using UserPanelAPP.Validations.FluentValidation;

namespace UserPanelAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbLocalContext _context;
        private readonly IValidator<User> _validator;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, DbLocalContext context, IValidator<User> validator,IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = _context.Users.Where(x => x.Status == true).ToList();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return View(userDtos);

        }


        public IActionResult CreateUser()
        {

            return View();


        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
           
            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

               
                return View(userDto);
            }
            User existingUser;
            using (var context = new DbLocalContext())
            {
                existingUser = context.Users.FirstOrDefault(u => u.Tcno == userDto.Tcno);
            }

            if (existingUser != null)
            {
                ViewData["ErrorMessage"] = "This User already exist";
                return View("EditUser", userDto);
            }

            bool values = false;
            if (user.BirthDate.HasValue)
            {
                var birthDate = user.BirthDate.Value;
                values = await TCverificationAsync(user.Tcno, user.Name, user.Surname, birthDate);
            }

            if (values)
            {
             

                using (var context = new DbLocalContext())
                {
                    DateTime now = DateTime.Now;
                    System.DateOnly currentDate = new System.DateOnly(now.Year, now.Month, now.Day);
                    user.CreatedDate = currentDate;
                    context.Users.Add(user);

                    context.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewData["ErrorMessage"] = "TcNo verification could not be verified on the Mernis system, please check ";
                return View("EditUser", userDto);

            }

        }

        public IActionResult EditUser(int id)
        {
            User user;
            using (var context = new DbLocalContext())
            {
                user = context.Users.SingleOrDefault(u => u.Id == id);

            }
       
            var userDtos = _mapper.Map<UserDto>(user);
            return View(userDtos);



        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            
            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                
                return View(userDto);
            }


            bool values = false;
            if (user.BirthDate.HasValue)
            {
                var birthDate = user.BirthDate.Value;
                values = await TCverificationAsync(user.Tcno, user.Name, user.Surname, birthDate);
            }

            if (values)
            {


                using (var context = new DbLocalContext())
                {

                    var existingUser = context.Users.FirstOrDefault(u => u.Tcno == user.Tcno);

                    if (existingUser != null)
                    {

                        existingUser.Name = user.Name;
                        existingUser.Surname = user.Surname;
                        existingUser.BirthDate = user.BirthDate;

                        DateTime now = DateTime.Now;
                        System.DateOnly currentDate = new System.DateOnly(now.Year, now.Month, now.Day);
                        existingUser.UpdatedDate = currentDate;

                        context.SaveChanges();
                    }

                }
             

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrorMessage"] = "TcNo verification could not be verified on the Mernis system, please check "; 
                return View("EditUser", userDto);
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {


                using (var context = new DbLocalContext())
                {

                    var existingUser = context.Users.FirstOrDefault(u => u.Id == id);

                    if (existingUser != null)
                    {

                        existingUser.Status = false;
                        context.SaveChanges();
                    }
                    else
                    {

                        return NotFound();
                    }
                }


                return RedirectToAction("Index", "Home");
            }


            return View();
        }
        public async Task<bool> TCverificationAsync(string tc, string name, string surname, DateOnly birthdate)
        {
            
            var client = new MernisService.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            
            var response = client.TCKimlikNoDogrulaAsync(Convert.ToInt64(tc), name, surname, Convert.ToInt16(birthdate.Year)).Result;

           
            return response.Body.TCKimlikNoDogrulaResult;
        }
    }
}

