using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Assignment1
    {
        public static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 1, 3, 1, 5, 4 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" }};
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        private static void printTriangle(int n)
        {
            int x, y;

            try
            {
                //Using for loop to calculate the numbers based on input number
                for (x = 0; x <= n; x++)
                {
                    for (y = 1; y <= n - x; y++) //if condition is true, it will go inside 
                    {
                        Console.Write(" "); // print space
                    }
                    for (y = 1; y <= 2 * x - 1; y++)
                    {
                        Console.Write("*"); // print '*'
                    }
                    Console.Write("\n");
                }
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        private static void printPellSeries(int n2)
        {
            
            try
            {
                //Creating an array of integers to hold calculated number series
                int[] series = new int[n2];

                //Using For loop to compute the numbers based on input number
                for (int x = 1; x < n2; x++)
                {
                    //using if conditon to print first 2 numbers of the series i.e 0,1. 
                    //To avoid out of Range error
                    if (x < 2)
                    {
                        series[x] = x;
                    }
                    else
                    {
                        series[x] = (series[x - 1] * 2) + series[x - 2];
                    }
                }
                //using foreach statement to print all items in the array
                foreach (var item in series)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
            }
            
            catch (Exception)
            {

                throw;
            }
        }


        private static bool squareSums(int n3)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //Using for loop check the valid inputs less than or equal to input and increment the x,y parameters
                for (int x = 0; x * x <= n3; x++) 
                {
                    for (int y = 0; y * y <= n3; y++)
                    {
                        if (x * x + y * y == n3) // if the codition satisfies it returns true
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }


        private static int diffPairs(int[] nums, int k)
        {
            
            try
            {
                //Performing validation on inputs
                if (nums == null || nums.Length == 0 || k < 0)
                {
                    return 0;
                }

                //Declaring variables 
                var pairs = new List<int[]>();
                var NumberSet = new HashSet<int>();
                var NumberExists = new HashSet<int>();

                //using foreach loop to read through each variable in the declared loop and
                //Calculate the number bigger or smaller than the number by the difference
                foreach (var number in nums)
                {
                    var BigNum = number + k;

                    var SmallNum = number - k;

                    // Using HashSet.Contains to check if HashSet contains the number
                    if (NumberSet.Contains(BigNum))
                    {
                        // Using HashSet.Contains checking if HashSet contains the bigger number
                        if (!NumberExists.Contains(BigNum))
                        {
                            // Using List.Add method add the pair
                            pairs.Add(new int[] { BigNum, number });
                            NumberExists.Add(BigNum);
                        }
                    }

                    if (NumberSet.Contains(SmallNum))
                    {
                        if (!NumberExists.Contains(number))
                        {
                            pairs.Add(new int[] { number, SmallNum });
                            NumberExists.Add(number);
                        }
                    }

                    NumberSet.Add(number);
                }

                return pairs.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                //declaring variables
                bool flag = false;
                bool flag1 = false;
                List<string> result = new List<string>();
                //using for each loop to read through each string in the declared loop
                foreach (string value in emails)
                {
                    string acc = "";
                    //using second for each loop to read through each character in the declared loop
                    foreach (char ch in value)
                    {
                        //if condition block to gather appropriate formatted email addresses to  acc string
                        if (ch == '@') { flag1 = true; flag = false; acc += ch; }
                        if ((char.IsLetter(ch) || char.IsDigit(ch)) && !flag) { acc += ch; }
                        if (ch == '.' && flag1) { acc += ch; }
                        if (ch == '+' && !flag && !flag1) { flag = true; }
                    }
                    //adding formatted email addresses to  acc string
                    result.Add(acc);
                    //resetting acc, flag and flag2 values for next iteration of for each loop
                    acc = ""; flag = false; flag1 = false;
                }
                //using distint function to eliminate repeatead emails and store it in 'Final Result'
                List<string> finalresult = result.Distinct().ToList();
                //returning int finalresult.count which is number of unique email adderesses.
                return finalresult.Count();
            }
            
            catch (Exception e)
            {
                Console.Write(e.Message);
                return 0;
            }
        }


        private static string DestCity(string[,] paths)
        {
            
            try
            {
                string temp = "";
                int length = paths.Length;
                for (int x = 0; x < length / 2; x++) //Using for loop for extracting all Destination cities in destination
                {
                    string destination = paths[x, 1];
                    for (int y = 0; y < length / 2; y++) //Using another for loop for comparing source cities
                    {
                        if (destination == paths[y, 0]) //checking if destination city is in Source city, If not return that city as destination city
                        {
                            break;
                        }
                        else
                        {
                            temp = destination;
                        }
                    }
                }
                return temp;
            }
            
            catch (Exception)
            {
                throw;
            }
        }
    }
}

