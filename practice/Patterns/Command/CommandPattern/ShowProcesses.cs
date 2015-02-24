namespace Epam.NetMentoring.CommandPattern
{
    public class ShowProcesses:ICommand
    {

        private Receiver _receiver;

        public ShowProcesses()
        {
          Name = "Show Processes";
        }
        
        public string Name { get; private set; }
       
        public void Execute()
        {
            _receiver.ShowProcess();
        }


        public Receiver Receiver 
        {
            get
            {
                return _receiver;
            }
            set
            {
                _receiver = value;
            } 
        }
        public ICommand Command
        {
            get { return this; }
        }
    }
}
