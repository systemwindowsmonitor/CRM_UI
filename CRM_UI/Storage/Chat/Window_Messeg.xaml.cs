using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для Window_Messeg.xaml
    /// </summary>
    public partial class Window_Messeg : UserControl
    {
        private string userLogin = String.Empty;
        public Window_Messeg()
        {
            InitializeComponent();
       
        }
        public Window_Messeg(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
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

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private void MessegingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source={String_Resources.pathToDatabase}")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT Orders.ID, User.Login,Categories.NAME, Goods.NAME, Goods.PRICE, Orders.ADD_Time FROM Orders INNER JOIN User ON Orders.ID_USER = User.Login_id INNER JOIN Goods ON Orders.ID_GOODS = Goods.ID INNER JOIN Categories ON Orders.ID_CATEGORIES = Categories.ID WHERE User.Login == '{this.userLogin}'", conn);
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
    }
}