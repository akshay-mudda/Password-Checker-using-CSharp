using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Checker_using_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Password Checker");
            Console.WriteLine("Enter your password:");

            string password = Console.ReadLine();

            while (IsCommonPassword(password) || string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("You didn't enter anything! Please enter a password:");
                }
                else if (password.Length < 8)
                {
                    Console.WriteLine("Password is too short! Please enter a password with at least 8 characters:");
                }
                else if (IsCommonPassword(password))
                {
                    Console.WriteLine("Dumb password! Please enter a different password:");
                }

                password = Console.ReadLine();
            }

            var strength = GetPasswordStrength(password);

            Console.WriteLine($"Password strength: {strength}");

            Console.WriteLine("Thank You!");
            Console.WriteLine("--By Akshay Mudda");
        }

        static string GetPasswordStrength(string password)
        {
            // Define criteria
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;
            string specialCharacters = "!@#$%^&*()-_=+[{]};:|<,>.?/";

            // Check criteria
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;
                else if (char.IsLower(c))
                    hasLowerCase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (specialCharacters.Contains(c))
                    hasSpecialChar = true;
            }

            // Calculate strength
            int strengthPoints = 0;
            if (password.Length >= 8) strengthPoints++;
            if (hasUpperCase) strengthPoints++;
            if (hasLowerCase) strengthPoints++;
            if (hasDigit) strengthPoints++;
            if (hasSpecialChar) strengthPoints++;

            // Define strength levels
            if (strengthPoints == 5)
                return "Very Strong";
            else if (strengthPoints >= 3)
                return "Strong";
            else if (strengthPoints >= 2)
                return "Moderate";
            else
                return "Weak";
        }

        static bool IsCommonPassword(string password)
        {
            // Check if the entered password starts with "password" followed by a number
            if (password.ToLower().StartsWith("password") && password.Length > 8)
            {
                int number;
                if (int.TryParse(password.Substring(8), out number)) // Check if the rest of the string is a valid number
                {
                    return true; // If it is, consider it a common password
                }
            }

            // List of other common passwords (you can add more)
            List<string> otherCommonPasswords = new List<string>
            {
                "123456",
                "password",
                "12345678",
                "qwerty",
                "abc123",
                "letmein",
                "admin123"
            };

            // Check if the entered password is in the list of other common passwords
            return otherCommonPasswords.Contains(password.ToLower());
        }

    }
}
