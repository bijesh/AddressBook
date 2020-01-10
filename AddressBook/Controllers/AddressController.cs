using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Contract;
using AddressBook.Interface;
using AddressBook.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ICityGroupViewModelBuilder _groupViewModelBuilder;
        public AddressController(IAddressService addressService, ICityGroupViewModelBuilder groupViewModelBuilder)
        {
            _addressService = addressService;
            _groupViewModelBuilder = groupViewModelBuilder;
        }

        [HttpGet]
        public async Task<IEnumerable<CityGroupViewModel>> Get()
        {
            var cityGroupViewModelList = new List<CityGroupViewModel>();
            var addressList = await _addressService.GetAddress();
            var addressGroupByCity = addressList.GroupBy(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.city));
            foreach(var group in addressGroupByCity)
            {
                var addressCollection = group.Select(x => new Address { firstname = x.firstname, lastname = x.lastname, city = x.city, country = x.country, streetaddress = x.streetaddress });
                cityGroupViewModelList.Add(_groupViewModelBuilder.Build(group.Key, addressCollection));
            }

            return cityGroupViewModelList;
        }
    }
}