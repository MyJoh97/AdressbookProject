using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Interfaces;
using Adressbook.Models;
using Adressbook.Services;

namespace Adressbook
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create instances of services with their dependencies
            var fileService = new FileService(@"c:\Projects\CSharp\Adressbook\contacts.json");
            var personInfoService = new PersonInfoService(fileService);
            var menuService = new MenuService(personInfoService);

            // Show the main menu
            menuService.ShowMainMenu();
        }
    }
}