using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using HRSA.Core.DataAccess.DataModel;

namespace HRSA.Core.DataAccess.Repository
{
    public interface IDbDataContext
    {
        DbSet<Page> Pages { get; set; }
        int SaveChanges();
    }

    public class PageDbDataContext : DbContext, IDbDataContext 
    {
        public PageDbDataContext(DbConnection connection)
            : base(connection, true)
        {
           
        }

        public DbSet<Page> Pages { get; set; }

    }
}
