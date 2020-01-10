using AddressBook.Contract;
using AddressBook.Controllers;
using AddressBook.Interface;
using AddressBook.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Test.Controllers
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class AddressControllerTests
    {
        private Mock<IAddressService> _addressServiceMock;
        private Mock<ICityGroupViewModelBuilder> _groupViewModelBuilderMock;
        private AddressController addressController;

        [SetUp]
        public void SetUp()
        {
            _addressServiceMock = new Mock<IAddressService>();
            _addressServiceMock.Setup(x => x.GetAddress()).ReturnsAsync(GetAddress);
            _groupViewModelBuilderMock = new Mock<ICityGroupViewModelBuilder>();
            _groupViewModelBuilderMock.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<IEnumerable<Address>>())).Returns(GetCityGroupViewModel);

            addressController = new AddressController(_addressServiceMock.Object, _groupViewModelBuilderMock.Object);
        }

        [Test]
        public async Task Get_Returns_Instance_Of_Enumerable_CityGroupViewModel()
        {
            // Act
            var result = await addressController.Get();

            // Assert
            Assert.IsInstanceOf<IEnumerable<CityGroupViewModel>>(result);
        }

        [Test]
        public async Task Get_Calls_GetAddress_Service()
        {
            // Act
            await addressController.Get();

            // Assert
            _addressServiceMock.Verify(x => x.GetAddress(), Times.Once);
        }

        [Test]
        public async Task Get_Calls_Build_Method()
        {
            // Act
            await addressController.Get();

            // Assert
            _groupViewModelBuilderMock.Verify(x => x.Build(It.IsAny<string>(), It.IsAny<IEnumerable<Address>>()), Times.Exactly(2));
        }

        private IEnumerable<Address> GetAddress()
        {
            return new List<Address>()
            {
                new Address
                {
                    firstname="John",
                    lastname= "smith",
                    country="UK",
                    city="London",
                    streetaddress="Test St 1"
                },
                new Address
                {
                    firstname="Jane",
                    lastname= "smith",
                    country="USA",
                    city="New York",
                    streetaddress="Test St 2"
                }
            };

        }

        private CityGroupViewModel GetCityGroupViewModel()
        {
            return new CityGroupViewModel
            {
                City = "London",
                Address = new List<AddressViewModel>()
            };
        }
    }
}
