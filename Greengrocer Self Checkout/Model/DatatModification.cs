using Greengrocer_Self_Checkout.Comand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Greengrocer_Self_Checkout.Model
{
    public class DatatModification
    {
        private readonly string con = Properties.Settings.Default.DataB;
        //reading from tabels the information of the products

        public void AddItem(string Name, double Price, string ItemType)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                // Set the INSERT query
                cmd.CommandText = "INSERT INTO Products (PName, Price,Purches,PurchesDate, PType) VALUES (@ProductName, @Price,@Purches,@PurchesDate,@Category)";

                // Set parameters for the INSERT query
                cmd.Parameters.AddWithValue("@ProductName", Name);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Purches", 0);
                cmd.Parameters.AddWithValue("@PurchesDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Category", ItemType);

                // Execute the INSERT query
                cmd.ExecuteNonQuery();


            }
        }
        public void DeleteItem(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                // Set the DELETE query
                cmd.CommandText = "DELETE FROM Products WHERE ID = @ProductID";

                // Set parameter for the DELETE query
                cmd.Parameters.AddWithValue("@ProductID", itemId);

                // Execute the DELETE query
                 cmd.ExecuteNonQuery();

              
            }

        }

        public void IncreasCount(int Id,double Amount)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string updateQuery = "UPDATE Products SET Purches = Purches  + @AmountToAdd,PurchesDate = @NewDate WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@NewDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AmountToAdd", Amount);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Count increased successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found or count not updated.");
                    }
                }
            }
        }
    }

}
