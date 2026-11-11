
int operacionesTotales = 0;
double recaudacionTotal = 0;
double importeMaximo = 0;
string clienteMaximo = "";

string entradaMenu = "";

do 
{
    Console.WriteLine("====================================");
    Console.WriteLine("      TALLER DE INFORMÁTICA");
    Console.WriteLine("====================================");
    Console.WriteLine("1. Nueva operación");
    Console.WriteLine("2. Consultar caja (Estadisticas)");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opción: ");

    entradaMenu = Console.ReadLine()!;  // Lee la opcion del numeor que hayamos elegido y la guarda como una variable

    if (entradaMenu == "1")
    {
        string cliente = "";
        while (cliente.Trim() == "")      //.Trim  es para que no haya espacios en blanco ni la principio ni al final.(ESTUDIAR)
        {
            Console.Write("Introduzce el nombre del cliente: ");
            cliente = Console.ReadLine()!;   //guarda el rtexto escrito por el usuario y lo guarda en cliente.
            if (cliente.Trim() == "")
            {
                Console.WriteLine("Error: El nombre no puede estar vacío. Por favor, introduzca un nombre válido.");
            }
        }

        double precioPrincipal = 0;
        string nombreServicio = "";
        bool servicioValido = false;

        while (!servicioValido)
        {
            Console.WriteLine("\n--- SERVICIOS PRINCIPALES ---");
            Console.WriteLine("1. Formateo y Sitema Operativo (40.00 $)");
            Console.WriteLine("2. Limpieza de virus (25.00 $)");
            Console.WriteLine("3. Diagnostico de hardware (15.00 $)");
            Console.Write("Elige un servicio (1-3): ");
            string opcionServicio = Console.ReadLine()!;

            if (opcionServicio == "1")
            {
                precioPrincipal = 40.00;
                nombreServicio = "Formateo";
                servicioValido = true;
            }
            else if (opcionServicio == "2")
            {
                precioPrincipal = 25.00;
                nombreServicio ="Limpieza";
                servicioValido = true;
            }
            else if (opcionServicio == "3")
            {
                precioPrincipal = 15.00;
                nombreServicio = "Diagnostico";
                servicioValido = true;
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, elige un servicio válido.");
            }
        }
        double suplementoUrgencia = 0;
        string tipoAtencion = "Nromal";
        Console.WriteLine("\n--- TIPO DE ANTENCIÓN ---");
        Console.WriteLine("1. Normal (SIn Conste adicional)");
        Console.WriteLine("2. Urgente (+20.00 $)");
        Console.Write("Elige el tipo de atención (1-2): ");
        if (Console.ReadLine()! == "2")
        {
            suplementoUrgencia = 20.00;
            tipoAtencion = "Urgente";
        }

        double totalExtras = 0;
        int cantidadExtras = 0;
        bool extra1comprado = false;
        bool extra2comprado = false;
        bool extra3comprado = false;
        bool terminarExtras = false;

        while (!terminarExtras)
        {
            Console.WriteLine("\n--- EXTRAS ---");
            Console.WriteLine("1. Baskup de datos (15.00 $)");
            Console.WriteLine("2. Licencia Antivirus (20.00 $)");
            Console.WriteLine("3. Cambio de pasta térmica (10.00 $)");
            Console.WriteLine("4. Terminar de añadir extras");
            Console.Write("Elige un extra (1-4): ");
            string opcionExtra = Console.ReadLine()!;

            if (opcionExtra == "1")
            { 
                if (!extra1comprado)
                {
                    totalExtras += 15.00;
                    cantidadExtras++;
                    extra1comprado = true;
                    Console.WriteLine("Bakcup añadido.");
                }
                else
                {
                    Console.WriteLine("Aviso: El Backup ya está añadido.");
                }
            }
            else if (opcionExtra == "2")
            {
                if (!extra2comprado)
                {
                    totalExtras += 20.00;
                    cantidadExtras++;
                    extra2comprado= true;
                    Console.WriteLine("Licencia Antivirus añadida.");
                }
                else
                {
                    Console.WriteLine("Aviso: La Licencia Antivirus ya está añadida.");
                }
            }
            else if (opcionExtra == "3")
            {
                if (!extra3comprado)
                {
                    totalExtras += 10.00;
                    cantidadExtras++;
                    extra3comprado = true;
                    Console.WriteLine("Cambio de pasta térmica añadido.");
                }
                else
                {
                    Console.WriteLine("Aviso: El Cambio de pasta térmica ya está añadido.");
                }
            }
            else if (opcionExtra == "4")
            {
                terminarExtras = true;
            }
            else
            {
                Console.WriteLine("Opción invalida.");
            }
        }

    double subtotal = precioPrincipal + totalExtras;
    double descuento = 0;

    if (subtotal > 50)
    {
        descuento = subtotal * 0.10;
    }

    double totalPagar= (subtotal - descuento) + suplementoUrgencia;

    if (totalPagar < 0) totalPagar = 0; 
    Console.WriteLine($"\nEl total a pagar es: {totalPagar.ToString("F2")} $");  // ToString convierte un valor numerico en texto, F dice que quiero un numero con deciaml y el 2 dice que solo quiero dos decimales.

    double dineroEntregado = 0;
    while (dineroEntregado < totalPagar)
    {
        Console.Write("Introduce el importe entregado por el cliente; ");
        dineroEntregado = Convert.ToDouble(Console.ReadLine()!);
        if (dineroEntregado < totalPagar)
        {
            Console.WriteLine("Error: El importe entregado es insuficiente. Por favor, introduce un importe válido.");
        }
    }

    double cambio = dineroEntregado - totalPagar;

    operacionesTotales++;
    recaudacionTotal += totalPagar;
    if (totalPagar > importeMaximo)
    {
        importeMaximo = totalPagar;
        clienteMaximo = cliente;
    }

    Console.WriteLine("\n===================================");
    Console.WriteLine("       TICKET DE PAGO");
    Console.WriteLine("===================================");
    Console.WriteLine($"Nº Operación: {operacionesTotales}");
    Console.WriteLine($"Cliente: {cliente}");
    Console.WriteLine($"Atención: {tipoAtencion}");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine($"Servicio: {nombreServicio} \t {precioPrincipal.ToString("F2")} $");

    if (cantidadExtras > 0)
    {
        Console.WriteLine($"Extras ({cantidadExtras}): \t {totalExtras.ToString("F2")} $");
    }
    else 
    {
        Console.WriteLine("Extras: \t\t Ninguno");
    }

    if (descuento > 0)
    {
        Console.WriteLine($"Descuento (10%): \t-{descuento.ToString("F2")} $");
    }

    if (suplementoUrgencia > 0)
    {
        Console.WriteLine($"Suplemento urgencia: \t {suplementoUrgencia.ToString("F2")} $");
    }

    Console.WriteLine("-------------------------------------");
    Console.WriteLine($"TOTAL: \t\t\t {totalPagar.ToString("F2")} $");
    Console.WriteLine($"Entregado: \t\t {dineroEntregado.ToString("F2")} $");
    Console.WriteLine($"Cambio: \t\t {cambio.ToString ("F2")} $");
    Console.WriteLine("====================================\n");

}
else if (entradaMenu == "2")
{
    Console.WriteLine("\n--- ESTADISTICAS DE LA SESION ---");
    if (operacionesTotales == 0)
    {
        Console.WriteLine("Todavia no se ha relaizado ninguna operación.");
    }
    else
    {
        double importeMedio = recaudacionTotal / operacionesTotales;
        Console.WriteLine($"Operaciones cobradas: {operacionesTotales}");
        Console.WriteLine($"Recaudacion total: {recaudacionTotal.ToString("F2")} $");
        Console.WriteLine($"Importe medio: {importeMedio.ToString("F2")} $");
        Console.WriteLine($"Operación más cara: {importeMaximo.ToString("F2")} $ (Cliente: {clienteMaximo})");
    }
    Console.WriteLine();
    }
    else if (entradaMenu == "3")
    {
    Console.WriteLine("\nCerrando aplicación. ");
    Console.WriteLine($"Resumen final -> Operaciones: {operacionesTotales} | Ingresos Totales: {recaudacionTotal.ToString("F2")} $");
    Console.WriteLine("¡Gracias por utilizar el taller de informática!");
    }
    else
    {
        Console.WriteLine("Opción inválida. Por favor, selecciona una opción válida.");
    }
} while (entradaMenu != "3");