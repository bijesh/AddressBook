using AddressBook.Contract;
using AddressBook.Interface;
using AddressBook.ViewModel;
using AddressBook.ViewModelBuilder;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AddressBook.Test.ViewModelBuilder
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class CityGroupViewModelBuilderTests
    {
        private CityGroupViewModelBuilder cityGroupViewModelBuilder;
        private Mock<IAddressViewModelBuilder> _addressViewModelBuilderMock;

        [SetUp]
        public void SetUp()
        {
            _addressViewModelBuilderMock = new Mock<IAddressViewModelBuilder>();
            _addressViewModelBuilderMock.Setup(x => x.Build(It.IsAny<Address>())).Returns(new ViewModel.AddressViewModel());
            cityGroupViewModelBuilder = new CityGroupViewModelBuilder(_addressViewModelBuilderMock.Object);
        }


        [Test]
        public void Build_Returns_InstanceOf_CityGroupViewModel()
        {

            // Act
            var actualResult = cityGroupViewModelBuilder.Build("London", GetAddress());

            // Assert
            Assert.IsInstanceOf<CityGroupViewModel>(actualResult);
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
    }
}
