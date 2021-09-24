using System;
using System.IO;

namespace FileManager
{
    public static class FolderWork
    {
        /* Method for recursively outputting all files and subfolders to the console 
                folderPath - path to the folder in which files and subfolders are searched
                level - how many levels deeper from the initial folder are searched
        */
        public static void GetRecursivelyAllFilesAndFolders(string folderPath, int level)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Console.WriteLine(new string('\t', level) + "Folder name: " + folderPath);
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (string filePath in files)
                    {
                        Console.WriteLine(new string('\t', level + 1) + "File name: " + filePath);
                    }

                    string[] folders = Directory.GetDirectories(folderPath);
                    level++;
                    foreach (string subfolderPath in folders)
                    {
                        GetRecursivelyAllFilesAndFolders(subfolderPath, level);
                    }
                }
                else
                {
                    Console.WriteLine("Directory not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}