using System.Collections.ObjectModel;

namespace DartsAssistant.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";
        public ObservableCollection<string> NumericButtons { get; } = new();

        public MainWindowViewModel()
        {
            for (int i = 1; i < 21; i++)
            {
                NumericButtons.Add(i.ToString());
            }
        }
    }
}
