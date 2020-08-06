using PizzaPlanetConsole2.DataAccess.DataModels;
using System;
using System.Linq;

namespace PizzaPlanetConsole.App.Classes
{
    public class AccountClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static Users Register()
        {
            var newUser = new Users();

            try
            {
                Console.Write("Enter your first name: ");
                newUser.FirstName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter your last name: ");
                newUser.LastName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter your email address: ");
                newUser.Email = Console.ReadLine();
                Console.WriteLine();

                newUser.Password = CheckPassword();

                newUser.IsAdmin = true;

                Console.Write("Enter your street address: ");
                newUser.Street = Console.ReadLine();
                Console.WriteLine();

                Console.Write("City: ");
                newUser.City = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter state: ");
                newUser.State = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter zip code: ");
                newUser.Zip = int.Parse(Console.ReadLine());
                Console.WriteLine();

                newUser.PhoneNumber = CheckPhoneNumberLength();

                ctx.Users.Add(newUser);
                ctx.SaveChanges();
                Console.WriteLine("Account has been register!");

                return Login();
            }
            catch(Exception)
            {
                Console.WriteLine("Something went wrong");
                return Register();
            }
        }

        public static string CheckPassword()
        {
            Console.Write("Enter a password:");
            string password1 = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Re-enter password: ");
            string passwrod2 = Console.ReadLine();
            Console.WriteLine();

            if (password1 == passwrod2)
                return password1;
            else
            {
                Console.WriteLine("Password do not match. Try again.");
                return CheckPassword();
            }
        }

        public static string CheckPhoneNumberLength()
        {
            Console.Write("Enter your phone number: ");
            string phone = Console.ReadLine();

            if (phone.Length >= 11)
            {
                Console.WriteLine("Phone number can only be 10 digits");
                return CheckPhoneNumberLength();
            }
            else
                return phone;
        }

        public static Users Login()
        {
            Console.WriteLine();
            Console.Write("Enter Email address: ");
            string userEmail = Console.ReadLine();
            Console.WriteLine();

            try
            {
                var user = ctx.Users.FirstOrDefault(e => e.Email == userEmail.ToLower());

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                Console.WriteLine();

                if (user.Password == password)
                    return user;
                else
                {
                    Console.Write("Incorrect attempt. Would you like to  try agaiin? ");
                    return IncorrectInfo();
                }
            }
            catch(Exception )
            {
                Console.Write("Incorrect attempt. Would you like to  try agaiin? ");
                return IncorrectInfo();
            }
        }

        public static Users IncorrectInfo()
        {
            
            string yesOrNo = Console.ReadLine();
            if (yesOrNo.ToLower() == "y")
                return Login();
            else
                return Register();
        }
    }
}
