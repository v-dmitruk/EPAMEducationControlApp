using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Infrastructure
{
    public class ServicesModule : NinjectModule
    {
        private string connectString;
        public ServicesModule(string connectionString)
        {
            connectString = connectionString;
        }
        public override void Load()
        {
            Bind<IBLLUnitOfWork>().To<BLLUnitOfWork>().WithConstructorArgument(connectString);
        }
    }
}