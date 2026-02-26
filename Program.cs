using System;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Es una variable para salir
            bool salir = false;
            //Ciclo del menu
            while (!salir)
            {
                Console.Clear();
                //Cuando se regresa al menu hace que se limpie la consola
                Console.WriteLine("¿Qué desea hacer?");
                Console.WriteLine("1-Multiplicar matrices");
                Console.WriteLine("2-Matriz Sarrus 3x3");
                Console.WriteLine("3-Matriz Laplace");
                Console.WriteLine("4-Matriz Cramer");
                Console.WriteLine("5-Matriz Gauss");
                Console.WriteLine("6-Salir");

                string opcion = Console.ReadLine();
                //Guarda la opcion deleccionada

                switch (opcion)
                //Revisa que opcion se eligio
                {
                    case "1":
                        MultiplicarMatrices();
                        //Aqui se manda a pedir el metodo
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
                        //Hace para salir del programa
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        //Por si se pone algo que no esta disponible
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    //Hace una pausa antes de volver al menu
                }
            }
        }
        static int LeerEnteroSeguro()
        //Hace que se puedan meter enteros y evita que se cierre el programa
        {
            int numero;

            while (!int.TryParse(Console.ReadLine(), out numero))
            //Esto hace de que si no se mete un numero valido siga esperando el programa
            {
                Console.WriteLine("carácter invalido");
                Console.Write("Intente de nuevo: ");
            }
            return numero;
        }

        static double LeerDoubleSeguro()
        //Hace que se puedan leer numeros decimales
        {
            double numero;
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

            //Aqui se miden las dimensiones de las matrices
            Console.WriteLine("Filas de la primera matriz:");
            int filasA = LeerEnteroSeguro();

            Console.WriteLine("Columnas de la primera matriz:");
            int columnasA = LeerEnteroSeguro();

            Console.WriteLine("Filas de la segunda matriz:");
            int filasB = LeerEnteroSeguro();

            Console.WriteLine("Columnas de la segunda matriz:");
            int columnasB = LeerEnteroSeguro();

            //Aqui se verifica si es posible hacer la multiplicacion
            if (columnasA != filasB)
            {
                Console.WriteLine("No se puede multiplicar.");
                Console.WriteLine("Las columnas de la primera deben ser iguales a las filas de la segunda.");
                //Se sale si no cumple los requisitos
                return;
            }

            int[,] A = new int[filasA, columnasA];
            int[,] B = new int[filasB, columnasB];
            int[,] resultado = new int[filasA, columnasB];

            Console.WriteLine("Valores de la matriz A");

            //Aqui se llenan los datos de la primera matriz
            for (int i = 0; i < filasA; i++)
            {
                for (int j = 0; j < columnasA; j++)
                {
                    Console.Write($"A[{i + 1},{j + 1}]: ");
                    A[i, j] = LeerEnteroSeguro();
                }
            }

            Console.WriteLine("Valores de la matriz B");
            //Aqui se llenan los datos de la segunda matriz
            for (int i = 0; i < filasB; i++)
            {
                for (int j = 0; j < columnasB; j++)
                {
                    Console.Write($"B[{i + 1},{j + 1}]: ");
                    B[i, j] = LeerEnteroSeguro();
                }
            }
            //Aqui se muestra el procedimiento
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
            //Muestra resultado
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
            //Aqui se crea la 3x3
            Console.WriteLine("Matriz sarrus 3x3");
            Console.WriteLine("Ingrese los valores de la matriz:");

            //Aqui se ponen los datos de la matriz
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                    matriz[i, j] = LeerEnteroSeguro();
                }
            }

            Console.WriteLine("\nMatriz ingresada:\n");
            //Se muestra la matreis ingresada por le usuario
            for (int i = 0; i < 3; i++)
            {
                Console.Write("/");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine("/");
            }
            //Aqui se asignan sus variables
            int a = matriz[0, 0];
            int b = matriz[0, 1];
            int c = matriz[0, 2];
            int d = matriz[1, 0];
            int e = matriz[1, 1];
            int f = matriz[1, 2];
            int g = matriz[2, 0];
            int h = matriz[2, 1];
            int i2 = matriz[2, 2];
            //Operaciones con la diagonal positiva y negativa
            int diagPos = (a * e * i2) + (d * h * c) + (g * b * f);
            int diagNeg = (c * e * g) + (f * h * a) + (i2 * b * d);

            int determinante = diagPos - diagNeg;
            //Aqui se enseña su procedimiento
            Console.WriteLine("\nProceso");
            Console.WriteLine($"Diagonal positiva: ({a}*{e}*{i2})+({d}*{h}*{c})+({g}*{b}*{f})= {diagPos}");
            Console.WriteLine($"Diagonal negativa: ({c}*{e}*{g})+({f}*{h}*{a})+({i2}*{b}*{d}) = {diagNeg}");

            Console.WriteLine($"\nDeterminante = {diagPos} - {diagNeg} = {determinante}");
        }

        protected static void MatrizLaplace()
        {
            {
                Console.WriteLine("Metodo Laplace 4x4 (Submatrices 3x3)\n");

                double[,] matriz = new double[4, 4];
                //Se crea la matriz 4x4

                // Ingreso de datos
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Elemento [{i},{j}]: ");
                        matriz[i, j] = double.Parse(Console.ReadLine());
                        //El usuario pone los numeros 
                    }
                }
                // muestra la matriz completa
                Console.WriteLine("\nMatriz 4x4:");
                MostrarMatriz4x4(matriz);

                double determinante = 0;
                //Aqui se pone guarda la det final

                Console.WriteLine("\nMatriz de la Primera fila:\n");
                //Se recorre la primera fila para los cofactores
                for (int col = 0; col < 4; col++)
                {
                    double[,] sub3x3 = SubMatriz3x3(matriz, 0, col);
                    //Se crea submatriz 3x3

                    Console.WriteLine($"Eliminando fila 1 y columna {col + 1}");
                    MostrarMatriz3x3(sub3x3);

                    double det3x3 = Determinante3x3(sub3x3);
                    //Se calcula su det

                    double signo = (col % 2 == 0) ? 1 : -1;
                    double cofactor = signo * matriz[0, col] * det3x3;
                    //Se calcula el cofactor

                    Console.WriteLine($"Cofactor = ({signo}) * {matriz[0, col]} * {det3x3} = {cofactor}\n");

                    determinante += cofactor;
                    //Suma del det final
                }

                Console.WriteLine($"Determinante Matriz 4x4 = {determinante}");
            }

            static double[,] SubMatriz3x3(double[,] matriz, int filaExcluir, int colExcluir)
            {
                double[,] sub = new double[3, 3];
                //Aqui se guarda la submatriz 3x3
                int r = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (i == filaExcluir) continue;
                    //Si esta fila se quiere quitar se salta

                    int c = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == colExcluir) continue;

                        sub[r, c] = matriz[i, j];
                        c++;
                    }
                    r++;
                }

                return sub;
                //Aqui se regrese a la submatriz ya armada
            }

            static double Determinante3x3(double[,] m)
            {
                // Regla de Sarrus para det
                double det =
                    m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]) -
                    m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]) +
                    m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

                Console.WriteLine($"Determinante 3x3 = {det}\n");

                return det;
            }

            static void MostrarMatriz4x4(double[,] m)
            {
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        Console.Write($"{m[i, j],8}");
                    Console.WriteLine();
                }
            }

            static void MostrarMatriz3x3(double[,] m)
            {
                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        Console.Write($"{m[i, j],8}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        protected static void MatrizCramer()
        {
            Console.WriteLine("Matriz usando Metodo Cramer");
            Console.Write("¿De cuánto es la matriz? (3 o 4): ");
            int n = int.Parse(Console.ReadLine());
            //Tamaño de la matriz

            double[,] mat = new double[n, n];
            //Matriz principal
            double[] res = new double[n];

            //Aqui se ponen los datos del usuario
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Ingresa[" + (i + 1) + "," + (j + 1) + "]: ");
                    mat[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write("Resultado" + (i + 1) + ": ");
                res[i] = double.Parse(Console.ReadLine());
            }

            // determinante principal
            double detPrincipal = 0;

            //Aqui depende que escogio el usuario y toma la funcion correcta
            if (n == 3)
            {
                detPrincipal = Calcular3x3ConPasos(mat, "Principal");
            }
            else
            {
                detPrincipal = Calcular4x4ConPasos(mat);
            }

            Console.WriteLine("\n> Determinante: " + detPrincipal);

            if (detPrincipal == 0)
                //Si la det da 0 no se puede resolver
            {
                Console.WriteLine("El determinante es 0, no se puede seguir.");
                return;
            }

            // incógnita reemplazando columnas
            for (int c = 0; c < n; c++)
            {
                double[,] temp = new double[n, n];

                for (int f = 0; f < n; f++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        temp[f, col] = mat[f, col];
                    }
                }
                //Aqui hace que se reemplace la columna por el resultado
                for (int f = 0; f < n; f++)
                {
                    temp[f, c] = res[f];
                }

                Console.WriteLine("\n--- Incognita " + (c + 1) + " ---");
                double detAux = 0;
                //Aqui se verifica nuevamente el tamaño
                if (n == 3)
                {
                    detAux = Calcular3x3ConPasos(temp, "X" + (c + 1));
                }
                else
                {
                    detAux = Calcular4x4ConPasos(temp);
                }
                // Formula de cramer
                double final = detAux / detPrincipal;
                Console.WriteLine("Resultado X" + (c + 1) + " = " + detAux + " / " + detPrincipal + " = " + final);
            }
        }

        // Función 3x3 
        static double Calcular3x3ConPasos(double[,] m, string nombre)
        {
            double lado1 = (m[0, 0] * m[1, 1] * m[2, 2]) + (m[0, 1] * m[1, 2] * m[2, 0]) + (m[0, 2] * m[1, 0] * m[2, 1]);
            double lado2 = (m[0, 2] * m[1, 1] * m[2, 0]) + (m[0, 0] * m[1, 2] * m[2, 1]) + (m[0, 1] * m[1, 0] * m[2, 2]);

            Console.WriteLine("  Determinante " + nombre + ":");
            Console.WriteLine("  Multiplicacion y suma Diagonal Pos: " + lado1);
            Console.WriteLine("  Multiplicacion y suma Diagonal Neg: " + lado2);

            return lado1 - lado2;
            //Aqui se resta y regresa al resultado
        }

        // Función 4x4 
        static double Calcular4x4ConPasos(double[,] m)
        {
            double sumaTotal = 0;
            for (int i = 0; i < 4; i++)
            {
                double[,] sub = new double[3, 3];
                int filSub = 0;
                for (int f = 1; f < 4; f++)
                {
                    int colSub = 0;
                    for (int c = 0; c < 4; c++)
                    {
                        if (c == i) continue;
                        sub[filSub, colSub] = m[f, c];
                        colSub++;
                    }
                    filSub++;
                }
                //Aqui se altera el signo
                double signo = (i % 2 == 0) ? 1 : -1;
                //Aqui se calcula det 3x3
                double d3 = (sub[0, 0] * sub[1, 1] * sub[2, 2] + sub[0, 1] * sub[1, 2] * sub[2, 0] + sub[0, 2] * sub[1, 0] * sub[2, 1]) -
                           (sub[0, 2] * sub[1, 1] * sub[2, 0] + sub[0, 0] * sub[1, 2] * sub[2, 1] + sub[0, 1] * sub[1, 0] * sub[2, 2]);

                double parte = signo * m[0, i] * d3;
                Console.WriteLine("  Cofactor fila 1, col " + (i + 1) + ": " + parte);
                sumaTotal += parte;
                //Aqui se suma todo
            }
            return sumaTotal;
            //Se regresa a la det total
        }
        protected static void MatrizGauss()
        {

            Console.WriteLine("Matriz Gauss");
            // Ingresar tamaño de matriz sin contar la columna de resultados
            Console.Write("Tamaño de matriz: ");
            int n = int.Parse(Console.ReadLine());

            Fraccion[,] A = new Fraccion[n, n];
            Fraccion[] B = new Fraccion[n];
            Fraccion[,] AB = new Fraccion[n, n + 1];

            // Ingresamos matriz 
            Console.WriteLine("\nIngrese matriz:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"A[{i},{j}]: ");
                    A[i, j] = Fraccion.Parse(Console.ReadLine());
                }
            }

            // Ingresar la columna que va despues del igual
            Console.WriteLine("\nIngrese columna extra:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"B[{i}]: ");
                B[i] = Fraccion.Parse(Console.ReadLine());
            }

            // Procedimiento de Gauss
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    AB[i, j] = A[i, j];

                AB[i, n] = B[i];
            }

            Console.WriteLine("\nProcedimiento:");
            MostrarMatriz(AB, n);

            // Eliminación de Gauss
            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    Fraccion factor = AB[i, k] / AB[k, k];

                    Console.WriteLine($"\nF{i + 1} = F{i + 1} - ({factor}) * F{k + 1}");

                    for (int j = k; j < n + 1; j++)
                    {
                        AB[i, j] = AB[i, j] - factor * AB[k, j];
                    }

                    MostrarMatriz(AB, n);
                }
            }

            // Sustitución
            Fraccion[] X = new Fraccion[n];

            for (int i = n - 1; i >= 0; i--)
            {
                X[i] = AB[i, n];

                for (int j = i + 1; j < n; j++)
                {
                    X[i] = X[i] - AB[i, j] * X[j];
                }

                X[i] = X[i] / AB[i, i];
            }

            Console.WriteLine("\nSolución de las incognitas");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"x{i + 1} = {X[i]}");
        }

        static void MostrarMatriz(Fraccion[,] M, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                    Console.Write($"{M[i, j],8}");
                Console.WriteLine();
            }
        }
    }
    //Creamos una clase para manejar fracciones y evitar problemas con decimales en el método de Gauss
    class Fraccion
    {
        public int Num;
        public int Den;

        public Fraccion(int num, int den = 1)
        {
            if (den == 0) throw new DivideByZeroException();
            Num = num;
            Den = den;
            Simplificar();
        }

        public static Fraccion Parse(string input)
        {
            if (input.Contains("/"))
            {
                string[] p = input.Split('/');
                return new Fraccion(int.Parse(p[0]), int.Parse(p[1]));
            }
            else
                return new Fraccion(int.Parse(input));
        }

        void Simplificar()
        {
            //usa el maximo comun divisor
            int mcd = MCD(Math.Abs(Num), Math.Abs(Den));
            Num /= mcd;
            Den /= mcd;

            if (Den < 0)
                //Si el denomimador es negativo lo pasa arriba
            {
                Num *= -1;
                Den *= -1;
            }
        }

        static int MCD(int a, int b)
        {
            //Se saca el mcd
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraccion operator +(Fraccion a, Fraccion b)
            => new Fraccion(a.Num * b.Den + b.Num * a.Den, a.Den * b.Den);

        public static Fraccion operator -(Fraccion a, Fraccion b)
            => new Fraccion(a.Num * b.Den - b.Num * a.Den, a.Den * b.Den);

        public static Fraccion operator *(Fraccion a, Fraccion b)
            => new Fraccion(a.Num * b.Num, a.Den * b.Den);

        public static Fraccion operator /(Fraccion a, Fraccion b)
            => new Fraccion(a.Num * b.Den, a.Den * b.Num);

        public override string ToString()
        {
            if (Den == 1) return Num.ToString();
            return Num + "/" + Den;
        }
    }
}
