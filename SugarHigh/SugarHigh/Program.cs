using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SugarHigh
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Variables wich we need*/
            int numOfCandies;
            bool check;
            int[] candies;
            int[] sortedCandies;
            int[] indicesOfCandies;
            int sugarForCandie;
            int i = 0;
            int j = 0;
            int treshold;
            int sum = 0;

            Console.WriteLine("Please enter the length of array wich represents candies: ");

            /*Checks if entered value is a string or a number*/
            check = Int32.TryParse(Console.ReadLine(), out numOfCandies);
            
            /*Checks boundaries for entered value
              Value must be a number greater than 0 and less or equal than 10^5*/
            while (numOfCandies <= 0 || numOfCandies > Math.Pow(10, 5) || !check)
            {
                Console.WriteLine("You must enter regular value!");
                Console.WriteLine("NOTE: Value must be a number greater than 0 and less or equal than 10^5.");
                Console.WriteLine("Please enter the regular length of array wich represents candies! ");
                check = Int32.TryParse(Console.ReadLine(), out numOfCandies);
            }

            /*Creating array of candies with length we've just entered*/
            candies = new int[numOfCandies];

            Console.WriteLine("Please enter the value of sugar for each candie: ");
            
            /*Entering values of sugar for each candie in array candies*/
            while (i < numOfCandies)
            {
                /*Checks boundaries for entered value
                  Value must be a number greater or equal than 0 and less or equal than 100*/
                check = Int32.TryParse(Console.ReadLine(), out sugarForCandie);
                while (sugarForCandie < 0 || sugarForCandie > 100 || !check)
                {
                    Console.WriteLine("You must enter regular value!");
                    Console.WriteLine("NOTE: Value must be a number greater or equal than 0 and less or equal than 100.");
                    Console.WriteLine("Please enter the regular value of sugar for candie!");
                    check = Int32.TryParse(Console.ReadLine(), out sugarForCandie);
                }

                /*If entered value is correct, we put it in array of candies and we are incrementing counter*/
                candies[i] = sugarForCandie;
                i++;
            }

            Console.WriteLine("Please enter the value of treshold:");
            /*Checks boundaries for entered value
              Value must be a number greater or equal than 1 and less or equal than 10^9*/
            check = Int32.TryParse(Console.ReadLine(), out treshold);
            while (treshold < 1 || treshold > Math.Pow(10, 9) || !check)
            {
                Console.WriteLine("You must enter regular value!");
                Console.WriteLine("NOTE: Value must be a number greater or equal than 1 and less or equal than 10^9.");
                Console.WriteLine("Please enter the regular value of treshold! ");
                check = Int32.TryParse(Console.ReadLine(), out treshold);
            }
            
            /*Printing array of candies*/
            Console.WriteLine("Array of candies: ");
            for (i = 0; i < numOfCandies; i++)
                Console.Write(candies[i] + " ");

            /*Printing value of treshold*/
            Console.WriteLine();
            Console.WriteLine("Treshold: " + treshold);

            /*Creating array sortedCandies wich we're going to sort*/
            sortedCandies = new int[numOfCandies];
            for (i = 0; i < numOfCandies; i++)
                sortedCandies[i] = candies[i];
           
            /*Sorting array of candies in ascending order with merge sort algorithm,
             I choose merge algoritham for sorting because he's one of the best
             algorithm according to the time complexity, 
             avarage time complexity = n*log(n)*/
            MergeSort(sortedCandies, 0, numOfCandies - 1, 1);

            /*Console.WriteLine("Array of sorted candies: ");
            for (i = 0; i < numOfCandies; i++)
                Console.Write(sortedCandies[i] + " ");*/

            /*Finding the maximum number of elements in sortedCandies array
             wich you can cosume*/
            for (i = 0; i < numOfCandies; i++)
            {
                sum += sortedCandies[i];
                if (sum >= treshold)
                    break;
                else
                    j++;
            }

            /*Finding indices of elements wich you can cosume*/
            if(j == 0)
            {
                Console.WriteLine("You can't eat any of candie beacuse each candy has greater value of sugar than treshold!");
                return;
            }
            else
            {
                indicesOfCandies = new int[j];
                for (int k = 0; k < j; k++)
                {
                    for (i = 0; i < numOfCandies; i++)
                    {
                        if(sortedCandies[k] == candies[i])
                        {
                            indicesOfCandies[k] = i;
                            break;
                        }
                    }
                }
            }

            /*Sorting array indicesOfCandies in ascending order 
             with merge sort algorithm*/
            MergeSort(indicesOfCandies, 0, j - 1, 1);

            /*Printing array indicesOfCandies wich represents
             indices of candies wich you can consume without passing the treshold*/
            Console.WriteLine("Array of indices of candies wich you can cosume: ");
            Console.Write("[");
            for (i = 0; i < j; i++)
                if(i != j-1)
                    Console.Write(indicesOfCandies[i] + ", ");
                else
                    Console.Write(indicesOfCandies[i]);
            Console.Write("]");




        }

        /*Functions for merge sort algorithm*/
        public static void Merge(int[] arr, int p, int q, int r, int ad)
        {
            int i, j, k;
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (i = 0; i < n1; i++)
            {
                L[i] = arr[p + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[q + 1 + j];
            }
            i = 0;
            j = 0;
            k = p;
            while (i < n1 && j < n2)
            {
                if (ad == 1)
                {
                    if (L[i] <= R[j])
                    {
                        arr[k] = L[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = R[j];
                        j++;
                    }
                }
                if (ad == 2)
                {
                    if (L[i] >= R[j])
                    {
                        arr[k] = L[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = R[j];
                        j++;
                    }
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        public static void MergeSort(int[] arr, int p, int r, int ad)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(arr, p, q, ad);
                MergeSort(arr, q + 1, r, ad);
                Merge(arr, p, q, r, ad);
            }
        }
    }
}
