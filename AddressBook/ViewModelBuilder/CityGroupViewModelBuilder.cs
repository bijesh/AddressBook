using AddressBook.Contract;
using AddressBook.Interface;
using AddressBook.ViewModel;
using System.Collections.Generic;

namespace AddressBook.ViewModelBuilder
{
    public class CityGroupViewModelBuilder : ICityGroupViewModelBuilder
    {
        private readonly IAddressViewModelBuilder _addressViewModelBuilder;
        public CityGroupViewModelBuilder(IAddressViewModelBuilder addressViewModelBuilder)
        {
            _addressViewModelBuilder = addressViewModelBuilder;

        }
        public CityGroupViewModel Build(string city,IEnumerable<Address> addressList)
        {
            var cityGroupViewModel = new CityGroupViewModel { City = city, Address = new List<AddressViewModel>()};
            foreach (var addres in addressList)
            {
                cityGroupViewModel.Address.Add(_addressViewModelBuilder.Build(addres));
            }
            return cityGroupViewModel;
        }
    }
}
