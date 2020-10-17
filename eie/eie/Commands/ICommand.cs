namespace ConsoleUI
{
    interface ICommand
    {
        string Name { get; }

        string Description { get; }

        void Execute(string[] args);

        string GetInfo() {
            return Name + " " + Description;
        }
    }
}
