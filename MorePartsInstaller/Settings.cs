using ModLoader;
using SFS.Input;
using SFS.IO;
using SFS.Parsers.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using UnityEngine;

namespace MorePartsInstaller
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
        public static void DownloadAndUnzipFile(string url, string destinationFolderPath)
        {
            using (var client = new WebClient())
            {
                string tempZipFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".zip");
                client.DownloadFile(url, tempZipFilePath);
                ZipFile.ExtractToDirectory(tempZipFilePath, destinationFolderPath);
                File.Delete(tempZipFilePath);
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
            string modFolderPath2 = modFolderPath.Replace("MorePartsInstaller", "");

            Debug.Log(modFolderPath);
            DownloadFile("https://github.com/DinitrogenTetroxide/sfs-electricity/releases/download/v0.4/N2O4_Electricity_V0.4-Base.pack", modFolderPath2+ "Custom Assets/Parts/N2O4_Electricity_V0.4-Base.pack");
            DownloadFile("https://github.com/105-Code/MorePartsMod/releases/download/v3.0.2/moreparts.pack", modFolderPath2 + "Custom Assets/Parts/moreparts.pack");
            
            string zipFileUrl = "https://github.com/105-Code/MorePartsMod/releases/download/v3.0.2/MorePartsMod.zip";
            string destinationFolderPath = modFolderPath2;

            try
            {
                DownloadAndUnzipFile(zipFileUrl, destinationFolderPath);
                Debug.Log("Zip file downloaded and extracted successfully.");
            }
            catch (Exception ex)
            {
                Debug.Log("Error downloading and extracting zip file: " + ex.Message);
            }

            DeleteFolder(modFolderPath);



        }



    }
}
