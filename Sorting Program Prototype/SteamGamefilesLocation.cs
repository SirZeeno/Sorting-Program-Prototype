namespace Sorting_Program_Prototype;

using System;
using System.IO;
using Indieteur.SAMAPI;

public class SteamGamefilesLocation
{
    string steamappsPath = @"C:\Program Files (x86)\Steam\steamapps\steamapps.vdf";
    SteamAppsManager sam;

    public void GetVdfInfo()
    {

        if (File.Exists(steamappsPath))
        {
            sam = new SteamAppsManager(steamappsPath);
        }
        else
        {
            sam = new SteamAppsManager();
        }

        List<string> steamLibraryFolders = sam.LibraryFolders.ToList();
    }
}