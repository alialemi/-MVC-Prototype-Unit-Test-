using HRSA.Core.DataAccess.DataModel;
using HRSA.Core.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototyped_MVP_WebApplication.Presenter
{
    public interface IDefaultPresenter
    {
        Page LoadPage(string pageName);
    }

    public class DefaultPresenter: IDefaultPresenter
    {
        private readonly IPageService pageService;
        public DefaultPresenter(IPageService pageService)
        {
            this.pageService = pageService;
        }



        public Page LoadPage(string pageName)
        {
            return pageService.GetPageByName(pageName);
        }
    }
}