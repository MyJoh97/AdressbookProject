using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Interfaces;



namespace Adressbook.Services
{
    public interface IFileService
    {
        bool SaveContentToFile(string content);
        string GetContentFromFile();
    }

    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public bool SaveContentToFile(string content)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath, true)) // Use 'true' for append mode
                {
                    sw.WriteLine(content);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string GetContentFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using (var sr = new StreamReader(_filePath))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty; // Return empty string if file doesn't exist or an error occurs
        }
    }
}








/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Interfaces;



namespace Adressbook.Services
{
    public interface IFileService
    {
        bool SaveContentToFile(string content);
        string GetContentFromFile();
    }

    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public bool SaveContentToFile(string content)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath, true)) // Use 'true' for append mode
                {
                    sw.WriteLine(content);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string GetContentFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using (var sr = new StreamReader(_filePath))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty; // Return empty string if file doesn't exist or an error occurs
        }
    }
} */