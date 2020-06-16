using DataLibraryOne.DataAccess;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public static class AddressRepository
    {
        public static void Create(AddressDTO addressDTO)
        {
            //parametry przekazywane do zapytania sql , pobierane z personDTO, nie działa przekazanie bezpośrednio
            var parameters = new
            {
                City = addressDTO.City,
                ZipCode = addressDTO.ZipCode,
                StreetName = addressDTO.StreetName,
                StreetNumber = addressDTO.StreetNumber,
                HomeNumber = addressDTO.HomeNumber,
                PersonID = addressDTO.PersonID
            };

            // zapytanie sql tworzące adres dla danej osoby
            string sql = @"insert into [dbo].[Address] (City,ZipCode,StreetName,StreetNumber,HomeNumber,PersonID)
                           values (@City,@ZipCode,@StreetName,@StreetNumber,@HomeNumber,@PersonID);";

            // funckja zapytań do bazy
            SqlDataAccess.SaveData(sql, parameters); ;
        }

        public static AddressDTO LoadOne(string _personID)
        {
            var parameter = new { personID = _personID };

            /// string sql = @"select * from dbo.[Address] where personID like @personID;";

            // var data = SqlDataAccess.LoadData<AddressDTO>(sql, parameter);
            // return data;
            return null;
        }
    }
}
