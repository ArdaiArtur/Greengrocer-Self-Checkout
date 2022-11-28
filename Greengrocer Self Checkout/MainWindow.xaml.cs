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
        
        public static List<Fruit> fufu = new List<Fruit>();
        public static List<Vegetables> veve = new List<Vegetables>();
        public static double multi = 0;
        public static double SelecWeight ;
        public static dynamic Getter;
        public static List<dynamic> lis;
        public ButtonLoader bl = new ButtonLoader();
        public MainWindow()
        {
            
          this.DataContext =Getter ;
            InitializeComponent();
            // grid1.Children.Add(  bl.GridButon());
            grid2 = bl.GridButon();

            grid1.Children.Add(grid2);
            Change.FontSize = 30;
            Change.Content = "Vegetables";
            try
            {
                Show.Text = (multi * Convert.ToDouble(Weight.Text)).ToString();
            }
            catch (Exception)
            {

                Show.Text = "Invalid number";
            }
           
            
        }



        private void Mainthing_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            // Show.Text = b.Name;
            try
            {
                SelecWeight = Convert.ToDouble(Weight.Text);
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

        private void Change_Click(object sender, RoutedEventArgs e)
        { grid2.Children.Clear();
            grid1.Children.Remove(grid2);

            // grid1.Children.Add(  bl.GridButon());
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Change.Content != "Fruits")
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            {
                Change.FontSize = 40;
                grid2 = bl.GridButonSwap();
                Change.Content = "Fruits";
            }
            else
            {
                Change.FontSize = 30;
                grid2 = bl.GridButon();
                Change.Content = "Vegetables";
            }
            grid1.Children.Add(grid2);
        }



        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
             Show.Text = Math.Round((multi * Convert.ToDouble(Weight.Text)), 2).ToString();

            }
            catch (Exception)
            {
                Show.Text = "Invalid weight";

            }
        }

        private void grid1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Show.Text = Math.Round((multi * Convert.ToDouble(Weight.Text)), 2).ToString();

            }
            catch (Exception)
            {
                Show.Text = "Invalid weight";

            }
        }
    }
}







