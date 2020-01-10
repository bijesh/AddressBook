using AddressBook.Contract;
using AddressBook.ViewModel;

namespace AddressBook.Interface
{
   public interface IAddressViewModelBuilder
    {
        AddressViewModel Build(Address address);
    }
}
