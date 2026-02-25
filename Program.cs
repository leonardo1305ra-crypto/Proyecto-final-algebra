using System.Diagnostics;

namespace Menu;

class Program
{
    static void Main(string[] args)
    {
        string opcion = "0";
        Console.WriteLine("¿Qué desea hacer?");
        Console.WriteLine("1-Multiplicar matrices");
        Console.WriteLine("2-Matriz Sarrus 3x3");
        Console.WriteLine("3-Matriz Laplace");
        Console.WriteLine("4-Matriz Cramer");
        Console.WriteLine("5-Matriz Gauss");
        opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                MultiplicarMatrices();
                break;
            case "2":
                MatrizSarrus3x3();
                break;
            case "3":
                MatrizLaplace();
                break;
            case "4":
                MatrizCramer();
                break;
            case "5":
                MatrizGauss();
                break;
            default:
                break;
        }
    }



    static void MultiplicarMatrices()
    {
        Console.WriteLine("Multiplicar Matrices");
        {
            Console.WriteLine("Filas de la primera matriz");
            int filasA =
            Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Columnas de la primera matriz ");
            int columnasA =
            Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Filas de la segunda matriz");
            int filasB =
                Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Columnas de la segunda matriz");
            int columnasB =
                Convert.ToInt32(Console.ReadLine());

            if (columnasA != filasB)
            
                Console.WriteLine("No se puede multiplicar");
                Console.WriteLine("Las filas y columnas deben tener los mismos parametros");

                    int[,] A = new int[filasA, columnasA];
                    int[,] B = new int[filasB, columnasB];
                    int[,] resultado = new int[filasA, columnasB];

                    Console.WriteLine("Valores de la matriz A");
                    for (int i = 0; i < filasA; i++) 
                    {
                        for (int j = 0; j < columnasA; j++) 
                        {
                            Console.Write($"A[{i},{j}]");
                            A[i, j] =
                            int.Parse(Console.ReadLine()); 
                        }
                    }
                    Console.WriteLine("Valores de la matriz B");
                    for (int i = 0; i < filasB; i++)
                    {
                        for (int j = 0; j < columnasB; j++)
                        {
                            Console.Write($"B[{i},{j}]");
                            B[i, j] =
                            int.Parse(Console.ReadLine());
                        }
                    }
                    for (int i = 0; i <filasA; i++)
                    {
                        for (int j = 0; j < columnasB; j++)
                        {
                            resultado[i, j] = 0;
                            for (int k = 0; k < columnasA; k++)
                            {
                                resultado[i, j] += A[i, k] * B[k, j];
                            }
                        }
                    }
            Console.WriteLine("Resultado");
            for (int i=0;i <filasA; i++)
            {
                for (int j=0; j < columnasB; j++)
                {
                    Console.Write(resultado[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    protected static void MatrizSarrus3x3()
    {
        int[,] matriz = new int[3, 3];
        Console.WriteLine("Matriz sarrus 3x3");
        Console.WriteLine("Ingrese los valores de la matriz");

        for (int i = 1; i < 3; i++)
        {
            for (int j = 1; j < 3; j++)
            {
                Console.Write($"Elemento [{i},{j}]");
                matriz[i, j] =
                    int.Parse(Console.ReadLine());
            }
        }
        int a = matriz[1, 1];
        int b = matriz[1, 2];
        int c = matriz[1, 3];
        int d = matriz[2, 1];
        int e = matriz[2, 2];
        int f = matriz[2, 3];
        int g = matriz[3, 1];
        int h = matriz[3, 2];
        int i2 = matriz[3, 3];

        int diagPos = (a * e * i2) + (b * f * g) + (c * d * h);
        int diagNeg = (c * e * g) + (b * d * i2) + (a * f * h);

        int determinante = diagPos - diagNeg;

        Console.WriteLine("\nProceso");
        Console.WriteLine($"Diagonal positiva: ({a}*{e}*{i2})+({b}*{f}*{g}+({c}*{d}*{h})= {diagPos}");
        Console.WriteLine($"Diagonal negativa: ({c}*{e}*{g}+({b}*{d}*{i2})+({a}*{f}*{h}) = {diagNeg}");

        Console.WriteLine($"\nDeterminante = {diagPos} - {diagNeg} = {determinante}");
    }
    protected static void MatrizLaplace()
    {
        Console.WriteLine("Matriz Laplace");
        {
            
        }
    }
    protected static void MatrizCramer()
    {
        Console.WriteLine("Matriz Cramer");
        Console.Write("Tamaño de la matriz (3x3 o 4x4)");
        
            int n =
            int.Parse(Console.ReadLine());

            double[,] matrizCoeficientes = new double[n, n];
            double[] terminosIndependientes = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Ingrese el número de la fila {i + 1}, columna {j + 1}: ");

                    matrizCoeficientes[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write($"Ingrese el resultado de la ecuacion {i + 1}:");
                terminosIndependientes[i] = double.Parse(Console.ReadLine());
            }
            double detBase = (n == 3) ?
            Calculadora3x3(matrizCoeficientes) :
            Calculadora4x4(matrizCoeficientes);

            Console.WriteLine($"\n proceso ");
            Console.WriteLine("Determinante del sistema: ");

            if (detBase == 0)
            {
                Console.WriteLine("Determinante es igual a 0,No se tiene una solucion unica");
                return;
            }
                    for ( int i = 0; i < n; ++i )
                    {
                        double[,]
                            matrizAuxiliar = (double[,])matrizCoeficientes.Clone();
                        for ( int j = 0;j < n; ++j )
                        {
                            matrizAuxiliar[j, i] = terminosIndependientes[j];
                        }
            double
                detAuxiliar = (n == 3) ?
                Calculadora3x3(matrizAuxiliar) :
                Calculadora4x4(matrizAuxiliar);
                        double resultadoFinal = detAuxiliar / detBase;

                        Console.WriteLine($"Incognita {i + 1}: {detAuxiliar} / {detBase} = {resultadoFinal}");
                    }
                }
                static double
                    Calculadora3x3(double[,]m)
                {
                    double pos = (m[0, 0] * m[1, 1] * m[2, 2]) + (m[0, 1] * m[1, 2] * m[2, 0]) + (m[0, 2] * m[1, 0] * m[2, 1]);
                    double neg = (m[0, 2] * m[1, 1] * m[2, 0]) + (m[0, 0] * m[1, 2] * m[2, 1]) + (m[0, 1] * m[1, 0] * m[2, 2]);
                    return pos - neg;
                }
                static double
                    Calculadora4x4(double[,]m)
                {
                    double total = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        double[,] sub = new double[3, 3];
                        for (int fila = 1; fila < 4; fila++)
                        {
                            int colSub = 0;
                            for (int col = 0; col < 4; col++)
                            {
                                if (col == i) continue;
                                sub[fila - 1, colSub] = m[fila, col];
                                colSub++;
                            }
                        }
                        double signo = (i % 2 == 0) ? 1 : -1;
                        total += signo * m[0, i] * Calculadora3x3(sub);
                    }
                    return total;
                }
            
        
    
    protected static void MatrizGauss()
    {
        Console.WriteLine("Matriz Gauss");
    }
}

    


