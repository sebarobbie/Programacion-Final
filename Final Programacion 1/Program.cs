using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Tarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }

        public Tarea(string titulo, string descripcion, DateTime fechaVencimiento)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            FechaVencimiento = fechaVencimiento;
            Completada = false;
        }
    }

    class GestorTareas
    {
        private List<Tarea> tareas;

        public GestorTareas()
        {
            tareas = new List<Tarea>();
        }

        public void AgregarTarea(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        public void MarcarTareaComoCompletada(int indice)
        {
            if (indice >= 0 && indice < tareas.Count)
            {
                tareas[indice].Completada = true;
            }
            else
            {
                Console.WriteLine("Índice de tarea no válido.");
            }
        }

        public void EliminarTarea(int indice)
        {
            if (indice >= 0 && indice < tareas.Count)
            {
                tareas.RemoveAt(indice);
            }
            else
            {
                Console.WriteLine("Índice de tarea no válido.");
            }
        }

        public void ListarTareas()
        {
            Console.WriteLine("Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i].Titulo} - Fecha de Vencimiento: {tareas[i].FechaVencimiento} - Completada: {tareas[i].Completada}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GestorTareas gestorTareas = new GestorTareas();

            while (true)
            {
                Console.WriteLine("Gestor de Tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Marcar Tarea como Completada");
                Console.WriteLine("3. Eliminar Tarea");
                Console.WriteLine("4. Listar Tareas");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese su opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título de la tarea: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Ingrese la fecha de vencimiento (yyyy-MM-dd): ");
                        DateTime fechaVencimiento = Convert.ToDateTime(Console.ReadLine());
                        Tarea nuevaTarea = new Tarea(titulo, descripcion, fechaVencimiento);
                        gestorTareas.AgregarTarea(nuevaTarea);
                        break;
                    case 2:
                        Console.Write("Ingrese el índice de la tarea para marcar como completada: ");
                        int indiceMarcarCompleta = Convert.ToInt32(Console.ReadLine()) - 1;
                        gestorTareas.MarcarTareaComoCompletada(indiceMarcarCompleta);
                        break;
                    case 3:
                        Console.Write("Ingrese el índice de la tarea para eliminar: ");
                        int indiceEliminar = Convert.ToInt32(Console.ReadLine()) - 1;
                        gestorTareas.EliminarTarea(indiceEliminar);
                        break;
                    case 4:
                        gestorTareas.ListarTareas();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}
