using DAL.Interfaces;
using DataAccessLayer.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        //private string connectString;
        //public ServiceModule(string connectionString)
        //{
        //    connectString = connectionString;
        //}
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
