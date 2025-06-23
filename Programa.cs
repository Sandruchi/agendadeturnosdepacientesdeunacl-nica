using System;

namespace AgendaTurnos
{
    // Definimos un registro (record) para guardar la información del paciente
    public record Paciente(string Nombre, string Cedula, string Fecha, string Hora);

    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 100;
            Paciente[] pacientes = new Paciente[MAX];
            int contador = 0;

            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== AGENDA DE TURNOS MÉDICOS =====");
                Console.WriteLine("1. Registrar turno");
                Console.WriteLine("2. Ver todos los turnos");
                Console.WriteLine("3. Buscar turno por cédula");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine() ?? "0");

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        if (contador < MAX)
                        {
                            Console.Write("Nombre del paciente: ");
                            string nombre = Console.ReadLine() ?? "";

                            Console.Write("Cédula: ");
                            string cedula = Console.ReadLine() ?? "";

                            Console.Write("Fecha de cita (dd/mm/aaaa): ");
                            string fecha = Console.ReadLine() ?? "";

                            Console.Write("Hora de cita (hh:mm): ");
                            string hora = Console.ReadLine() ?? "";

                            pacientes[contador] = new Paciente(nombre, cedula, fecha, hora);
                            contador++;

                            Console.WriteLine("Turno registrado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Límite de pacientes alcanzado.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("=== Turnos Registrados ===");
                        for (int i = 0; i < contador; i++)
                        {
                            Console.WriteLine($"Paciente: {pacientes[i].Nombre}, Cédula: {pacientes[i].Cedula}, Fecha: {pacientes[i].Fecha}, Hora: {pacientes[i].Hora}");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese la cédula a buscar: ");
                        string cedBuscar = Console.ReadLine() ?? "";
                        bool encontrado = false;

                        for (int i = 0; i < contador; i++)
                        {
                            if (pacientes[i].Cedula == cedBuscar)
                            {
                                Console.WriteLine($"Paciente: {pacientes[i].Nombre}, Fecha: {pacientes[i].Fecha}, Hora: {pacientes[i].Hora}");
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine("Paciente no encontrado.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 4);
        }
    }
}
