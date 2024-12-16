using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UppgiftSeeSharp_MainApp.Models;
using UppgiftSeeSharp_MainApp.ViewModels;

namespace UppgiftSeeSharp_MainApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        var tempModel = new User();
        DataContext = viewModel;
    }

    private void AddUser_Click(object sender, RoutedEventArgs e)
    {
        var userItem = new User();
        {
            userItem.IsCompleted = true;
        };
        /*Activities.Items.Add(userItem);

        Activity.Clear();*/
    }

    private void ChangeStatus_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            if (button.DataContext is User user)
            {
                user.IsCompleted = true;
            }
        }
    }
}