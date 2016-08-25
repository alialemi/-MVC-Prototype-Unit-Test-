using HRSA.Core.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyped_MVC_WebApplicationTest.Helper
{
    public static class UserHelper
    {
        public static User Create(int? userId = null, 
            string firstName = null,
            string lastName = null, 
            string userName = null)
        {
            return new User()
            {
                FirstName = firstName ?? Utility.GetRandomString(),
                LastName = lastName ?? Utility.GetRandomString(),
                UserId = userId ?? Utility.GetRandomInteger(),
                UserName = userName ?? Utility.GetRandomString()
            };
        }

        public static IList<User> CreateList(int count)
        {
            var retList = new List<User>();
            for (int ii = 0; ii <= count; ii++)
            {
                retList.Add(Create());
            }
            return retList;
        }


    }
}
