using AddressBook.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Utilities
{
    public class FileHelper : IFileHelper
    {
        public async Task<string> ReadFile(string path)
        {
            var streamReader = new StreamReader(@path, Encoding.UTF8);
            return await streamReader.ReadToEndAsync();
        }
    }
}
