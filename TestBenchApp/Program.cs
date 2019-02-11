using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBenchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //handytest();
            //ArrayWorks();
            //oddEvenIndices();            
            //RunTest_FindConsecutivOnes();
            //shift_numbers();
            //StringToInteger("123");
            //ArrayRangeUpdate objArrayRangeUpdate = new ArrayRangeUpdate();
            //objArrayRangeUpdate.Execute();

            for (int i = 1; i < 8; i++)
            {
                ModelObject obj = ModelObject.getInstance();
            }
        }

        private static void shift_numbers()
        {
            int x = 1 & 2;

            int i = 1;
            i = i << 1;

            int j = 1;
            j = j << 33;
        }

        private static double StringToInteger(string NumericValue)
        {            
            char[] numbers = NumericValue.ToCharArray();
            int LengthOfString = numbers.Length;
            double integerValue = 0;           

            
            
           

            for (int i = 0; i <= LengthOfString - 1; i++)
            {
                if (numbers[i] >= 48 && numbers[i] <= 57)
                {
                    double powValue = ((LengthOfString - i - 1));
                    double tt = Math.Pow(10, powValue);
                    integerValue += Convert.ToInt32(numbers[i] - '0') * (tt > 0 ? tt  : 1);
                }
                else
                    throw new Exception("Bad number");
            }

            return integerValue;
        }

        private static void handytest()
        {
            int i = 20;
            decimal dec = Convert.ToDecimal(i) / 100;
            double doub = Convert.ToDouble(i) / 100;
            Console.WriteLine(dec);
            Console.WriteLine(doub);
            int[] arr = new int[5] { 2, 3, 4, 5, 6 };
        }

        private static void RunTest_FindConsecutivOnes()
        {
            BinaryOperation obj = new BinaryOperation();
            int[] bitvalues = obj.ConvertToBinary(5).ToArray();
            Console.WriteLine(findConsecutiveOnes(bitvalues));

            int[] bitvalues1 = obj.ConvertToBinary(6).ToArray();
            Console.WriteLine(findConsecutiveOnes(bitvalues1));
        }

        private static int findConsecutiveOnes(int[] bitvalues)
        {
            int currentConsecutiveCount = 0, maxConsecutiveCount = 0;

            for (int m = 0; m <= bitvalues.Length - 1; m++)
            {
                if (bitvalues[m] == 0)
                {
                    if (m > 0 && bitvalues[m - 1] == 1)
                    {
                        currentConsecutiveCount = 0;
                    }
                }
                else if (bitvalues[m] == 1)
                {
                    if (m > 0 && bitvalues[m - 1] == 1)
                    {
                        currentConsecutiveCount += 1;
                    }
                    else
                        currentConsecutiveCount = 1;
                }

                if (currentConsecutiveCount > maxConsecutiveCount)
                    maxConsecutiveCount = currentConsecutiveCount;
            }

            return maxConsecutiveCount;
        }

        private static void oddEvenIndices()
        {
            string[] str = new string[5];

            str[0] = "this is test string";
            char[] arr = str[0].ToArray();

            string evenIndices = string.Empty;
            string oddIndices = string.Empty;

            for (int j = 0; j <= arr.Length - 1; j++)
            {
                if (arr[j] != ' ')
                {
                    if (j % 2 != 0)
                        evenIndices = evenIndices + arr[j];
                    else
                        oddIndices = oddIndices + arr[j];
                }
            }
        }

        private static void ArrayWorks()
        {
            ArrayList values = new ArrayList();
            values.Add(1);
            values.Add(5.0);
            values.Add("string values");
            values.Add(true);

            //Console.WriteLine(values[2]);

            string[] str = new string[5] { "fdsf", "dfdsf", "dfdsf", "fdfd", "fdfdf" };

            int cnt = str.Where<string>(x => x == "fdsf").Count();

            string[] s1 = Array.ConvertAll(str, arr => "pre" + arr);

            IEnumerable<string> test = str.Select(x => x + "_");

            int[][] testArray = new int[5][]
            {      new int[] { 1, 2, 3 },
                   new int[] { 1, 2, 3 },
                   new int[] { 1, 2, 3, 6, 7 } ,
                   new int[] { 0,6,6,66,6,6,},
                   new int[] { 9,7,7,7,7,73,23}
                };


            var tt = testArray[1].Length;
            var td = testArray[2].Length;
            

            int[,] testArray1 = new int[5, 3]
                {
                 { 1,2,3}, {2,6,7}, {4,5,6}, {4,4,4}, { 1,2,1}
                };



            foreach (int[] thisrow in testArray)
            {
                foreach (int row in thisrow)
                    Console.Write(row + " ");
                Console.WriteLine();
            }

            foreach (int values1 in testArray1)
                Console.Write(values1 + " ");

            Console.WriteLine("Rank :" + testArray.Rank);
            Console.WriteLine("Rank :" + testArray1.Rank);
            Console.ReadLine();

            string s = string.Empty;
            string[] arr23 = Console.ReadLine().Split(' ').ToArray();

        }
       
    }

    public class ModelObject
    {
        private static int counter;
        protected ModelObject()
        {

        }

        public static ModelObject getInstance()
        {
            if (counter < 5)
            {
                counter += 1;
                return new ModelObject();
            }
            else
            {
                // throw new Exception("you have crossed threshold");
                return null;
            }
        }

        ~ModelObject()
        {
            counter -= 1;
        }        
    }
}
