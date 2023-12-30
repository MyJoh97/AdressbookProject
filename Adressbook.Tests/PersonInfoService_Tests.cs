using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Services;
using Xunit; // Make sure you have this using directive for xUnit

namespace Adressbook.Tests
{
    public class PersonInfoService_Tests
    {
        [Fact]
        public void AddToListShould_AddOnePersonInfoToPersonInfoList_ThenReturnTrue()
        {
            // Arrange
            IPersonInfo personInfo = new PersonInfo();
            IPersonInfoService personInfoService = new PersonInfoService();

            // Act
            bool result = personInfoService.AddPesonInfoToList(personInfo);

            // Assert
            Assert.True(result); // Assert that result is true
        }
    }
}