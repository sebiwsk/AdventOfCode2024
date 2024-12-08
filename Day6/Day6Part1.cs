using System.Security;
using System.Security.Cryptography;

namespace AdventOfCode2024.Day6
{
    public class Day6Part1
    {
        public static void Start() 
        {
            string filePath = @"../../../Day6/input.txt";
            var convert = ConvertToChar(filePath);
            int[,] array = convert.Item1;
            (int, int) character = convert.Item2;
            Console.WriteLine()
            Walking(array, character);
        }
        private static (int[,], (int, int)) ConvertToChar(string filePath)
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
                for (int i = 0; i < array.GetLength(0); i++)
                {
                   
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(" " + array[i, j]);
                    }
                    Console.WriteLine(",");
           
                }
                return (array, character);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        private static void Walking(int[,] array, (int, int) character) 
        {

        }
    }
}