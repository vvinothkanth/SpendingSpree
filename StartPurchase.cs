//*************************
//  Auther : Vinothkanth V
//  Creation date :27 /7/ 2018
//   
//   This is an branch section
//
//*************************

/// <summary>
/// The SpendingSpreeProgram Namespace
/// </summary>

namespace SpendingSpreeProgram
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The StartPurchasing Class
    /// </summary>
    class StartPurchase
    {
        static void Main(string[] args)
        {
            // To start SpendingSpree
            SpendingSpree spendingSpree = new SpendingSpree();
	    Console.WriteLine("Welcome User");
            Console.Write("Please Enter how much purchase  amount you have $:");
            double userWalletAmount = spendingSpree.setInitialPurchaseAmount();
	
            while (spendingSpree.UserWallet > 0)
            {
                Console.WriteLine("You have ${0} money remaining to spend. \n", spendingSpree.UserWallet);
                Console.Write("Enter the cost of the item that you want to buy $");
                double purchaseAmount = Convert.ToDouble(Console.ReadLine());

                if (purchaseAmount > 0)
                {
                    bool isHaveTheAmount = spendingSpree.isUserHaveRequirAmount(purchaseAmount);
                    if (isHaveTheAmount)
                    {
                        Console.WriteLine("Are you sure that you want to purchase the ${0} item ? (yes or no) ", purchaseAmount);
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money to purchase that item. ");
                        Console.WriteLine("Are you sure that you want to purchase the ${0} item and go into debt ?", purchaseAmount);
                    }

                    string purchaseConfirmation = Convert.ToString(Console.ReadLine());

                    bool isConfirm = spendingSpree.isPurchaseConfirm(purchaseConfirmation);

                    if (isConfirm)
                    {
                        double walletBallence = spendingSpree.withdrawOrDebuitAmount(purchaseAmount);
                        if (walletBallence <= 0)
                        {
                            Console.WriteLine("You have spent too much money and now owe: ${0}\n", spendingSpree.UserWallet.ToString().Trim('-'));
                            Console.WriteLine("Thankyou for Purchasing ...!!! \nVisit Again");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Enter Valid Amount");
                }
            }
        }
    }
}
