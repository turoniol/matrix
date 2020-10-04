using System;
using MatrixSpace;

class Program
{
    static Matrix CreateMatrix()
    {
        int w, h;
        w = Convert.ToInt32(Console.ReadLine());
        h = Convert.ToInt32(Console.ReadLine());
        int size = w*h; 
        int[] arr = new int[size];
        
        for (int i = 0; i < size; ++i) 
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
            

        return new Matrix(w, h, arr);
    }
    static void Main(string[] args)
    {
        Matrix A = CreateMatrix();
        Matrix B = CreateMatrix();
        Console.WriteLine("Matrix A:");
        A.Print();
        Console.WriteLine("Matrix B:");
        B.Print();
        Console.WriteLine("Multiplication A * B: ");
        Matrix Mult = A * B;
        Mult?.Print();
    }  
}

