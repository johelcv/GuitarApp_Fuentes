using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guitar.Entities;
using NSubstitute;
using System.Collections.Generic;
using Guitar.DAC;

namespace Guitar.BL.MSUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateGuitarTest()
        {
            var model = new Guitars();
            model.Id = 1;
            model.Name = "Guitar Test";
            model.BodyID = 1;
            model.NeckID = 1;
            model.BridgeID = 1;
            model.PickupID = 1;
            model.StartDate = Convert.ToDateTime("01/10/2017");
            model.PaintDate = Convert.ToDateTime("10/10/2017");
            model.TestDate = Convert.ToDateTime("15/10/2017");
            model.FinishDate = Convert.ToDateTime("27/10/2017");

            var repository = Substitute.For<IGuitarRepositorio>();

            var service = new GuitarService(repository);

            service.Create(model);

            //Assert
            repository.Received().Create(model);

        }

        [TestMethod]
        public void CreateGuitarTestIncorrect()
        {
            var model = new Guitars();
            model.Id = 0;
            model.Name = "Guitar Test";
            model.BodyID = 1;
            model.NeckID = 1;
            model.BridgeID = 1;
            model.PickupID = 1;
            model.StartDate = Convert.ToDateTime("01/10/2017");
            model.PaintDate = Convert.ToDateTime("01/10/2017");
            model.TestDate = Convert.ToDateTime("01/10/2017");
            model.FinishDate = Convert.ToDateTime("01/10/2017");

            var repository = Substitute.For<IGuitarRepositorio>();

            var service = new GuitarService(repository);

            try
            {
                service.Create(model);

                Assert.Fail("the validation is not complete");
            }
            catch (ApplicationException ex)
            {

            }

            //Assert
            repository.DidNotReceive().Create(model);

        }
    }
}
