namespace Sorting_Program_Prototype;
using System;
using System.IO;
using Newtonsoft.Json;

public class JsonFileUtils
{
    private static Data data;
    
    static void Main9(string[] args)
    {
        // Test file path
        string path = @"C:\Users\leon\Downloads\Testing\test.json";
        // Create a new object to serialize
        data = new Data() {Name = "John Smith", Age = 30, Location = "New York"};

        SaveData(path);
        LoadData(path);
    }

    public static void LoadData(string filePath)
    {
        // Read the data from the JSON file
        data = JsonFileUtility.ReadFromJsonFile<Data>(filePath);
    }

    public static void SaveData(string filePath)
    {
        // Write the data to the JSON file
        JsonFileUtility.WriteToJsonFile(filePath, data);
    }
    
    public static void ReadJsonFile(string filePath)
    {
        // Open the JSON file
        using StreamReader sr = new StreamReader(filePath);
        // Create a JSON serializer
        JsonSerializer serializer = new JsonSerializer();

        // Create a JsonReader object using the StreamReader object
        using (JsonReader reader = new JsonTextReader(sr))
        {
            // Deserialize the JSON data into an object of the Data class
            Data data = serializer.Deserialize<Data>(reader) ?? throw new InvalidOperationException();

            // Access the data in the JSON file
            Console.WriteLine(data.Name);
            Console.WriteLine(data.Age);
            Console.WriteLine(data.Location);
        }
    }

    public static void WriteJsonFile<T>(string filePath, T jsonData)
    {
        // Serialize the object to a JSON string
        string json = JsonConvert.SerializeObject(jsonData);

        // Open the JSON file using a FileStream
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            // Write the JSON string to the file
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(json);
            }
        }

        Console.WriteLine("Data written to file successfully.");
    }

    class Data
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }
}

public static class JsonFileUtility
{
    public static T ReadFromJsonFile<T>(string filePath)
    {
        // Open the JSON file
        using StreamReader sr = new StreamReader(filePath);
        // Create a JSON serializer
        JsonSerializer serializer = new JsonSerializer();

        // Create a JsonReader object using the StreamReader object
        using (JsonReader reader = new JsonTextReader(sr))
        {
            // Deserialize the JSON data into an object of the specified type
            return serializer.Deserialize<T>(reader);
        }
    }
    
    public static void WriteToJsonFile<T>(string filePath, T jsonData)
    {
        // Serialize the object to a JSON string
        string json = JsonConvert.SerializeObject(jsonData);

        // Open the JSON file using a FileStream
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            // Write the JSON string to the file
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(json);
            }
        }
    }
}