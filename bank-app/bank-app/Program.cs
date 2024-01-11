using System;
using System.Linq;

// Define the blueprint to use to create and modify bank accounts
class userAccount
{
    // Define variables
    string cardNum; // unique card number
    string firstName;
    string lastName;
    int pinNum; // unique PIN code
    double Balance;

    // Set up constructor
    public userAccount(string cardNum, string firstName, string lastName, int pinNum, double balance)
    {
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pinNum = pinNum;
        this.Balance = balance;
    }

    // Getters
    public String getCardNum() { return cardNum; }
    public String getFirstName() { return firstName; }
    public String getLastName() { return lastName; }
    public int getPinNum() { return pinNum; }
    public double getBalance() { return Balance; }

    // Setters
    public void setCardNum(String newCardNum) { this.cardNum = newCardNum; }
    public void setFirstName(String newFirstName) { this.firstName = newFirstName; }
    public void setLastName(String newLastName) { this.lastName = newLastName; }
    public void setPinNum(int newPinNum) { this.pinNum = newPinNum; }
    public void setBalance(double newBalance) { this.Balance = this.Balance + newBalance; }

    // Main
    public static void Main(String[] args)
    {
        /* -----------------------------LIST OF FUNCTIONS------------------------------ */
        
        // After entering the bank account, ask the user to choose between options
        void printOptions()
        {
            Console.WriteLine("Please choose one of the following options (type the relative number)...");
            Console.WriteLine(" ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Whitdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        // Ask the user for the amount of money that should be deposited and update the balance
        void deposit(userAccount currentUser) 
        {
            Console.WriteLine("How much do you want to deposit? Type the amount here below (enter 0 to cancel operation and return to menu): ");
            double deposit = 0;
            while(true)
            {
                try
                {
                    deposit = Double.Parse(Console.ReadLine());
                    break;

                }
                catch { Console.WriteLine("Please insert valid number."); }
            }
            
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you, the operation was successful. Your new balance is " + currentUser.getBalance());

        }

        // Ask the user for the amount of money that should be whitdrawn and update the balance
        void whitdraw(userAccount currentUser)
        {
            Console.WriteLine("How much do you want to whitdraw? Type the amount here below (enter 0 to cancel operation and return to menu): ");

            double whitdrawal = 0;
            while (true)
            {
                try
                {
                    whitdrawal = - Double.Parse(Console.ReadLine());
                    break;
                }
                catch { Console.WriteLine("Please insert valid number."); }
            }
            currentUser.setBalance(whitdrawal);
            Console.WriteLine("Thank you, the operation was successful. Your new balance is " + currentUser.getBalance());

        }

        // Show current balance
        void showBalance(userAccount currentUser)
        {
            Console.WriteLine("Your current balance is " + currentUser.getBalance());
        }


        /* -----------------------------USER ACCOUNTS DATABASE------------------------------ */

        // List of user accounts
        List<userAccount> userAccounts = new List<userAccount>();

        userAccounts.Add(new userAccount("1234567891234567", "Anna", "Alphinger", 4321, 200.00));
        userAccounts.Add(new userAccount("1235337891255567", "Beth", "Bramaldi", 1212, 53.70));
        userAccounts.Add(new userAccount("1457887891234567", "Cate", "Coboldi", 1453, 100.90));
        userAccounts.Add(new userAccount("1234567891234567", "Dan", "Delstington", 1333, 112.00));
        userAccounts.Add(new userAccount("1344567893368967", "Elton", "Erasmus", 3567, 10.15));

        
        /* ----------------------------- CONSOLE UI ------------------------------ */

        // Prompt user
        Console.WriteLine("Welcome to the bank!");
        Console.WriteLine("Please insert your card number: ");
        string inputCardNum = "";
        userAccount currentUser;

        // Check if card is present in the database (account list)
        while(true) 
        {
            try
            {
                inputCardNum = Console.ReadLine(); // take in user's input/card number
                currentUser = userAccounts.FirstOrDefault(a => a.cardNum == inputCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please insert valid card number."); }
            }
            catch { Console.WriteLine("Card not recognized. Please insert valid card number."); }
        }

        // Ask user to insert pin
        Console.WriteLine("Please insert your PIN: ");
        int inputPin = 0;

        // Check PIN
        while (true)
        {
            try
            {
                inputPin = Int32.Parse(Console.ReadLine()); // take in PIN
                if (currentUser.getPinNum() == inputPin) { break; }
                else { Console.WriteLine("Invalid PIN. Please insert PIN again."); }
            }
            catch { Console.WriteLine("Invalid PIN. Please insert PIN again."); }
        }

        // Welcome user
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) ");
        int option = 0;

        // Show options, take in options and return the proper function
        do
        {
            printOptions();
            try
            {
                option = Int32.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("Please insert valid option."); }

            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { whitdraw(currentUser); }
            else if (option == 3) { showBalance(currentUser);  }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4); // Exit account
        Console.WriteLine("Thank you! have a nice day :) ");
    }

}