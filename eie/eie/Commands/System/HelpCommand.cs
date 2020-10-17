using System;

namespace ConsoleUI.Commands
{
    class HelpCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public HelpCommand()
        {
            Name = "help";
            Description = ": lists available commands";
        }

        public void Execute(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (var command in Shell.Commands)
            {
                Console.WriteLine(command.GetInfo());
            }
            Console.ResetColor();
        }
    }
}
