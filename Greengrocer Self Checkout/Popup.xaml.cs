﻿using System;
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
           this.DataContext =MainWindow.Getter ;
            InitializeComponent();


                Amaount.Text = MainWindow.SelecWeight.ToString();
                Pprice.Text = Math.Round(MainWindow.Getter.Price * MainWindow.SelecWeight,2).ToString();
                ddate.Text += DateTime.Now.ToString();
            
            
            
           
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
           
        }
    }
}
