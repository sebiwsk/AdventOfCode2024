using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode2024.Day9
{
    public class Day9Part1
    {
        public static void Start()
        {
            string filePath = @"..\..\..\Day9\input.txt";
            int[] convert = ConvertToString(filePath);
            var convertToList = ConvertToList(convert);
            List<int> list = convertToList.Item1;
            int count = convertToList.Item2;
            MoveElement(list, count);
            long answer = Checksum(list);
            Console.WriteLine("Answer: " + answer);
        }
        private static int[] ConvertToString(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                int[] ints = new int[content.Length];
                for (int i = 0; i < content.Length; i++)
                {
                    ints[i] = content[i] - '0';
                }
                return ints;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        private static (List<int>, int) ConvertToList(int[] input)
        {
            List<int> intList = new List<int>();
            int id = 0;
            int count = 0;
            for(int i = 0; i < input.Length;  i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < input[i]; j++)
                    {
                        intList.Add(id);
                    }
                    id++;
                }
                else
                {
                    for(int j = 0; j < input[i]; j++)
                    {
                        intList.Add(-1);
                        count++;
                    }
                }
            }
            return (intList, count);
        }
        private static void MoveElement(List<int> intList, int border)
        {
            bool finished = false;
            int count = 0;
            while (finished == false)
            {
                for (int i = intList.Count - 1; i > 0;i--)
                {
                    if (intList[i] != -1 && i > 0)
                    {
                        int buffer = intList[i];
                        int bufferj = 0;
                        for (int j = 0; j < intList.Count; j++)
                        {
                            if (count == border)
                            {
                                finished = true;
                                break;
                            }
                            if (intList[j] == -1)
                            {
                                count++;
                                bufferj = intList[j];
                                intList[j] = buffer;
                                break;
                            }
                        }
                        if (finished == false) {
                            intList[i] = bufferj;
                        }
                        break;
                    }
                }
            }
        }
        private static long Checksum(List<int> list)
        {
            long answer = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != -1 )
                {
                    answer += i * list[i];
                }
            }
            return answer;
        }
    }
}