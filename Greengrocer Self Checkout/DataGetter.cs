using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Windows;
using System.Data.SqlClient;

namespace Greengrocer_Self_Checkout
{
  public  abstract class DataGetter
    {  
        public void GetInList(String con)
        {
            
            SqlConnection coco = new SqlConnection(con);
            coco.Open();
            SqlCommand cmd = coco.CreateCommand();
            SqlDataReader DR;
            cmd.CommandText = "SELECT * FROM Fruits";
            DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                Fruit f = new Fruit();
                f.Id = (int)DR.GetValue(0);
                f.Name = (string)DR.GetValue(1);
                f.Price=Convert.ToDouble( DR.GetValue(2));
                f.Count= Convert.ToDouble(DR.GetValue(3));
                f.Date= (DateTime)DR.GetValue(4);
               MainWindow.fufu.Add(f);
            }
            coco.Close();
            coco.Open();
            SqlCommand veg = coco.CreateCommand();
            SqlDataReader vegDR;
            veg.CommandText = "SELECT * FROM Vegetables";
            vegDR = veg.ExecuteReader();
            while (vegDR.Read())
            {
                Vegetables f = new Vegetables();
                f.Id = (int)vegDR.GetValue(0);
                f.Name = (string)vegDR.GetValue(1);
                f.Price = Convert.ToDouble(vegDR.GetValue(2));
                f.Count = Convert.ToDouble(vegDR.GetValue(3));
                f.Date = (DateTime)vegDR.GetValue(4);
                MainWindow.veve.Add(f);
            }



            coco.Close();
        }

    }
}
