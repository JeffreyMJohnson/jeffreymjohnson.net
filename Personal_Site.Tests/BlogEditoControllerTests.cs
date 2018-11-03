using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Personal_Site.Controllers;
using Personal_Site.Models;

namespace Personal_Site.Tests
{
    [TestClass]
    public class BlogEditoControllerTests
    {
        [TestMethod]
        public void Index()
        {
            var blogPosts = new TestDbSet<BlogPost>();
            blogPosts.Add(new BlogPost() {Id = 1, Body = "body"});
            blogPosts.Add(new BlogPost() { Id = 2, Body = "body"});

            var mockcontext = new Mock<IDbContext>();

            mockcontext.Setup(c => c.BlogPosts).Returns(blogPosts);

            var controller = new BlogEditorController(mockcontext.Object);
            var result = controller.Index() as ViewResult;
            var resultModel = result.Model as List<BlogPost>;

            //verify blogs returned.
            Assert.AreEqual(2, resultModel.Count);

        }
    }
}
