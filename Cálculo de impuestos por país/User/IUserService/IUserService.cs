using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cálculo_de_impuestos_por_usuario.User;

namespace Cálculo_de_impuestos_por_usuario.User.InterfaceUserService
{
    public interface IUserService
    {
        public UserEntity NewUser(string Name, string Country, int NewID, decimal Amount);
        public string GetUserCountry(string Country);
        public int GetIDByUser(string UserName);
        public bool ChekUserExists(string UserName);
        public List<UserEntity> GetUserList();
        public UserEntity GetUserByName(string UserName);
    }
}
