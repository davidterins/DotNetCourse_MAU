using Assignment_2b.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_2b.Views
{
  /// <summary>
  /// Interaction logic for LogInScreen.xaml
  /// </summary>
  public partial class LogInScreen : UserControl
  {
    public LogInScreen()
    {
      InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
      var vm = (LogInViewModel)DataContext;
      vm.Password = PasswordBox.Password;
    }

    private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
    {
      var vm = (LogInViewModel)DataContext;
      vm.NewPassword = NewPassword.Password;
    }
  }
}
