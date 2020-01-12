using BLL.DTOModels;
using BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace API.Infrastructure
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await UserService.GetUserForAuth(new UserDTO { Email = context.UserName, Password = context.Password });
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("FirstName", user.FirstName));
                identity.AddClaim(new Claim("LastName", user.LastName));
                identity.AddClaim(new Claim("UserID", user.Id));
                identity.AddClaim(new Claim("Role", user.Role));
                identity.AddClaim(new Claim("BirthdayDate", user.BirthdayDate.ToString()));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                identity.AddClaim(new Claim("Expiration", (DateTime.Now.AddMinutes(60)).ToString()));
                context.Validated(identity);
            }
            else
                return ;
        }
        private IUserService UserService
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<IUserService>();
            }
        }
    }
}