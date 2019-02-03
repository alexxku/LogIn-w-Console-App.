using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogInLibrary;

namespace LogIn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press L to Log In or Press R to Register: ");
            string choice = Console.ReadLine();

            if (choice == "L" || choice == "l")
            {
                lgin();
            }
            else if (choice == "R" || choice == "r")
            {
                reg();
            }
            else
            {
                Console.WriteLine("Invalid Response...Good Bye!");
                Console.ReadLine();
            }
        }

        static void lgin()
        {
            string username;
            string password;

            Console.WriteLine("\nLog In !");

            Restart:

            Console.Write("\nUsername: ");

            username = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            bool result = Log.lg(username, password);

            if (result == true)
            {
                Console.WriteLine("You are now logged in.\n\nWelcome !");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid Log In. Try Again.");
                Console.ReadLine();

                goto Restart;
            }

        }

        static void reg()
        {
            string username;
            string password;


            Console.WriteLine("\n" +
                "Register !");

            restart:

            Console.Write("\nUsername: ");

            username = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            int result = register.reg(username, password);

            if (result == 0)
            {
                Console.WriteLine("You entered no password. Try again.");
                Console.ReadLine();

                goto restart;

            }
            else if (result == 1)
            {
                Console.WriteLine("Username taken. Try again.");
                Console.ReadLine();

                goto restart;
            }
            else
            {
                Console.WriteLine("Account created.");
                Console.ReadLine();

                lgin();
            }
        }
    }
}
