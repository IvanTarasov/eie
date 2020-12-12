using ConsoleUI;
using eie.App;
using System.IO;
using System.Text;

namespace eie.Commands.Custom
{
    class NewVariantCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public NewVariantCommand()
        {
            Name = "nvar";
            Description = "[var_name]: create a new variant template";
        }

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Shell.PrintErrorMessage("Argument don't recieved!");
                return;
            }
            string varName = args[1];

            try
            {
                string mainDir = AppInfo.GetMainDir();
                InitTasks(mainDir + "\\" + varName);

                Shell.PrintSuccessMessage("Variant '" + varName + "' was added!");
            }
            catch (System.Exception e)
            {
                Shell.PrintErrorMessage("ERROR: " + e.Message);
            }

        }

        private void InitTasks(string currentDir)
        {
            CreateTask(currentDir, "test.py");
            CreateTask(currentDir + "\\n2", "n2.py");
            CreateTask(currentDir + "\\n6", "n6.py");
            CreateTask(currentDir + "\\n12", "n12.py");
            CreateTask(currentDir + "\\n16", "n16.py");
            CreateTask(currentDir + "\\n17", "n17.py");
            CreateTask(currentDir + "\\n22", "n22.py");
            CreateTask(currentDir + "\\n23", "n23.py");
            CreateTask(currentDir + "\\n24", "n24.py");
            CreateTask(currentDir + "\\n25", "n25.py");
            CreateTask(currentDir + "\\n26", "n26.py");
            CreateTask(currentDir + "\\n27", "n27.py");
        }

        private void CreateTask(string path, string scriptName)
        {
            Directory.CreateDirectory(path);
            using (FileStream fs = File.Create(path + "\\" + scriptName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("print('pass script')");
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }
    }
}
