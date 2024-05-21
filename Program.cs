using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите действие (1 - кодировать, 2 - декодировать):");
        string actionInput = Console.ReadLine();

        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        string result;

        if (actionInput == "1")
        {
            result = RunLengthEncoding(input);
            Console.WriteLine("Закодированная строка: " + result);
        }
        else if (actionInput == "2")
        {
            result = RunLengthDecoding(input);
            Console.WriteLine("Декодированная строка: " + result);
        }
        else
        {
            Console.WriteLine("Неверное действие. Выберите 1 для кодирования или 2 для декодирования.");
        }
    }

    static string RunLengthEncoding(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder encoded = new StringBuilder();
        int count = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                count++;
            }
            else
            {
                encoded.Append(input[i - 1]);
                encoded.Append(count);
                count = 1;
            }
        }

        encoded.Append(input[input.Length - 1]);
        encoded.Append(count);

        return encoded.ToString();
    }

    static string RunLengthDecoding(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder decoded = new StringBuilder();

        for (int i = 0; i < input.Length; i += 2)
        {
            char character = input[i];
            int count = (int)Char.GetNumericValue(input[i + 1]);

            for (int j = 0; j < count; j++)
            {
                decoded.Append(character);
            }
        }

        return decoded.ToString();
    }
}