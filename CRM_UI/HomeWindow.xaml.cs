using CRM_UI.Storage;
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
using System.Windows.Shapes;

namespace CRM_UI
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;


            switch (index)
            {
                case 6:


                    GridMain.Children.Clear();
                    Navigation_Bar form = new Navigation_Bar();
                    GridMain.Children.Add(form);
                    break;
                default:
                    break;
            }
        }

        //private void ButtonPowerOff1_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ButtonPowerOff1.Background = Brushes.Red;
        //}

        //private void ButtonPowerOff1_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    ButtonPowerOff1.Background = Brushes.White;
        //    //////ButtonPowerOff1.Style.Setters["MaterialDesignFloatingActionMiniAccentButton"] = null;
        //}
    }
}
