using ModLoader;
using SFS.Input;
using SFS.IO;
using SFS.Parsers.Json;
using System.IO;
using System.Net;
using UnityEngine;

namespace SFSMod
{
	public class Settings 
	{


		public static Settings Main;

        public static void DownloadFile(string url, string destinationFilePath)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, destinationFilePath);
            }
        }
        public static void DeleteFolder(string folderPath)
        {
            Directory.Delete(folderPath, true);
        }



        public static void Setup()
		{
            // Again for the singleton pattern. To use keybindings values anywhere in your mod.


            string modFolderPath = MyMod.modFolder.ToString();
            string modFolderPath2 = modFolderPath.Replace("SFSMod", "");

            Debug.Log(modFolderPath);
            DownloadFile("https://github.com/cucumber-sp/UITools/releases/latest/download/UITools.dll", modFolderPath2+ "UITools.dll");
            DownloadFile("https://github.com/cucumber-sp/PartEditor/releases/download/v1.0/PartEditor.dll", modFolderPath2+ "PartEditor.dll");

            DeleteFolder(modFolderPath);



        }



    }
}
