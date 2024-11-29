using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp
{
    public class ProductDB
    {
        // Database String Connection
        private string connection = "data source=DESKTOP-83TNMGJ;initial catalog=WPF;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;";
        SqlConnection conn;
        SqlCommand cmd;

        // List of Product in DB
        public List<Product> GetProduct()
        {
            List<Product> products = new List<Product>();
            using (conn = new SqlConnection(connection)) // Database connected
            {
                // Opens Connection
                conn.Open();
                string query = "SELECT * FROM Product";
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Item_ID = (int)reader["Item_ID"],
                        Name = (string)reader["Name"],
                        Quantity = (int)reader["Quantity"],
                        Price = (decimal)reader["Price"],
                        Description = (string)reader["Description"]
                    });
                }
                return products;
            }
        }

        // Function that inserts Product into DB by query
        public void InsertProduct(Product product)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "INSERT INTO Product (Name, Quantity, Price, Description) VALUES (@Name, @Quantity, @Price, @Description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
