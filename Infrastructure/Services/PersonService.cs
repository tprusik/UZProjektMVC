using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.DTO;
using Infrastructure.Commands;
using System.Data;
using System.Runtime.CompilerServices;
using Core.Domain;
using Infrastructure.Mapper;

namespace Infrastructure.Services
{
  public class PersonService
    {

       private readonly PersonRepository personRepository;
        private readonly AddressRepository addressRepository;

        public PersonService()
        {
            personRepository = new PersonRepository();
            addressRepository = new AddressRepository();
        }

        public PersonService(PersonRepository _personRepository,AddressRepository _addressRepository)
        {
            personRepository = _personRepository;
            addressRepository = _addressRepository;
        }

        public  void Create(CreatePersonCommand createPerson, string userID)
        {
            var person = new Person(
                createPerson.Name, createPerson.Sourname, createPerson.TelephoneNumber, userID);
            // tu mapper

            var imapper = AutoMapperConfig.GetMapper(); // mapuje obiekt domenowy na płaski obiekt
            var dest = imapper.Map<Person, PersonDTO>(person);

            personRepository.Create(dest);
        }

        public  List<PersonDTO> LoadAll()
        {
            var data = personRepository.ReadAll ();
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

        public  PersonDTO Load(string userID)
        {
            var person = personRepository.ReadOne(userID);
          
            return person;
        }

        public  int UpdatePerson(CreatePersonCommand createPerson,string userID)
        {
            var personDTO = personRepository.ReadOne(userID);
            var person = new Person(personDTO.Name, personDTO.Sourname,
                personDTO.TelephoneNumber, personDTO.PersonID, personDTO.UserID);

            var imapper = AutoMapperConfig.GetMapper(); // mapuje obiekt domenowy na płaski obiekt
            var personDTO1 = imapper.Map<Person, PersonDTO>(person);


            return personRepository.Update(personDTO1);
        }

        public int DeletePerson(string userID)
        {
           return personRepository.Delete(userID);
        }

        public  void CompleteAddress(CreateAddressCommand createAddress, string personID) {

            var address = new Address(createAddress.City, createAddress.ZipCode, createAddress.StreetName, personID, createAddress.StreetNumber, createAddress.HomeNumber);

            var imapper = AutoMapperConfig.GetMapper(); // mapuje obiekt domenowy na płaski obiekt
            var addressDTO = imapper.Map<Address, AddressDTO>(address);

            addressRepository.Create(addressDTO);
        }

        public  AddressDTO LoadAddress(string personID)
        {
            var address = addressRepository.LoadOne(personID);
            return address;
        }
    }
}
