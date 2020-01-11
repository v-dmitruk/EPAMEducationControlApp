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


        //[HttpPost]
        //public async Task<ActionResult> Login(LoginModel model)
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
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return View(model);
        //}

        [Route("api/User/LogOut")]
        public IHttpActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return Ok();
        }


        [Route("api/User/Register")]
        [HttpPost]
        public async Task<IdentityResult> Register(AccountModel model)
        {
            //await SetInitialDataAsync();
            UserDTO userDto = new UserDTO
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                BirthdayDate = model.BirthdayDate,
                Role = "visitor"
            };
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
    }
}
