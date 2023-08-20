using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Windows;
using System.Data.SqlClient;

namespace Greengrocer_Self_Checkout
{
  public  class DataGetter
    {
        private readonly string con = Properties.Settings.Default.DataB;
        //reading from tabels the information of the products
        
        public void GetInList(string database)
        {

            SqlConnection coco = new SqlConnection(this.con);
            coco.Open();
            SqlCommand cmd = coco.CreateCommand();
            SqlDataReader DR;
            cmd.CommandText = "SELECT * FROM "+database;
            DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                CommonThings f = new CommonThings();
                f.Id = (int)DR.GetValue(0);
                f.Name = (string)DR.GetValue(1);
                f.Price=Convert.ToDouble( DR.GetValue(2));
                f.Count= Convert.ToDouble(DR.GetValue(3));
                f.Date= (DateTime)DR.GetValue(4);
               MainWindow.fufu.Add(f);
            }
            coco.Close();
           
           



            
        }

    }
}
