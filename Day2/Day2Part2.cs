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
            List<int> convert = ConvertToArray(filePath);
            int answer = Reports(convert);
            Console.WriteLine("Answer: " + answer);
        }
        private static List<int> ConvertToArray(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                List<int> convert = new List<int>();

                foreach (string line in lines)
                {
                    string[] zahlen = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string zahl in zahlen)
                    {
                        convert.Add(int.Parse(zahl));
                    }
                    convert.Add(-1);
                }
                return convert;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        private static int Reports(List<int> convert)
        {
            int answer = 0;
            int buffer = 0;
            int count = 0;
            bool isPossible = true;
            bool isPositiv = false;
            int mitzählen = 0;
            foreach (var item in convert)
            {
                if (item == -1)
                {
                Console.WriteLine("-----");
                    if (isPossible == true)
                    {
                        answer++;
                    }
                    count = 0;
                    isPossible = true;
                    Console.WriteLine("So oft war falsch" + mitzählen);
                    mitzählen = 0;
                }
                else
                {
                    int cache = buffer - item;
                    if (count > 0)
                    {
                        Console.WriteLine(item);
                        if (count == 1)
                        {
                            isPositiv = cache > 0;
                        }

                        if (cache == 0 || (cache > 0) != isPositiv || Math.Abs(cache) >= 4)
                        {
                            Console.WriteLine("No going");
                            isPossible = false;
                            mitzählen++;
                        }
                    }
                    buffer = item;
                    count++;
                }
            }
            return answer;
        }
    }
}
