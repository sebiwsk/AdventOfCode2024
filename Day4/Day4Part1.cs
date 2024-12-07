using System.Security.Cryptography;

namespace AdventOfCode2024.Day4
{
    public class Day4Part1
    {
        public static void Start() 
        {
            string filePath = @"..\..\..\Day4\input.txt";
            char[] convert = ConvertToChar(filePath);
            int answer = 0;
            int rowLength = RowAndColLength(convert);
            answer += SearchRightToLeft(convert);
            answer += SearchLeftToRight(convert);
            answer += SearchDiagonalBottomToTopLeftToRight(convert, rowLength);
            answer += SearchDiagonalBottomToTopRightToLeft(convert, rowLength);
            answer += SearchDiagonalTopToBottomLeftToRight(convert, rowLength);
            answer += SearchDiagonalTopToBottomRightToLeft(convert, rowLength);
            answer += SearchHorizontalBottomToTop(convert, rowLength);
            answer += SearchHorizontalTopToBottom(convert, rowLength);
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
        private static int SearchLeftToRight(char[] convert) 
        {
            int count = 0;
            for (int i = 0; i < convert.Length; i++) 
            {
                if (convert[i] == 'X' && i + 3 < convert.Length)
                {
                    if (convert[i + 1] == 'M' && 
                        convert[i + 2] == 'A' && 
                        convert[i + 3] == 'S') 
                    {
                        count++;
                        i += 3;
                    }
                }
            }
            return count;
        }
        private static int SearchRightToLeft(char[] convert) 
        {
            int count = 0;
            for (int i = convert.Length - 1; i > 0; i--) 
            {
                if (convert[i] == 'X' && i - 3 < convert.Length)
                {
                    if (convert[i - 1] == 'M' && 
                        convert[i - 2] == 'A' && 
                        convert[i - 3] == 'S') 
                    {
                        count++;
                        i -= 3;
                    }
                }
            }
            return count;
        }
        private static int SearchDiagonalTopToBottomLeftToRight(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = 0; i < convert.Length; i++) 
            {
                if (i - rowLength * 3 >= 0) 
                {
                    if (convert[i] == 'X' && 
                        convert[i - rowLength + 1] == 'M' &&
                        convert[i - rowLength * 2 + 2] == 'A' &&
                        convert[i - rowLength * 3 + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static int SearchDiagonalTopToBottomRightToLeft(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = 0; i < convert.Length; i++) 
            {
                if (i - rowLength * 3 >= 0) 
                {
                    if (convert[i] == 'X' && 
                        convert[i - rowLength - 1] == 'M' &&
                        convert[i - rowLength * 2 - 2] == 'A' &&
                        convert[i - rowLength * 3 - 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static int SearchDiagonalBottomToTopRightToLeft(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = convert.Length - 1; i >= 0; i--) 
            {
                if (i + rowLength * 3 < convert.Length) 
                {
                    if (convert[i] == 'X' && 
                        convert[i + rowLength - 1] == 'M' &&
                        convert[i + rowLength * 2 - 2] == 'A' &&
                        convert[i + rowLength * 3 - 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static int SearchDiagonalBottomToTopLeftToRight(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = convert.Length - 1; i >= 0; i--) 
            {
                if (i + rowLength * 3 < convert.Length) 
                {
                    if (convert[i] == 'X' && 
                        convert[i + rowLength + 1] == 'M' &&
                        convert[i + rowLength * 2 + 2] == 'A' &&
                        convert[i + rowLength * 3 + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static int SearchHorizontalBottomToTop(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = 0; i < convert.Length; i++) 
            {
                if (i - rowLength * 3 >= 0) {
                    if (convert[i] == 'X' && 
                        convert[i - rowLength] == 'M' &&
                        convert[i - rowLength * 2] == 'A' &&
                        convert[i - rowLength * 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static int SearchHorizontalTopToBottom(char[] convert, int rowLength) 
        {
            int count = 0;
            for (int i = convert.Length - 1; i >= 0; i--) 
            {
                if (i + rowLength * 3 < convert.Length) 
                {
                    if (convert[i] == 'X' && 
                        convert[i + rowLength] == 'M' &&
                        convert[i + rowLength * 2] == 'A' &&
                        convert[i + rowLength * 3] == 'S')
                    {
                        count++;
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