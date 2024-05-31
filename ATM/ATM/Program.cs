using System;
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getCardNum()
    { 
        return cardNum;
    }
    public int getPin()
    { 
        return pin;
    }
    public String getFirstName() 
    {
        return firstName;
    }
    public String getLastName() 
    {
        return lastName;
    }
    public double getBalance() 
    {
        return balance;
    }
    public void setNum(String newCardNum) 
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin) 
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName) 
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    { 
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    { 
        balance = newBalance;
    }
    public static void Main(String[] args) 
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrow");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. /n Your new balance is:" + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if (currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient Balance:");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("you are good to go! Thank You:");
            }
        }
        void balance(cardHolder currentUser) 
        {
            Console.WriteLine("Current Balance:" +currentUser.getBalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4532772818527396", 1235, "Ram", "Siram", 250.31));
        cardHolders.Add(new cardHolder("4532772818527397", 1236, "Sham", "Patil", 350.31));
        cardHolders.Add(new cardHolder("4532772818527398", 1237, "Sita", "Gupte", 450.31));
        //prompt user
        Console.WriteLine("Welcome to simple ATM");
        Console.WriteLine("Please insert your debit card:");
        String debitCardNum = "";
        cardHolder currentUser;
        while (true) 
        {
            try
            {
                debitCardNum= Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a=>a.cardNum==debitCardNum);
                if (currentUser != null) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("card not recognized.please try again");
                }
            }
            catch
            {
                Console.WriteLine("card not recognized. please try again");
            }
        }
        Console.WriteLine("Please enter your pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check against our db
                //currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin .please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. please try again");
            }
        }
        Console.WriteLine("Welcome\t" + currentUser.getFirstName()+":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            { }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4); 
        {
            Console.WriteLine("Thank You! Have a nice Day");
        }

    }

}