using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;
using System.IO;
using System.Xml;
using System.Data.SQLite;
using System.Data.Common;
using CRM_UI.Models;

namespace CRM_UI.Storage
{
    /// <summary>
    /// Логика взаимодействия для Storage_Window.xaml
    /// </summary>
    public partial class Storage_Window : UserControl
    {
        private BindingList<BaseModel> _todoData;
        long selected_categorie = 0;

        public Storage_Window()
        {
            InitializeComponent();
            _todoData = new BindingList<BaseModel>();

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
        private void ClearDataView()
        {
            //if(_todoData)
            _todoData.Clear();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SelectFolders();
            SelectGoods();
            UpdateDataView();
        }
        private void SelectFolders()
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Categories;", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        _todoData.Add(new FolderModel()
                        {
                            vendorcode = record.GetInt64(0).ToString(),
                            Title = record.GetString(1),
                            icon_path = CRM_UI.String_Resources.Folder_icon_path
                        }) ;
                    }
                }
            }
        }
        private void UpdateDataView()
        {
            dgXAML.ItemsSource = _todoData;
        }
        private void SelectGoods()
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT* FROM Goods WHERE ID_CATEGORI = {selected_categorie};", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        _todoData.Add(new ProductModel()
                        {
                            vendorcode = record.GetInt64(0).ToString(),
                            Title = record.GetString(1),
                            Price = record.GetDouble(2).ToString()
                        });

                    }
                }
            }
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

            if (TextBoxNumber.Text.Length > 0 && ComboBoxMaterial.SelectedIndex >= 0)
            {
                TextBoxNumber.BorderBrush = Brushes.Gray;
                TextBoxNumber.Foreground = Brushes.Black;


                btnOnAdd.Visibility = Visibility.Visible;
                btnOffAdd.Visibility = Visibility.Collapsed;
                TextBoxNumber.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void ComboBoxMaterial_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ComboBoxMaterial.ItemsSource == null)
            {
                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }
        }




        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GC.Collect();
        }

        private void ComboBoxMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxMaterial.SelectedIndex < 0)
            {
                ComboBoxMaterial.BorderBrush = Brushes.Red;
                ComboBoxMaterial.Foreground = Brushes.Red;


                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }

            if (ComboBoxMaterial.SelectedIndex >= 0 && TextBoxNumber.Text.Length > 0)
            {
                ComboBoxMaterial.BorderBrush = Brushes.Gray;
                ComboBoxMaterial.Foreground = Brushes.Black;


                btnOnAdd.Visibility = Visibility.Visible;
                btnOffAdd.Visibility = Visibility.Collapsed;
                ComboBoxMaterial.Style = this.FindResource("MaterialDesignFloatingHintComboBox") as Style;
            }
        }

        private void TextBoxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                CancelDHMinusMaterial.Command.Execute("x:Static materialDesign:DialogHost.CloseDialogCommand");
            }
            if (e.Key.Equals(Key.LeftCtrl) || e.Key.Equals(Key.RightCtrl))
                e.Handled = true;
        }

        private void TextBoxNumber_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
         e.Command == ApplicationCommands.Cut ||
         e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void popupbox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
        }

        private void Material_MouseEnter(object sender, MouseEventArgs e)
        {
            Material.Style = this.FindResource("MaterialDesignFloatingActionMiniAccentButton") as Style;
            Material.Background = Brushes.Red;
        }
        private void Material_MouseLeave(object sender, MouseEventArgs e)
        {
            Material.Background = null;
            Material.Style = this.FindResource("MaterialDesignFloatingActionMiniAccentButton") as Style;
        }

        private void btnAddMaterials_Click(object sender, RoutedEventArgs e)
        {
            MaterialsPanel.Children.Add(((Separator)XamlReader.Load(XmlReader.Create(new StringReader(XamlWriter.Save(separ))))));
            MaterialsPanel.Children.Add(((TextBox)XamlReader.Load(XmlReader.Create(new StringReader(XamlWriter.Save(TextBoxAddMaterial))))));
        }


        private void dgXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgXAML.SelectedItem is FolderModel)
            {
                selected_categorie = long.Parse((dgXAML.SelectedItem as FolderModel).vendorcode);
                ClearDataView();
                if (selected_categorie > 0)
                {
                    AddReturnFolder();
                    SelectGoods();
                }
                else
                {   
                    SelectFolders();
                }
            }
            if(dgXAML.SelectedItem is ProductModel)
            {
                MessageBox.Show((dgXAML.SelectedItem as ProductModel).Title);
            }
            UpdateDataView();
        }

        private void AddReturnFolder()
        {
            _todoData.Add(new FolderModel() { icon_path = CRM_UI.String_Resources.Folder_return_icon_path, Title = CRM_UI.String_Resources.Folder_return_text, vendorcode = "0" });
        }

        private void AddCategorie_btn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"INSERT INTO Categories(NAME) values(@name);", conn);
                command.Parameters.Add(new SQLiteParameter("@name", NameCategorie_Tb.Text));
                command.ExecuteNonQuery();
            }
            ClearDataView();
            SelectFolders();
            UpdateDataView(); 

        }

        private void OpenMaterial_Loaded(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Categories;", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        SelectCategorie_CB.Items.Add(record.GetString(1));
                    }
                }
            }
            SelectCategorie_CB.SelectedIndex = 0;
        }

        private void AddMaterial_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"INSERT INTO Goods(NAME,PRICE,ID_CATEGORI) values(@name,@price,@cat_id);", conn);
                command.Parameters.Add(new SQLiteParameter("@name", NameTextBox.Text));
                command.Parameters.Add(new SQLiteParameter("@price", PriceTxt.Text));
                command.Parameters.Add(new SQLiteParameter("@cat_id", ++SelectCategorie_CB.SelectedIndex));
                command.ExecuteNonQuery();
            }
        }
    }
}
