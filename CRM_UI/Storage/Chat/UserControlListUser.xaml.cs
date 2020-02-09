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

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для UserControlListUser.xaml
    /// </summary>
    public partial class UserControlListUser : UserControl
    {
        public UserControlListUser()
        {
            InitializeComponent();
           
        }
        public UserControlListUser(string imageURL, string login, string msgCount)
        {
            InitializeComponent();
            this.ImgUser.ImageSource = new BitmapImage(new Uri(imageURL));
            this.UserLogin_TB.Text = login;
            this.MessegeCout_TB.Text = msgCount;
        }

        private void StartChatWithUser_btn_Click(object sender, RoutedEventArgs e)
        {
            Window_Messeg m =  new Window_Messeg(this.UserLogin_TB.Text);
            
        }
    }
}
