using HRSA.Core.DataAccess.DataModel;
using HRSA.Core.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSA.Core.DataAccess.Service
{
    public interface IPageService
    {
        Page GetPageByName(string pageName);

    }

    public class PageService : IPageService
    {
        private readonly IDbDataContext pageDataContext;
        public PageService(IDbDataContext pageDataContext)
        {
            this.pageDataContext = pageDataContext;
        }

        public Page GetPageByName(string pageName)
        {
            return pageDataContext.Pages.Single(p => p.PageName == pageName);
        }
    }
}
