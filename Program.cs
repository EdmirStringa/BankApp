using Bank;
namespace Bank
{ 
    public class Program{
        public static void Main()
        {
        var users = new List<User>();
        while (true)
            {
                Console.WriteLine("Welcome to our bank");
                Console.WriteLine("1. Log in                    2. Register");
                var op = Convert.ToInt32(Console.ReadLine());
                if (op == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Username:");
                    var username = Console.ReadLine();
                    var checkuser = users.Where(u => u.Username == username).FirstOrDefault();
                    if (checkuser != null)
                    { 
                        Console.WriteLine("Password");
                        var password = Console.ReadLine();
                        var checkuserr = users.Where(u => u.Password == password).FirstOrDefault();
                        if (checkuserr != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Hello {checkuser.Fullname}! Your balance is {checkuser.Balance} LEK.");
                            if (checkuser.Notes.Count()  > 0)
                            {
                                foreach(var note in checkuser.Notes){
                                    Console.WriteLine(note);
                                }
                            }
                            while (true)
                            {                           
                            Console.WriteLine("1. Deposit         2. Withdraw       3.Transfer    4.Forgot Password     0.Logout");
                            var option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1)
                            {
                                    Console.Clear();
                                    checkuser.Deposit();
                            }
                            else if(option == 2)
                            {
                                    Console.Clear();
                                    checkuser.Withdraw();
                            }
                            else if (option == 3)
                            {
                                    Console.Clear();
                                    Console.WriteLine("Username of the beneficiary:");
                                    var usernameProfit = Console.ReadLine();
                                    var userProfit = users.Where(u => u.Username == usernameProfit).FirstOrDefault();
                                    if(userProfit != null)
                                    {
                                        checkuser.Transfer(userProfit);
                                    }
                                    else
                                    {
                                        Console.WriteLine("This user does not exist");
                                    }
                                }
                            else if (option == 0)
                                {                            
                                    Console.Clear();
                                    break;
                            } else if (option == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Write the new password");
                                    var newPassword= Console.ReadLine();
                                    var newUser = new User(checkuser.Username, newPassword, checkuser.Fullname,checkuser.Balance);
                                    users.Add(newUser);
                                    Console.Clear();
                                    var old = users.Where(u => u.Password == password).FirstOrDefault();
                                    users.Remove(old);

                                }
                            else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid option!");
                                }
                            }
                        }
                        else
                        { 
                            Console.WriteLine("Your password is incorrect. Press 1 to try again or 2 to reset your password");
                            var passOptions=Convert.ToInt32(Console.ReadLine());
                            if (passOptions == 1) { Console.Clear(); 
                            Console.WriteLine("Try again!");
                                password = Console.ReadLine();
                            }
                            else if (passOptions == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Type in the new Password");
                                var newPassword  = Console.ReadLine();
                                users.RemoveAll(u => u.Username == checkuser.Username);
                                var newUser = new User(checkuser.Username, newPassword, checkuser.Fullname, checkuser.Balance);
                                users.Add(newUser);
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Your username is wrong. Please try again! :");
                    }
                }
                else if (op == 2)
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    var username = Console.ReadLine();

                    var checkuser = users.Where(u => u.Username == username).FirstOrDefault();
                    if (checkuser != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Username is already being used! Please change your username!");
                    }
                    else
                    {

                        Console.Write("Password: ");
                        var password = Console.ReadLine();
                        Console.Write("Full Name: ");
                        var fullname = Console.ReadLine();
                        Console.Write("Initial Balance: ");
                        var balance = Convert.ToDouble(Console.ReadLine());
                        var newUser = new User(username, password, fullname, balance);
                        users.Add(newUser);
                        Console.Clear();
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid");
                }
            }
    }
}
}