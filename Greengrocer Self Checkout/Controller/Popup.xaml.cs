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
using Greengrocer_Self_Checkout.Comand;
using Greengrocer_Self_Checkout.Model;

namespace Greengrocer_Self_Checkout
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {

        public static event EventHandler MyPropertyChanged;
        public Popup()
        {   
            InitializeComponent();

            if( MainWindow.BoughtItemsList.Count>0)
            foreach (var item in MainWindow.BoughtItemsList)
            {
                string s = $"{item.Name}  {item.Price}*{item.Weight} = {Math.Round( item.Price * item.Weight,2)}";
                Comb.Items.Add(s);
            }
            ALlitems.Text= Math.Round(MainWindow.TotalPrice, 2).ToString();
               
                ddate.Text += DateTime.Now.ToString();
            
            
            
           
        }

        protected virtual void OnMyPropertyChanged()
        {
            MyPropertyChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {   
            DatatModification datatModification = new DatatModification();
            foreach (var item in MainWindow.BoughtItemsList)
            {
                datatModification.IncreasCount(item.Id,item.Weight);
            }
            MainWindow.AllItems.Clear();
            DataGetter dataGetter = new DataGetter();
            dataGetter.GetInList();
            MainWindow.BoughtItemsList.Clear();
            MainWindow.TotalPrice = 0;
            OnMyPropertyChanged();
            
            
            this.Close();
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
