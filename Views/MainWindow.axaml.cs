using Avalonia.Controls;
using Avalonia.Interactivity;

namespace lab4.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

	public void OnButtonClick(object sender, RoutedEventArgs e)
        {
                Console.WriteLine("Clicked button " + (sender as Button)!.Content);
        }


    }
}
