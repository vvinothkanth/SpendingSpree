//
// Auther : Vinothkanth V
//  Creation date :29 /7/ 2018
//
// ----------------------------------

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
        SpendingSpree spendingSpree = new SpendingSpree();
        /// <summary>
        /// To check the balence is available in user wallet
        /// </summar>
        [TestMethod]
        public void checkAccountBalance()

        {
            try
            {
                spendingSpree.UserWallet = 1000;
                Assert.IsFalse(spendingSpree.isUserHaveRequirAmount(1600));
                Assert.IsFalse(spendingSpree.isUserHaveRequirAmount(1200));
                Assert.IsFalse(spendingSpree.isUserHaveRequirAmount(1500));

                Assert.IsTrue(spendingSpree.isUserHaveRequirAmount(400));
                Assert.IsTrue(spendingSpree.isUserHaveRequirAmount(900));
                Assert.IsTrue(spendingSpree.isUserHaveRequirAmount(900));
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
                spendingSpree.UserWallet = 1000;
                double amount = spendingSpree.withdrawOrDebuitAmount(1200);
                double amountLow = spendingSpree.withdrawOrDebuitAmount(600);

                Assert.AreEqual(-800, amountLow);
                Assert.AreNotEqual(400, amountLow);
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
                spendingSpree.UserWallet = 1000;
                double amount = spendingSpree.withdrawOrDebuitAmount(-500);
                Assert.AreNotEqual(500, amount);
                Assert.AreEqual(-500, amount);
                Assert.AreNotEqual(300, amount);
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
            Assert.IsTrue(spendingSpree.isPurchaseConfirm("yes"));
            Assert.IsTrue(spendingSpree.isPurchaseConfirm("Yes"));
            Assert.IsFalse(spendingSpree.isPurchaseConfirm("no"));
            Assert.IsFalse(spendingSpree.isPurchaseConfirm("No"));
        }

       
    }
}
