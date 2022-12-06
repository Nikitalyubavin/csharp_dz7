/* Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3. */

Console.Clear();
int rows = UserInput("Введите количество строк: ", "Введено неверное значение!");
int columns = UserInput("Введите количество столбцов: ", "Введено неверное значение!");
int[,] array = ArrayOfRealNumbers(rows, columns, -100, 100);
PrintArray(array);
Console.Write("Среднее арифметическое каждого столбца: ");
ShowAverage(array);



void ShowAverage(int[,] array)
{
    int sum = 0;
    double result;
    int j = 0;
    for (; j < array.GetLength(1) - 1; j++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum += array[i,j];
        }
        result = Math.Round(Convert.ToDouble(sum) / Convert.ToDouble(array.GetLength(0)), 1);
        Console.Write($"{result}; ");
        sum = 0;
    }
    if (j == array.GetLength(1) - 1)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum += array[i,j];
        }
        result = Math.Round(Convert.ToDouble(sum) / Convert.ToDouble(array.GetLength(0)), 1);
        Console.Write($"{result}.");
    }
}

int[,] ArrayOfRealNumbers(int rows, int columns, int minValue, int maxValue)
{
    int[,] arr = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            arr[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return arr;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i,j]}  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int UserInput(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine()??"", out int number) && number > 0) return number;
        else Console.WriteLine(errorMessage);
    }
}