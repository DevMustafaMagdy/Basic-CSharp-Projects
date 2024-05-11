using System.Text;

namespace Projects.PasswordManager
{
    internal class Program
    {
        private static Dictionary<string, string> _passwordList = [];
        static void Main(string[] args)
        {
            ReadPassword();
            Console.WriteLine("Welcome to Password Manager");
            Console.WriteLine("Please choose which option you want");
            while (true)
            {
                Console.WriteLine("1- List all pass\n2- Add or change pass\n3- Get pass\n4- Delete pass\n5- Exit");
                var userChoice = int.Parse(Console.ReadLine());

                if (userChoice == 1)
                    ListAllPassword();
                else if (userChoice == 2)
                    AddOrChangePassword();
                else if (userChoice == 3)
                    GetPassword();
                else if (userChoice == 4)
                    DeletePassword();
                else if (userChoice == 5)
                    break;
                else
                    Console.WriteLine("Invalid Option!");
            }
        }

        private static void ListAllPassword()
        {
            foreach (var entry in _passwordList)
            {
                Console.WriteLine($"{entry.Key} = {entry.Value}");
            }
        }

        private static void AddOrChangePassword()
        {
            Console.Write("Please enter the website/app name: ");
            var appName = Console.ReadLine();
            Console.Write("Please enter your password: ");
            var password = Console.ReadLine();
            if (_passwordList.ContainsKey(appName))
            {
                _passwordList[appName] = password;
                Console.WriteLine("Added Successfully!");
            }
            else
            {
                _passwordList.Add(appName, password);
                Console.WriteLine("Changed Successfully!");
            }
            savePassword();
        }

        private static void GetPassword()
        {
            Console.Write("Please enter the website/app name: ");
            var appName = Console.ReadLine();
            if (_passwordList.ContainsKey(appName))
                Console.WriteLine($"Pass = {_passwordList[appName]}");
            else
                Console.WriteLine("Password Not Found!");
        }

        private static void DeletePassword()
        {
            Console.Write("Please enter the website/app name: ");
            var appName = Console.ReadLine();
            if (_passwordList.ContainsKey(appName))
            {
                _passwordList.Remove(appName);
                Console.WriteLine("Deleted Successfully!");
            }
            else
                Console.WriteLine("Password Not Found!");
            savePassword();
        }

        private static void ReadPassword()
        {
            if (File.Exists("passwords.txt"))
            {
                var passwordLines = File.ReadAllText("passwords.txt");
                foreach (var Line in passwordLines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(Line))
                    {
                        var equalIndex = Line.IndexOf('=');
                        var appName = Line[..equalIndex];
                        var password = Line[(equalIndex + 1)..];
                        _passwordList.Add(appName, password);
                    }
                }
                if (_passwordList.ContainsKey("MasterKey"))
                {
                    Console.Write("Please Enter Your Master Password: ");
                    while (true)
                    {
                        var password = Console.ReadLine();
                        if (password != _passwordList["MasterKey"])
                            Console.Write("Wrong Password!\nTry Again: ");
                        else
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a strong password so that can access the app with it later");
                    var masterPassword = Console.ReadLine();
                    _passwordList.Add("MasterKey", masterPassword);
                    savePassword();
                }
            }
        }

        private static void savePassword()
        {
            var sb = new StringBuilder();
            foreach (var entry in _passwordList)
                sb.AppendLine($"{entry.Key}={entry.Value}");
            File.WriteAllText("passwords.txt", sb.ToString());
        }
    }
}
