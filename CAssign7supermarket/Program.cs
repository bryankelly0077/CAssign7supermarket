using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAssign6Supermarket
{
    class SqlCommandDemo
    {
        SqlConnection conn;

        public SqlCommandDemo()
        {
            // Instantiate the connection
            conn = new SqlConnection(
    "Data Source = lugh4.it.nuigalway.ie; Initial Catalog = msdb2432; User ID = msdb2432; Password = msdb2432BR");
        }

        // call methods that demo SqlCommand capabilities
        static void Main()
        {
            SqlCommandDemo scd = new SqlCommandDemo();

            Console.WriteLine("\nCustomers Before Insert");

             // use ExecuteReader method
             scd.ReadData("select CustomerName from CUSTOMER");

             // use ExecuteNonQuery method for Insert
             scd.Insertdata();
             Console.WriteLine("\nCustomers After Insert");

             scd.ReadData("select CustomerName from CUSTOMER");


             Console.WriteLine("\nProduct Before Update");
             scd.ReadData("select ProductName from PRODUCT");
             // use ExecuteNonQuery method for Update
             scd.UpdateData();

             Console.WriteLine("\nProduct After Update");

             scd.ReadData("select ProductName from PRODUCT");


             Console.WriteLine("\nCustomers Before Delete");
             scd.ReadData("select CustomerName from CUSTOMER");

             // use ExecuteNonQuery method for Delete
             scd.DeleteData();

             Console.WriteLine("\nCustomers After Delete");

             scd.ReadData("select CustomerName from CUSTOMER");

            // use ExecuteScalar method
            int meanPrice = scd.GetMeanPrice();

            Console.WriteLine();
            Console.WriteLine("Mean Price of Orders: {0}", meanPrice);
            
            // use ExecuteScalar method
            int totalOrders = scd.GetTotalOrders();
            
            Console.WriteLine("\nTotal Price of Orders: {0}", totalOrders);

            // use ExecuteScalar method
            int maxPrice = scd.GetMaxPrice();

            Console.WriteLine("\nLargest Price of Orders: {0}", maxPrice);

            // use ExecuteScalar method
            int minPrice = scd.GetMinPrice();

            Console.WriteLine("\nLowest Price of Orders: {0}", minPrice);

            // use ExecuteScalar method
            int numProducts = scd.GetNumProducts();

            Console.WriteLine("\nNumber of Products: {0}", numProducts);

            Console.Read();
        }


        /// use ExecuteReader method
        public void ReadData(String query)
        {
            SqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Insert
        /// </summary>
        public void Insertdata()
        {
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string insertString = @"
                 insert into CUSTOMER
                 (CustomerName,CustomerAddress)
                 values ('Mary', 'Kerry')";

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(insertString, conn);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateData()
        {
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string updateString = @"
                update PRODUCT
                set ProductName = 'carrot'
                where ProductName = 'spud'";

                // 1. Instantiate a new command with command text only
                SqlCommand cmd = new SqlCommand(updateString);

                // 2. Set the Connection property
                cmd.Connection = conn;

                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        //use ExecuteNonQuery method for Delete

        public void DeleteData()
        {
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string deleteString = @"
                 delete from CUSTOMER
                 where CustomerName = 'Mary'";

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand();

                // 2. Set the CommandText property
                cmd.CommandText = deleteString;

                // 3. Set the Connection property
                cmd.Connection = conn;

                // 4. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int GetTotalOrders()
        {
            int sum;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand("select sum(Price) from ORDERS", conn);

                // 2. Call ExecuteScalar to send command
                sum = (int)cmd.ExecuteScalar();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return sum;
        }

        //use ExecuteScalar method
        public int GetMaxPrice()
        {
            int max;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand("select max(Price) from ORDERS", conn);

                // 2. Call ExecuteScalar to send command
                max = (int)cmd.ExecuteScalar();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return max;
        }

        //use ExecuteScalar method
        public int GetMinPrice()
        {
            int min;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand("select min(Price) from ORDERS", conn);

                // 2. Call ExecuteScalar to send command
                min = (int)cmd.ExecuteScalar();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return min;
        }

        //use ExecuteScalar method
        public int GetNumProducts()
        {
            int count;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand("select count(*) from PRODUCT", conn);

                // 2. Call ExecuteScalar to send command
                count = (int)cmd.ExecuteScalar();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }

        //use ExecuteScalar method
        public int GetMeanPrice()
        {
            int avg;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand("select avg(Price) from ORDERS", conn);

                // 2. Call ExecuteScalar to send command
                avg = (int)cmd.ExecuteScalar();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return avg;
        }
    }
}
