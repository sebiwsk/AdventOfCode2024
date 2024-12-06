using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day1
{
    public class Day1Part2
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day1\input.txt";
            (int[] leftNumbers, int[] rightNumbers) = ConvertToArray(filePath);
            int answer = similarityscore(leftNumbers, rightNumbers);
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
        private static int similarityscore(int[] leftNumbers, int[] rightNumbers)
        {
            int answer = 0;
            for (int i = 0; i < leftNumbers.Length; i++)
            {
                int target = leftNumbers[i];
                int score = compare(rightNumbers, target);
                answer += target * score;
            }
            return answer;
        }
        private static int compare(int[] rightNumbers, int target)
        {
            int score = 0;
            for (int i = 0; i < rightNumbers.Length; i++) 
            { 
                if (rightNumbers[i] == target)
                {
                    score++;
                }
            }
            return score;
        }
    }
}
