using Adressbook.Models;
using Adressbook.Models.Responses;

namespace Adressbook.Interfaces
{

    // CRUD - Create Read Update Delete

    public interface IPersonInfoService
    {
        IServiceResult AddPersonInfoToList(IPersonInfo personInfo);
        
        IServiceResult GetPersonsInfoFromList();
        void SavePersonsInfoToFile();
        IServiceResult UpdatePersonInfoInList(PersonInfo personInfo);

        IServiceResult DeletePersonInfo(string email);
        bool AddPesonInfoToList(IPersonInfo personInfo);
        
    }
}




