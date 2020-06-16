using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands
{
   public class CreateAddressCommand
    {
        public string ZipCode;
        public string City;
        public string StreetName;
        public int StreetNumber;
        public int HomeNumber;
        public string PersonID;
    }
}
