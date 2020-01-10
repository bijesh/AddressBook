using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Interface
{
    public interface IFileHelper
    {
        Task<string> ReadFile(string path);
    }
}
