using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Greengrocer_Self_Checkout
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup()
        {   
            InitializeComponent();

            if( MainWindow.BoughtItemsList.Count>0)
            foreach (var item in MainWindow.BoughtItemsList)
            {
                string s = $"{item.Name}  {item.Price}*{item.Weight} = {Math.Round( item.Price * item.Weight,2)}";
                Comb.Items.Add(s);
            }
            ALlitems.Text=MainWindow.TotalPrice.ToString();
               
                ddate.Text += DateTime.Now.ToString();
            
            
            
           
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
