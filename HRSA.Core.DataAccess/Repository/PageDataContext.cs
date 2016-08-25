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
        IQueryable<Page> Pages { get;}
        int SaveChanges();
        void Dispose();
    }

    public class PageDbDataContext : DbContext, IDbDataContext 
    {
        public PageDbDataContext(DbConnection connection)
            : base(connection, true)
        {
           
        }

        public IQueryable<Page> Pages {
            get
            {
                return this.Set<Page>();
            }
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Page>().ToTable("Pages");
            
        }
    }
}
