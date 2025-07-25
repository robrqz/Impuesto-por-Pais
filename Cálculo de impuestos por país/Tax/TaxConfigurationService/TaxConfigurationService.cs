using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cálculo_de_impuestos_por_usuario.Tax.ITax;
using Cálculo_de_impuestos_por_usuario.User;

namespace Cálculo_de_impuestos_por_usuario.Tax.TaxConfigurationService
{
    public class TaxConfigurationService : ITaxConfigurationService
    {
        public decimal GetTaxResult(string Country)
        {
            return Country.ToLower() switch
            {
                "argentina" => 0.21m,
                "brasil" => 0.17m,
                "usa" => 0.10m,
                "otro" => 0m,
                _ => throw new NotSupportedException()
            };
        }

        public void ShowUserInfo(UserEntity User)
        {
            if (User == null || User.LastAmount == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Usuario: {User?.name ?? "Desconocido"} - No tiene monto registrado.");
                Console.ResetColor();
                return;
            }

            decimal tasa = GetTaxResult(User.country);
            decimal impuesto = User.LastAmount * tasa;
            decimal total = User.LastAmount + impuesto;

            Console.WriteLine("=== Resumen de usuarios registrados ===");
            Console.WriteLine($"Usuario: {User.name}");
            Console.WriteLine($"País: {User.country}");
            Console.WriteLine($"Monto original: {User.LastAmount:C}");
            Console.WriteLine($"Impuesto aplicado ({tasa:P0}): {impuesto:C}");
            Console.WriteLine($"Total con impuesto: {total:C}");
            Console.WriteLine("----------------------------------------");
        }
    }

}
