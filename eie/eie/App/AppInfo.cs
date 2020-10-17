using System.IO;
using System.Text.Json;

namespace eie.App
{
    static class AppInfo
    {
        public static string OpenedVariant { get; private set; }

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
