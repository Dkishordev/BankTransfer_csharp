using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace testcsharp
{
    
    [TestFixture()]
    public class MainClassTest
    {
        BalanceTransaction transfer = new BalanceTransaction();
        TestDataUtils testdata = new TestDataUtils();
        public string today = DateTime.Now.ToString("yyyy-MM-dd");
      

        public void InitializeTest(int from, int to, float Ac1balance, float Ac2balance, float transfered_today)
        {
            testdata.TruncateTable("Account");
            testdata.TruncateTable("Transfer");
            testdata.InsertData_Account(from, Ac1balance);
            testdata.InsertData_Account(to, Ac2balance);
            testdata.InsertData_Transfer(from, to, transfered_today, today);
        }
        


        [TestCase(10001, 10002, 10000, 20000, 80000, 1000,"Success")]
        [TestCase(10001, 10002, 30000, 20000, 100000, 1000, "Failure")]
        [TestCase(10001, 10002, 20000, 10000, 5000, 5000, "Success")]
        [TestCase(10001, 10002, 30000, 20000, 5000, -1000, "Failure")]
        [TestCase(10001, 10002, 10000, 20000, 5000, 6000, "Failure")]
        [TestCase(10001, 10002, 30000, 20000, 10000, 35000, "Failure")]
        public void TransferTest(int from, int to, float Ac1balance, float Ac2balance, 
                                 float transfered_today, int amount, string status)
        {
            InitializeTest(from, to, Ac1balance, Ac2balance, transfered_today);

            var result = transfer.Transfer(from, to, amount);
             
            Assert.AreEqual(status, result);
        }

    }
}
