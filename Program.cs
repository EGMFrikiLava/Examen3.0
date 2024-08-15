using System;

namespace ExamenExposicion
{
    internal class Program
    {
        //inicio
        static void Main(string[] args)
        {
            // Inicialización de la matriz de resultados y la variable de última operación.
            int[,] ultimaMatrizResultado = new int[0, 0];
            string ultimaOperacion = "";

            // Bucle infinito para el menú principal.
            while (true)
            {
                Console.WriteLine("=== Menú de Operaciones con Matrices ===");
                Console.WriteLine("1. Suma de Matrices");
                Console.WriteLine("2. Resta de Matrices");
                Console.WriteLine("3. Multiplicación de Matrices");
                Console.WriteLine("4. Mostrar Último Resultado");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                // Manejo de las opciones 1, 2 y 3 (Suma, Resta, Multiplicación de Matrices).
                if (opcion == "1" || opcion == "2" || opcion == "3")
                {
                    // Solicitar el número de filas y columnas para las matrices.
                    Console.Write("Número de filas: ");
                    int filas = int.Parse(Console.ReadLine());
                    Console.Write("Número de columnas: ");
                    int columnas = int.Parse(Console.ReadLine());

                    // Inicialización de dos matrices con las dimensiones proporcionadas.
                    int[,] matriz1 = new int[filas, columnas];
                    int[,] matriz2 = new int[filas, columnas];

                    // Rellenar la primera matriz.
                    Console.WriteLine("Primera matriz:");
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Console.Write($"Elemento [{i},{j}]: ");
                            matriz1[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    // Rellenar la segunda matriz.
                    Console.WriteLine("Segunda matriz:");
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Console.Write($"Elemento [{i},{j}]: ");
                            matriz2[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    // Inicialización de la matriz resultado.
                    int[,] resultado = new int[filas, columnas];

                    // Realizar la operación seleccionada.
                    if (opcion == "1") // Suma
                    {
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                resultado[i, j] = matriz1[i, j] + matriz2[i, j];
                            }
                        }
                        ultimaOperacion = "Suma";
                    }
                    else if (opcion == "2") // Resta
                    {
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                resultado[i, j] = matriz1[i, j] - matriz2[i, j];
                            }
                        }
                        ultimaOperacion = "Resta";
                    }
                    else if (opcion == "3") // Multiplicación
                    {
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                resultado[i, j] = 0;
                                for (int k = 0; k < columnas; k++)
                                {
                                    resultado[i, j] += matriz1[i, k] * matriz2[k, j];
                                }
                            }
                        }
                        ultimaOperacion = "Multiplicación";
                    }

                    // Actualizar la matriz de resultados y mostrar el resultado.
                    ultimaMatrizResultado = resultado;
                    Console.WriteLine("Resultado:");
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Console.Write(ultimaMatrizResultado[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }

                    // Guardar el resultado en un archivo de texto.
                    string archivo = "resultado_matriz.txt";
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(archivo))
                    {
                        writer.WriteLine($"Resultado de la {ultimaOperacion}:");
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                writer.Write(ultimaMatrizResultado[i, j] + "\t");
                            }
                            writer.WriteLine();
                        }
                    }
                    Console.WriteLine($"Resultado guardado en {archivo}.");
                }
                // Manejo de la opción 4 (Mostrar Último Resultado).
                else if (opcion == "4")
                {
                    if (ultimaMatrizResultado.GetLength(0) == 0)
                    {
                        Console.WriteLine("No hay resultados.");
                    }
                    else
                    {
                        Console.WriteLine($"Última operación: {ultimaOperacion}");
                        for (int i = 0; i < ultimaMatrizResultado.GetLength(0); i++)
                        {
                            for (int j = 0; j < ultimaMatrizResultado.GetLength(1); j++)
                            {
                                Console.Write(ultimaMatrizResultado[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                // Manejo de la opción 5 (Salir).
                else if (opcion == "5")
                {
                    Console.WriteLine("Adiós.");
                    break;
                }
                // Manejo de opciones no válidas.
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }
    }
}
