namespace Menu;

class Program
{
    static void Main(string[] args)
    {
        string opcion = "0";
        Console.WriteLine("¿Qué desea hacer?");
        Console.WriteLine("1-Matriz Sarrus");
        Console.WriteLine("2-Matriz Laplace");
        Console.WriteLine("3-Matriz Cramer");
        Console.WriteLine("4-Matriz Gauss");
        opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                MatrizSarrus();
                break;
            case "2":
                MatrizLaplace();
                break;
            case "3":
                MatrizCramer();
                break;
            case "4":
                MatrizGauss();
                break;
            default:
                break;
        }
    }
    protected static void MatrizSarrus()
    {
        Console.WriteLine("Matriz sarrus");
    }
    protected static void MatrizLaplace()
    {
        Console.WriteLine("Matriz Laplace");
    }
    protected static void MatrizCramer()
    {
        Console.WriteLine("Matriz Cramer");
    }
    protected static void MatrizGauss()
    {
        Console.WriteLine("Matriz Gauss");
    }
}

    


