//===================================
//  Auther : Vinothkanth V
//  Creation date :27 /7/ 2018
//  
//  This program allows the user to keep track of items being purchased on  a quick purchasing spending spree. 
//  The program should allows the user to start with $1000 and then ask him/her repeatedly 
//  to enter costs of items to be purchased, confirming every purchase
//  The program should allow purchases to be made until there is no more money left. 
//  The program should end when the user has no money left or has gone into debt from a single over purchase, 
// ===================================

/// <summary>
/// The SpendingSpreeProgram Namespace
/// </summary>
namespace SpendingSpreeProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The Spending Spree Class
    /// </summary>
    public class SpendingSpree
    {
  
        /// <summary>
        /// Get and set the initial amount
        /// </summary>
        public double UserWallet
        {
            get;
            set;
        }

        /// <summary>
        /// To initial amount for purchase to the customer
        /// </summary>
        /// <returns>return the initial amount</returns>
        public double setInitialPurchaseAmount()
        {
            double userHavingAmount = 0.0;
            try
            {
                userHavingAmount = Convert.ToDouble(Console.ReadLine());
                UserWallet = userHavingAmount;
            }
            catch (FormatException)
            {
                Console.WriteLine("Your input is not in correct formate");
                throw new FormatException();
            }
            return userHavingAmount;
        }

        /// <summary>
        /// To check the balance is enough for purchase.
        /// </summary>
        /// <param name="randomePrice">PriceValue</param>
        /// <returns>true/false</returns>
        public bool isUserHaveRequirAmount(double priceValue)
        {
            bool balanceStatus = false;
            try
            {
                if (UserWallet > priceValue)
                {
                    balanceStatus = true;
                }
            }
            catch (ArithmeticException argument)
            {
                throw new ArithmeticException(argument.Message);
            }

            return balanceStatus;
        }

        /// <summary>
        /// Check the purchase is confirm or not
        /// </summary>
        /// <param name="confirmAmount">Confirm Amount</param>
        /// <returns>confirm status true/false</returns>
        public  bool isPurchaseConfirm(string confirmAmount)
        {
            bool confirmStatus = false;
            try
            {
                if (confirmAmount == "Yes" || confirmAmount == "yes")
                {
                    confirmStatus = true;
                }
            }
            catch (FormatException cancel)
            {
                throw new FormatException(cancel.Message);
            }

            return confirmStatus;
        }

        /// <summary>
        /// To reduce the purchase amount into user wallet
        /// </summary>
        /// <param name="purchasedAmount">Purchased Amount</param>
        /// <returns>Remaining amount in wallet</returns>
        public  double withdrawOrDebuitAmount(double purchasedAmount)
        {
            try
            {
                if (purchasedAmount < 0)
                {
                    return purchasedAmount;
                }
                else
                {
                    UserWallet -= purchasedAmount;
                }
            }
            catch (ArithmeticException)
            {
                throw new ArithmeticException();
            }

            return UserWallet;
        }
    }
}
