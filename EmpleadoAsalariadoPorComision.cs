
namespace sistema_de_nomina
{
    public class EmpleadoAsalariadoPorComision : EmpleadoPorComision
    {
        public decimal SalarioBase { get; set; }

        public EmpleadoAsalariadoPorComision (
            string Nombre,
            string Apellido,
            string nss,
            decimal VentasBrutas,
            decimal TarifaComision,
            decimal SalarioBase)

            : base(
                  Nombre,
                  Apellido,
                  nss,
                  VentasBrutas,
                  TarifaComision)

        {
            SalarioBase = SalarioBase;
        }

        public override decimal CalcularPago()
        {
            return (VentasBrutas = TarifaComision) +
                SalarioBase +
                (SalarioBase * 0.10m);
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nTipo: Empleado Asalariado por Comisión" +
                   $"\nSalario Base: {SalarioBase:C}" +
                   $"\nPago Total: {CalcularPago():C}";
        }
    }
}

