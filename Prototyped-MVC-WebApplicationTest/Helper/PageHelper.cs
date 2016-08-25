using HRSA.Core.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyped_MVC_WebApplicationTest.Helper
{
    public static class PageHelper
    {
        public static Page Create(int? pageId = null,
            string content = null,
            string pageName = null,
            DateTime? createdOn = null,
            string createdBy = null)
        {
            return new Page()
            {
                CreatedBy = createdBy ?? Utility.GetRandomString(10),
                CreatedOn = createdOn ?? DateTime.Now,
                Id = pageId ?? Utility.GetRandomInteger(),
                PageContent = content ?? Utility.GetRandomString(200),
                PageName = pageName ?? Utility.GetRandomString()
            };
        }

        public static IList<Page> CreateList(int count)
        {
            var retList = new List<Page>();

            for (int ii = 0; ii < count; ii++)
            {
                retList.Add(Create());
            }
            return retList;
        }
    }
}
