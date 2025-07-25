using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cálculo_de_impuestos_por_usuario.UniversalHelpers.ValidationHelpers.ValidationHelpers
{
    public class ValidationHelpers
    {
        public static (bool isValid, string MessageError) ValidateTextWithoutNumbers(string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(nombreCampo))
                return (false, $"No puede estar vacío.");

            if (nombreCampo.Any(char.IsDigit))
                return (false, $"No debe contener números.");

            return (true, string.Empty);
        }
    }
}
