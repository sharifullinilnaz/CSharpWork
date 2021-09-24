using System;
using System.Text;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            Console.WriteLine("Enter task number: ");
            Console.WriteLine("1 - write text in a specific encoding");
            Console.WriteLine("2 - remove 5 rows from the end of a file");
            Console.WriteLine("3 - recursively outputting all files and subfolders");
            string taskNumber = Console.ReadLine();
            
            switch (taskNumber)
            {
                case "1":
                    Console.Write("Enter folder path: ");
                    string targetFolderPath = Console.ReadLine();
                    
                    FolderWork.GetRecursivelyAllFilesAndFolders(targetFolderPath, 0);
                    Console.ReadKey();
                    break; 
                case "2":
                    Console.Write("Enter path to file: ");
                    string filePath = Console.ReadLine();
                    FileWork.DeleteLastRows(filePath, 5);
                    break;
                case "3": 
                    Console.Write("Enter path to write: ");
                    string writePath = Console.ReadLine();
                    Console.Write("Enter text to write: ");
            
                    string text = Console.ReadLine();
                    string line;
                    do {
                        line = Console.ReadLine();
                        if (line != null)
                            text = String.Concat(text, "\n" + line);
                    } while (line != null);
            
                    Console.Write("Enter codepage id: ");
                    int codepageId = int.TryParse(Console.ReadLine(), out int num) ? num : 0;
                    
                    FileWork.WriteToFile(writePath, codepageId, text);
                    FileWork.ReadFromFile(writePath, codepageId); 
                    break;
                default:
                    Console.WriteLine("Wrong task number");
                    break;
            }
            
        }
    }
}
