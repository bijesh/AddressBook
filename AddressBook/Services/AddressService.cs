using AddressBook.Contract;
using AddressBook.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class AddressService : IAddressService
    {
        private readonly IFileHelper _fileHelper;
        public AddressService(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }
        public async Task<IEnumerable<Address>> GetAddress()
        {
            var path = System.AppContext.BaseDirectory +"\\Data\\Address.json";
            var jsonString = await _fileHelper.ReadFile(path);
            return JsonConvert.DeserializeObject<List<Address>>(jsonString);
        }
    }
}
