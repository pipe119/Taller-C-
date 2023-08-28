using System;

namespace CalculadoraFracciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de Fracciones");

            // Ingresar la primera fracción
            Console.Write("Ingrese la primera fracción (num/den): ");
            int num1, den1;
            ParseFraccion(Console.ReadLine(), out num1, out den1);

            // Ingresar el operador
            Console.Write("Ingrese el operador (+, -, *, /): ");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Ingresar la segunda fracción
            Console.Write("Ingrese la segunda fracción (num/den): ");
            int num2, den2;
            ParseFraccion(Console.ReadLine(), out num2, out den2);

            // Realizar la operación
            int resultNum = 0, resultDen = 0;

            switch (op)
            {
                case '+':
                    resultNum = num1 * den2 + num2 * den1;
                    resultDen = den1 * den2;
                    break;
                case '-':
                    resultNum = num1 * den2 - num2 * den1;
                    resultDen = den1 * den2;
                    break;
                case '*':
                    resultNum = num1 * num2;
                    resultDen = den1 * den2;
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: No se puede dividir entre cero.");
                        return;
                    }
                    resultNum = num1 * den2;
                    resultDen = den1 * num2;
                    break;
                default:
                    Console.WriteLine("Operador no válido.");
                    return;
            }

            // Mostrar el resultado
            Console.WriteLine("Resultado: " + SimplificarFraccion(resultNum, resultDen));
        }

        // Función para dividir la entrada del usuario en numerador y denominador
        static void ParseFraccion(string input, out int numerador, out int denominador)
        {
            string[] parts = input.Split('/');
            numerador = int.Parse(parts[0]);
            denominador = int.Parse(parts[1]);
        }

        // Función para simplificar una fracción
        static string SimplificarFraccion(int numerador, int denominador)
        {
            int mcd = MaximoComunDivisor(numerador, denominador);
            return denominador == 1 ? numerador.ToString() : $"{numerador}/{denominador}";
        }

        // Función para encontrar el máximo común divisor usando el algoritmo de Euclides
        static int MaximoComunDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}




// Punto 2

Random random = new Random();

Console.Write("Ingrese el número inicial del rango: ");
int rangoI = int.Parse(Console.ReadLine());

Console.Write("Ingrese el número final del rango: ");
int rangoF = int.Parse(Console.ReadLine());

for (int num = rangoI; num <= rangoF; num++)
{
    Console.WriteLine($"\nTabla del {num}:");

    int factorOculto = random.Next(1, 11);
    int resultadoOculto = num * factorOculto;

    for (int factor = 1; factor <= 10; factor++)
    {


        if (factor == factorOculto)
        {
            Console.Write($"{num} x ? = {resultadoOculto}\t");
        }
        else
        {
            int resultado = num * factor;
            Console.Write($"{num} x {factor} = {resultado}\t");
        }

        if (factor % 5 == 0)
        {
            Console.WriteLine();
        }
    }

    Console.WriteLine("\nIngrese las respuestas:");
    int numIngresado = int.Parse(Console.ReadLine());

    if (numIngresado == factorOculto)
    {
        Console.WriteLine("¡Respuesta correcta!\n");
    }
    else
    {
        Console.WriteLine($"Respuesta incorrecta. La respuesta correcta era: {factorOculto}\n");
    }
}





//Punto 3


Console.Write("Ingrese un número: ");
int numero = int.Parse(Console.ReadLine());

bool esEspecial = EsNumeroEspecial(numero);

if (esEspecial)
{
    Console.WriteLine("El número es especial.");
}
else
{
    Console.WriteLine("El número no es especial.");
}


bool EsNumeroEspecial(int num)
{
    return num % 5 == 0 && num % 2 != 0 && num % 3 != 0 && SumaDigitos(num) > 10;
}

int SumaDigitos(int num)
{
    int suma = 0;

    while (num > 0)
    {
        suma += num % 10;
        num /= 10;
    }

    return suma;
}





// Punto 4


string[] palCorrectas = { "gato", "en", "jardin" };
int intentosMaximos = 10;
int intentosRestantes = intentosMaximos;

Console.WriteLine("Adivina las palabras correctas.");
Console.WriteLine("El _____ juega _____ el _____");


foreach (string palCorrecta in palCorrectas)
{
    while (intentosRestantes > 0)
    {
        Console.Write($"Ingresa la palabra: ");
        string palIngresada = Console.ReadLine();

        if (palIngresada == palCorrecta)
        {
            Console.WriteLine("¡Correcto!");
            break;
        }
        else
        {
            intentosRestantes--;
            Console.WriteLine($"Incorrecto. Intentos restantes: {intentosRestantes}");
        }
    }

    if (intentosRestantes == 0)
    {
        Console.WriteLine("Se agotaron los intentos. Mejor suerte la próxima vez.");
        break;
    }
}

Console.WriteLine("Fin del juego.");

