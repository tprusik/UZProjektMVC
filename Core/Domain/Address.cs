using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Address
    {
        public Address(string _zipCode,string _city,string _streetName,string _personID,int _streetNumber,int _homeNumber)
        {
            ZipCode = _zipCode;
            City = _city;
            StreetName = _streetName;
            StreetNumber = _streetNumber;
            HomeNumber = _homeNumber;
            PersonID = _personID; 
        }

        public string ZipCode { get; protected set; }
        public string City { get; protected set; }
        public string StreetName { get; protected set; }
        public int StreetNumber { get; protected set; }
        public int HomeNumber { get; protected set; }
        public string PersonID { get; protected set; }
    }
}
