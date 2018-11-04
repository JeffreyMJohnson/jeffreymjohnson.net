using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        [TestMethod]
        public void GetBlogPostValid()
        {
            var blogPosts = new TestDbSet<BlogPost>();
            blogPosts.Add(new BlogPost() { Id = 1, Body = "body" });

            var mockcontext = new Mock<IDbContext>();

            mockcontext.Setup(c => c.BlogPosts).Returns(blogPosts);

            var controller = new BlogEditorController(mockcontext.Object);
            var result = controller.GetBlogPost(1) as JsonResult;

            var data = result.Data as BlogPost;

            //verify blog returned.
            Assert.AreEqual(1, data.Id);
            Assert.AreEqual("body", data.Body);
        }


        [TestMethod]
        public void SaveBlogPostNewValid()
        {
            var blogPosts = new TestDbSet<BlogPost>();

            var mockcontext = new Mock<IDbContext>();

            mockcontext.Setup(c => c.BlogPosts).Returns(blogPosts);

            var testBlog = new BlogPost()
            {
                Id = 0,
                Title = "title",
                Summary = "summary",
                Body = "body"
            };

            var controller = new BlogEditorController(mockcontext.Object);
            var result = controller.SaveBlogPost(testBlog) as JsonResult;

            //verify success returned
            var success = (bool)(result.Data.GetType().GetProperty("success").GetValue(result.Data));
            Assert.IsTrue(success);
            //verify the new record is there and data integrity

            var resultBlog = blogPosts.FirstOrDefault();
            Assert.IsNotNull(resultBlog);
            Assert.AreEqual(testBlog.Title, resultBlog.Title);
            Assert.AreEqual(testBlog.Summary, resultBlog.Summary);
            Assert.AreEqual(testBlog.Body, resultBlog.Body);

        }

        [TestMethod]
        public void SaveBlogPostUpdateValid()
        {
            var blogPosts = new TestDbSet<BlogPost>();
            blogPosts.Add(new BlogPost()
            {
                Id = 1,
                Title = "old title",
                Summary = "old summary",
                Body = "old body"
            });

            var mockcontext = new Mock<IDbContext>();

            mockcontext.Setup(c => c.BlogPosts).Returns(blogPosts);

            var testBlog = new BlogPost()
            {
                Id = 1,
                Title = "new title",
                Summary = "new summary",
                Body = "new body"
            };


            var controller = new BlogEditorController(mockcontext.Object);
            var result = controller.SaveBlogPost(testBlog) as JsonResult;

            //verify success returned
            var success = (bool)(result.Data.GetType().GetProperty("success").GetValue(result.Data));
            Assert.IsTrue(success);
            //verify the new record is there and data integrity

            var resultBlog = blogPosts.FirstOrDefault();
            Assert.IsNotNull(resultBlog);
            Assert.AreEqual(testBlog.Title, resultBlog.Title);
            Assert.AreEqual(testBlog.Summary, resultBlog.Summary);
            Assert.AreEqual(testBlog.Body, resultBlog.Body);
        }
    }
}
