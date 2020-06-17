using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.DTO;
using Infrastructure.Commands;
using System.Data;
using System.Runtime.CompilerServices;

using Infrastructure.Domain;
using Core.Domain;

namespace Infrastructure.Services
{
  public static  class PersonService
    { 

        public static void Create(CreatePersonCommand createPerson, string userID)
        {

            var person = new Person(
                createPerson.Name, createPerson.Sourname, createPerson.TelephoneNumber, userID);
            // tu mapper

            PersonDTO persondto = new PersonDTO()
            {
                Name = person.Name,
                Sourname = person.Sourname,
                TelephoneNumber = person.TelephoneNumber,
                PersonID = person.PersonID,
                UserID = userID

            };

            PersonRepository.Create(persondto);
        }

        public static List<PersonDTO> LoadAll()
        {
            var data = PersonRepository.ReadAll ();
            List<PersonDTO> personDtoList = new List<PersonDTO>();

            foreach (var row in data)
            {
                personDtoList.Add(new PersonDTO
                {
                    Name = row.Name,
                    Sourname = row.Sourname,
                    TelephoneNumber = row.TelephoneNumber
                }); 
                
            }

            return personDtoList;
        }

        public static PersonDTO Load(string userID)
        {
            var person = PersonRepository.ReadOne(userID);
          

            return person;
        }
       
        public static int UpdatePerson(string userID)
        {
            var person = PersonRepository.ReadOne(userID);

            PersonDTO personDTO = new PersonDTO()
            {
                Name = person.Name,
                Sourname = person.Sourname,
                TelephoneNumber = person.TelephoneNumber,
                PersonID = person.PersonID,
                UserID = person.UserID
            };

           return PersonRepository.Update(personDTO);
        }

        public static int DeletePerson(string userID)
        {
           return PersonRepository.Delete(userID);
        }

        public static void CompleteAddress(CreateAddressCommand createAddress, string personID) {

            var address = new Address(createAddress.City, createAddress.ZipCode, createAddress.StreetName, personID, createAddress.StreetNumber, createAddress.HomeNumber);

            var addressDTO = new AddressDTO
            {
                City = address.City,
                ZipCode = address.ZipCode,
                StreetName = address.StreetName,
                PersonID = address.PersonID,
                StreetNumber = address.StreetNumber,
                HomeNumber = address.HomeNumber
            };

            AddressRepository.Create(addressDTO);
        }

        public static AddressDTO LoadAddress(string personID)
        {
            var address = AddressRepository.LoadOne(personID);
            return address;
        }
    }
}
