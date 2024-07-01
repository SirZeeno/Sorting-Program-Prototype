namespace Sorting_Program_Prototype;

public class Deprecated
{
    static void Main2(string[] args)
    {
        /*
        string folderPath = "C:\\Downloads\\";

        List<FileInfo> allFiles = GetAllFiles(folderPath);

        foreach (FileInfo file in allFiles)
        {
            // Process the file
            Console.WriteLine(file.FullName);

            // Copy the file to another location
            file.CopyTo("C:\\MyOtherFolder\\" + file.Name);

            // Delete the file
            file.Delete();
        }
        
        string folder = "C:\\Users\\leon\\Downloads";
        Dictionary<string, List<string>> filesByExtension = GetAllFilesSortedByExtension(folder);
        
        foreach (var files in filesByExtension)
        {
            // Print the file extension and the files with that extension
            Console.WriteLine(files.Key);
            foreach (string file in files.Value)
            {
                Console.WriteLine(file);
            }
        }
        */
    }
    
    public static List<FileInfo> GetAllFiles(string folder)
    {
        List<FileInfo> files = new List<FileInfo>();

        // Check if the folder exists
        if (Directory.Exists(folder))
        {
            // Create a DirectoryInfo object for the folder
            DirectoryInfo directory = new DirectoryInfo(folder);

            // Get all of the files in the folder and its subfolders
            // using a single call and a single iteration over the results
            files.AddRange(directory.EnumerateFiles("*", SearchOption.AllDirectories));
        }

        return files;
    }
    
    public static Dictionary<string, List<string>> GetAllFilesSortedByExtension(string folder)
    {
        Dictionary<string, List<string>> filesByExtension = new Dictionary<string, List<string>>();

        // Check if the folder exists
        if (Directory.Exists(folder))
        {
            // Create a DirectoryInfo object for the folder
            DirectoryInfo directory = new DirectoryInfo(folder);

            // Get all of the files in the folder and its subfolders
            // using a single call and a single iteration over the results
            IEnumerable<string> allFiles = directory.EnumerateFiles("*", SearchOption.AllDirectories)
                .Select(file => file.FullName);

            // Group the files by their file extension
            var filesByExt = allFiles.GroupBy(file => Path.GetExtension(file));

            // Add the grouped files to the dictionary
            foreach (var files in filesByExt)
            {
                filesByExtension.Add(files.Key, files.ToList());
            }
        }

        return filesByExtension;
    }

}