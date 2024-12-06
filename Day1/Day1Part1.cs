using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2024.Day1
{
    public class Day1Part1
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day1\input.txt";
            (int[] leftNumbers, int[] rightNumbers) = ConvertToArray(filePath);
            int n = leftNumbers.Length;
            int[] sortleftNumbers = SortArray(leftNumbers, 0, n - 1);
            n = rightNumbers.Length;
            int[] sortrightNumbers = SortArray(rightNumbers, 0, n - 1);
            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer += Math.Abs(sortleftNumbers[i] - sortrightNumbers[i]);
            }
            Console.WriteLine($"Answer {answer}");
        }
        private static (int[], int[]) ConvertToArray(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath)
                                .Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                                .ToArray();

                int[] leftNumbers = lines.Select(parts => int.Parse(parts[0])).ToArray();
                int[] rightNumbers = lines.Select(parts => int.Parse(parts[1])).ToArray();

                return (leftNumbers, rightNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return (new int[0], new int[0]);
            }
        }
        public static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }
    }
}