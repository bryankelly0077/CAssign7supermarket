using System.Data.SqlClient;
using NUnit.Framework;
using System.Transactions;
using CAssign6Supermarket;


namespace CAssign7supermarket
{
    public class SupermarketTest
    {
        [Test]
        public void TestNumProducts()
        {
            SqlCommandDemo scd = new SqlCommandDemo();
            int numProducts = scd.GetNumProducts();
            int expectedResult = 3;
            Assert.AreEqual(numProducts, expectedResult);
        }

        [Test]
        public void TestMeanPrice()
        {
            SqlCommandDemo scd = new SqlCommandDemo();
            int meanPrice = scd.GetMeanPrice();
            int expectedResult = 3;
            Assert.AreEqual(meanPrice, expectedResult);
        }

        [Test]
        public void TestMaxPrice()
        {
            SqlCommandDemo scd = new SqlCommandDemo();
            int maxPrice = scd.GetMaxPrice();
            int expectedResult = 6;
            Assert.AreEqual(maxPrice, expectedResult);
        }
        [Test]
        public void TestMinPrice()
        {
            SqlCommandDemo scd = new SqlCommandDemo();
            int minPrice = scd.GetMinPrice();
            int expectedResult = 2;
            Assert.AreEqual(minPrice, expectedResult);
        }
        [Test]
        public void TestTotalOrders()
        {
            SqlCommandDemo scd = new SqlCommandDemo();
            int totalOrders = scd.GetTotalOrders();
            int expectedResult = 11;
            Assert.AreEqual(totalOrders, expectedResult);
        }
    }
}