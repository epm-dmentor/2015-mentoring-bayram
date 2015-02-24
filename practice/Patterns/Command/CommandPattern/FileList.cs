namespace Epam.NetMentoring.CommandPattern
{
    class FileList:ICommand
    {
        private Receiver _receiver;
        
        public FileList()
        {
            Name = "List Files";
        }
        public string Name { get; private set; }
        
        public void Execute()
        {
           _receiver.ListFiles(@"D:\");
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
