using System.Threading.Channels;

namespace Dz4APPDEVC_
{
    internal class Program
    {
        static List<int> FindTriplets(int[] nums, int target) 
        {
            var triplets = new List<int>(); 
            var numMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) 
            {
                numMap[nums[i]] = i;
            }
            for (int i = 0;i<nums.Length; i++) 
            {
                int firstNumber = nums[i];
                int remainigTwoDigitsSum = target - firstNumber;
                for (int j = i+1;j<nums.Length;j++) 
                {
                    int theLastDigit = remainigTwoDigitsSum - nums[j];
                    if (numMap.ContainsKey(theLastDigit) && numMap[theLastDigit] != i && numMap[theLastDigit] != j) 
                    {
                        int secondNumber = nums[j];
                        triplets.AddRange(new int[] { firstNumber, secondNumber, theLastDigit } );
                    }
                }
            }

            return triplets;
        }
      
       
        
        static void Main(string[] args)
        {
            //Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
            //Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два
            //числа равных по сумме первому.

            int[] numbers = { 1,2, 3, 4, 5 ,6,7,8,9,10 };
            int target = 10;
            List<int> nums = FindTriplets(numbers, target);
           while (nums.Count > 0) 
            {
                Console.Write("| ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(nums[i] + " ");
                }
                Console.Write($"={target} |");
                nums.RemoveRange(0, 3);
                Console.WriteLine();
            }

            
            



           

           // Второй вариант тоже рабочий но очень медленный , он жнизу закоментирован.
           
          /* for (int i = 0; i < numbers.Length; i++) 
            {
                for (int j = 0; j < numbers.Length-1; j++) 
                {
                    for (int k = 0; k < numbers.Length - 1; k++) 
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == target) 
                        {
                            Console.WriteLine($"{numbers[i]} + {numbers[j]} + {numbers[k]} = {target}");
                        }
                    }
                }
            }*/


        }
    }
}
