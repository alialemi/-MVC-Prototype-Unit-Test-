using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using System.Data.Common;
using System.Data.SqlClient;

namespace Prototyped_MVC_WebApplication.App_Start
{
    public class NinjectDbConnectionModule: NinjectModule
    {
        private readonly string pageConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=""C:\Users\ali.alemi\Documents\Visual Studio 2013\Projects\HRSA-Prototype-MVCApplication\HRSA-Prototype-EHBs\HRSA.Core.DataAccess\DbFile\HRSA-Prototype-Database.mdf"";Integrated Security=True";
        public override void Load()
        {
            this.Bind<DbConnection>()
                .To<SqlConnection>()
                .WithConstructorArgument(pageConnectionString);
        }
    }
}