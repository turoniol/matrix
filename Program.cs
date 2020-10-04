using System;
using MatrixSpace;

class Program
{
    static void Main(string[] args)
    {
        Matrix A = new Matrix(1, 4, new int[] { 0, -1, 2, 5 });
        Matrix B = new Matrix(4, 1, new int[] { 1, -1, 3, 7 });
        Console.WriteLine("Matrix A:");
        A.Print();
        Console.WriteLine("Matrix B:");
        B.Print();
        Console.WriteLine("Multiplication A * B: ");
        Matrix Mult = A * B;
        Mult?.Print();
    }  
}

