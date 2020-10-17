using System.IO;
using System.Text.Json;

namespace eie.App
{
    class ConfigFile
    {
        public string MainDir { get; set; }
        public void Save()
        {
            string config = JsonSerializer.Serialize((ConfigFile)MemberwiseClone());
            using (StreamWriter sw = new StreamWriter("C:\\eie\\config.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteAsync(config);
            }
        }
    }
}
