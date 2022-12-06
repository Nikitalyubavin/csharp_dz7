/* Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
и возвращает значение этого элемента или же указание, что такого элемента нет.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет */

Console.Clear();
int rows = UserInput("Введите количество строк в массиве: ", "Введено неверное значение!");
int columns = UserInput("Введите количество столбцов в массиве: ", "Введено неверное значение!");
int[,] array = ArrayOfRealNumbers(rows, columns, -100, 100);
PrintArray(array);

int position = UserInput("Введите позицию необходимого числа в массиве: ", "Введено неверное значение!");
Console.Write($"{position} -> ");
PositionOfNumber(position, array);



void PositionOfNumber(int position, int[,] arr)
{
    int i = 0;
    int j = 0;
    if (position > arr.Length || position <= 0) Console.WriteLine("такого числа в массиве нет!");
    while (i < arr.GetLength(0))
    {
        if (position > (arr.GetLength(1) * i) && position <= (arr.GetLength(1) * (i + 1)))
        {
            j = position - 1 - (i * arr.GetLength(1));
            Console.WriteLine($"данный элемент в массиве принимает значение {arr[i,j]}");
            break;
        }
        i++;
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
            Console.Write($"{inArray[i,j]} \t");
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