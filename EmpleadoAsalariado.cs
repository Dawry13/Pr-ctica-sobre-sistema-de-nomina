
namespace sistema_de_nomina
{
    public class EmpleadoAsalariado : Empleado
    {
        public decimal SalarioSemanal { get; set; }

        public EmpleadoAsalariado(
            string Nombre,
            string Apellido,
            string nss,
            decimal salarioSemanl)
            : base (Nombre, Apellido, nss)

        {
            SalarioSemanal = salarioSemanl;
        }

        public override decimal CalcularPago() 
        { 
            return SalarioSemanal; 
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nTipo: Empleado Asalariado" +
                   $"\nSalario Semanal: {SalarioSemanal:C}" +
                   $"\nPago: {CalcularPago():C}";
        }
    }
}

