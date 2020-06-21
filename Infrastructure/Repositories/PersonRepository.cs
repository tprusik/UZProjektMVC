using System.Data.SqlClient;
using Infrastructure.DTO;
using System.Collections.Generic;
using Infrastructure.DataAccess;

namespace Infrastructure.Repositories
{
    public  class PersonRepository
    {
        public void Create(PersonDTO person)
        {
            //parametry przekazywane do zapytania sql , pobierane z personDTO,
            var parameters = new
            {
                Name = person.Name,
                Sourname = person.Sourname,
                TelephoneNumber = person.TelephoneNumber,
                PersonID = person.PersonID,
                UserID = person.UserID
            };

            // zapytanie sql tworzące nową osobę
            string sql = @"insert into [dbo].[Person] (Name,Sourname,TelephoneNumber,PersonID,UserID)
                           values (@Name,@Sourname , @TelephoneNumber,@PersonID,@UserID);";

            // funckja zapytań do bazy
            SqlDataAccess.SaveData(sql, parameters); 
        }

        public  List<PersonDTO> ReadAll()
        {
            string sql = @"select * from dbo.[Person];";
            var data = SqlDataAccess.LoadData<PersonDTO>(sql);
            return data;
        }

        public  PersonDTO ReadOne(string _userID)
        {
            var parameter = new { userID = _userID };
            string sql = @"select * from dbo.[Person] where userID like @userID;";

            var data = SqlDataAccess.LoadData<PersonDTO>(sql, parameter);
            return data;
        }

        public  int Update(PersonDTO person)
        {
            
            var parameters = new
            {
                Name = person.Name,
                Sourname = person.Sourname,
                TelephoneNumber = person.TelephoneNumber,
                PersonID = person.PersonID,
                UserID = person.UserID
            };

            // zapytanie sql tworzące nową osobę
            string sql = @"insert into [dbo].[Person] (Name,Sourname,TelephoneNumber,PersonID,UserID)
                           values (@Name,@Sourname , @TelephoneNumber,@PersonID,@UserID);";

            // funkcja zapytań do bazy zwraca int liczbe zaktualizowanych rekordów
            return SqlDataAccess.SaveData(sql, parameters); ;
        }

        public  int Delete(string _userID)
        {
            var parameters = new { userID = _userID };
            string sql = @"delete from [dbo].[Person] where userID like @userID;";

            return SqlDataAccess.SaveData(sql, parameters); 
        }
    }
}
