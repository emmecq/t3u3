using System;

class Program{

	/// <summary>
	/// Procesa un conjunto de clientes solicitando sus datos por consola,
	/// calcula el precio final con descuento y muestra un resumen total.
	/// </summary>
	/// <param name="n">Cantidad de clientes a procesar.</param>
	/// <param name="p">Precio base sobre el cual se aplica el descuento.</param>
	static void Procesar(int n, double p)
	{
		double totalAcumulado = 0;
        int clientesConDescuento = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Cliente {i}:");

            string nombre;
            int visitas;
            string tipo;

            LeerCliente(out nombre, out visitas, out tipo);

            double descuento = CalcularDescuento(visitas, tipo);
            double totalFinal = CalcularTotal(p, descuento);

            totalAcumulado += totalFinal;
            if (descuento > 0) clientesConDescuento++;

            ImprimirCliente(nombre, totalFinal, descuento);
        }

		ImprimirResumen(totalAcumulado, clientesConDescuento);

	}

	/// <summary>
	/// Lee los datos de un cliente desde consola.
	/// </summary>
	static void LeerCliente(out string nombre, out int visitas, out string tipo)
	{
		Console.Write("Nombre: ");
		nombre = Console.ReadLine()??"";

		Console.Write("Visitas: ");
		visitas = int.Parse(Console.ReadLine()??"");

		Console.Write("Tipo: ");
		tipo = Console.ReadLine()??"";
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
		
}