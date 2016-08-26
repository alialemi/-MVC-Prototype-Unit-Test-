﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRSA.Core.DataAccess.Service;
using HRSA.Core.DataAccess.Repository;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using HRSA.Core.DataAccess.DataModel;
using System.Collections.Generic;
using Prototyped_MVC_WebApplicationTest.Helper;

namespace Prototyped_MVC_WebApplicationTest.Services
{
    [TestClass]
    public class PageServiceTest
    {
        private IDbDataContext testDbContext;
        private IPageService pageService;
        private IUserService testUserService;
        private Page mockedPage;
        private User mockedUser;
        private IList<Feature> mockedFeatures;

        [TestInitialize]
        public void Setup()
        {
            testDbContext = Substitute.For<IDbDataContext>();
            testUserService = Substitute.For<IUserService>();
            pageService = new PageService(testDbContext, testUserService);
            mockedPage = PageHelper.Create();
            mockedUser = UserHelper.Create();
            mockedUser.Accesses = new List<UserAccess>();
            mockedFeatures = FeatureHelper.CreateList(3);
            FeatureHelper.CreateFeatureAccess(mockedFeatures, mockedPage, mockedUser, AccessType.None);
            mockedPage.Features = mockedFeatures;
            testUserService.GetUserByUserName(mockedUser.UserName).Returns(mockedUser);
        }

        [TestMethod]
        public void TestGetPageName()
        {
            mockedPage.PageName = "Index";
            var mockedPages = new List<Page>() { mockedPage }.AsQueryable();
            
            testDbContext.Pages.Returns(mockedPages);
            var page = pageService.GetPageByName("Index");
            Assert.AreSame(page, mockedPage);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestReadAccessToPage()
        {
            mockedPage.PageName = "Index";
            var mockedPages = new List<Page>() { mockedPage }.AsQueryable();
            testDbContext.Pages.Returns(mockedPages);
            var page = pageService.GetPageByNameUserName("Index", mockedUser.UserName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            testDbContext.Dispose();
        }
    }
}
