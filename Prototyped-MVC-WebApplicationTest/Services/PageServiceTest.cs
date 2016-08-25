using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRSA.Core.DataAccess.Service;
using HRSA.Core.DataAccess.Repository;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using HRSA.Core.DataAccess.DataModel;
using System.Collections.Generic;

namespace Prototyped_MVC_WebApplicationTest.Services
{
    [TestClass]
    public class PageServiceTest
    {
        private IDbDataContext testDbContext;
        private IPageService pageService;

        [TestInitialize]
        public void Setup()
        {
            testDbContext = Substitute.For<IDbDataContext>();
            pageService = new PageService(testDbContext);
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetPageName()
        {
            var mockedPages = new List<Page>().AsQueryable();
 
            testDbContext.Pages.Returns(mockedPages);
            pageService.GetPageByName("Index");
        }

        [TestCleanup]
        public void Cleanup()
        {
            testDbContext.Dispose();
        }
    }
}
