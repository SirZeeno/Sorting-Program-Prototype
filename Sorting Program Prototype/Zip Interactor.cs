namespace Sorting_Program_Prototype;
using System.IO;
using System.IO.Compression;

public class Zip_Interactor
{
    static void Main7(string[] args)
    {
        string directory = "C:\\Users\\leon\\Downloads\\Pixiv\\冬野みかん";
        UnzipFiles(directory);
    }

    public static void UnzipFiles(string directory)
    {
        // Check if the directory exists
        if (Directory.Exists(directory))
        {
            // Get all of the zip files in the directory
            string[] zipFiles = Directory.GetFiles(directory, "*.zip");

            // Iterate over the zip files
            foreach (string zipFile in zipFiles)
            {
                // Create a folder with the name of the zip file
                // in the same directory as the zip file
                string folder = Path.Combine(directory, Path.GetFileNameWithoutExtension(zipFile));
                Directory.CreateDirectory(folder);

                // Move the zip file to the new folder
                File.Move(zipFile, Path.Combine(folder, Path.GetFileName(zipFile)));

                // Unzip the file in the new folder
                ZipFile.ExtractToDirectory(Path.Combine(folder, Path.GetFileName(zipFile)), folder);
                
                // Delete the zip file
                File.Delete(Path.Combine(folder, Path.GetFileName(zipFile)));
            }
        }
    }
}