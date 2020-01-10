using AddressBook.Contract;
using AddressBook.Interface;
using AddressBook.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Test.Services
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class AddressServicesTests
    {
        private Mock<IFileHelper> _fileHelperMock;
        private AddressService addressServices;

       [SetUp]
        public void SetUp()
        {
            _fileHelperMock = new Mock<IFileHelper>();
            _fileHelperMock.Setup(x => x.ReadFile(It.IsAny<string>())).ReturnsAsync(GetJson);
            addressServices = new AddressService(_fileHelperMock.Object);
        }

        [Test]
        public async Task GetAddress_Returns_Address_List()
        {

            //Act
            var address = await addressServices.GetAddress();

            //Assert
            Assert.IsInstanceOf<IEnumerable<Address>>(address);
        }

        [Test]
        public async Task GetAddress_Calls_ReadFile_Method()
        {
            // Act
            await addressServices.GetAddress();

            // Assert
            _fileHelperMock.Verify(x => x.ReadFile(It.IsAny<string>()), Times.Once);
        }

        private string GetJson()
        {
            var path = System.AppContext.BaseDirectory;
            var streamReader = new StreamReader(@path + "Address.json", Encoding.UTF8);
            return streamReader.ReadToEnd();
        }

    }
}
