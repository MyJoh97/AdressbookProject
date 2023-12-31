using Adressbook.Enums;
using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Services;
using Xunit;

namespace Adressbook.Tests
{
    public class PersonInfoService_Tests
    {
        [Fact]
        public void AddToListShould_AddOnePersonInfoToPersonInfoList_ThenReturnSuccessStatus()
        {
            // Arrange
            IPersonInfo personInfo = new PersonInfo();
            var fileService = new FileService();
            IPersonInfoService personInfoService = new PersonInfoService(fileService);

            // Act: Utför den handling som ska testas.
            IServiceResult result = personInfoService.AddPersonInfoToList(personInfo);

            // Assert: Kontrollerar så att resultatet blev som det skulle.
            Assert.Equal(ServiceStatus.SUCCESSED, result.Status);
        }
    }
}