namespace Sorting_Program_Prototype;
using System;
using System.Collections.Generic;
using System.IO;

public class TextFileReaders
{
    static void Main5(string[] args)
    {
        // The path to the text file containing the directories
        string filePath = "C:\\Users\\leon\\Documents\\Testing\\Test.txt";

        List<string> directories = GetDirectoriesFromFile(filePath);
        directories = AddBackslashToDirectories(directories);

        foreach (string directory in directories)
        {
            Console.WriteLine(directory);
        }
    }

    static List<string> GetDirectoriesFromFile(string filePath)
    {
        // The list of directories to be returned
        List<string> directories = new List<string>();

        // Read the text file line by line
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine() ?? throw new InvalidOperationException()) != null)
            {
                // Split the line on commas and add each directory to the list
                string[] directoryNames = line.Split(", ");
                foreach (string directoryName in directoryNames)
                {
                    // Check if the directory exists and is valid
                    if (Directory.Exists(directoryName))
                    {
                        directories.Add(directoryName);
                    }
                }
            }
        }

        return directories;
    }
    
    static List<string> AddBackslashToDirectories(List<string> directories)
    {
        // The list of directories with added backslashes
        List<string> updatedDirectories = new List<string>();

        foreach (string directory in directories)
        {
            // Add a backslash next to any existing backslashes in the directory name
            string updatedDirectory = directory.Replace("\\", "\\\\");

            updatedDirectories.Add(updatedDirectory);
        }

        return updatedDirectories;
    }
}