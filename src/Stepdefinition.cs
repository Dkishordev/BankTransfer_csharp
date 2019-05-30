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

        [Given(@"the (.*) balance is (.*)")]
        public void GivenTheBalanceIs(int Sender, int senderbalance)
        {
	    testdata.InsertData_Account(Sender,senderbalance);
        }

        [Given(@"(.*) balance is (.*)")]
        public void GivenBalanceIs(int Receiver, int receiverbalance)
        {
            testdata.InsertData_Account(Receiver, receiverbalance);
        }
        
        [Given(@"(.*) has already transfered to (.*) (.*) on (.*)")]
        public void GivenHasAlreadyTransferedToOn(int Sender, int Receiver, int alreadytransfered, string transferdate)
        {
            testdata.InsertData_Transfer(Sender, Receiver, alreadytransfered, transferdate);
        }
        
        [When(@"(.*) transfers (.*) to (.*) account")]
        public void WhenTransfersToAccount(int Sender, int Receiver, int amount)
        {
            var test = new BalanceTransaction();
            result = test.Transfer(Sender, Receiver, amount);

        }
        
        [Then(@"transfer should be (.*)")]
        public void ThenTransferShouldBe(string status)
        {
            Assert.AreEqual(status, result);
        }
        
       
    }
}
