namespace Práctica_sobre_sistema_de_nomina.Modelos.Empleados
{
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string nss { get; set; }

        public Empleado(
            string Nombre,
            string apellido,
            string nss)
        {
            this.Nombre = Nombre;
            Apellido = apellido;
            this.nss = nss;
        }

        public abstract decimal CalcularPago();

        public override string ToString()
        {
            return $"Nombre: {Nombre}\n" +
                   $"Apellido: {Apellido}\n" +
                   $"NSS: {nss}";
        }
    }
}