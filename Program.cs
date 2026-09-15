namespace sistema_de_nomina
{
    public class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=== SISTEMA DE NÓMINA ===");
                Console.WriteLine("1. Registrar Empleado");
                Console.WriteLine("2. Actualizar Empleado");
                Console.WriteLine("3. Mostrar Reporte Semanal");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarEmpleado();
                        break;

                    case 2:
                        ActualizarEmpleado();
                        break;

                    case 3:
                        MostrarReporte();
                        break;

                    case 0:
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione enter para continuar...");
                Console.ReadKey();

            } while (opcion != 0);
        }


        // REGISTRAR EMPLEADOS
        static void RegistrarEmpleado()
        {
            Console.Clear();

            Console.WriteLine("===== TIPO DE EMPLEADO =====");
            Console.WriteLine("1. Empleado Asalariado");
            Console.WriteLine("2. Empleado por Horas");
            Console.WriteLine("3. Empleado por Comisión");
            Console.WriteLine("4. Empleado Asalariado por Comisión");

            Console.Write("\nSeleccione una opción: ");
            int tipo = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("NSS: ");
            string nss = Console.ReadLine();

            switch (tipo)
            {
                case 1:
                    {
                        Console.Write("Salario Semanal: ");
                        decimal salario = Convert.ToDecimal(Console.ReadLine());

                        empleados.Add(new EmpleadoAsalariado(
                            nombre,
                            apellido,
                            nss,
                            salario));

                        break;
                    }

                case 2:
                    {
                        Console.Write("Sueldo por Hora: ");
                        decimal sueldoHora = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Horas Trabajadas: ");
                        decimal horas = Convert.ToDecimal(Console.ReadLine());

                        empleados.Add(new EmpleadoPorHoras(
                            nombre,
                            apellido,
                            nss,
                            sueldoHora,
                            horas));

                        break;
                    }

                case 3:
                    {
                        Console.Write("Ventas Brutas: ");
                        decimal ventas = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Tarifa Comisión (Ej: 0.10): ");
                        decimal tarifa = Convert.ToDecimal(Console.ReadLine());

                        empleados.Add(new EmpleadoPorComision(
                            nombre,
                            apellido,
                            nss,
                            ventas,
                            tarifa));

                        break;
                    }

                case 4:
                    {
                        Console.Write("Ventas Brutas: ");
                        decimal ventas = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Tarifa Comisión (Ej: 0.08): ");
                        decimal tarifa = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Salario Base: ");
                        decimal salarioBase = Convert.ToDecimal(Console.ReadLine());

                        empleados.Add(new EmpleadoAsalariadoPorComision(
                            nombre,
                            apellido,
                            nss,
                            ventas,
                            tarifa,
                            salarioBase));

                        break;
                    }

                default:
                    Console.WriteLine("\nTipo inválido.");
                    return;
            }

            Console.WriteLine("\nEmpleado registrado correctamente.");
        }

        // ACTUALIZAR EMPLEADOS
        static void ActualizarEmpleado()
        {
            Console.Clear();

            Console.Write("Ingrese el nss del empleado: ");
            string nss = Console.ReadLine();

            Empleado empleadoEncontrado = empleados.Find(e => e.nss == nss);

            if (empleadoEncontrado == null)
            {
                Console.WriteLine("\nEmpleado no encontrado.");
                return;
            }

            Console.WriteLine("\nEmpleado encontrado:");
            Console.WriteLine(empleadoEncontrado);

            // EMPLEADO ASALARIADO
            if (empleadoEncontrado is EmpleadoAsalariado asalariado)
            {
                Console.Write("\nNuevo salario semanal: ");
                asalariado.SalarioSemanal = Convert.ToDecimal(Console.ReadLine());
            }

            // EMPLEADO POR HORAS
            else if (empleadoEncontrado is EmpleadoPorHoras horas)
            {
                Console.Write("\nNuevo sueldo por hora: ");
                horas.SueldoPorHora = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Nuevas horas trabajadas: ");
                horas.HorasTrabajadas = Convert.ToDecimal(Console.ReadLine());
            }

            // EMPLEADO POR COMISION
            else if (empleadoEncontrado is EmpleadoPorComision comision &&
                     !(empleadoEncontrado is EmpleadoAsalariadoPorComision))
            {
                Console.Write("\nNuevas ventas brutas: ");
                comision.VentasBrutas = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Nueva tarifa comisión: ");
                comision.TarifaComision = Convert.ToDecimal(Console.ReadLine());
            }

            // EMPLEADO ASALARIADO POR COMISION
            else if (empleadoEncontrado is EmpleadoAsalariadoPorComision asalariadoComision)
            {
                Console.Write("\nNuevas ventas brutas: ");
                asalariadoComision.VentasBrutas = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Nueva tarifa comisión: ");
                asalariadoComision.TarifaComision = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Nuevo salario base: ");
                asalariadoComision.SalarioBase = Convert.ToDecimal(Console.ReadLine());
            }

            Console.WriteLine("\nInformación actualizada correctamente.");
        }


        // REPORTE SEMANAL
        static void MostrarReporte()
        {
            Console.Clear();

            Console.WriteLine("=== REPORTE SEMANAL DE PAGOS ===");

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine(empleado);

                Console.WriteLine($"Pago Semanal: RD$ {empleado.CalcularPago():N2}");

                // Mostrar detalle del cálculo
                if (empleado is EmpleadoAsalariado)
                {
                    Console.WriteLine("Cálculo: salarioSemanal");
                }

                else if (empleado is EmpleadoPorHoras horas)
                {
                    if (horas.HorasTrabajadas <= 40)
                    {
                        Console.WriteLine(
                            $"Cálculo: {horas.SueldoPorHora} × {horas.HorasTrabajadas}");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Cálculo: ({horas.SueldoPorHora} × 40) + " +
                            $"({horas.SueldoPorHora} × 1.5 × " +
                            $"({horas.HorasTrabajadas} - 40))");
                    }
                }

                else if (empleado is EmpleadoAsalariadoPorComision ac)
                {
                    Console.WriteLine(
                        $"Cálculo: ({ac.VentasBrutas} × {ac.TarifaComision}) + " +
                        $"{ac.SalarioBase} + " +
                        $"({ac.SalarioBase} × 0.10)");
                }

                else if (empleado is EmpleadoPorComision c)
                {
                    Console.WriteLine(
                        $"Cálculo: {c.VentasBrutas} × {c.TarifaComision}");
                }

                Console.WriteLine("---------------------------------\n");
            }

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }
    }
}