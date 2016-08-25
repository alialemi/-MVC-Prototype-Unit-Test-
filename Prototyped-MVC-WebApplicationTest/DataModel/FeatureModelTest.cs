using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRSA.Core.DataAccess.DataModel;
using Prototyped_MVC_WebApplicationTest.Helper;
using System.Collections;
using System.Collections.Generic;


namespace Prototyped_MVC_WebApplicationTest.DataModel
{
    [TestClass]
    public class FeatureModelTest
    {
        private User mockedUser;
        private IList<Feature> mockedFeatures;
        private Page mockedPage;

        [TestInitialize]
        public void Setup()
        {
            mockedUser = UserHelper.Create();
            mockedPage = PageHelper.Create();
            mockedFeatures = FeatureHelper.CreateList(5);
            mockedPage.Features = mockedFeatures;
            mockedUser.Accesses = new List<UserAccess>();
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
                    AccessType = AccessType.Read_Write,
                    Feature = ft,
                    Page = mockedPage,
                    User = mockedUser
                };
                mockedUser.Accesses.Add(access);
                ft.UserAccesses.Add(access);
            }
            
        }

        [TestMethod]
        public void TestUserVisibileAccess()
        {
            //All the features on this page should be visible to the user.
            foreach (var ft in mockedFeatures)
            {
                Assert.IsTrue(ft.VisibleToUser(mockedUser, mockedPage));
            }

            var feat = mockedFeatures[2];
            
            //If works if the access is changed to READ_ONLY.
            feat.UserAccesses[0].AccessType = AccessType.Read;
            mockedUser.Accesses.FirstOrDefault(uc => uc.Feature.FeatureId == feat.FeatureId).AccessType = AccessType.Read;
            Assert.IsTrue(feat.VisibleToUser(mockedUser, mockedPage));

            //It shouls return false if the access types changed to None.
            feat.UserAccesses[0].AccessType = AccessType.None;
            mockedUser.Accesses.FirstOrDefault(uc => uc.Feature.FeatureId == feat.FeatureId).AccessType = AccessType.None;
            Assert.IsFalse(feat.VisibleToUser(mockedUser, mockedPage));
            
        }

        [TestMethod]
        public void TestUserWriteAccess()
        {
            //All the features on this page should be visible to the user.
            foreach (var ft in mockedFeatures)
            {
                Assert.IsTrue(ft.UserCanEdit(mockedUser, mockedPage));
            }

            var feat = mockedFeatures[2];

            //If works if the access is changed to READ_ONLY.
            feat.UserAccesses[0].AccessType = AccessType.Read;
            mockedUser.Accesses.FirstOrDefault(uc => uc.Feature.FeatureId == feat.FeatureId).AccessType = AccessType.Read;
            Assert.IsFalse(feat.UserCanEdit(mockedUser, mockedPage));

            //It shouls return false if the access types changed to None.
            feat.UserAccesses[0].AccessType = AccessType.None;
            mockedUser.Accesses.FirstOrDefault(uc => uc.Feature.FeatureId == feat.FeatureId).AccessType = AccessType.None;
            Assert.IsFalse(feat.UserCanEdit(mockedUser, mockedPage));
        }

        [TestCleanup]
        public void Cleanup()
        {
                // Coide for any cleanup will be added here. 
        }
    }
}
