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
using Greengrocer_Self_Checkout.Comand;

namespace Greengrocer_Self_Checkout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        public static List<CommonThings> AllItems = new List<CommonThings>();
        public static List<CommonThings> fufu = new List<CommonThings>();    
        public static List<BoughtItems> BoughtItemsList = new List<BoughtItems>();
        public static double TotalPrice ;
        public static CommonThings InfoOfProduct=new CommonThings();
        public static UIElement previousContent;
        public ButtonLoader bl = new ButtonLoader();
      
        public MainWindow()
        {
            InitializeComponent();
            bl.GetInList();
            bl.ButtonClicked += Event_ButtonClicked;
            Popup.MyPropertyChanged+= MyInstance_MyPropertyChanged;

            try
            {
                Show.Text = (InfoOfProduct.Price * Convert.ToDouble(Weight.Text)).ToString();
            }
            catch (Exception)
            {

                Show.Text = "Invalid number";
            } 
        }
        private  void MyInstance_MyPropertyChanged(object sender, EventArgs e)
        {
            Show.Text = Math.Round(TotalPrice, 2).ToString();
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
                    BoughtItems items = new BoughtItems
                    {
                        Id = InfoOfProduct.Id,
                        Name = InfoOfProduct.Name,
                        Count = InfoOfProduct.Count,
                        Price = InfoOfProduct.Price,
                        Date = InfoOfProduct.Date,
                        Weight = TextWeight,
                        ItemType = InfoOfProduct.ItemType,
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
           // Button b = (Button)sender;
            // Show.Text = b.Name;
            try
            {
                if (!Weight.Text.Equals("ADDITEM123"))
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
                else
                {
                    if (Content != null)
                    {

                        previousContent = (UIElement)Content;
                    }
                    Content = new AddItemPage();
                }
            }
            catch (Exception)
            {

                
            }
            ShoppingList.Items.Clear();
               
           
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
                if( double.TryParse(Weight.Text, out double doubleValue))
                Show.Text = "Invalid weight";
                else { Show.Text = "Select Items"; }

            }
           
            

        }

        private void VegetabldeB_Click(object sender, RoutedEventArgs e)
        { 

            grid2.Children.Clear();
            grid1.Children.Remove(grid2);
            grid2 = bl.GridButon("Vegetable"); 
            grid1.Children.Add(grid2);
        }

        private void FruitB_Click(object sender, RoutedEventArgs e)
        {
            grid2.Children.Clear();
            grid1.Children.Remove(grid2);
            grid2 = bl.GridButon("Fruit");
            grid1.Children.Add(grid2);
        }
        private void Meat_Click(object sender, RoutedEventArgs e)
        {
            grid2.Children.Clear();
            grid1.Children.Remove(grid2);
            grid2 = bl.GridButon("Meat");
            grid1.Children.Add(grid2);
        }
        private void Dairy_Click(object sender, RoutedEventArgs e)
        {
            grid2.Children.Clear();
            grid1.Children.Remove(grid2);
            grid2 = bl.GridButon("Dairy");
            grid1.Children.Add(grid2);
        }
        private void DelList_Click(object sender, RoutedEventArgs e)
        {
            
           
            if (ShoppingList.SelectedItem != null)
            {
                string[] s = ShoppingList.SelectedItem.ToString().Split(" ");
               
                TotalPrice -=Convert.ToDouble( s[s.Length - 1]);
                ShoppingList.Items.Remove(ShoppingList.SelectedItem);
                BoughtItemsList.Remove(BoughtItemsList.FirstOrDefault(item => item.Name == s[0] && item.Weight == Convert.ToDouble( s[2].Split('*')[1] )));
            }

            Show.Text = Math.Round(TotalPrice, 2).ToString();
        }
    }
}
