using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestSupermarket;
using System.Transactions;
namespace UnitTestSupermarket
{
    [TestFixture]
    public class YourFixture
    {
        private TransactionScope scope;
        // creates connection variable
        private readonly MySqlConnection conn = new MySqlConnection("Server = danu6.it.nuigalway.ie; Database = mydb2463; Uid = mydb2463ca; Pwd = mi3tax");

        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }
    }
