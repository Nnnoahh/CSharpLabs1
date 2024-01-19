using System;

class Program
{
    static void Swap(ref int lhs, ref int rhs)
    {
        int temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
    
    static void PrintMatrix(ref int[,] numArray) 
    {
        for (int i = 0; i < numArray.GetLength(0); i++) {
            for (int j = 0; j < numArray.GetLength(1); j++) {
                
                System.Console.Write($"{numArray[i, j]} ");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
    
    static void MatrixStrSwap(ref int[,] numArray) 
    {
        for (int i = 0; i < numArray.GetLength(0); i++)
        {
            Program.Swap( ref numArray[i, 0], ref numArray[i, 3] );
            Program.Swap( ref numArray[i, 1], ref numArray[i, 4] );
        }
    }
    
    static void Main() 
    {
        int[,] matrix4x5 = new int[,] { { 1, 2, 3, 4, 5 }, 
                                        { 6, 7, 8, 9, 10 }, 
                                        { 11, 12, 13, 14, 15 }, 
                                        { 16, 17, 18, 19, 20 } };
        Program.MatrixStrSwap(ref matrix4x5 );
        Program.PrintMatrix(ref matrix4x5);
    }
}