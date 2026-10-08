using Microsoft.Data.SqlClient;
using RegistroGastoBD;

namespace RegistroGasto
{
    public class Program
    {
        private const string CadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;" +
            @"Database=GastosDB;" +
            @"Trusted_Connection=True;" +
            @"TrustServerCertificate=True;";

        public static void Main(string[] args)
        {
            List<Gasto> gastos = Cargar();

            if (gastos.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados.");
                return;
            }

            decimal totalGeneral = 0;

            Console.WriteLine(
                $"{"Id",-3} {"Descripción",-20} {"Monto",10} {"Categoría",-15}");

            foreach (Gasto g in gastos)
            {
                Console.WriteLine(g);
                totalGeneral += g.Monto;
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL GASTADO: Q {totalGeneral:N2}");
        }

        private static List<Gasto> Cargar()
        {
            List<Gasto> gastos = new List<Gasto>();

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();

                string sql =
                    "SELECT Id, Descripcion, Monto, Categoria FROM Gastos";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        gastos.Add(new Gasto
                        {
                            Id = lector.GetInt32(0),
                            Descripcion = lector.GetString(1),
                            Monto = lector.GetDecimal(2),
                            Categoria = lector.GetString(3)
                        });
                    }
                }
            }

            return gastos;
        }
    }
}