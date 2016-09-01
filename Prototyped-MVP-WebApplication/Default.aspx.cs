using Ninject;
using Prototyped_MVP_WebApplication.Presenter;
using Prototyped_MVP_WebApplication.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototyped_MVP_WebApplication
{
    public partial class _Default : Ninject.Web.PageBase, IDefaultView
    {
        [Inject]
        public IDefaultPresenter Presenter { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            HRSA.Core.DataAccess.DataModel.Page page = Presenter.LoadPage("Index");
        }
    }
}