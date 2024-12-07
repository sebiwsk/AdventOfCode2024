using System.Runtime.CompilerServices;

namespace AdventOfCode2024.Day4
{
    public class Day4Part2
    {
        public static void Start() {
            string filePath = @"..\..\..\Day4\input.txt";
            char[] convert = ConvertToChar(filePath);
            int rowLength = RowAndColLength(convert);
            int answer = LookUp(convert, rowLength);
            Console.WriteLine($"Answer {answer}");
        }
        private static char[] ConvertToChar(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                char[] charArray = content.ToCharArray();
                return charArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {ex.Message}");
                return null;
            }
        }
        public static int LookUp(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = 0; i < convert.Length; i++) 
            {
                if (i - rowLength + 1 >= 0 && i - rowLength + 1 < convert.Length &&
                    i - rowLength - 1 >= 0 && i - rowLength - 1 < convert.Length &&
                    i + rowLength + 1 >= 0 && i + rowLength + 1 < convert.Length &&
                    i + rowLength - 1 >= 0 && i + rowLength - 1 < convert.Length) 
                {
                    char topLeft = convert[i - rowLength - 1];
                    char topRight = convert[i - rowLength + 1];
                    char bottomLeft = convert[i + rowLength - 1];
                    char bottomRight = convert[i + rowLength + 1];
                    if (convert[i] == 'A')
                    {
                        bool isDiagonalMatch = 
                            ((topLeft == 'M' && bottomRight == 'S') || (topLeft == 'S' && bottomRight == 'M')) &&
                            ((topRight == 'M' && bottomLeft == 'S') || (topRight == 'S' && bottomLeft == 'M'));

                        if (isDiagonalMatch)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        private static int RowAndColLength(char[] convert) 
        {
            int rowLenght = 0;
            for (int i = 0; i < convert.Length; i++){
                rowLenght++;
                if (convert[i] == '\n') {
                    break;
                }
            }
            return rowLenght;
        }
    }
}