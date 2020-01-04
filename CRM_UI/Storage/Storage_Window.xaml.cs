using CRM_UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CRM_UI.Storage
{
    /// <summary>
    /// Логика взаимодействия для Storage_Window.xaml
    /// </summary>
    public partial class Storage_Window : UserControl
    {
        private BindingList<TodoModel> _todoData;

        public Storage_Window()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _todoData = new BindingList<TodoModel>()
            {
                new TodoModel(){vendorcode = "TF3667", Title = "Ботинки", Measurements = "шт", CostPrice = 15.92, Price = 58.99, Weight = 20, Volume = 5,
                Url = "https://intertop.ua/ua/catalog/muzhskaya_obuv/timberland-tbl-icon-6-double-collar/?gclid=CjwKCAiA_f3uBRAmEiwAzPuaM_sPzJBm0m52fmhYSmb-XRdfXYAEABhIVbFSJD2TM7uw-_NpOZe2HhoCcCMQAvD_BwE",
                InStock = false}

            };

            dgXAML.ItemsSource = _todoData;
        }

        private void OpenPopUpBox_Click(object sender, RoutedEventArgs e)
        {
            OpenPopUpBox.Visibility = Visibility.Collapsed;
            ClosedPopUpBox.Visibility = Visibility.Visible;
        }

        private void ClosedPopUpBox_Click(object sender, RoutedEventArgs e)
        {
            OpenPopUpBox.Visibility = Visibility.Visible;
            ClosedPopUpBox.Visibility = Visibility.Collapsed;
        }

        private void VendorTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                NameTextBox.BorderBrush = Brushes.Red;
                NameTextBox.Foreground = Brushes.Red;

            }

            if (NameTextBox.Text.Length > 0)
            {
                NameTextBox.BorderBrush = Brushes.Gray;
                NameTextBox.Foreground = Brushes.Black;


                NameTextBox.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void UnitTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UnitTxt.Text == "")
            {
                UnitTxt.BorderBrush = Brushes.Red;
                UnitTxt.Foreground = Brushes.Red;

            }

            if (UnitTxt.Text.Length > 0)
            {
                UnitTxt.BorderBrush = Brushes.Gray;
                UnitTxt.Foreground = Brushes.Black;


                UnitTxt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void CostTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CostTxt.Text == "")
            {
                CostTxt.BorderBrush = Brushes.Red;
                CostTxt.Foreground = Brushes.Red;

            }

            if (CostTxt.Text.Length > 0)
            {
                CostTxt.BorderBrush = Brushes.Gray;
                CostTxt.Foreground = Brushes.Black;


                CostTxt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void PriceTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PriceTxt.Text == "")
            {
                PriceTxt.BorderBrush = Brushes.Red;
                PriceTxt.Foreground = Brushes.Red;

            }

            if (PriceTxt.Text.Length > 0)
            {
                PriceTxt.BorderBrush = Brushes.Gray;
                PriceTxt.Foreground = Brushes.Black;


                PriceTxt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void WeightTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void VolumetTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void UrltTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBoxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxNumber.Text == "")
            {
                TextBoxNumber.BorderBrush = Brushes.Red;
                TextBoxNumber.Foreground = Brushes.Red;


                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }

            if (TextBoxNumber.Text.Length > 0)
            {
                TextBoxNumber.BorderBrush = Brushes.Gray;
                TextBoxNumber.Foreground = Brushes.Black;


                btnOnAdd.Visibility = Visibility.Visible;
                btnOffAdd.Visibility = Visibility.Collapsed;
                TextBoxNumber.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        

        private void btnOnAdd_Click(object sender, RoutedEventArgs e)
        {

            

            //if (ComboBoxMaterial.ItemsSource == null)
            //{
            //    btnOnAdd.Visibility = Visibility.Collapsed;
            //    btnOffAdd.Visibility = Visibility.Visible;
            //}
            //if (ComboBoxMaterial.SelectedIndex > 0)
            //{
            //    ComboBoxMaterial.BorderBrush = Brushes.Gray;
            //    ComboBoxMaterial.Foreground = Brushes.Black;


            //    btnOnAdd.Visibility = Visibility.Visible;
            //    btnOffAdd.Visibility = Visibility.Collapsed;
            //    TextBoxNumber.Style = this.FindResource("MaterialDesignFloatingHintComboBox") as Style;
            //}
        }

        private void ComboBoxMaterial_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ComboBoxMaterial.ItemsSource == null)
            {
                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }
        }
    }
}
