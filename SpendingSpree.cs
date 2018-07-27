//*************************
//  Auther : Vinothkanth V
//  Creation date :27 /7/ 2018
//  
//  This program allows the user to keep track of items being purchased on  a quick purchasing spending spree. 
//  The program should allows the user to start with $1000 and then ask him/her repeatedly 
//  to enter costs of items to be purchased, confirming every purchase
//  The program should allow purchases to be made until there is no more money left. 
//  The program should end when the user has no money left or has gone into debt from a single over purchase, 
//
//*************************

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
        /// Inititial Amount for user
        /// </summary>
        private static double userWallet = 1000;

        /// <summary>
        /// Get and set the initial amount
        /// </summary>
        public static double UserWallet
        {
            get { return userWallet; }
            set { userWallet = value; }
        }        

        /// <summary>
        /// To generate the randome price amount in between 1000$ doller 
        /// </summary>
        /// <returns>randome price amount</returns>
        public static double generateRamdomePrice()
        {
            double randomePrice = 0.0;
            try
            {
                Random random = new Random();
                randomePrice = random.Next(50,1000); 
            }
            catch (ArgumentOutOfRangeException randomeException)
            {
                throw new ArgumentOutOfRangeException(randomeException.Message);
            }

            return randomePrice;
        }

        /// <summary>
        /// To inform the amount of purchasing 
        /// </summary>
        /// <returns>string of query</returns>
        public static string costEntryQuery(double queryPrice)
        {
            string costQuery = string.Empty;
            try
            {
                Console.WriteLine("Enter the cost of the item that you want to buy {0}", queryPrice);
            }
            catch (ArgumentNullException argumentException)
            {
                throw new ArgumentNullException(argumentException.Message);
            }

            return costQuery;
        }

        /// <summary>
        /// To ask and process the purchase amount
        /// </summary>
        /// <param name="randomePrice">purchase Amount</param>
        /// <returns>Wallet Balance</returns>
        public static double getAmount(double randomePrice)
        {
            try
            {
                double userEnteredAmount = Convert.ToDouble(Console.ReadLine());
                if (userEnteredAmount == randomePrice)
                {
                    if (purcheshConfirmation(randomePrice) == true)
                    {
                       UserWallet = withdrawOrDebuitAmount(randomePrice);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Entry try again");
                }
            }
            catch (ArithmeticException cannotProcess)
            {
                throw new ArithmeticException(cannotProcess.Message);
            }

            return UserWallet;
        }

        /// <summary>
        /// To check the balance is enough for purchase.
        /// </summary>
        /// <param name="randomePrice">PriceValue</param>
        /// <returns>true/false</returns>
        public static bool checkBalance(double priceValue)
        {
            bool balanceStatus = false;
            try
            {
                if (UserWallet > priceValue)
                {
                    balanceStatus = true;
                }
            }
            catch (ArgumentException argument)
            {
                throw new ArgumentException(argument.Message);
            }

            return balanceStatus;
        }

        /// <summary>
        /// Check the purchase is confirm or not
        /// </summary>
        /// <param name="confirmamount">Confirm Amount</param>
        /// <returns>confirm status true/false</returns>
        public static bool purcheshConfirmation(double confirmamount)
        {
            bool confirmStatus = false;
            try
            {
                if (checkBalance(confirmamount) == true)
                {
                    Console.WriteLine("Are you sure that you want to purchase the ${0} item ? (yes or no) ", confirmamount);
                }
                else
                {
                    Console.WriteLine("You don't have enough money to purchase that item. ");
                    Console.WriteLine("Are you sure that you want to purchase the ${0} item and go into debt ?", confirmamount);
                }
                string confirmation = Convert.ToString(Console.ReadLine());
                if (confirmation == "Yes" || confirmation == "yes")
                {
                    confirmStatus = true;
                }
            }
            catch (OperationCanceledException cancel)
            {
                throw new OperationCanceledException(cancel.Message);
            }

            return confirmStatus;
        }

        /// <summary>
        /// To reduce the purchase amount into user wallet
        /// </summary>
        /// <param name="purchasedAmount">Purchased Amount</param>
        /// <returns>Remaining amount in wallet</returns>
        public static double withdrawOrDebuitAmount(double purchasedAmount)
        {
            try
            {
                if (checkBalance(purchasedAmount) == true)
                {
                    UserWallet -= purchasedAmount;
                }
                else
                {
                    UserWallet -= purchasedAmount;
                    Console.WriteLine("You have spent too much money and now owe: ${0}\n", UserWallet.ToString().Trim('-'));
                    Console.WriteLine("Thankyou for Purchasing ...!!! \nVisit Again");
                    Console.ReadKey();
                    System.Environment.Exit(-1);
                }

            }
            catch (ArithmeticException amountIsNotValid)
            {
                throw new ArithmeticException(amountIsNotValid.Message);
            }

            return UserWallet;
        }

        /// <summary>
        /// Continue the purchase process until the user get debit amount .
        /// </summary>
        /// <returns>true</returns>
        public static bool startPurchase()
        {
            try
            {
                Console.WriteLine("You have ${0} money remaining to spend. \n", SpendingSpree.UserWallet);
                double randomePrize = SpendingSpree.generateRamdomePrice();
                SpendingSpree.costEntryQuery(randomePrize);
                double remainingAmount = SpendingSpree.getAmount(randomePrize);
                startPurchase();
            }
            catch (Exception porcessFlowException)
            {
                throw new Exception(porcessFlowException.Message);
            }

            return true;
        }
    }
}
