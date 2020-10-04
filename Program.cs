using System;
using MatrixSpace;

class Program
{
    static void Main(string[] args)
    {
        Matrix A = new Matrix(2, 2, new int[] {2, -3, 4, -6});
        Matrix B = new Matrix(2, 2, new int[] {9, -6, 6, -4});
        Console.WriteLine("Matrix A:");
        A.Print();
        Console.WriteLine("Matrix B:");
        B.Print();
        Console.WriteLine("Multiplication A * B: ");
        Matrix Mult = A * B;
        Mult?.Print();
    }  
}

