namespace Bank
{
    public class User
    {
        public string Username { get; set;}
        public string Password {get; set;}
        public string Fullname { get; set;}
        public double Balance {  get; set;}
        public List<string> Notes { get; set;} = new List<string>();
        public User(string username, string password, string fullname, double balance )
        {
            Username = username;
            Password = password;
            Fullname = fullname;
            Balance = balance;
        }
        public void Deposit()
        {
            Console.WriteLine("Amount");
            var amount = Convert.ToInt32(Console.ReadLine());
            if(amount%500 == 0)
            {
                Balance += amount;
                Console.WriteLine($"New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Wrong amount!");
            }
        }
        public void Withdraw()
        {
            Console.WriteLine("Amount");
            var amount = Convert.ToInt32(Console.ReadLine());
            if (amount % 500 == 0 && amount <=Balance)
            {
                Balance -= amount;
                Console.WriteLine($"New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Wrong amount!");
            }
        }
        public void Transfer (User profit)
        {
            Console.WriteLine("Amount");
            var amount = Convert.ToInt32(Console.ReadLine());
            if (amount % 500 == 0 && amount <= Balance)
            {
                Console.Write("Note: ");
                var note = Console.ReadLine();
                var finalNote = $"{Username} sent {amount} LEK and left the note: {note}";
                profit.Notes.Add(finalNote);
                Balance -= amount;
                profit.Balance += amount;
                Console.WriteLine($"New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Wrong amount!");
            }
        }

    }
}
