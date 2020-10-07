using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Commands.Custom
{
    class TestCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; set; }

        public TestCommand()
        {
            Name = "test";
            Description = "is test command";
        }

        public void Execute()
        {
            Console.WriteLine("You are execute 'test' command :)");
        }
    }
}
