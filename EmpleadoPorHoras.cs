namespace sistema_de_nomina
{
    public class EmpleadoPorHoras : Empleado
    {
        public decimal SueldoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }

        public EmpleadoPorHoras(
            string Nombre,
            string apellido,
            string nss,
            decimal sueldoPorHora,
            decimal horasTrabajadas)
            : base(Nombre, apellido, nss)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public override decimal CalcularPago()
        {
            if (HorasTrabajadas <= 40)
            {
                return SueldoPorHora * HorasTrabajadas;
            }
            else
            {
                return (SueldoPorHora * 40) +
                       (SueldoPorHora * 1.5m * (HorasTrabajadas - 40));
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nTipo: Empleado por Horas" +
                   $"\nSueldo por Hora: {SueldoPorHora:C}" +
                   $"\nHoras Trabajadas: {HorasTrabajadas}" +
                   $"\nPago: {CalcularPago():C}";
        }
    }
}
