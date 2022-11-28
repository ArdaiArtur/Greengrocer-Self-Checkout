using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Greengrocer_Self_Checkout
{
    public class ButtonLoader : DataGetter
    {
        private readonly string con = Properties.Settings.Default.DataB;
        private readonly Grid  gr ;
        private int buttoncount;
        private dynamic ShowePrice;
       
        public ButtonLoader()
        {
            GetInList(con);
            gr = new Grid();
        }

        private void GridSize(int size)
        {
            gr.ColumnDefinitions.Clear();
            gr.RowDefinitions.Clear();
            for (int i = 0; i < size; i++)
            {
                ColumnDefinition c = new ColumnDefinition
                {
                    //  c.Width = new GridLength(240);
                    Width = new GridLength(1, GridUnitType.Star)
                };
                gr.ColumnDefinitions.Add(c);
            }
            for (int j = 0; j < size; j++)
            {
                RowDefinition c = new RowDefinition
                {
                    // c.Height = new GridLength(240);
                    Height = new GridLength(1, GridUnitType.Star)
                };
                gr.RowDefinitions.Add(c);
            }
        }

        
        private void GridItemFufu(int size,dynamic fufu)
        {
            int counter = 0;
           

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if (counter < fufu.Count)
                    {
                        
                        Button bt = new Button();
                        Grid.SetColumn(bt, j);
                        Grid.SetRow(bt, i);
                        bt.Name = fufu[counter].Name;
                       
                        bt.Click += new RoutedEventHandler(Button_Click);
                        bt.MouseEnter += new MouseEventHandler (Button_MouseEnter);
                        bt.MouseLeave += new MouseEventHandler(Button_MouseLeave);



                        if (File.Exists("img/" + fufu[counter].Name + ".jpg"))
                        {
                            var brush = new ImageBrush();
                            brush.ImageSource = new BitmapImage(new Uri("img/" +fufu[counter].Name + ".jpg", UriKind.Relative));
                            bt.Background = brush;
                        }
                        else
                        {
                             bt.Content = fufu[counter].Name;
                        }


                        Style style = new Style(typeof(Border));
                        style.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));
                        bt.Resources.Add(typeof(Border), style);
                        _ = gr.Children.Add(bt);
                        
                       
                       
                        
                    }
                    counter++;
                }
            }
        }
       
        public void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;

            //var value = MainWindow.fufu.First(item => item.Name == b.Name).Name;
            //getting a fruit or vegi class from the lists by the name of the button which we selected  

            b.Content = null;

        }
        public void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            try
            {
             var value = MainWindow.fufu.First(item => item.Name == b.Name).Price;
            //getting a fruit or vegi class from the lists by the name of the button which we selected
            //
            if (MainWindow.fufu.Count < 100)
             b.FontSize = 66;
             b.Content = value.ToString();
            }
            catch (Exception)
            {
                var value = MainWindow.veve.First(item => item.Name == b.Name).Price;
                //getting a fruit or vegi class from the lists by the name of the button which we selected
                //
                if (MainWindow.veve.Count < 100)
                    b.FontSize = 66;
                b.Content = value.ToString();

            }
           
            

        }

    

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            //getting a fruit or vegi class from the lists by the name of the button which we selected  
            dynamic value;
            try
            {
                 value = MainWindow.fufu.First(item => item.Name == b.Name);
                //getting a fruit or vegi class from the lists by the name of the button which we selected
                //
                
            }
            catch (Exception)
            {
                 value = MainWindow.veve.First(item => item.Name == b.Name);
                //getting a fruit or vegi class from the lists by the name of the button which we selected
                //
               

            }
            MainWindow.Getter = value;
            MainWindow.multi = value.Price;
            
          

        }

      
        

        private void GridPozition(int a,int b)
        {
            Grid.SetColumn(gr, a);
            Grid.SetRow(gr, b);
        }
       
        public Grid GridButon()
        {  
             buttoncount = (int)Math.Sqrt(MainWindow.fufu.Count) + 1;
            GridSize(buttoncount);
            
            GridItemFufu(buttoncount,MainWindow.fufu);
            GridPozition(1, 1);
            ShowePrice = MainWindow.fufu;
            return gr;
            
        }
        public Grid GridButonSwap()
        {
            gr.Children.Clear();
            buttoncount = (int)Math.Sqrt(MainWindow.veve.Count) + 1;
            GridSize(buttoncount);
            GridItemFufu(buttoncount, MainWindow.veve);
            GridPozition(1, 1);
            ShowePrice = MainWindow.veve;
            return gr;
        }

    }
}
