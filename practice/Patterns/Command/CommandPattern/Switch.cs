namespace Epam.NetMentoring.CommandPattern
{
    public class Switch
    {
        private readonly ViewModel _model;
        
        public Switch(ViewModel model)
        {
            _model = model;
        }
        
        public void StoreAndExecute(ICommand command)
        {
            if (!_model.Menu.Contains(command))
            {
                _model.Menu.Add(command);
            }
            command.Execute();
        }
    }
}
