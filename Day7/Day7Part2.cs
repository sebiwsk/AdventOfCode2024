using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day7
{
    public class Day7Part2
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day7\input.txt";
            string[] convert = ConvertToString(filePath);
            long answer = LookUpCombinations(convert);
            Console.WriteLine("Answer: " + answer);
        }
        private static string[] ConvertToString(string filePath)
        {
            try
            {
                string[] content = File.ReadAllLines(filePath);
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        
        private static long LookUpCombinations(string[] convert)
        {
            long answer = 0;
            for (int i = 0; i < convert.Length; i++)
            {
                var parts = convert[i].Split(":");
                var sum = long.Parse(parts[0].Trim());
                var equation = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numbers = equation.Select(long.Parse).ToArray();
                if (CanSolve(numbers, sum))
                {
                    answer += sum;
                }
            }
            return answer;
        }
        public static bool CanSolve(Int64[] array, Int64 sum)
        {
            return Solve(array, sum, array[0], 0);
        }
        public static bool Solve(Int64[] array, Int64 result, Int64 current, int index)
        {
            if (current > result)
            {
                return false;
            }
            if (index == array.Length - 1)
            {
                return current == result;
            }
            if (Solve(array, result, (current * array[index + 1]), index + 1))
            {
                return true;
            }
            if (Solve(array, result, long.Parse((current.ToString() + array[index + 1].ToString())), index + 1))
            {
                return true;
            }
            if (Solve(array, result, (current + array[index + 1]), index + 1))
            {
                return true;
            }
            return false;
        }
        public static int[] InputToList(string input)
        {
            List<int> resultList = new List<int>();
            var parts = input.Split(":");
            var expected = long.Parse(parts[0].Trim());
            var equation = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var numbers = equation.Select(int.Parse).ToArray();
            return numbers;
        }
    }
}