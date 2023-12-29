using Adressbook.Interfaces;
using Adressbook.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Adressbook.Services
{
    public interface IMenuService
    {
        void ShowMainMenu();
    }

    public class MenuService : IMenuService
    {
        private readonly IPersonInfoService _personInfoService;

        // Constructor with dependency injection
        public MenuService(IPersonInfoService personInfoService)
        {
            _personInfoService = personInfoService;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                DisplayMenuTitle("CONTACT MENU");
                Console.WriteLine($"{"1.",-3} Add new contact");
                Console.WriteLine($"{"2.",-3} View all contacts");
                Console.WriteLine($"{"3.",-3} Search contact");
                Console.WriteLine($"{"4.",-3} Delete contact");
                Console.WriteLine($"{"0.",-3} Exit Contact Application");
                Console.WriteLine();
                Console.Write("Enter your contact menu option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowAddPersonOption();
                        break;

                    case "2":
                        ShowViewPersonListOption();
                        break;

                    case "3":
                        SearchContactByEmail();
                        break;

                    case "0":
                        ShowExitApplicationOption();
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        break;
                }

                Console.ReadKey();
            }
        }

        private void ShowExitApplicationOption()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit this contact application? (y/n): ");
            var option = Console.ReadLine();

            if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

        private void ShowAddPersonOption()
        {
            var newPerson = new PersonInfo();

            DisplayMenuTitle("Add new contact");

            Console.Write("First Name: ");
            newPerson.FirstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            newPerson.LastName = Console.ReadLine()!;

            Console.Write("PhoneNumber: ");
            newPerson.PhoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            newPerson.Email = Console.ReadLine()!;

            Console.Write("Adress: ");
            newPerson.Address = Console.ReadLine()!;

            var res = _personInfoService.AddPersonInfoToList(newPerson);

            switch (res.Status)
            {
                case Enums.ServiceStatus.SUCCESSED:
                    Console.WriteLine("The contact was added.");
                    break;

                case Enums.ServiceStatus.ALREADY_EXISTS:
                    Console.WriteLine("The contact already exists in the address book");
                    break;

                case Enums.ServiceStatus.FAILED:
                    Console.WriteLine("Failed to add the contact.");
                    Console.WriteLine("See error message: " + res.Result?.ToString());
                    break;
            }

            DisplayPressAnyKey();
        }

        private void ShowViewPersonListOption()
        {
            DisplayMenuTitle("Contact list");
            var res = _personInfoService.GetPersonsInfoFromList();

            if (res.Status == Enums.ServiceStatus.SUCCESSED)
            {
                if (res.Result is List<IPersonInfo> personList)
                {
                    if (!personList.Any())
                    {
                        Console.WriteLine("No Contacts found.");
                    }
                    else
                    {

                        foreach (var personInfo in personList)
                        {
                            Console.WriteLine($"{personInfo.FirstName} {personInfo.LastName} <{personInfo.PhoneNumber}> {personInfo.Email} - {personInfo.Address}");
                        }
                    }
                }
            }

            DisplayPressAnyKey();
        }

        private void SearchContactByEmail()
        {
            Console.Clear();
            Console.Write("## Search contact by email ##\n");
            Console.WriteLine();
            Console.Write("Please enter the contacts email:\n");
            string email = Console.ReadLine();

            var serviceResult = _personInfoService.GetPersonsInfoFromList();
            if (serviceResult.Status == Enums.ServiceStatus.SUCCESSED)
            {
                var personList = serviceResult.Result as List<IPersonInfo>;
                var person = personList.FirstOrDefault(p => p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (person != null)
                {
                    Console.WriteLine("Contact found:");
                    Console.WriteLine($"{person.FirstName} {person.LastName} <{person.Email}> {person.PhoneNumber} - {person.Address}");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Unable to retrieve contacts.");
            }

            DisplayPressAnyKey();
        }


        private void UpdatePersonInfoToList()
        {

        }

        private void DisplayMenuTitle(string title)
        {
            Console.Clear();
            Console.WriteLine($"# {title} #");
            Console.WriteLine();
        }

        private void DisplayPressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}