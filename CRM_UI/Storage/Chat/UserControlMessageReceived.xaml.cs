using System.Windows;
using System.Windows.Controls;

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для UserControlMessageReceived.xaml
    /// </summary>
    public partial class UserControlMessageReceived : UserControl
    {
        public UserControlMessageReceived()
        {
            InitializeComponent();
        }
        public UserControlMessageReceived(string user_msg)
        {
            InitializeComponent();
            this.TextFromUser_TB.Text = user_msg;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
