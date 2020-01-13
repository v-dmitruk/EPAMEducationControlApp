using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using API.Models;

namespace API.Controllers
{
    public class RoleController : ApiController
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var roles = UserService.GetRoles();
            List<RoleModel> result = new List<RoleModel>();
            foreach (var item in roles)
            {
                RoleModel role = new RoleModel { Id = item.Id, Name = item.Name };
                result.Add(role);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
