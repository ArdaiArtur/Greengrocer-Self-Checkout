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
using System.Data.Entity;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Controls.Primitives;

namespace Greengrocer_Self_Checkout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        
        public static List<CommonThings> fufu = new List<CommonThings>();    
        public static List<BoughtItems> BoughtItemsList = new List<BoughtItems>();
        public static double TotalPrice ;
        public static CommonThings InfoOfProduct=new CommonThings();
       
       
        public ButtonLoader bl = new ButtonLoader();
        public MainWindow()
        {
            
            
            InitializeComponent();
            // grid1.Children.Add(  bl.GridButon());
            //grid2 = bl.GridButon("Fruits");
            bl.ButtonClicked += Event_ButtonClicked;
            // grid1.Children.Add(grid2);
            
            try
            {
                Show.Text = (InfoOfProduct.Price * Convert.ToDouble(Weight.Text)).ToString();
            }
            catch (Exception)
            {

                Show.Text = "Invalid number";
            }
           
            
        }

        private void Event_ButtonClicked(object sender, EventArgs e)
        {
            double Value = 0;
            
            // Handle button click
            try
            {   double TextWeight = Convert.ToDouble(Weight.Text);
                Value = Math.Round((InfoOfProduct.Price * TextWeight), 2);
             if (Weight.Text != "0")
                {
                  BoughtItems items =new BoughtItems
                  { 
                  Id = InfoOfProduct.Id,
                  Name=InfoOfProduct.Name,
                  Count= InfoOfProduct.Count,
                  Price= InfoOfProduct.Price,
                  Date= InfoOfProduct.Date,
                  Weight = TextWeight
                  };
                    
                  BoughtItemsList.Add(items);         
                  ShoppingList.Items.Add($"{InfoOfProduct.Name}  {InfoOfProduct.Price}*{Weight.Text} = {Value}");
                  TotalPrice += Value;
                  Show.Text = Math.Round(TotalPrice, 2).ToString();
                }
            }
            catch (Exception)
            {
                Show.Text = "Invalid weight ";

            }
           
        }



        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            // Show.Text = b.Name;
            try
            {
               
                Popup popup = new Popup();
                try
                {
                popup.Show();
                }
                catch (Exception)
                {

                
                }
            }
            catch (Exception)
            {

                
            }
            
           
        }
       
       


        //to make it more interactive 
        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            double Value=0;
            try
            {
             Value = Math.Round((InfoOfProduct.Price * Convert.ToDouble(Weight.Text)), 2);

            }
            catch (Exception)
            {
                Show.Text = "Invalid weight";

            }
           
            

        }

        private void VegetabldeB_Click(object sender, RoutedEventArgs e)
        { 

            grid2.Children.Clear();
            grid1.Children.Remove(grid2);
            grid2 = bl.GridButon("Vegetables"); 
            grid1.Children.Add(grid2);
        }

        private void FruitB_Click(object sender, RoutedEventArgs e)
        {
            grid2.Children.Clear();
            grid1.Children.Remove(grid2);
            grid2 = bl.GridButon("Fruits");
            grid1.Children.Add(grid2);
        }

        private void DelList_Click(object sender, RoutedEventArgs e)
        {
            
           
            if (ShoppingList.SelectedItem != null)
            {
                string[] s = ShoppingList.SelectedItem.ToString().Split(" ");
                MessageBox.Show(s[0] + "xlx" + s[1] + "xlx" + s[2] + "l");
                TotalPrice -=Convert.ToDouble( s[s.Length - 1]);
                ShoppingList.Items.Remove(ShoppingList.SelectedItem);
                BoughtItemsList.Remove(BoughtItemsList.FirstOrDefault(item => item.Name == s[0] && item.Weight == Convert.ToDouble( s[2].Split('*')[1] )));
            }
            Show.Text = Math.Round(TotalPrice, 2).ToString();
        }
    }
}







