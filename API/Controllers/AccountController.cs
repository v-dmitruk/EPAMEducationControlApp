using API.Models;
using BLL.DTOModels;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountController : ApiController
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }


        //// Cookie based authorization
        //[HttpPost]
        //[Route("api/User/LogIn")]
        //public async Task<IHttpActionResult> Login(LoginModel model)
        //{
        //    await SetInitialDataAsync();
        //    if (ModelState.IsValid)
        //    {
        //        UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
        //        ClaimsIdentity claim = await UserService.Authenticate(userDto);
        //        if (claim == null)
        //        {
        //            ModelState.AddModelError("", "Неверный логин или пароль.");
        //        }
        //        else
        //        {
        //            AuthenticationManager.SignOut();
        //            AuthenticationManager.SignIn(new AuthenticationProperties
        //            {
        //                IsPersistent = true
        //            }, claim);                    
        //        }
        //        return Ok();
        //    }
        //    return BadRequest();
        //}


        [HttpGet]
        [Route("api/GetUserClaims")]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            try
            {
                AccountModel model = new AccountModel()
                {
                    Id = identityClaims.FindFirst("UserID").Value,
                    UserName = identityClaims.FindFirst("Username").Value,
                    Email = identityClaims.FindFirst("Email").Value,
                    FirstName = identityClaims.FindFirst("FirstName").Value,
                    LastName = identityClaims.FindFirst("LastName").Value,
                    BirthdayDate = identityClaims.FindFirst("BirthdayDate").Value,
                    LoggedOn = identityClaims.FindFirst("LoggedOn").Value,
                    Expired = identityClaims.FindFirst("Expiration").Value,
                    Role = identityClaims.FindFirst("Role").Value
                };
                return model;
            }
            catch
            {
                return null;
            }
        }


        [HttpGet]
        [Route("api/User/LogOut")]
        [AllowAnonymous]
        public IHttpActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return Ok();
        }


        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IdentityResult> Register(AccountModel model)
        {
            await SetInitialDataAsync();
            UserDTO userDto = new UserDTO
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                //BirthdayDate = (DateTime?)Convert.ToDateTime(model.BirthdayDate),
                Role = model.Role
            };
            if (string.IsNullOrEmpty(model.BirthdayDate))
                userDto.BirthdayDate = null;
            else 
            {
                userDto.BirthdayDate = (DateTime?)Convert.ToDateTime(model.BirthdayDate);
            }
            try
            {
                IdentityResult result = await UserService.Create(userDto);
                return result;
            }
            catch (Exception ex)
            {
                return new IdentityResult(ex.Message);
            }
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "admin@ukr.net",
                UserName = "GDE_ZDES_VIHOD",
                Password = "12345",
                FirstName = "Vladimir",
                LastName = "Dmitruk",
                BirthdayDate = new DateTime(1991,9,25),
                Role = "admin",
            }, new List<string> { "student", "visitor", "teacher", "admin" });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "student")]
        [Route("api/ForStudentRole")]
        public string ForStudentRole()
        {
            return "For student role";
        }

        [HttpGet]
        [Authorize(Roles = "student,visitor")]
        [Route("api/ForStudentOrVisitor")]
        public string ForStudentOrVisitor()
        {
            return "For student/reader role";
        }
    }
}
