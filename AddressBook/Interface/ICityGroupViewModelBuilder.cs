using AddressBook.Contract;
using AddressBook.ViewModel;
using System.Collections.Generic;

namespace AddressBook.Interface
{
    public interface ICityGroupViewModelBuilder
    {
        CityGroupViewModel Build(string city, IEnumerable<Address> addressList);
    }
}
