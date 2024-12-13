using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2024.Day5
{
    public class Day5Part2
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day5\input.txt";
            string[] convert = ConvertToString(filePath);
            var rules = ConvertToRule(convert);
            List<String> orderingRules = rules.Item1;
            List<String> pageNumbers = rules.Item2;
            int answer = Check(orderingRules, pageNumbers);
            Console.WriteLine($"Answer {answer}");
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
        private static (List<String>, List<String>) ConvertToRule(string[] convert)
        {
            bool toggle = false;
            List<String> orderingRules = new List<String>();
            List<String> pageNumbers = new List<String>();
            foreach (string element in convert)
            {
                if (element == "")
                {
                    toggle = true;
                }
                else
                {
                    if (toggle == false)
                    {
                        orderingRules.Add(element);
                    }
                    else
                    {
                        pageNumbers.Add(element);
                    }
                }
            }
            return (orderingRules, pageNumbers);
        }
        private static int Check(List<String> orderingRules, List<String> pageNumbers)
        {
            int answer = 0;
            foreach (string elementPageNumbers in pageNumbers)
            {
                string[] numbers = elementPageNumbers.Split(',');
                bool swapped;
                bool anySwaps = false;
                do
                {
                    swapped = false;
                    for (int i = 0; i < numbers.Length - 1; i++)
                    {
                        string numbersToCompare = numbers[i] + "|" + numbers[i + 1];
                        bool foundWinner = false;
                        foreach (string elementOrderingRules in orderingRules)
                        {
                            if (numbersToCompare == elementOrderingRules)
                            {
                                foundWinner = true;
                                break;
                            }
                        }
                        if (!foundWinner)
                        {
                            string temp = numbers[i];
                            numbers[i] = numbers[i + 1];
                            numbers[i + 1] = temp;
                            swapped = true;
                            anySwaps = true;
                        }
                    }
                } while (swapped);
                if (numbers.Length > 0 && anySwaps)
                {
                    if (numbers.Length % 2 == 1)
                    {
                        int middleIndex = numbers.Length / 2;
                        answer += int.Parse(numbers[middleIndex]);
                    }
                }
            }
            return answer;
        }
    }
}