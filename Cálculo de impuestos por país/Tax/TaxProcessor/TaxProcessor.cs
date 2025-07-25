using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cálculo_de_impuestos_por_usuario.User.InterfaceUserService;
using Cálculo_de_impuestos_por_usuario.Tax.ITax;
using Cálculo_de_impuestos_por_usuario.User;

namespace Cálculo_de_impuestos_por_usuario.Tax.TaxProcessor
{
    public class TaxProcessor
    {
        private readonly IUserService _userService;
        private readonly ITaxConfigurationService _taxService;

        public TaxProcessor(IUserService userService, ITaxConfigurationService taxService)
        {
            _userService = userService;
            _taxService = taxService;
        }

        public void Run(UserEntity user, decimal montoOriginal)
        {
            
            decimal tasa = _taxService.GetTaxResult(user.country);
            decimal impuesto = montoOriginal * tasa;
            decimal total = montoOriginal + impuesto;

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"UserName: {user.name}");
            Console.WriteLine($"País: {user.country}");
            Console.WriteLine($"Monto original: {montoOriginal:C}");
            Console.WriteLine($"Impuesto: {impuesto:C}");
            Console.WriteLine($"Total: {total:C}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Ingrese cualquier tecla para volver al menu");
            Console.ReadKey();
        }
    }
}
