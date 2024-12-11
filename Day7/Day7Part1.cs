using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day7
{
    public class Day7Part1
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day7\input.txt";
            string[] convert = ConvertToString(filePath);
            long[][] array = ConvertToArray(convert);
            long answer = 0;
            answer += LookUpCombinations(array);
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
        private static long[][] ConvertToArray(string[] content)
        {
            long[][] array = new long[content.Length][];
            for (int i = 0; i < content.Length; i++)
            {
                string[] subs = content[i].Split(" ");
                array[i] = new long[subs.Length];
                for (int j = 0; j < subs.Length; j++)
                {
                    if (j == 0)
                    {
                        subs[j] = subs[j].Remove(subs[j].Length-1);
                    }
                    if (long.TryParse(subs[j], out long number))
                    {
                        array[i][j] += number;
                    }
                    else
                    {
                        Console.WriteLine($"Warnung: '{subs[j]}' ist keine gültige Zahl.");
                    }
                }
            }
            return array;
        }
        private static long LookUpCombinations(long[][] array)
        {
            long answer = 0;
            for (int i = 0; i < array.Length; i++)
            {
                long[] zahlen = new long[array[i].Length - 1];
                long ziel = 0;
                for (int j = 0;j < array[i].Length; j++)
                {
                    if (j == 0)
                    {
                        ziel = array[i][j];
                    }
                    else
                    {
                        zahlen[j -1] += array[i][j];
                    }
                }
                answer += CheckCombinations(zahlen, ziel);
            }
            return answer;
        }
        static long CheckCombinations(long[] zahlen, long ziel)
        {
            int n = zahlen.Length;
            int possibleOperators = 1 << (n - 1); ;
            for (int i = 0; i < possibleOperators; i ++)
            {
                long result = zahlen[0];
                for (int j = 1; j < n; j++)
                {
                    if ((i & (1 << (j - 1))) > 0)
                    {
                        result *= zahlen[j];
                    }
                    else
                    {
                        result += zahlen[j];
                    }
                }
                if (result == ziel)
                {
                    return ziel;
                }
            }
            return 0;
        }
    }
}
