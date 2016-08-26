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
        Page GetPageByNameUserName(string pageName, string userName);
        int SavePageByUserName(Page page, string userName);
    }

    public class PageService : IPageService
    {
        private readonly IDbDataContext pageDataContext;
        private readonly IUserService userService;

        public PageService(
            IDbDataContext pageDataContext,
            IUserService userService
            )
        {
            this.pageDataContext = pageDataContext;
            this.userService = userService;
        }

        public Page GetPageByName(string pageName)
        {
            return pageDataContext.Pages.Single(p => p.PageName == pageName);
        }

        public Page GetPageByNameUserName(string pageName, string userName)
        {
            var user = userService.GetUserByUserName(userName);
            var page = GetPageByName(pageName);
            if (page.IsVisibleToUser(user))
            {
                return page;
            }

            throw new InvalidOperationException("User Access to this page is denied");
        }

        public int SavePageByUserName(Page page, string userName)
        {
            var user = userService.GetUserByUserName(userName);
            if (page.IsEditableByUser(user))
            {
                var oldPage = GetPageByName(page.PageName);
                oldPage = page;
                return pageDataContext.SaveChanges();
            }
            throw new InvalidOperationException("Insufficient privileges to update this page.");
        }
    }
}
