using System;
using TechTalk.SpecFlow;
using NUnit;
using NUnit.Framework;


namespace testcsharp
{
    [Binding]
    public class banktransfer
    {
        public string result;
	TestDataUtils testdata = new TestDataUtils();

        [BeforeScenario(Order = 0)]
        public void initialize()
        {
            testdata.TruncateTable("Account");
            testdata.TruncateTable("Transfer");
        }

        [Given(@"the (.*) balance is (.*)")]
        public void GivenTheBalanceIs(int Sender, int senderbalance)
        {
            testdata.InsertData_Account(Sender, senderbalance);
        }

        [Given(@"(.*) has balance  (.*)")]
        public void GivenHasBalance(int Receiver, int receiverbalance)
        {
            testdata.InsertData_Account(Receiver, receiverbalance);
        }

        [When(@"(.*) transfers (.*) to (.*)")]
        public void WhenTransfersToAccount(int Sender, int amount, int Receiver)
        {
            var test = new BalanceTransaction();
            result = test.Transfer(Sender, Receiver, amount);

        }

        [Given(@"(.*) already transferred (.*) amount to (.*) on ""(.*)""")]
        public void GivenAlreadyTransferredAmountToOn(int Sender,  int alreadytransfered, int Receiver, string transferdate)
        {
            testdata.InsertData_Transfer(Sender, Receiver, alreadytransfered, transferdate); 
        }

        [Then(@"transfer should be ""(.*)""")]
        public void ThenTransferShouldBe(string status)
        {
            Assert.AreEqual(status, result);
        }
        
       
    }
}
