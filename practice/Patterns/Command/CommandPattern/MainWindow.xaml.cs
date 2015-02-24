using System.Windows;
using System.Windows.Controls;

namespace Epam.NetMentoring.CommandPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new ViewModel();
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        
            //IT: Adding default Command Menus

            viewModel.Menu.Add(new FileList());
            viewModel.Menu.Add(new ShowProcesses());
            viewModel.Menu.Add(new ShowRestRequest());
            menuItems.ItemsSource = viewModel.Menu;
        }

        private void ExecuteCommand(object sender, RoutedEventArgs e)
        {
            var selectedItem = (MenuItem)sender;
            var command = (ICommand)selectedItem.CommandParameter;
            var receiver = new Receiver(viewModel);
            command.Receiver = receiver;
            var invoker = new Switch(viewModel);
            invoker.StoreAndExecute(command);
        }
    }
}
