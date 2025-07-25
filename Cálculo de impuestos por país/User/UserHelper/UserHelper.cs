using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cálculo_de_impuestos_por_usuario.User.UserHelper
{
    public class UserHelpers
    {
        public static (bool IsValidCountry, string ErrorMessage, string CountryName) ValidateCountrySelection(string input)
        {
            if (!int.TryParse(input, out int option) || option < 1 || option > 4)
            {
                return (
                    false,
                    "Ingrese un número válido entre 1 y 4.",
                    null
                );
            }

            string country = option switch
            {
                1 => "Argentina",
                2 => "Brasil",
                3 => "USA",
                4 => "Other",
                _ => null
            };

            return (true, "", country);
        }

        public static bool UserCheker(List<UserEntity> UserList)
        {
            if (!UserList.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. ");
                Console.ResetColor();
                Console.WriteLine("No hay usuarios registrados. Agreguelos en el case 1.");
                Console.ResetColor();
                Console.WriteLine("Presione una tecla para volver al menú...");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
            return true;
        }
    }
}
