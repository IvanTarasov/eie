using System;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace eie.Launcher
{
    class Launcher
    {
        public string MainDir { get; private set; }
        public string CurrentDir { get; private set; }
        private ScriptEngine Engine;

        Launcher(string mainDirPath)
        {
            Engine = Python.CreateEngine();
            OpenOrCreateMainDir(mainDirPath);
        }

        public void RunScript(string scriptName) // with '.py'
        {
            Engine.ExecuteFile(CurrentDir + scriptName);
        }

        private void OpenOrCreateMainDir(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            MainDir = dirInfo.FullName;
        }
    }
}
