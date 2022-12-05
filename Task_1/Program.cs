/* Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

m = 3, n = 4.

0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9 */

Console.Clear();
int rows = UserInput("Введите количество строк: ", "Введено неверное значение!");
int columns = UserInput("Введите количество столбцов: ", "Введено неверное значение!");
double[,] array = ArrayOfRealNumbers(rows, columns);
PrintArray(array);


double[,] ArrayOfRealNumbers(int rows, int columns)
{
    double[,] arr = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            arr[i,j] = Math.Round(new Random().NextDouble() * 100, 2);
        }
    }
    return arr;
}

void PrintArray(double[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i,j]}   ");
        }
        Console.WriteLine();
    }
}

int UserInput(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine()??"", out int number)) return number;
        else Console.WriteLine(errorMessage);
    }
}