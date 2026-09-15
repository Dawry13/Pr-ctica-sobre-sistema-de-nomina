
using Práctica_sobre_sistema_de_nomina.Modelos;

namespace Práctica_sobre_sistema_de_nomina.Modelos.Empleados
{
    public class EmpleadoPorComision : Empleado
    {
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }

        public EmpleadoPorComision(
            string Nombre,
            string Apellido,
            string nss,
            decimal VentasBrutas,
            decimal TarifaComision)
            : base(Nombre, Apellido, nss)
        {
            VentasBrutas = VentasBrutas;
            TarifaComision = TarifaComision;
        }

        public override decimal CalcularPago()
        {
            return VentasBrutas * TarifaComision;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nTipo: Empleado por Comisión" +
                   $"\nVentas Brutas: {VentasBrutas:C}" +
                   $"\nTarifa Comisión: {TarifaComision:P}" +
                   $"\nPago: {CalcularPago():C}";

        }
    }
}

