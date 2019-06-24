using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.WriteLine("Enter the string in the form of A*B=C with one ? at any numeric position");
            string s = Console.ReadLine();
            Console.WriteLine("Enter the numeric value of ? in the above provided string");
            int n = Convert.ToInt32(Console.ReadLine());
            Test(s, n);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            char[] delimit = { '*', '=' };
            string[] var = equation.Split(delimit);
            int a, b, c;
            string s;
            //A contains ?
            if (var[0].Contains('?'))
            {
                b = Convert.ToInt32(var[1]);
                c = Convert.ToInt32(var[2]);
                if(c % b != 0)
                {
                    return -1;
                }
                else
                {
                    a = c / b;
                    s = a.ToString();
                    if (s.Length == var[0].Length)
                    {
                        return Convert.ToInt32(s[var[0].IndexOf('?')].ToString());
                    }
                    else
                        return -1;
                }               

            }

            //B contains ?
            if (var[1].Contains('?'))
            {
                a = Convert.ToInt32(var[0]);
                c = Convert.ToInt32(var[2]);
                if (c % a != 0)
                {
                    return -1;
                }
                else
                {
                    b = c / a;
                    s = b.ToString();
                    if (s.Length == var[1].Length)
                    {
                        return Convert.ToInt32(s[var[1].IndexOf('?')].ToString());
                    }
                    else
                        return -1;
                    
                }

            }

            //C contains ?
            else
            {
                a = Convert.ToInt32(var[0]);
                b = Convert.ToInt32(var[1]);
                c = a * b;
                s = c.ToString();
                if (s.Length == var[2].Length)
                {
                    return Convert.ToInt32(s[var[2].IndexOf('?')].ToString());
                }
                else
                    return -1;


            }
            throw new NotImplementedException();
        }
    }
}
