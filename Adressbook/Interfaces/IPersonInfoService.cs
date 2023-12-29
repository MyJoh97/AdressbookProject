using Adressbook.Models;
using Adressbook.Models.Responses;

namespace Adressbook.Interfaces
{

    // CRUD - Create Read Update Delete

    public interface IPersonInfoService
    {
        IServiceResult AddPersonInfoToList(IPersonInfo personInfo);
        //ServiceResult GetPersonInfoByEmailFromList(string email);
        IServiceResult GetPersonsInfoFromList();

        //ServiceResult UpdatePersonInfoInList(PersonInfo personInfo);
        //ServiceResult DeletePersonIfoFromList(Func<PersonInfo, bool> predicate);
        //ServiceResult DeletePersonIfoFromList(Func<PersonInfo, bool> predicate);
    }
}




// Lambda expression (personInfo) => personInfo.FirstName == "My"
// Vad som kallas för FUNC ovanför.