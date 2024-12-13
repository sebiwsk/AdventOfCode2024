using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2024.Day5
{
    public class Day5Part1
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
        private static (string[], int) NumbersToCompare(string elementPageNumbers)
        {
            string[] numbers = elementPageNumbers.Split(',');
            string[] convertNumbers = new string[numbers.Length - 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 1 < numbers.Length)
                {
                    convertNumbers[i] = numbers[i] + "|" + numbers[i + 1];
                }
            }
            int middleIndex = ((numbers.Length - 1) / 2);
            int middleNumber = int.Parse(numbers[middleIndex]);
            return (convertNumbers, middleNumber);
        }
        private static int Check(List<String> orderingRules, List<String> pageNumbers)
        {
            int answer = 0;
            foreach (string elementPageNumbers in pageNumbers)
            {
                int count = 0;
                (string[] numbers, int middleNumber) = NumbersToCompare(elementPageNumbers);
                for (int i = 0; i < numbers.Length; i++)
                {
                    foreach (string elementOrderingRules in orderingRules)
                    {
                        if (numbers[i] ==  elementOrderingRules)
                        {
                            count++;
                        }
                    }
                }
                if (count == numbers.Length)
                {
                    answer += middleNumber;
                }
            }
            return answer;
        }
    }
}