using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day2
{
    public class Day2Part2
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day2\input.txt";
            string[] convert = ConvertToString(filePath);
            int answer = Reports(convert);
            Console.WriteLine("Answer: " + answer);
        }
        private static string[] ConvertToString(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        private static int Reports(string[] convert)
        {
            int answer = 0;
            for (int i = 0; i < convert.Length; i++)
            {
                List<int> list = TurnInList(convert[i]);
                answer += IsValidSequence(list);
            }
            return answer;
        }
        private static List<int> TurnInList(string convert)
        {
            List<int> list = new List<int>();
            string[] lines = convert.Split(" ");
            for (int i = 0; i < lines.Length; i++)
            {
                list.Add(int.Parse(lines[i]));
            }
            return list;
        }
        private static int IsValidSequence(List<int> convert)
        {
            if (Logic(convert) == true)
            {
                return 1;
            }
            for (int i = 0; i < convert.Count(); i++)
            {
                List<int> tempList = convert.ToList();
                tempList.RemoveAt(i);
                if (Logic(tempList) == true)
                {
                    return 1;
                }
            }
            return 0;
        }
        private static bool Logic(List<int> tempList)
        {
            bool isPositiv = (tempList[0] - tempList[1]) > 0;
            bool isPossible = true;
            for (int i = 0; i < tempList.Count; i++)
            {
                if (i + 1 < tempList.Count)
                {
                    int cache = tempList[i] - tempList[i + 1];
                    if (cache == 0 || (cache > 0) != isPositiv || Math.Abs(cache) >= 4)
                    {
                        isPossible = false;
                    }
                }
            }
            if (isPossible)
            {
                return true;
            }
            return false;
        }
    }
}
