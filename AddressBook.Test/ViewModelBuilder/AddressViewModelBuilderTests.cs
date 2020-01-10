using AddressBook.Contract;
using AddressBook.ViewModel;
using AddressBook.ViewModelBuilder;
using FluentAssertions;
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
    public class AddressViewModelBuilderTests
    {
        private AddressViewModelBuilder _addressViewModelBuilder;

        [SetUp]
        public void SetUp()
        {
            _addressViewModelBuilder = new AddressViewModelBuilder();
        }

        [Test]
        public void Build_Returns_Expected_AddressViewModel_Result()
        {
            // Arrange
            var expectedResult = GetAddressViewModel();

            // Act
            var actualResult = _addressViewModelBuilder.Build(GetAddress());

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Build_Returns_InstanceOf_AddressViewModel()
        {

            // Act
            var actualResult = _addressViewModelBuilder.Build(GetAddress());

            // Assert
            Assert.IsInstanceOf<AddressViewModel>(actualResult);
        }
        private Address GetAddress()
        {
            return new Address
                {
                    firstname="John",
                    lastname= "smith",
                    country="UK",
                    city="London",
                    streetaddress="Test St 1"
                };

        }
        private AddressViewModel GetAddressViewModel()
        {
            return new AddressViewModel
            {
                firstname = "John",
                lastname = "smith",
                country = "UK",
                city = "London",
                streetaddress = "Test St 1"
            };

        }
    }
}
