namespace Sorting_Program_Prototype;
using System;
using System.Diagnostics;
using System.Collections.Generic;

public class WingetHelper
{
    string[] _listOfPackages = { "Visual Studio Code", "Git", "Chrome" };
    List<string> _notAvailable = new List<string>();
    List<string> _available = new List<string>();

    private void InstallPackages()
    {
        CheckIfAvailable();
        foreach (var package in _available)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"install {package} -y -h",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }
    }

    private void Export()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "winget",
                Arguments = $"export -o {Environment.CurrentDirectory}\\winget.json",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        if(output.Contains("Installed package is not available from any source: "))
        {
            _notAvailable.Add(output.Substring(52));
        }
    }

    private void Import()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "winget",
                Arguments = $"import -i {Environment.CurrentDirectory}\\winget.json",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        if (output.Contains("Installed package is not available from any source: "))
        {
            _notAvailable.Add(output.Substring(52));
        }
    }
    
    private void CheckIfAvailable()
    {
        foreach (string package in _listOfPackages)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"search {package}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if(output.Contains(package))
            {
                _available.Add(package);
            }
            else
            {
                _notAvailable.Add(package);
            }
        }

        if(_notAvailable.Count > 0)
        {
            Console.WriteLine("The following packages were not available: ");
            Console.WriteLine(string.Join(", ",_notAvailable));
        }
    }
}