using HRSA.Core.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Prototyped_MVC_WebApplicationTest.Helper
{
    public class FeatureHelper
    {
        public static Feature Create(int? featureId = null,
            string featureName = null,
            string description = null,
            DateTime? publishedOn = null,
            string publishedBy = null)
        {
            return new Feature()
            {
                Description = description ?? Utility.GetRandomString(),
                FeatureId = featureId ?? Utility.GetRandomInteger(),
                FeatureName = featureName ?? Utility.GetRandomString(),
                PublishedOn = publishedOn ?? DateTime.Now,
                PublishedBy = publishedBy ?? Utility.GetRandomString(10)
            };
        }

        public static IList<Feature> CreateList(int count)
        {
            var retList = new List<Feature>();
            for (int ii = 0; ii < count; ii++)
            {
                retList.Add(Create());
            }
            return retList;
        }

        public static void CreateFeatureAccess(IList<Feature> mockedFeatures,
            Page mockedPage,
            User mockedUser,
            AccessType mockedAccessType)
        {
            int cnt = 0;
            foreach (var ft in mockedFeatures)
            {
                cnt++;
                ft.Pages = new List<Page>();
                ft.Pages.Add(mockedPage);
                ft.UserAccesses = new List<UserAccess>();
                var access = new UserAccess()
                {
                    AccessId = cnt,
                    AccessType = mockedAccessType,
                    Feature = ft,
                    Page = mockedPage,
                    User = mockedUser
                };
                mockedUser.Accesses.Add(access);
                ft.UserAccesses.Add(access);
            }
        }
    }
}
