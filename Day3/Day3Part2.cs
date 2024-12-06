using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day3
{
    public class Day3Part2
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day3\input.txt";
            string convert = ConvertToString(filePath);
            int answer = Matches(convert);
            Console.WriteLine($"Answer {answer}");
        }
        private static string ConvertToString(string filePath)
        {
            try
            {
                string content = string.Join(" ", File.ReadAllLines(filePath));
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        private static int Matches(string convert)
        {
            string fullPattern = @"(do\(\)|don\'t\(\)|mul\(\d+,\d+\))";
            string operationPattern = @"mul\(\d+,\d+\)";
            string patternNumber = @"\d+";
            string patternDo = @"do\(\)";
            string patternDont = @"don\'t\(\)";
            int answer = 0;
            bool isPossible = true;
            MatchCollection operationMatches = Regex.Matches(convert, fullPattern);
            foreach (Match operationMatch in operationMatches) 
            {
                string value = operationMatch.Value;
                if (value == "do()")
                {
                    isPossible = true;
                }
                else if (value == "don't()")
                {
                    isPossible = false;
                }
                if (isPossible) 
                { 
                    var numberMatches = Regex.Matches(operationMatch.Value, patternNumber);

                    List<int> extractedNumbers = numberMatches
                        .Cast<Match>()
                        .Select(i => int.Parse(i.Value))
                        .ToList();
                    int zahl1 = extractedNumbers.Count > 0 ? extractedNumbers[0] : 0;
                    int zahl2 = extractedNumbers.Count > 1 ? extractedNumbers[1] : 0;
                    answer += zahl1 * zahl2;
                }
            }
            return answer;
        }
    }
}
