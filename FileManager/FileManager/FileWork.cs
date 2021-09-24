using System;
using System.IO;
using System.Text;

namespace FileManager
{
    public static class FileWork
    {
        /* Method for writing text to a given file in a specific encoding 
        filePath - path to the file in which the text should be written
        codepageId - the identifier of the code page in which the text should be encoded
        text - text to write
        */
        public static void WriteToFile(string filePath, int codepageId, string text)
        {
            try
            {
                FileInfo fileInf = new FileInfo(filePath);
                if (Directory.Exists(fileInf.DirectoryName))
                {
                    Encoding encoding= Encoding.GetEncoding(codepageId);
                    using (StreamWriter sw = new StreamWriter(filePath, false, encoding))
                    {
                        sw.WriteLine(text);
                    }

                    Console.WriteLine("The text is written to the file in the encoding " + encoding.BodyName);
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
        
        /* Method for read text from a given file in a specific encoding 
        filePath - path to the file from which the text should be read
        codepageId - the identifier of the code page in which the text should be read
        */
        public static void ReadFromFile(string filePath, int codepageId)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Encoding encoding= Encoding.GetEncoding(codepageId);
                    using StreamReader sr = new StreamReader(filePath, encoding);
                    Console.WriteLine(sr.ReadToEnd());
                }
                else
                {
                    Console.WriteLine("File not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /* Method to remove a specified number of rows from the end of a file 
        filePath - path to the file from which rows are to be removed
        rowsCount - number of rows to delete
        */
        public static void DeleteLastRows(string filePath, int rowsCount)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    using StreamWriter sw = new StreamWriter(filePath, false);
                    for (int i = 0; i < lines.Length - rowsCount; i++)
                    {
                        sw.WriteLine(lines[i]);
                    }
                }
                else
                {
                    Console.WriteLine("File not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}