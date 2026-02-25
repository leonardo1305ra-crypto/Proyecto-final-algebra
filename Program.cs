using System;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("¿Qué desea hacer?");
                Console.WriteLine("1-Multiplicar matrices");
                Console.WriteLine("2-Matriz Sarrus 3x3");
                Console.WriteLine("3-Matriz Laplace");
                Console.WriteLine("4-Matriz Cramer");
                Console.WriteLine("5-Matriz Gauss");
                Console.WriteLine("6-Salir");

                string opcion = Console.ReadLine();

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
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // ==========================================
        // FUNCIONES PARA VALIDAR QUE NO SE CIERRE EL PROGRAMA
        // ==========================================
        static int LeerEnteroSeguro()
        {
            int numero;
            // Mientras no se pueda convertir a entero, muestra el error
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("carácter invalido");
                Console.Write("Intente de nuevo: ");
            }
            return numero;
        }

        static double LeerDoubleSeguro()
        {
            double numero;
            // Mientras no se pueda convertir a double, muestra el error
            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("carácter invalido");
                Console.Write("Intente de nuevo: ");
            }
            return numero;
        }

        static void MultiplicarMatrices()
        {
            Console.WriteLine("Multiplicar Matrices");

            Console.WriteLine("Filas de la primera matriz:");
            int filasA = LeerEnteroSeguro();

            Console.WriteLine("Columnas de la primera matriz:");
            int columnasA = LeerEnteroSeguro();

            Console.WriteLine("Filas de la segunda matriz:");
            int filasB = LeerEnteroSeguro();

            Console.WriteLine("Columnas de la segunda matriz:");
            int columnasB = LeerEnteroSeguro();

            if (columnasA != filasB)
            {
                Console.WriteLine("No se puede multiplicar.");
                Console.WriteLine("Las columnas de la primera deben ser iguales a las filas de la segunda.");
                return;
            }

            int[,] A = new int[filasA, columnasA];
            int[,] B = new int[filasB, columnasB];
            int[,] resultado = new int[filasA, columnasB];

            Console.WriteLine("Valores de la matriz A");
            for (int i = 0; i < filasA; i++)
            {
                for (int j = 0; j < columnasA; j++)
                {
                    Console.Write($"A[{i + 1},{j + 1}]: ");
                    A[i, j] = LeerEnteroSeguro();
                }
            }

            Console.WriteLine("Valores de la matriz B");
            for (int i = 0; i < filasB; i++)
            {
                for (int j = 0; j < columnasB; j++)
                {
                    Console.Write($"B[{i + 1},{j + 1}]: ");
                    B[i, j] = LeerEnteroSeguro();
                }
            }

            for (int i = 0; i < filasA; i++)
            {
                for (int j = 0; j < columnasB; j++)
                {
                    Console.Write($"C[{i},{j}] = ");
                    resultado[i, j] = 0;
                    for (int k = 0; k < columnasA; k++)
                    {
                        Console.Write($"({A[i, k]}*{B[k, j]})");
                        resultado[i, j] += A[i, k] * B[k, j];
                        if (k < columnasA - 1)
                            Console.Write(" + ");
                    }
                    Console.WriteLine($" = {resultado[i, j]}");
                }
            }

            Console.WriteLine("\nMatriz resultado:\n");
            for (int i = 0; i < filasA; i++)
            {
                for (int j = 0; j < columnasB; j++)
                {
                    Console.Write(resultado[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        protected static void MatrizSarrus3x3()
        {
            int[,] matriz = new int[3, 3];
            Console.WriteLine("Matriz sarrus 3x3");
            Console.WriteLine("Ingrese los valores de la matriz:");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                    matriz[i, j] = LeerEnteroSeguro();
                }
            }

            Console.WriteLine("\nMatriz ingresada:\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("/");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine("/");
            }

            int a = matriz[0, 0];
            int b = matriz[0, 1];
            int c = matriz[0, 2];
            int d = matriz[1, 0];
            int e = matriz[1, 1];
            int f = matriz[1, 2];
            int g = matriz[2, 0];
            int h = matriz[2, 1];
            int i2 = matriz[2, 2];

            int diagPos = (a * e * i2) + (d * h * c) + (g * b * f);
            int diagNeg = (c * e * g) + (f * h * a) + (i2 * b * d);

            int determinante = diagPos - diagNeg;

            Console.WriteLine("\nProceso");
            Console.WriteLine($"Diagonal positiva: ({a}*{e}*{i2})+({d}*{h}*{c})+({g}*{b}*{f})= {diagPos}");
            Console.WriteLine($"Diagonal negativa: ({c}*{e}*{g})+({f}*{h}*{a})+({i2}*{b}*{d}) = {diagNeg}");

            Console.WriteLine($"\nDeterminante = {diagPos} - {diagNeg} = {determinante}");
        }

        protected static void MatrizLaplace()
        {
            Console.WriteLine("Matriz Laplace");
            int n = 4;
            double[,] matriz = new double[n, n];

            Console.WriteLine("Determinante por Laplace");
            Console.WriteLine("Ingrese los valores de la matriz:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                    matriz[i, j] = LeerDoubleSeguro();
                }
            }

            double determinante = 0;

            for (int p = 0; p < n; p++)
            {
                double[,] sub = SubMatriz(matriz, n, 0, p);
                MostrarCuadrada(sub, n - 1);
                double detSub = Determinante(sub, n - 1);
                // REEMPLAZO DE Math.Pow PARA CUMPLIR LA REGLA
                double signo = (p % 2 == 0) ? 1 : -1;
                double cofactor = signo * matriz[0, p];
                determinante += cofactor * detSub;
            }

            Console.WriteLine($"\nDeterminante = {determinante}");

            static double[,] SubMatriz(double[,] matriz, int n, int filaExcluir, int colExcluir)
            {
                double[,] sub = new double[n - 1, n - 1];
                int r = 0;

                for (int i = 0; i < n; i++)
                {
                    if (i == filaExcluir) continue;

                    int c = 0;

                    for (int j = 0; j < n; j++)
                    {
                        if (j == colExcluir) continue;

                        sub[r, c] = matriz[i, j];
                        c++;
                    }
                    r++;
                }
                return sub;
            }

            static void MostrarCuadrada(double[,] matriz, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                    }
                }
            }

            static double Determinante(double[,] matriz, int n)
            {
                if (n == 1) return matriz[0, 0];
                if (n == 2) return matriz[0, 0] * matriz[1, 1] - matriz[0, 1] * matriz[1, 0];

                double det = 0;

                for (int p = 0; p < n; p++)
                {
                    double[,] sub = SubMatriz(matriz, n, 0, p);
                    // REEMPLAZO DE Math.Pow PARA CUMPLIR LA REGLA
                    double signo = (p % 2 == 0) ? 1 : -1;
                    det += matriz[0, p] * signo * Determinante(sub, n - 1);
                }
                return det;
            }
        }

        protected static void MatrizCramer()
        {
            Console.WriteLine("Matriz Cramer");
            Console.Write("Tamaño de la matriz (3 o 4 para 3x3 o 4x4): ");

            int n = LeerEnteroSeguro();

            double[,] matrizCoeficientes = new double[n, n];
            double[] terminosIndependientes = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Ingrese el número de la fila {i + 1}, columna {j + 1}: ");
                    matrizCoeficientes[i, j] = LeerDoubleSeguro();
                }
                Console.Write($"Ingrese el resultado de la ecuacion {i + 1}: ");
                terminosIndependientes[i] = LeerDoubleSeguro();
            }

            double detBase = (n == 3) ? Calculadora3x3(matrizCoeficientes) : Calculadora4x4(matrizCoeficientes);

            Console.WriteLine($"\nProceso");
            Console.WriteLine("Determinante del sistema: " + detBase);

            if (detBase == 0)
            {
                Console.WriteLine("Determinante es igual a 0, No se tiene una solucion unica");
                return;
            }

            for (int i = 0; i < n; ++i)
            {
                double[,] matrizAuxiliar = (double[,])matrizCoeficientes.Clone();
                for (int j = 0; j < n; ++j)
                {
                    matrizAuxiliar[j, i] = terminosIndependientes[j];
                }

                double detAuxiliar = (n == 3) ? Calculadora3x3(matrizAuxiliar) : Calculadora4x4(matrizAuxiliar);
                double resultadoFinal = detAuxiliar / detBase;

                Console.WriteLine($"Incognita {i + 1}: {detAuxiliar} / {detBase} = {resultadoFinal}");
            }

            static double Calculadora3x3(double[,] m)
            {
                double pos = (m[0, 0] * m[1, 1] * m[2, 2]) + (m[0, 1] * m[1, 2] * m[2, 0]) + (m[0, 2] * m[1, 0] * m[2, 1]);
                double neg = (m[0, 2] * m[1, 1] * m[2, 0]) + (m[0, 0] * m[1, 2] * m[2, 1]) + (m[0, 1] * m[1, 0] * m[2, 2]);
                return pos - neg;
            }

            static double Calculadora4x4(double[,] m)
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
        }

        protected static void MatrizGauss()
        {
            Console.WriteLine("Matriz Gauss");
            int n = 4;
            double[,] A = new double[n, n + 1];

            Console.WriteLine("Ingrese la matriz aumentada (4x5):");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                    A[i, j] = LeerDoubleSeguro();
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (A[i, i] == 0)
                {
                    Console.WriteLine("Pivote 0, no se puede continuar.");
                    return;
                }

                for (int k = i + 1; k < n; k++)
                {
                    double factor = A[k, i] / A[i, i];
                    for (int j = i; j <= n; j++)
                    {
                        A[k, j] -= factor * A[i, j];
                    }
                }
            }

            double[] x = new double[n];

            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = A[i, n];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= A[i, j] * x[j];
                }

                x[i] /= A[i, i];
            }

            Console.WriteLine("\nSolución:");
            for (int i = 0; i < n; i++)
            {
                // REEMPLAZO DE Math.Round PARA CUMPLIR LA REGLA
                Console.WriteLine($"x{i + 1} = {x[i].ToString("0.####")}");
            }
        }
    }
}