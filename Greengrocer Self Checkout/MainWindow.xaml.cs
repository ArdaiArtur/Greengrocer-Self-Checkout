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
        public ButtonLoader bl = new ButtonLoader();
        public MainWindow()
        {
            InitializeComponent();


            // grid1.Children.Add(  bl.GridButon());
            grid2 = bl.GridButon();

            grid1.Children.Add(grid2);
            Change.Content = "fufu";

            Show.Text = (multi * Convert.ToDouble(Weight.Text)).ToString();
            
        }



        private void Mainthing_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
           // Show.Text = b.Name;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        { grid2.Children.Clear();
            grid1.Children.Remove(grid2);

            // grid1.Children.Add(  bl.GridButon());
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Change.Content == "fufu")
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            {
                grid2 = bl.GridButonSwap();
                Change.Content = "veve";
            }
            else
            {
                grid2 = bl.GridButon();
                Change.Content = "fufu";
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

