namespace Sorting_Program_Prototype;

static class SortingProgramPrototype
{
    static void Main4(string[] args)
    {
        string folder = "C:\\Users\\leon\\Downloads";
        string[] allowedExtensions = new string[] { ".txt", ".docx", ".pdf" };
        Dictionary<string, List<string>> filesByExtension = GetAllFilesSortedByExtension(folder, allowedExtensions);
        string logFile = "C:\\Users\\leon\\Documents\\Testing\\log.txt";
        
        WriteResultsToLogFile(filesByExtension, logFile);
        
        /*
        string destinationDirectory = "C:\\MyFolder\\SortedFiles";
        MoveFilesToFolders(filesByExtension, destinationDirectory);
        */
    }
    
    public static Dictionary<string, List<string>> GetAllFilesSortedByExtension(string folder, string[] allowedExtensions)
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

            // Filter the files by their file extension
            IEnumerable<string> filteredFiles = allFiles.Where(file => allowedExtensions.Contains(Path.GetExtension(file)));

            // Group the files by their file extension
            var filesByExt = filteredFiles.GroupBy(file => Path.GetExtension(file));

            // Add the grouped files to the dictionary
            foreach (var files in filesByExt)
            {
                filesByExtension.Add(files.Key, files.ToList());
            }
        }

        return filesByExtension;
    }
    
    public static void WriteResultsToLogFile(Dictionary<string, List<string>> filesByExtension, string logFile)
    {
        // Open the log file for writing
        using (StreamWriter log = File.CreateText(logFile))
        {
            // Write the results to the log file
            foreach (var files in filesByExtension)
            {
                log.WriteLine(files.Key);
                foreach (string file in files.Value)
                {
                    log.WriteLine(file);
                }
            }
        }
    }
    
    public static void MoveFilesToFolders(Dictionary<string, List<string>> filesByExtension, string destinationDirectory)
    {
        // Create the destination directory if it doesn't exist
        Directory.CreateDirectory(destinationDirectory);

        // Iterate over the dictionary of files
        foreach (var files in filesByExtension)
        {
            // Create a new folder with the name of the file extension
            // in the destination directory
            string folder = Path.Combine(destinationDirectory, files.Key.Trim('.'));
            Directory.CreateDirectory(folder);

            // Move each file in the list to the new folder
            foreach (string file in files.Value)
            {
                File.Move(file, Path.Combine(folder, Path.GetFileName(file)));
            }
        }
    }
}