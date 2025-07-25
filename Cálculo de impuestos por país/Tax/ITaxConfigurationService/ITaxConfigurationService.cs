using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cálculo_de_impuestos_por_usuario.User;

namespace Cálculo_de_impuestos_por_usuario.Tax.ITax
{
    public interface ITaxConfigurationService
    {
        decimal GetTaxResult(string Country);
        void ShowUserInfo(UserEntity User);
    }
}
