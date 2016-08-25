using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSA.Core.DataAccess.DataModel
{
    public class Feature
    {
        public int FeatureId { get; set; }

        public string FeatureName { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public string PublishedBy { get; set; }

        public IList<Page> Pages { get; set; }

        public IList<UserAccess> UserAccesses { get; set; }

        public bool VisibleToUser(User user, Page page)
        {
            return UserAccesses.Any(uc => new[] { AccessType.Read, AccessType.Read_Write }
                .Contains(uc.AccessType) &&
                page.Id == uc.Page.Id &&
                user.UserId == uc.User.UserId);
        }

        public bool UserCanEdit(User user, Page page)
        {
            return UserAccesses.Any(uc => new[] { AccessType.Read_Write, AccessType.Write }
                .Contains(uc.AccessType) &&
                page.Id == uc.Page.Id &&
                user.UserId == uc.User.UserId);
        }
    }
}
