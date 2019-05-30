using System;
using TechTalk.SpecFlow;
using NUnit;
using NUnit.Framework;


namespace BankTransaction
{
    [Binding]
    public class banktransfer
    {
        public string result;
	    TestDataUtils testdata = new TestDataUtils();

        [Given(@"the (.*) balance is (.*)")]
        public void GivenTheSenderBalanceIs(int Sender, int senderbalance)
        {
	    testdata.InsertData_Account(Sender,senderbalance);
        }

        [Given(@"the (.*) balance is (.*)")]
        public void GivenTheReceiverBalanceIs(int Receiver, int receiverbalance)
        {
            testdata.InsertData_Account(Receiver, receiverbalance);
        }
        
        [Given(@"(.*) has already transfered to (.*) (.*) on (.*)")]
        public void GivenThereIsTransactionMadeBySenderOnThatDay(int Sender, int Receiver, int alreadytransfered, string transferdate)
        {
            testdata.InsertData_Transfer(Sender, Receiver, alreadytransfered, transferdate);
        }
        
        [When(@"(.*) transfers (.*) to (.*) account")]
        public void WhenSenderTransfersToReceiverSAccount(int Sender, int Receiver, int amount)
        {
            var test = new BalanceTransaction();
            result = test.Transfer(Sender, Receiver, amount);

        }
        
        [Then(@"transfer status should be (.*)")]
        public void ThenTransferStatusIsFailure(string status)
        {
            Assert.AreEqual("Failure", result);
        }
        
       
    }
}