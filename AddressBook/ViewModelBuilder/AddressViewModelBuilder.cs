using AddressBook.Contract;
using AddressBook.Interface;
using AddressBook.ViewModel;

namespace AddressBook.ViewModelBuilder
{
    public class AddressViewModelBuilder : IAddressViewModelBuilder
    {
        public AddressViewModel Build(Address address)
        {
            return new AddressViewModel { 
                firstname= address.firstname,
                lastname = address.lastname,
                city = address.city,
                country = address.country,
                streetaddress = address.streetaddress
            };
        }
    }
}
