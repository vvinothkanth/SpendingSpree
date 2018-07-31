//
// Auther : Vinothkanth V
//  Creation date :29 /7/ 2018
//
// ************************

/// <summary>
/// The SpendingSpreeProgram Namespace
/// </summary>
namespace PortFolioTestCaseOne
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SpendingSpreeProgram;

    /// <summary>
    /// The SpendingSpreeTesting Class
    /// </summary>
    [TestClass]
    public class SpendingSpreeTesting
    {
        /// <summary>
        /// To check the balence is available in user wallet
        /// </summar>
        [TestMethod]
        public void checkAccountBalance()
        {
            try
            {
                Assert.IsFalse(SpendingSpree.checkWalletBalance(1600));
                Assert.IsFalse(SpendingSpree.checkWalletBalance(1200));
                Assert.IsTrue(SpendingSpree.checkWalletBalance(-1400));
                Assert.IsTrue(SpendingSpree.checkWalletBalance(400));
                Assert.IsTrue(SpendingSpree.checkWalletBalance(900));
            }
            catch (ArithmeticException e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }
        }

        /// <summary>
        /// TO check the withdraw amount is available in user wallet
        /// </summar>
        [TestMethod]
        public void checkWithDrawAmount()
        {
            try
            {
                double amount = SpendingSpree.withdrawOrDebuitAmount(1200);
                Assert.AreEqual(-200, amount);
                Assert.AreNotEqual(2200, amount);
                Assert.AreNotEqual(300, amount);
            }
            catch (ArithmeticException e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }
        }

        /// <summary>
        /// TO check the withdraw amount is available in user wallet
        /// </summar>
        [TestMethod]
        public void checkWithDrawAmount_I()
        {
            try
            {
                double amount = SpendingSpree.withdrawOrDebuitAmount(-500);
                Assert.AreNotEqual(500, amount);
                Assert.AreNotEqual(-500, amount);
                Assert.AreEqual(300, amount);
            }
            catch (ArithmeticException e)
            {
                StringAssert.Contains(e.Message, "File Not Found Exception");
                return;
            }
        }

        /// <summary>
        /// To check the purchase confirmation
        /// </summary>
        [TestMethod]
        public void purchaseMethos()
        {
            Assert.IsTrue(SpendingSpree.purcheshConfirmation(300));
            Assert.IsTrue(SpendingSpree.purcheshConfirmation(700));
            Assert.IsTrue(SpendingSpree.purcheshConfirmation(-100));
        }

        /// <summary>
        /// To test the  balance wallet amount
        /// </summary>
        [TestMethod]
        public void getWallet()
        {
            Assert.AreEqual(700, SpendingSpree.getWalletAmount(300));
            Assert.AreEqual(300, SpendingSpree.getWalletAmount(700));
            Assert.AreNotEqual(-300, SpendingSpree.getWalletAmount(700));
        }
       
    }
}
