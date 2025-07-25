using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cálculo_de_impuestos_por_usuario.User;
using Cálculo_de_impuestos_por_usuario.User.UserHelper;
using Cálculo_de_impuestos_por_usuario.User.InterfaceUserService;
using Cálculo_de_impuestos_por_usuario.Tax.TaxConfigurationService;

namespace Cálculo_de_impuestos_por_usuario.User.UserService
{
    public class UserService : IUserService
    {
        private List<UserEntity> _UserList = new List<UserEntity>();

        public UserEntity NewUser(string UserName, string Country, int NewID, decimal Amount)
        {
            if (_UserList.Exists(c => c.name.Equals(UserName, StringComparison.OrdinalIgnoreCase)))
            {
                
            }

            NewID = _UserList.Any() ? _UserList.Max(m => m.id) + 1 : 1;

            var user = new UserEntity(UserName, Country, Amount);

            _UserList.Add(user);
            user.SetId(NewID);

            return user;
        }

        public string GetUserCountry(string CountryInput)
        {
            var validation = UserHelpers.ValidateCountrySelection(CountryInput);
            if (!validation.IsValidCountry)
            {
                throw new ArgumentException(validation.ErrorMessage);
            }

            return validation.CountryName;
        }

        public int GetIDByUser(string UserName)
        {
            int resp = 1;
            var user = _UserList.Where(m => m.name.Equals(UserName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (user != null)
            {
                resp = user.id;
            }
            else
            {
                resp = _UserList.Any() ? _UserList.Max(m => m.id) + 1 : 1;
            }
            return resp;
        }

        public List<UserEntity> GetUserList()
        {
            return _UserList;
        }

        public bool ChekUserExists(string UserName)
        {
            return _UserList.Any(u =>
                u.name.Equals(UserName, StringComparison.OrdinalIgnoreCase));
        }

        public UserEntity GetUserByName(string UserName)
        {
            return _UserList.FirstOrDefault(u => u.name == UserName);
        }

       


    }
}
