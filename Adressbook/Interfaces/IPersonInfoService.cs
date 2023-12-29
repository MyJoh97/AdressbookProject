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
        void SavePersonsInfoToFile();
        IServiceResult UpdatePersonInfoInList(PersonInfo personInfo);
        
        //ServiceResult DeletePersonInfoFromList(Func<PersonInfo, bool> predicate);
    }
}




// Lambda expression (personInfo) => personInfo.FirstName == "My"
// Vad som kallas för FUNC ovanför.