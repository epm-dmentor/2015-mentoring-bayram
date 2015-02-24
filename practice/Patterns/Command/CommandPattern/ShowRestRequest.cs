namespace Epam.NetMentoring.CommandPattern
{
    public class ShowRestRequest:ICommand
    {
        private Receiver _receiver;
        
        public ShowRestRequest()
        {
            Name = "Show Content of REST Request";
        }

        public string Name { get; private set; }
        
        public void Execute()
        {
           _receiver.ShowRestRequest();
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
