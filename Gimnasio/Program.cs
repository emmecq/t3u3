using System;
using System.Collections.Generic;

class Program{

	/// <summary>
    /// Procesa un conjunto de clientes utilizando listas de datos,
    /// calcula el precio final con descuento y muestra un resumen total.
    /// </summary>
	static void Procesar(List<string> nombres,
                         List<int> visitas,
                         List<string> tipos,
                         double p)
    {
        double totalAcumulado = 0;
        int clientesConDescuento = 0;

        for (int i = 0; i < nombres.Count; i++)
        {
            double descuento = CalcularDescuento(visitas[i], tipos[i]);
            double totalFinal = CalcularTotal(p, descuento);

            totalAcumulado += totalFinal;
            if (descuento > 0) clientesConDescuento++;

            ImprimirCliente(nombres[i], totalFinal, descuento);
        }

        ImprimirResumen(totalAcumulado, clientesConDescuento);
    }

	/// <summary>
	/// Lee los datos de un cliente desde consola.
	/// </summary>
	static void LeerCliente(out string nombre, out int visitas, out string tipo)
	{
		Console.WriteLine("Nombre: ");
		nombre = Console.ReadLine()??"";

		Console.WriteLine("Visitas: ");
		while(!int.TryParse(Console.ReadLine(), out visitas)){
			Console.WriteLine("Entrada inválida. Favor reingresar.");
		}

		Console.WriteLine("Tipo: ");
		string entrada;

		do
		{
			Console.Write("Tipo (premium/regular): ");
			entrada = (Console.ReadLine() ?? "").ToLower();

		} while (entrada != "premium" && entrada != "regular");

		tipo = entrada;
		
	}

	/// <summary>
	/// Lee los datos de múltiples clientes desde consola y los almacena en listas paralelas.
	/// </summary>
	/// <param name="n">Cantidad de clientes a leer.</param>
	/// <param name="nombres">Lista de nombres de los clientes.</param>
	/// <param name="visitas">Lista de cantidades de visitas de cada cliente.</param>
	/// <param name="tipos">Lista de tipos de cliente ("premium" o "regular").</param>
	static void LeerClientes(int n,
		out List<string> nombres,
		out List<int> visitas,
		out List<string> tipos)
	{
		nombres = new List<string>();
		visitas = new List<int>();
		tipos = new List<string>();

		for (int i = 0; i < n; i++)
		{
			Console.WriteLine($"Cliente {i + 1}:");

			string nombre;
			int visitasCliente;
			string tipo;

			LeerCliente(out nombre, out visitasCliente, out tipo);

			nombres.Add(nombre);
			visitas.Add(visitasCliente);
			tipos.Add(tipo);
		}
	}

	/// <summary>
	/// Calcula el porcentaje de descuento según el tipo de cliente y sus visitas.
	/// </summary>
	static double CalcularDescuento(int visitas, string tipo)
	{
		if (tipo == "premium") return 0.20;
		else if (visitas > 15) return 0.10;
		return 0;
	}

	/// <summary>
	/// Calcula el valor final a pagar aplicando el descuento.
	/// </summary>
	static double CalcularTotal(double precio, double descuento)
	{
		return precio * (1 - descuento);
	}

	/// <summary>
	/// Imprime la información de un cliente procesado.
	/// </summary>
	static void ImprimirCliente(string nombre, double total, double descuento)
	{
		Console.WriteLine($"{nombre}: {total:C} (desc {descuento:P0})");
	}

	/// <summary>
	/// Imprime el resumen final del procesamiento.
	/// </summary>
	static void ImprimirResumen(double total, int conDescuento)
	{
		Console.WriteLine($"Total: {total:C} | Con descuento: {conDescuento}");
	}

	/// <summary>
	/// Punto de entrada del programa. 
	/// Solicita los datos iniciales, coordina la lectura de clientes
	/// y ejecuta el procesamiento de la información.
	/// </summary>
	static void Main()
	{
		int n;
		Console.Write("Cantidad de clientes: ");
		while (!int.TryParse(Console.ReadLine(), out n))
		{
			Console.WriteLine("Entrada inválida. Favor reingresar.");
		}

		double precio;
		Console.Write("Precio base: ");
		while (!double.TryParse(Console.ReadLine(), out precio))
		{
			Console.WriteLine("Entrada inválida. Favor reingresar.");
		}

		List<string> nombres;
		List<int> visitas;
		List<string> tipos;

		LeerClientes(n, out nombres, out visitas, out tipos);

		Procesar(nombres, visitas, tipos, precio);
	}
		
}