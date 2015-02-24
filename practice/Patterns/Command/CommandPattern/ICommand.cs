namespace Epam.NetMentoring.CommandPattern
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
        ICommand Command { get; }
        Receiver Receiver { get; set; }
     
    }
}
