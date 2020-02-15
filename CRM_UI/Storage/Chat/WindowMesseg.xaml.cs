using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
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
using System.Windows.Shapes;

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для WindowMesseg.xaml
    /// </summary>
    public partial class WindowMesseg : Window
    {
        public static string UserName { get; set; }
        public WindowMesseg()
        {
            InitializeComponent();
        }
        public WindowMesseg(string userLogin)
        {
            InitializeComponent();
            UserName = userLogin;


            MessegingPanel.UpdateLayout();
        }

        private void Messeg_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Messeg_Txt.Text == "")
            {
                Messeg_Txt.BorderBrush = Brushes.Red;
                Messeg_Txt.Foreground = Brushes.Red;


                SendMesseg_Btn.Visibility = Visibility.Collapsed;
                SendMessegOff_Btn.Visibility = Visibility.Visible;
            }

            if (Messeg_Txt.Text.Length > 0)
            {
                Messeg_Txt.BorderBrush = Brushes.Gray;
                Messeg_Txt.Foreground = Brushes.Black;


                SendMesseg_Btn.Visibility = Visibility.Visible;
                SendMessegOff_Btn.Visibility = Visibility.Collapsed;
                Messeg_Txt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void CloseChat_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HideChat_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private void MessegingWindow_Loaded(object sender, RoutedEventArgs e)

        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source={String_Resources.pathToDatabase}")))
            {
                conn.Open();
                //this.UserName = "Mr_VlaLin";
                SQLiteCommand command = new SQLiteCommand($"SELECT Orders.ID, User.Login,Categories.NAME, Goods.NAME, " +
                    $"Goods.PRICE, Orders.ADD_Time FROM Orders INNER JOIN User ON Orders.ID_USER = User.Login_id INNER JOIN Goods ON " +
                    $"Orders.ID_GOODS = Goods.ID INNER JOIN Categories ON Orders.ID_CATEGORIES = Categories.ID WHERE User.Login == '{UserName}'", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        MessegingPanel.Children.Add(new UserControlMessageReceived(
                            $"Заказ !\n{record.GetValue(0)}\n{record.GetValue(1)}\n{record.GetValue(2)}\n{record.GetValue(3)}\nЦена {record.GetValue(4)}", record.GetValue(5).ToString()));

                    }
                }
            }

        }

        private void MessegingPanel_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
