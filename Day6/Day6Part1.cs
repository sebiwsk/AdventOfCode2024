using System;
using System.Security;
using System.Security.Cryptography;

namespace AdventOfCode2024.Day6
{
    public class Day6Part1
    {
        public static void Start() 
        {
            string filePath = @"../../../Day6/input.txt";
            var convert = ConvertToArray(filePath);
            int[,] array = convert.Item1;
            (int, int) startPoint = convert.Item2;
            int answer = Walking(array, startPoint);
            Console.WriteLine($"Answer {answer}");
        }
        private static (int[,], (int, int)) ConvertToArray(string filePath)
        {
            try
            {
                string[] content = File.ReadAllLines(filePath);
                int[,] array = new int[content.Length, content[0].Length];
                (int, int) character = (0,0);
                for (int i = 0; i < content.Length; i++)
                {
                    for (int j = 0; j < content[i].Length; j++)
                    {
                        char currentChar = content[i][j];
                        if (currentChar == '#')
                        {
                            array[i, j] = 1;
                        }
                        else if (currentChar == '^')
                        {
                            array[i, j] = 2;
                            character = (i,j);
                        }
                        else
                        {
                            array[i, j] = 0;
                        }
                    }
                }
                return (array, character);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return (null, (0,0));
            }
        }
        private static int Walking(int[,] array, (int, int) startPoint) 
        {
            int bufferLeft = startPoint.Item1;
            int bufferRight = startPoint.Item2;
            char[] directions = ['U', 'R', 'D', 'L'];
            char direction = directions[0];
            int index = 0;
            array[bufferLeft, bufferRight] = 3; //StartPunkt vom Spieler setzten
            while (true)
            {
                bool moved = false;
                if (direction == 'U' && bufferLeft - 1 < array.GetLength(0) && bufferLeft != 0)
                {
                    if (array[bufferLeft -1, bufferRight] == 1)
                    {
                        index++;
                        direction = directions[index];
                    }
                    else
                    {
                        bufferLeft--;
                        array[bufferLeft, bufferRight] = 3;
                    }
                    moved = true;
                }
                if (direction == 'R' && bufferRight + 1 < array.GetLength(1) && bufferRight != 0)
                {
                    if (array[bufferLeft, bufferRight + 1] == 1)
                    {
                        index++;
                        direction = directions[index];
                    }
                    else
                    {
                        bufferRight++;
                        array[bufferLeft, bufferRight] = 3;
                    }
                    moved = true;
                }
                if (direction == 'D' && bufferLeft + 1 < array.GetLength(0) && bufferLeft != 0)
                {
                    if (array[bufferLeft + 1, bufferRight] == 1)
                    {
                        index++;
                        direction = directions[index];
                    }
                    else
                    {
                        bufferLeft++;
                        array[bufferLeft, bufferRight] = 3;
                    }
                    moved = true;
                }
                if (direction == 'L' && bufferRight - 1 < array.GetLength(1) && bufferRight != 0)
                {
                    if (array[bufferLeft, bufferRight -1] == 1)
                    {
                        index = 0;
                        direction = directions[index];
                    }
                    else
                    {
                        bufferRight--;
                        array[bufferLeft, bufferRight] = 3;
                    }
                    moved = true;
                }
                if (!moved)
                {
                    int count = 0;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                           if ((array[i, j] == 3)) {
                                count++;
                           }
                        }
                    }
                    return count;
                }
            }
        }
    }
}