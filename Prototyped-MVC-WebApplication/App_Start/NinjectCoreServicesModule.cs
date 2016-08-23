using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using HRSA.Core.DataAccess.Service;
using HRSA.Core.DataAccess.Repository;

namespace Prototyped_MVC_WebApplication.App_Start
{
    public class NinjectCoreServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbDataContext>().To<PageDbDataContext>();
            Bind<IPageService>().To<PageService>();
        }
    }
}