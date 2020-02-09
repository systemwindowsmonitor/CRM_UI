using System.Data.Common;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для WindowHomeChat.xaml
    /// </summary>
    public partial class WindowHomeChat : UserControl
    {
        public WindowHomeChat()
        {
            InitializeComponent();
        }

        private void ContactGrupe_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (170 * index), 0, 0, 0);

            //switch (index)
            //{
            //    case 0:
            //        ChatUsers_Grid.Children.Clear();
            //        ChatUsers_Grid.Children.Add(new UserControlListUser());
            //        break;

            //    case 1:
            //        ChatUsers_Grid.Children.Clear();
            //        ChatUsers_Grid.Children.Add(new UserControlListAdmin());
            //        break;
            //    default:
            //        break;
            //}
        }

        private void UserWithOrders_SP_Loaded(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source={String_Resources.pathToDatabase}")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM USER", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        UserWithOrders_SP.Children.Add(new UserControlListUser("https://i.pinimg.com/originals/33/b8/69/33b869f90619e81763dbf1fccc896d8d.jpg", reader.GetValue(1).ToString(), "-999"));
                    }
                }
            }
            //UserWithOrders_SP.Children.Add(new UserControlListUser("https://i.pinimg.com/originals/33/b8/69/33b869f90619e81763dbf1fccc896d8d.jpg", "LOX", "-999"));
            //UserWithOrders_SP.Children.Add(new UserControlListUser());
            //UserWithOrders_SP.Children.Add(new UserControlListUser());
        }
    }
}
