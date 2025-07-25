using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cálculo_de_impuestos_por_usuario.UniversalHelpers.MenuHelper
{
    public static class HelperMenu
    {
        public static (bool esValido, string ErrorMessage) MenuHelper(out int nombreCampo)
        {
            Console.WriteLine("=== Impuestos Por Pais ===");
            Console.WriteLine(" 1.Crear usuario");
            Console.WriteLine(" 2.Mostrar la informacion del usuario");
            Console.WriteLine(" 3.salir");

            string MenuEntrada = Console.ReadLine();

            if (!int.TryParse(MenuEntrada, out nombreCampo) || nombreCampo < 1 || nombreCampo > 4)
            {
                return (false, "Debes ingresar un número entre 1 y 4.");
            }

            return (true, string.Empty);
        }
    }
}
