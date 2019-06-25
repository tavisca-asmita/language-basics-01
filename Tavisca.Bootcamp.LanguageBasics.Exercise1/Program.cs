using System;

namespace Tavisca.bootcamp.Languagebasics.Exercise1
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
            string stringValue;
            char[] delimit = { '*', '=' };
            string[] splitEqu = equation.Split(delimit);  //splitting equation using delimit char array and storing in string array
            int firstNum, secondNum, thirdNum;
            
            //firstNum contains ?
            if (splitEqu[0].Contains('?'))
            {
                secondNum = Convert.ToInt32(splitEqu[1]); //converting string to int
                thirdNum= Convert.ToInt32(splitEqu[2]);   //converting string to int
                if (thirdNum % secondNum != 0)            //checking for whole number
                {
                    return -1;
                }
                else
                {
                    firstNum= thirdNum / secondNum;
                    stringValue = firstNum.ToString();              //converting result to string
                    if (stringValue.Length == splitEqu[0].Length)   //comparing lengths of two string
                    {
                        //returns numeric value of the character absent from string and denoted by ?
                        return Convert.ToInt32(stringValue[splitEqu[0].IndexOf('?')].ToString());
                    }
                    else
                        return -1;
                }               

            }
            //secondNum contains ?
            if (splitEqu[1].Contains('?'))
            {
                firstNum= Convert.ToInt32(splitEqu[0]);   //converting string to int
                thirdNum = Convert.ToInt32(splitEqu[2]);  //converting string to int
                if (thirdNum % firstNum != 0)             //checking for whole number
                {
                    return -1;
                }
                else
                {
                    secondNum = thirdNum / firstNum;
                    stringValue = secondNum.ToString();             //converting result to string
                    if (stringValue.Length == splitEqu[1].Length)   //comparing lengths of two string
                    {
                        //returns numeric value of the character absent from string and denoted by ?
                        return Convert.ToInt32(stringValue[splitEqu[1].IndexOf('?')].ToString());
                    }
                    else
                        return -1;                 
                }
            }
            //thirdNum contains ?
            else
            {
                firstNum= Convert.ToInt32(splitEqu[0]);       //converting string to int
                secondNum = Convert.ToInt32(splitEqu[1]);     //converting string to int
                thirdNum = firstNum * secondNum;              
                stringValue = thirdNum.ToString();            //converting result to string
                if (stringValue.Length == splitEqu[2].Length) //comparing lengths of two string
                {
                    //returns numeric value of the character absent from string and denoted by ?
                    return Convert.ToInt32(stringValue[splitEqu[2].IndexOf('?')].ToString());
                }
                else
                    return -1;                
            }            
        }
    }
}
