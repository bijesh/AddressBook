using AddressBook.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Interface
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddress();
    }
}
