using ConsoleUI;
using System;
using System.IO;
using System.Text.Json;

namespace eie.App
{
    static class AppInfo
    {
        public static string OpenedVariant { get; private set; }

        public static void InitConfig()
        {
            try
            {
                // if root dir not found then create this and config file
                DirectoryInfo rootDirInfo = new DirectoryInfo("C:\\eie");
                if (!rootDirInfo.Exists)
                {
                    rootDirInfo.Create();

                    ConfigFile config = new ConfigFile();
                    config.MainDir = "C:\\eie";
                    config.EditorPath = "C:\\Windows\\System32\\notepad.exe";
                    config.Save();

                    Shell.PrintWarningMessage("Main dir is 'C:\\eie', you can change it - just enter 'smd [path]'");
                }

                DirectoryInfo mainDirInfo = new DirectoryInfo(GetMainDir());
                if (!mainDirInfo.Exists)
                {
                    mainDirInfo.Create();
                }
            }
            catch (Exception e)
            {
                Shell.PrintErrorMessage("ERROR: " + e.Message);
            }
        }

        public static string GetEditorPath()
        {
            using (StreamReader sr = new StreamReader("C:\\eie\\config.txt"))
            {
                ConfigFile config = JsonSerializer.Deserialize<ConfigFile>(sr.ReadLine());
                return config.EditorPath;
            }
        }

        public static string GetMainDir()
        {
            using (StreamReader sr = new StreamReader("C:\\eie\\config.txt"))
            {
                ConfigFile config = JsonSerializer.Deserialize<ConfigFile>(sr.ReadLine());
                return config.MainDir;
            }
        }

        public static void ChangeVariant(string varName)
        {
            OpenedVariant = varName;
        }
    }
}
