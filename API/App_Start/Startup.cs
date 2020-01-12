using API.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(API.App_Start.Startup))]

namespace API.App_Start
{
    public class Startup
    {
        ////-----------------------------------------cookie autorization-----------------------------------------------------------
        //IServiceCreator serviceCreator = new ServiceCreator();
        //public void Configuration(IAppBuilder app)
        //{
        //    app.CreatePerOwinContext<IUserService>(CreateUserService);
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Account/Login"),
        //        ExpireTimeSpan = TimeSpan.FromMinutes(60)
        //    });
        //}

        //private IUserService CreateUserService()
        //{
        //    return serviceCreator.CreateUserService(ConfigurationManager.ConnectionStrings["UserDb"].ToString());
        //}


        //public void Configuration(IAppBuilder app)
        //{
        //    app.UseCors(CorsOptions.AllowAll);
        //OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
        //{
        //    TokenEndpointPath = new PathString("/token"),
        //    Provider = new ApplicationOAuthProvider(),
        //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
        //    AllowInsecureHttp = true
        //};
        //    app.UseOAuthAuthorizationServer(option);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        //}


        //-------------------------token based authorization---------------------------------------------
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService(ConfigurationManager.ConnectionStrings["UserDb"].ToString());
        }
    }
}