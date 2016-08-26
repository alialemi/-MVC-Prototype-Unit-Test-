using HRSA.Core.DataAccess.DataModel;
using HRSA.Core.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSA.Core.DataAccess.Service
{
    public interface IUserService
    {
        User GetUserByUserName(string userName);
    }

    public class UserService : IUserService
    {

        private readonly IDbDataContext dataContext;

        public UserService(IDbDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public User GetUserByUserName(string userName)
        {
            return dataContext.Users.Single(u => u.UserName == userName);
        }
    }
}
