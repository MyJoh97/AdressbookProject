using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Models.Responses;
using Newtonsoft.Json;


namespace Adressbook.Services
{
    public class PersonInfoService : IPersonInfoService
    {
        private List<IPersonInfo> _personInfos;
        private readonly FileService _fileService;

        public PersonInfoService(FileService fileService)
        {
            _fileService = fileService;
            LoadContactsFromFile();
        }

        private void LoadContactsFromFile()
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _personInfos = JsonConvert.DeserializeObject<List<IPersonInfo>>(content, new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new IPersonInfoConverter() }
                }) ?? new List<IPersonInfo>();
            }
            else
            {
                _personInfos = new List<IPersonInfo>();
            }
        }

        public IServiceResult AddPersonInfoToList(IPersonInfo personInfo)
        {
            var response = new ServiceResult();
            try
            {
                if (!_personInfos.Any(x => x.Email == personInfo.Email))
                {
                    _personInfos.Add(personInfo);
                    string jsonContent = JsonConvert.SerializeObject(_personInfos);
                    _fileService.SaveContentToFile(jsonContent);
                    response.Status = Enums.ServiceStatus.SUCCESSED;
                }
                else
                {
                    response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = ex.Message;
            }
            return response;
        }

        public IServiceResult GetPersonsInfoFromList()
        {
            var response = new ServiceResult();
            try
            {
                response.Status = Enums.ServiceStatus.SUCCESSED;
                response.Result = _personInfos;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = ex.Message;
            }
            return response;
        }

        public IServiceResult UpdatePersonInfoInList(PersonInfo updatedPersonInfo)
        {
            var response = new ServiceResult();
            try
            {
                var person = _personInfos.FirstOrDefault(p => p.Email == updatedPersonInfo.Email);
                if (person != null)
                {
                    // Update the details
                    person.FirstName = updatedPersonInfo.FirstName;
                    person.LastName = updatedPersonInfo.LastName;
                    person.PhoneNumber = updatedPersonInfo.PhoneNumber;
                    person.Address = updatedPersonInfo.Address;
                    // Save the updated list
                    string jsonContent = JsonConvert.SerializeObject(_personInfos);
                    _fileService.SaveContentToFile(jsonContent);
                    response.Status = Enums.ServiceStatus.UPDATED;
                }
                else
                {
                    response.Status = Enums.ServiceStatus.NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = ex.Message;
            }
            return response;
        }
    }
}













/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Models.Responses;
using Newtonsoft.Json;


namespace Adressbook.Services
{
    public class PersonInfoService : IPersonInfoService
    {
        private List<IPersonInfo> _personInfos;
        private readonly FileService _fileService;

        public PersonInfoService(FileService fileService)
        {
            _fileService = fileService;
            LoadContactsFromFile();
        }

        private void LoadContactsFromFile()
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _personInfos = JsonConvert.DeserializeObject<List<IPersonInfo>>(content, new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new IPersonInfoConverter() }
                }) ?? new List<IPersonInfo>();
            }
            else
            {
                _personInfos = new List<IPersonInfo>();
            }
        }

        public IServiceResult AddPersonInfoToList(IPersonInfo personInfo)
        {
            var response = new ServiceResult();
            try
            {
                if (!_personInfos.Any(x => x.Email == personInfo.Email))
                {
                    _personInfos.Add(personInfo);
                    string jsonContent = JsonConvert.SerializeObject(_personInfos);
                    _fileService.SaveContentToFile(jsonContent);
                    response.Status = Enums.ServiceStatus.SUCCESSED;
                }
                else
                {
                    response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = ex.Message;
            }
            return response;
        }

        public IServiceResult GetPersonsInfoFromList()
        {
            var response = new ServiceResult();
            try
            {
                response.Status = Enums.ServiceStatus.SUCCESSED;
                response.Result = _personInfos;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = ex.Message;
            }
            return response;
        }
    }
}*/