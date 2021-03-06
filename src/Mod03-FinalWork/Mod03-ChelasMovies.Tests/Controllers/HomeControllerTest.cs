﻿using System.Web.Mvc;

namespace Mod03_WebApplications.DemoMVC3WebApp.Tests.Controllers
{
    using Mod03_ChelasMovies.WebApp.Controllers;

    using NUnit.Framework;

    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
    using Mod03_ChelasMovies.DomainModel.ServicesImpl;

    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new WallService(new InMemoryMoviesService(), new InMemoryCommentsService()));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(new WallService(new InMemoryMoviesService(), new InMemoryCommentsService()));

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
