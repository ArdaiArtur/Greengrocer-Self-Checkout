using System;
using System.Collections.Generic;
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
using Greengrocer_Self_Checkout.Model;
using Greengrocer_Self_Checkout.Comand;
using Microsoft.Win32;
using System.IO;

namespace Greengrocer_Self_Checkout
{

    public partial class AddItemPage : Page
    {
        private  DatatModification modification = new DatatModification();
        private DataGetter DataGetter = new DataGetter();

        public AddItemPage()
        {
            
            InitializeComponent();
            dataGrid.ItemsSource = MainWindow.AllItems;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//exit button
            if (MainWindow.previousContent != null)
            {
                Content = MainWindow.previousContent;
                MainWindow.previousContent = null; // Clear previous content to avoid repeating
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//ADD BUTTON
            MainWindow.AllItems.Clear();
            try
            {
                modification.AddItem(Product.Text, Convert.ToDouble(Price.Text), Type.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("incorrect price or name ");
            }
            
            dataGrid.ItemsSource = null;
            DataGetter.GetInList();
            dataGrid.ItemsSource = MainWindow.AllItems;
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                string destinationFolderPath = "C:\\Users\\Arrtur\\Desktop\\Bank\\Greengrocer Self Checkout\\Greengrocer Self Checkout\\bin\\Debug\\netcoreapp3.1\\img"; // Replace with your folder path
                string newFileName = Product.Text+".jpg"; 

                string destinationFilePath = System.IO.Path.Combine(destinationFolderPath, newFileName);

                try
                {
                    File.Move(selectedFilePath, destinationFilePath);
                    MessageBox.Show("Item added  successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//DELLET BUTTON
            
            if (dataGrid.SelectedItem != null)
            {
                // Assuming your data source items are of a class type
                CommonThings selectedItem = (CommonThings)dataGrid.SelectedItem;
                modification.DeleteItem(selectedItem.Id);
                // Perform any necessary backend deletion, if applicable
                // Example: Remove the item from your original collection
                MainWindow.AllItems.Remove(selectedItem);

                try
                {
                    File.Delete(selectedItem.Name);
                    MessageBox.Show("File deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the file: {ex.Message}");
                }
                // Update the data grid to reflect the changes
                dataGrid.Items.Refresh();
            }


        }
    }
}
