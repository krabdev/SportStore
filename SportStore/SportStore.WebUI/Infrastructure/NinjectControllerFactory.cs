﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace SportStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            // put binding here
            Mock<IProductRepository> mock = new Mock<SportStore.Domain.Abstract.IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product { Name = "Football", Price = 25 },
                new Product { Name = "Surf Board", Price = 179 },
                new Product { Name = "Running shoes", Price = 95 }
            }.AsQueryable());


            //we bind every implementation of IProductRepository to the mock data
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}